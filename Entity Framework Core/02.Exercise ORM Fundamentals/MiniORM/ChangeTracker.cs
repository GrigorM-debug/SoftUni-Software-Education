using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Linq;

namespace MiniORM
{
    internal class ChangeTracker<T>
            where T : class, new()
    {
        // TODO: Create your ChangeTracker class here.
        private readonly IList<T> allEntities;
        private readonly IList<T> added;
        private readonly IList<T> removed;

        public ChangeTracker(IEnumerable<T> entities)
        {
            this.added= new List<T>();
            this.removed= new List<T>();
            this.allEntities = CloneEntities(entities);
        }

        private static IList<T>? CloneEntities(IEnumerable<T> entities)
        {
            IList<T> clonedEntities = new List<T>();
            var propertiesToClone = typeof(T).GetProperties().Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType)).ToArray();

            foreach (var entity in entities)
            {
                var clonedEntity = Activator.CreateInstance<T>();

                foreach(var property in propertiesToClone)
                {
                    var value = property.GetValue(entity);
                    property.SetValue(clonedEntity, value);
                }
                clonedEntities.Add(clonedEntity);
            }
            return clonedEntities;
        }

        public IReadOnlyCollection<T> AllEntities
               => (IReadOnlyCollection<T>)this.allEntities;

        public IReadOnlyCollection<T> Added 
            => (IReadOnlyCollection<T>)this.added;

        public IReadOnlyCollection<T> Removed
            => (IReadOnlyCollection<T>)this.removed;

        public void Add(T entity)
            => this.added.Add(entity);

        public void Remove(T entity)
            => this.removed.Add(entity);

        public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
        {
            IList<T> modifiedEntities = new List<T>();
            var primaryKeys = typeof(T).GetProperties().Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            foreach(var proxyEntity in AllEntities)
            {
                var primaryKeyValues = GetPrimaryKeyValues(primaryKeys, proxyEntity).ToArray();

                var entity = dbSet.Entities.Single(e => GetPrimaryKeyValues(primaryKeys, e).SequenceEqual(primaryKeyValues));

                var isMofied = IsModified(proxyEntity, entity);

                if (isMofied)
                {
                    modifiedEntities.Add(proxyEntity);
                }
            }
            return modifiedEntities;
        }

        private static bool IsModified(T proxyEntity, T entity)
        {
            var monitoredEntities = typeof(T).GetProperties().Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType));

            var modifiedProperties = monitoredEntities
                .Where(pi=> !Equals(pi.GetValue(entity), pi.GetValue(proxyEntity))).ToArray();

            var isModified = modifiedProperties.Any();

            return isModified;
        }

        private static IEnumerable<object> GetPrimaryKeyValues(PropertyInfo[] primaryKeys, T entity)
        {
            return primaryKeys.Select(pk => pk.GetValue(entity));
        }
    }
}
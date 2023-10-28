using System.Collections;

namespace MiniORM
{
    public class DbSet<TEntity> : ICollection<TEntity>
        where TEntity : class, new()
    {
        // TODO: Create your DbSet class here.
        internal ChangeTracker<TEntity> ChangeTracker { get; set;}

        internal IList<TEntity> Entities { get;set;}

        internal DbSet(IEnumerable<TEntity> entities)
        {
            this.Entities = entities.ToList();
            this.ChangeTracker = new ChangeTracker<TEntity>(entities);
        }

        public int Count => this.Entities.Count;

        public bool IsReadOnly => this.Entities.IsReadOnly;

        public void Add(TEntity entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException(nameof(entity), Exceptions.ItemIsNull);
            }

            this.Entities.Add(entity);
            this.ChangeTracker.Add(entity);
        }

        public bool Remove(TEntity entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException(nameof(entity), Exceptions.ItemIsNull); 
            }

            var removedSuccessfully = this.Entities.Remove(entity);

            if (removedSuccessfully)
            {
                this.ChangeTracker.Remove(entity);
            }
            return removedSuccessfully;
        }

        public void Clear()
        {
            while (this.Entities.Any())
            {
                var entity = this.Entities.First();
                Remove(entity);
            }
        }

        public bool Contains(TEntity entity)
            => this.Entities.Contains(entity);

        public void CopyTo(TEntity[] array, int arrayIndex)
            => this.Entities.CopyTo(array, arrayIndex);

        public IEnumerator<TEntity> GetEnumerator()
            => this.Entities.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach(var entity in entities.ToArray())
            {
                this.Remove(entity);
            }
        }
    }
}

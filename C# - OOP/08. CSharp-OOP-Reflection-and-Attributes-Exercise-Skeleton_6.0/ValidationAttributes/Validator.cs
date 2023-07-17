using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();

            PropertyInfo[] propertyInfos = type.GetProperties()
                .Where(p => p.CustomAttributes
                .Any(ca => typeof(MyValidationAttribute)
                .IsAssignableFrom(ca.AttributeType)))
                .ToArray();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                IEnumerable<MyValidationAttribute> attributes = propertyInfo.GetCustomAttributes()
                .Where(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.GetType())).Cast<MyValidationAttribute>();

                foreach (MyValidationAttribute attr in attributes)
                {
                    if (!attr.IsValid(propertyInfo.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

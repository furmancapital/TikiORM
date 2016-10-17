using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapitalTechGroup.TikiORM.Core.Mappers
{
    public class ObjectFieldMapping
    {
        public string FieldName
        {
            get;
            private set;
        }

        public PropertyInfo Property
        {
            get;
            private set;
        }

        public ObjectFieldMapping (string fieldName, PropertyInfo propertyInfo)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
            {
                throw new ArgumentNullException(nameof(fieldName));
            }

            if (propertyInfo == null)
            {
                throw new ArgumentNullException(nameof(propertyInfo));
            }

            this.FieldName = fieldName;
            this.Property = propertyInfo;
        }

    }
}

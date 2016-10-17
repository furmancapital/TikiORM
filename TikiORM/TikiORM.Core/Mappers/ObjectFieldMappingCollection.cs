using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapitalTechGroup.TikiORM.Core.Mappers
{
    public class ObjectFieldMappingCollection
    {
        private string ObjectType
        {
            get;set;
        }

        private Type SourceObjectType
        {
            get;set;
        }

        private Dictionary<string, ObjectFieldMapping> _fieldNameToMapping = new Dictionary<string, ObjectFieldMapping>(StringComparer.OrdinalIgnoreCase);

        public static ObjectFieldMappingCollection CreateMappingCollection(object sourceObject)
        {
            var sourceObjectType = sourceObject.GetType();
            var fieldMappingCollection = new ObjectFieldMappingCollection(sourceObjectType);

            foreach(var property in sourceObjectType.GetProperties())
            {
                fieldMappingCollection.AddFieldMapping(property.Name, property);
            }

            return fieldMappingCollection;
        }

        private ObjectFieldMappingCollection (Type sourceObjectType)
        {
            if (sourceObjectType == null)
            {
                throw new ArgumentNullException(nameof(sourceObjectType));
            }

            this.SourceObjectType = sourceObjectType;
        }

        public void AddFieldMapping (string fieldName, PropertyInfo fieldInformation)
        {
            this._fieldNameToMapping.Add(fieldName, new ObjectFieldMapping(fieldName, fieldInformation));
        }

        public ObjectFieldMapping GetFieldInfo (string fieldName)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
            {
                throw new ArgumentNullException(nameof(fieldName));
            }

            ObjectFieldMapping fieldMapping;
            this._fieldNameToMapping.TryGetValue(fieldName, out fieldMapping);
            return fieldMapping;
        }

        public override string ToString()
        {
            return this.SourceObjectType.Name;
        }
    }
}

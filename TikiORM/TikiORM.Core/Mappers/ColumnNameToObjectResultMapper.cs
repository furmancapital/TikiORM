using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapitalTechGroup.TikiORM.Core.Mappers
{
    public abstract class ColumnNameToObjectResultMapper
    {
        /// <summary>
        /// Provides the dictionary used to cache mappings
        /// </summary>
        public static ConcurrentDictionary<Type, ObjectFieldMappingCollection> ObjectTypeToMapping
        {
            get;
        } = new ConcurrentDictionary<Type, ObjectFieldMappingCollection>();
    }

    /// <summary>
    /// This mapper is used to map column names directly to property names.
    /// If the names do NOT match, associated properties will NOT be mapped
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public class ColumnNameToObjectResultMapper<TResult> : ColumnNameToObjectResultMapper, IResultMapper<TResult>
        where TResult : new()
    {
        private Type CachedType
        {
            get;
            set;
        }

        public ColumnNameToObjectResultMapper()
        {
            this.CachedType = typeof(TResult);
        }


        public TResult MapResult(IDataReader dataReader, QueryResultStructure resultStructure)
        {
            TResult createdInstance = new TResult();

            ObjectFieldMappingCollection fieldMappingCollection = ObjectTypeToMapping.GetOrAdd(CachedType,
                (key) => ObjectFieldMappingCollection.CreateMappingCollection(createdInstance));

            foreach (var column in resultStructure.GetColumns())
            {
                var associatedMapping = fieldMappingCollection.GetFieldInfo(column);
                if (associatedMapping == null)
                {
                    //unknown column; no such property exist
                    continue;
                }

                var fieldIndex = resultStructure.GetColumnIndex(column);
                if (dataReader.IsDBNull(fieldIndex))
                {
                    continue;
                }

                switch (associatedMapping.Property.PropertyType.FullName)
                {
                    case "System.String":
                        associatedMapping.Property.SetValue(createdInstance, dataReader.GetString(fieldIndex));
                        break;
                    case "System.Double":
                        associatedMapping.Property.SetValue(createdInstance, dataReader.GetDouble(fieldIndex));
                        break;
                    case "System.Int16":
                        associatedMapping.Property.SetValue(createdInstance, dataReader.GetInt16(fieldIndex));
                        break;
                    case "System.Int32":
                        associatedMapping.Property.SetValue(createdInstance, dataReader.GetInt32(fieldIndex));
                        break;
                    case "System.Int64":
                        associatedMapping.Property.SetValue(createdInstance, dataReader.GetInt64(fieldIndex));
                        break;
                    case "System.DateTime":
                        associatedMapping.Property.SetValue(createdInstance, dataReader.GetDateTime(fieldIndex));
                        break;
                    case "System.Decimal":
                        associatedMapping.Property.SetValue(createdInstance, dataReader.GetDecimal(fieldIndex));
                        break;
                }

            }

            return createdInstance;
        }
    }
}

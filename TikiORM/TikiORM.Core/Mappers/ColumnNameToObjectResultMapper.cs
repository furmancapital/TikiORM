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
        public TResult MapResult(IDataReader dataReader, QueryResultStructure resultStructure)
        {
            TResult createdInstance = new TResult();

            ObjectFieldMappingCollection fieldMappingCollection = ObjectTypeToMapping.GetOrAdd(typeof(TResult),
                (key) => ObjectFieldMappingCollection.CreateMappingCollection(createdInstance));

            throw new NotImplementedException();
        }
    }
}

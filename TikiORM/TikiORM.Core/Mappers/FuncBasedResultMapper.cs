using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapitalTechGroup.TikiORM.Core.Mappers
{
    /// <summary>
    /// This mapper is based on a Func<> that is passed in
    /// via the constructor to allow for simple mappings
    /// </summary>
    public class FuncBasedResultMapper<TItem> : IResultMapper<TItem>
    {
        Func<IDataReader, TItem> MappingFunction
        {
            get;set;
        }

        public FuncBasedResultMapper (Func<IDataReader, TItem> mappingFunction)
        {
            if (mappingFunction == null)
            {
                throw new ArgumentNullException(nameof(mappingFunction));
            }

            this.MappingFunction = mappingFunction;
        }

        public TItem MapResult(IDataReader dataReader, QueryResultStructure queryResultStructure)
        {
            return MappingFunction(dataReader);
        }
    }
}

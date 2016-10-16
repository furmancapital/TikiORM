using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapitalTechGroup.TikiORM.Core.Mappers
{
    /// <summary>
    /// This mapper is used to take column names and map them to the associated object
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public class ColumnNameToObjectResultMapper<TItem> : IResultMapper<TItem>
    {
        public TItem MapResult(IDataReader dataReader, QueryResultStructure queryResultStructure)
        {
            throw new NotImplementedException();
        }
    }
}

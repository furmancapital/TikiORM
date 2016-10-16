using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapitalTechGroup.TikiORM.Core.Mappers
{
    public class ColumnNameToObjectResultMapper<TResult> : IResultMapper<TResult>
    {
        public TResult MapResult(IDataReader dataReader, QueryResultStructure resultStructure)
        {
            throw new NotImplementedException();
        }
    }
}

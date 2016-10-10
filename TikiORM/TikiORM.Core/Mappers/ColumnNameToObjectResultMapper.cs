using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapitalTechGroup.TikiORM.Core.Mappers
{
    public class ColumnNameToObjectResultMapper<TItem> : IResultMapper<TItem>
    {
        public TItem MapResult(IDataReader dataReader)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapital.TikiORM.Core
{
    public interface IQuery
    {
        /// <summary>
        /// Returns the actual query associated with this query object
        /// </summary>
        string UnderlyingQuery
        {
            get;
        }

        /// <summary>
        /// Returns the parsed out parameters
        /// </summary>
        IReadOnlyCollection<IDbDataParameter> Parameters
        {
            get;
        }
    }
}

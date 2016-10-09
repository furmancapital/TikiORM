using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapital.TikiORM.Core
{
    public class Query
    {
        public Query (string sqlQuery)
            : this(sqlQuery, null)
        {
        }        

        public Query (string sqlQuery, dynamic queryParameter)
        {
            if (sqlQuery == null)
            {
                throw new ArgumentNullException(nameof(sqlQuery));
            }

            this.UnderlyingQuery = sqlQuery;
        }

        /// <summary>
        /// Returns the actual query associated with this query object
        /// </summary>
        public string UnderlyingQuery
        {
            get;
            private set;
        }

        /// <summary>
        /// Returns the parsed out parameters
        /// </summary>
        public IEnumerable<IDbDataParameter> Parameters
        {
            get;
            private set;
        }
    }
}

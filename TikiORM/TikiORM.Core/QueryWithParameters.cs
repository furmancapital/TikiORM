using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapital.TikiORM.Core
{
    /// <summary>
    /// This class represents a query that has a single set of parameters.
    /// </summary>
    public class QueryWithParameters
    {
        public QueryWithParameters(string sqlQuery, IDictionary<string, object> parameters)
        {
            if (sqlQuery == null)
            {
                throw new ArgumentNullException(nameof(sqlQuery));
            }

            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            this.UnderlyingQuery = sqlQuery;
            this.QueryParameters = parameters;

        }

        public QueryWithParameters(string sqlQuery, ExpandoObject parameters)
        {
            if (sqlQuery == null)
            {
                throw new ArgumentNullException(nameof(sqlQuery));
            }

            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            this.UnderlyingQuery = sqlQuery;
            this.QueryParameters = parameters;

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
        /// Returns a collection of parameters
        /// </summary>
        public IDictionary<string, object> QueryParameters
        {
            get;
            private set;
        }
    }
}

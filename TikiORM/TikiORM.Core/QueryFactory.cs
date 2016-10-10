using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapital.TikiORM.Core
{
    /// <summary>
    /// Helper factory class to generate 'query' objects
    /// </summary>
    public class QueryFactory
    {
        private QueryFactory()
        {

        }

        /// <summary>
        /// Returns a query that does not have any parameters
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static Query GetQueryWithoutParameters (string query)
        {
            return new Query(query);
        }

        /// <summary>
        /// Returns a query that has a single set of parameters 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static QueryWithParameters GetQueryWithParameters (string query, dynamic parameters)
        {
            return new QueryWithParameters(query, parameters);
        }

    }
}

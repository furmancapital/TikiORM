using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapital.TikiORM.Core
{
    public static class ConnectionHelpers
    {
        /// <summary>
        /// Queries for a single item without any parameters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlQuery"></param>
        /// <returns></returns>
        public static T QuerySingleItem<T> (this IDbConnection connection, Query query)
        {
            return default(T);
        }

        /// <summary>
        /// Queries for a single item with parameters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="queryWithParameters"></param>
        /// <returns></returns>
        public static T QuerySingleItemWithParameters <T>(this IDbConnection connection, QueryWithParameters queryWithParameters)
        {
            return default(T);
        }


        /// <summary>
        /// Queries for a multiple items without any parameters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlQuery"></param>
        /// <returns></returns>
        public static IEnumerable<T> QueryMultipleItems<T>(this IDbConnection connection, Query query)
        {
            return new List<T>();
        }

        /// <summary>
        /// Queries for multiple items with parameters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="queryWithParameters"></param>
        /// <returns></returns>
        public static List<T> QueryMultipleItems<T>(this IDbConnection connection, QueryWithParameters queryWithParameters)
        {
            return new List<T>();
        }
    }
}

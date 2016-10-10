using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapitalTechGroup.TikiORM.Core
{
    public static class ConnectionHelpers
    {
        /// <summary>
        /// This helper method executes a retrieval query and returns the result for the
        /// associated connection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static List<T> RetrievalQuery<T> (this IDbConnection connection, RetrievalQueryExecutor<T> executor)
        {
            return executor.PerformOnConnection(connection);
        }

        /// <summary>
        /// This method is used to execute an update and return the number of rows that have been
        /// updated / deleted
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static int UpdateQuery (this IDbConnection connection)
        {
            throw new NotImplementedException();
        }

    }
}

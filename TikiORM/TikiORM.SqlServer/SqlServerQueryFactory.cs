using FurmanCapital.TikiORM.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapital.TikiORM.SqlServer
{
    /// <summary>
    /// This implementation is used to generate sql server specific query factory
    /// </summary>
    public class SqlServerQueryFactory : IQueryFactory
    {
        public IQuery CreateQuery(string queryText)
        {
            return new SqlServerQuery(queryText);
        }

        public IQuery CreateQueryWithParameters(string queryText, dynamic queryParameters)
        {
            return new SqlServerQuery(queryText, queryParameters);
        }
    }
}

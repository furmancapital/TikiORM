﻿using FurmanCapital.TikiORM.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FurmanCapital.TikiORM.SqlServer
{
    /// <summary>
    /// SQL server specific implementation
    /// </summary>
    public class SqlServerQuery : IQuery
    {
        public SqlServerQuery(string sqlQuery)
            : this(sqlQuery, null)
        {
        }

        public SqlServerQuery(string sqlQuery, dynamic queryParameter)
        {
            if (sqlQuery == null)
            {
                throw new ArgumentNullException(nameof(sqlQuery));
            }

            this.UnderlyingQuery = sqlQuery;
        }

        public IReadOnlyCollection<IDbDataParameter> Parameters
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string UnderlyingQuery
        {
            get;
            private set;
        }

        private void ExtractAndVerifyParameters(dynamic parameterObject)
        {
            if (parameterObject == null)
            {
                return;
            }


        }
    }
}

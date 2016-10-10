﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapital.TikiORM.Core
{
    /// <summary>
    /// This class represents a query that does NOT have any parameters associated with it
    /// </summary>
    public class Query
    {
        public Query (string sqlQuery)
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

    }
}
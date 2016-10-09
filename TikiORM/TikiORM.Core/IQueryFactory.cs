using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapital.TikiORM.Core
{
    /// <summary>
    /// This factory is used to generate the provider specific implementation of IQuery implementations
    /// </summary>
    public interface IQueryFactory
    {
        /// <summary>
        /// Creates a provider specific query with no parameters
        /// </summary>
        /// <param name="queryText"></param>
        /// <returns></returns>
        IQuery CreateQuery(string queryText);

        /// <summary>
        /// Creates a provider specific query that supports parameters
        /// </summary>
        /// <param name="queryText"></param>
        /// <param name="queryParameters"></param>
        /// <returns></returns>
        IQuery CreateQueryWithParameters(string queryText, dynamic queryParameters);
    }
}

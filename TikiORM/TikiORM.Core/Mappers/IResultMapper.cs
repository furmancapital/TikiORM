using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapitalTechGroup.TikiORM.Core.Mappers
{
    /// <summary>
    /// This interface represents a mapper that is used to map objects from the underlying reader
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface IResultMapper<TResult>
        where TResult : new()
    {
        /// <summary>
        /// Maps the results from the passed in data reader
        /// </summary>
        /// <param name="dataReader">The datareader from which we will be mapping the result</param>
        /// <param name="resultStructure">The structure of the results that are returned from the query execution</param>
        /// <returns></returns>
        TResult MapResult(IDataReader dataReader, QueryResultStructure resultStructure);
    }
}

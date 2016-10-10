using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapital.TikiORM.Core.Mappers
{
    /// <summary>
    /// This interface represents a mapper that is used to map objects from the underlying reader
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface IResultMapper<TResult>
    {
        /// <summary>
        /// Maps the results from the passed in data reader
        /// </summary>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        TResult MapResult(IDataReader dataReader);
    }
}

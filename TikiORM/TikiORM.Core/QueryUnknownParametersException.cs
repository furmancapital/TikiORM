using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapital.TikiORM.Core
{
    /// <summary>
    /// This exception indicates a situation in which we have unknown parameters (i.e. parameters are either passed in that are NOT
    /// in the query, or we have parameters the query expects that have NOT been passed in)
    /// </summary>
    public class QueryUnknownParametersException : Exception
    {
    }
}

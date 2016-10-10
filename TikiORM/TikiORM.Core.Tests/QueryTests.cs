using FurmanCapital.TikiORM.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikiORM.Core.Tests
{
    [TestFixture]
    public class QueryTests
    {
        /// <summary>
        /// This test verifies that if we have parameters in the query for which we have NOT passed in parameters in the parameter
        /// object, then should throw an exception
        /// </summary>
        [Test]
        public void Constructor_Verify_Query_Required()
        {
            Assert.Throws<QueryUnknownParametersException>(() =>
            {
                new Query(null);
            });
        }


    }
}

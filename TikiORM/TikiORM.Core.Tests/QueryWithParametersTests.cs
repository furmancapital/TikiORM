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
    public class QueryWithParametersTests
    {
        [Test]
        public void Constructor_Verify_Query_Required()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new QueryWithParameters(null, null);
            });
        }

        [Test]
        public void Constructor_Verify_QueryParameters_Required()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new QueryWithParameters("select * from somewhere", null);
            });
        }


        [Test]
        public void Constructor_Verify_Parameters_Properly_Populated()
        {
            var query = new QueryWithParameters("SELECT * FROM SOMEWHERE WHERE Param = @Param", new { Param = "myParam" });
            Assert.AreEqual(1, query.QueryParameters.Count(), "Did not add the parameter");
            Assert.AreEqual("@Param", query.QueryParameters.First().Key, "Did not populate the parameter name properly");
            Assert.AreEqual("myParam", query.QueryParameters.First().Value, "Did not populate the parameter value properly");
        }
    }
}

using FurmanCapital.TikiORM.Core;
using FurmanCapital.TikiORM.SqlServer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikiORM.Core.Tests
{
    [TestFixture]
    public class SqlServerQueryTests
    {
        /// <summary>
        /// This test verifies that if we have parameters in the query for which we have NOT passed in parameters in the parameter
        /// object, then should throw an exception
        /// </summary>
        [Test]
        public void Constructor_Verify_If_Query_Contains_Parameters_That_Have_Not_Been_Passed_Throw_Exception()
        {
            Assert.Throws<QueryUnknownParametersException>(() =>
            {
                new SqlServerQuery("SELECT * FROM SOMEWHERE WHERE something = @somethingElse", new { Param = this });
            });
        }

        /// <summary>
        /// This test verifies that if we have parameters that are passed in that are NOT in the query, then an 
        /// exception should be thrown
        /// </summary>
        [Test]
        public void Constructor_Verify_If_Parameters_Contain_Parameters_That_Are_Not_In_Query_Throw_Exception()
        {
            Assert.Throws<QueryUnknownParametersException>(() =>
            {
                new SqlServerQuery("SELECT * FROM SOMEWHERE WHERE Param = @Param", new { Param = this, ParamThat = this });
            });
        }

        [Test]
        public void Constructor_Verify_Parameters_Properly_Populated()
        {
            var query = new SqlServerQuery("SELECT * FROM SOMEWHERE WHERE Param = @Param", new { Param = "myParam" });
            Assert.AreEqual(1, query.Parameters.Count(), "Did not add the parameter");
            Assert.AreEqual("@Param", query.Parameters.First().ParameterName, "Did not populate the parameter name properly");
            Assert.AreEqual("myParam", query.Parameters.First().Value, "Did not populate the parameter value properly");
        }

        [Test]
        public void Constructor_If_No_Parameters_Verify_Parameters_Property_Not_Null()
        {
            var query = new SqlServerQuery("SELECT * FROM SOMEWHERE");
            Assert.NotNull(query.Parameters, "Should never be null");
            Assert.AreEqual(0, query.Parameters.Count(), "Should not add any parameters when there are no parameters passed in");
        }
    }
}

using FurmanCapital.TikiORM.SqlServer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapital.TikiORM.SqlServer
{
    [TestFixture]
    public class SqlServerQueryFactoryTests
    {
        [Test]
        public void CreateQuery_Verify_Proper_Instance_Created()
        {
            var result = new SqlServerQueryFactory().CreateQuery("SELECT * FROM SOMEWHERE");
            Assert.IsInstanceOf<SqlServerQuery>(result, "Incorrect type of query created");

        }

        [Test]
        public void CreateQueryWithParameters_Verify_Proper_Instance_Created()
        {
            var result = new SqlServerQueryFactory().CreateQueryWithParameters("SELECT * FROM SOMEWHERE WHERE a = @a", new { a = "me"});
            Assert.IsInstanceOf<SqlServerQuery>(result, "Incorrect type of query created");

        }
    }
}

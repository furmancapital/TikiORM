using FurmanCapitalTechGroup.TikiORM.Core.Mappers;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapitalTechGroup.TikiORM.Core
{
    [TestFixture]
    public class RetrievalQueryExecutorTests
    {
        public class MyTestClass
        {
            public string A
            {
                get;set;
            }

            public string B
            {
                get;set;
            }
        }

        private IDbConnection Connection
        {
            get; set;
        }

        private IDbCommand Command
        {
            get;set;
        }

        private IDataReader DataReader
        {
            get;set;
        }

        private IDbDataParameter Parameter
        {
            get;set;
        }

        private IDataParameterCollection ParameterCollection
        {
            get;set;
        }


        [SetUp]
        public void OnSetup()
        {
            this.Connection = MockRepository.GenerateMock<IDbConnection>();
            this.Command = MockRepository.GenerateMock<IDbCommand>();
            this.DataReader = MockRepository.GenerateMock<IDataReader>();
            this.Parameter = MockRepository.GenerateMock<IDbDataParameter>();
            this.ParameterCollection = MockRepository.GenerateMock<IDataParameterCollection>();

            this.Connection.Stub(x => x.CreateCommand())
                .Return(Command);

            this.Command.Stub(x => x.Parameters)
                .Return(ParameterCollection);

            this.Command.Stub(x => x.ExecuteReader())
                .Return(DataReader);
        }

        [Test]
        public void PerformOnConnection_Verify_IfNoParameters_NoneShouldBeSpecified()
        {
            this.Command.Expect(x => x.CreateParameter())
                .Repeat
                .Never();

            var result = RetrievalQueryExecutorBuilder<MyTestClass>.ForQuery("QUERY")
                .WithCustomFuncMapper((x) => null)
                .Build()
                .PerformOnConnection(this.Connection);

            this.Parameter.VerifyAllExpectations();
        }


        [Test]
        public void PerformOnConnection_Verify_IfParameters_Verify_Created_And_Added_To_Command()
        {
            var value = new object();

            this.Command.Expect(x => x.CreateParameter())
                .Return(Parameter);

            this.ParameterCollection.Expect(x => x.Add(Parameter))
                .Return(1);

            this.Parameter.Expect(x => x.ParameterName = Arg<string>.Matches(item => item == "myParam"));
            this.Parameter.Expect(x => x.Value = Arg<object>.Matches(item => item == value));


            var result = RetrievalQueryExecutorBuilder<MyTestClass>.ForQuery("QUERY")
                .WithCustomFuncMapper((x) => null)
                .WithParameters(new Dictionary<string, object>
                {
                    { "myParam", value}
                })
                .Build()
                .PerformOnConnection(this.Connection);

            this.Command.VerifyAllExpectations();

            this.ParameterCollection.VerifyAllExpectations();

            this.Parameter.VerifyAllExpectations();
        }


        [Test]
        public void PerformOnConnection_Verify_Mapper_Called_On_DataReader()
        {
            IResultMapper<MyTestClass> mockMapper = MockRepository.GenerateMock<IResultMapper<MyTestClass>>();

            var mockTestClass = new MyTestClass();

            this.DataReader.Stub(x => x.Read())
                .Repeat
                .Once()
                .Return(true);


            mockMapper.Expect(x => x.MapResult(this.DataReader))
                .Return(mockTestClass);

            var result = RetrievalQueryExecutorBuilder<MyTestClass>.ForQuery("QUERY")
                .WithCustomResultMapper(mockMapper)
                .Build()
                .PerformOnConnection(this.Connection);

            mockMapper.VerifyAllExpectations();

            Assert.AreSame(mockTestClass, result.First(), "Did not return the expected mapped object");
        }

     
    }
}

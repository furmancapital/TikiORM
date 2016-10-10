using FurmanCapitalTechGroup.TikiORM.Core.Mappers;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapitalTechGroup.TikiORM.Core
{
    public class RetrievalQueryExecutorBuilderTests
    {
        [Test]
        public void Build_Verify_If_No_Parameters_Specified_Should_Return_NonNull_Default_Parameters()
        {
            var result = RetrievalQueryExecutorBuilder<int>.ForQuery("A")
                .Build();

            Assert.AreSame(RetrievalQueryExecutorBuilder.EmptyParameters, result.Parameters);
        }

        [Test]
        public void Build_Verify_If_Parameters_Specified_Should_Return_Them()
        {
            var mockParameters = new Dictionary<string, object>();

            var result = RetrievalQueryExecutorBuilder<int>.ForQuery("A")
                .WithParameters(mockParameters)
              .Build();

            Assert.AreSame(mockParameters, result.Parameters);
        }

        [Test]
        public void Build_Verify_WithParameter_Appends_Parameters()
        {
            var mockParameters = new Dictionary<string, object>()
            {
                { "A", "B" }
            };

            var result = RetrievalQueryExecutorBuilder<int>.ForQuery("A")
                .WithParameters(mockParameters)
                .WithParameter("C", "D")
              .Build();

            Assert.AreEqual(2, result.Parameters.Count);
        }


        [Test]
        public void Build_Verify_WithParameters_Clears_Previous_Parameters()
        {
            var mockParameters = new Dictionary<string, object>()
            {
                { "A", "B" }
            };

            var result = RetrievalQueryExecutorBuilder<int>.ForQuery("A")
                .WithParameter("C", "D")
                .WithParameters(mockParameters)
              .Build();

            Assert.AreEqual(1, result.Parameters.Count);
        }

        [Test]
        public void Build_Verify_WithCustomFuncMapper_CustomMapper_Added()
        {
            var result = RetrievalQueryExecutorBuilder<int>.ForQuery("A")
                .WithCustomFuncMapper((x) => { return 1; })
              .Build();

            Assert.IsInstanceOf<FuncBasedResultMapper<int>>(result.ResultMapper, "Incorrect mapper retrieved");
        }


        [Test]
        public void Build_Verify_WithCustomMapper_CustomMapper_Added()
        {
            var mockMapper = MockRepository.GenerateMock<IResultMapper<int>>();

            var result = RetrievalQueryExecutorBuilder<int>.ForQuery("A")
                .WithCustomResultMapper(mockMapper)
              .Build();

            Assert.AreEqual(mockMapper, result.ResultMapper, "Did not set the specified mapper");
        }


    }
}

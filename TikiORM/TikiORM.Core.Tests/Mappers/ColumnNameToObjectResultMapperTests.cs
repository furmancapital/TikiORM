using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapitalTechGroup.TikiORM.Core.Mappers
{
    [TestFixture]
    public class ColumnNameToObjectResultMapperTests
    {
        private class MyDummyClass
        {
            public string Property1
            {
                get;set;
            }

            public Int16 PropertyInt16
            {
                get;set;
            }

            public Int32 PropertyInt32
            {
                get;set;
            }

            public Int64 PropertyInt64
            {
                get;set;
            }

            public DateTime PropertyDateTime
            {
                get;set;
            }

            public double PropertyDouble
            {
                get;set;
            }

            public decimal PropertyDecimal
            {
                get;set;
            }

            private string PrivateStringProperty
            {
                get;set;
            }
        }

        private IDataReader DataReader
        {
            get;set;
        }

        [SetUp]
        public void OnSetup()
        {
            this.DataReader = MockRepository.GenerateMock<IDataReader>();
        }

        private QueryResultStructure CreateDummyStructure(IEnumerable<string> fieldNames)
        {
            QueryResultStructure structure = new QueryResultStructure();

            fieldNames.Select((field, index) =>
            {
                return new
                {
                    Field = field,
                    Index = index
                };
            }).ToList().ForEach(item =>
            {
                structure.AddColumn(item.Field, item.Index);
            });

            
            return structure;
        }

        private ColumnNameToObjectResultMapper<MyDummyClass> GetMapper()
        {
            return new ColumnNameToObjectResultMapper<MyDummyClass>();
        }

        [Test]
        public void MapResult_Verify_Matching_Private_Columns_Mapped()
        {
            var dummyStructure = this.CreateDummyStructure(new[] { "PrivateStringProperty" });

            var targetColumnIndex = dummyStructure.GetColumnIndex("PrivateStringProperty");

            this.DataReader.Expect(x => x.IsDBNull(targetColumnIndex))
                .Return(false);

            this.DataReader.Expect(x => x.GetString(targetColumnIndex))
                .Return("TARGET_VAL");

            var mappedObject = this.GetMapper().MapResult(this.DataReader, dummyStructure);

            var privateValue = mappedObject.GetType().GetProperty("PrivateStringProperty").GetValue(mappedObject);

            Assert.AreEqual("TARGET_VAL", privateValue, "Did not set private value properly");
        }

    }
}

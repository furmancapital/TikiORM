using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapitalTechGroup.TikiORM.Core.Mappers
{
    [TestFixture]
    public class ColumnNameToObjectResultMapperTests
    {
        private class MyDummyClass
        {
            public string PropertyString
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

        private PropertyInfo GetPropertyFromType (Type sourceType, string property)
        {
            var targetProperty = sourceType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(item => item.Name.Equals(property))
                .FirstOrDefault();

            Assert.NotNull(targetProperty, $"Unable to find the {property} property");

            return targetProperty;
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

            var privateValue = GetPropertyFromType(mappedObject.GetType(), ("PrivateStringProperty")).GetValue(mappedObject);

            Assert.AreEqual("TARGET_VAL", privateValue, "Did not set private value properly");
        }

        [Test]
        public void MapResult_Verify_String_Columns_Mapped()
        {
            var dummyStructure = this.CreateDummyStructure(new[] { "PropertyString" });

            var targetColumnIndex = dummyStructure.GetColumnIndex("PropertyString");

            this.DataReader.Expect(x => x.IsDBNull(targetColumnIndex))
                .Return(false);

            this.DataReader.Expect(x => x.GetString(targetColumnIndex))
                .Return("TARGET_VAL");

            var mappedObject = this.GetMapper().MapResult(this.DataReader, dummyStructure);
            Assert.AreEqual("TARGET_VAL", mappedObject.PropertyString, "Did not set value properly");
        }

        [Test]
        public void MapResult_Verify_Int16_Columns_Mapped()
        {
            var dummyStructure = this.CreateDummyStructure(new[] { "PropertyInt16" });

            var targetColumnIndex = dummyStructure.GetColumnIndex("PropertyInt16");

            this.DataReader.Expect(x => x.IsDBNull(targetColumnIndex))
                .Return(false);

            this.DataReader.Expect(x => x.GetInt16(targetColumnIndex))
                .Return(1);

            var mappedObject = this.GetMapper().MapResult(this.DataReader, dummyStructure);

            Assert.AreEqual(1, mappedObject.PropertyInt16, "Did not set value properly");
        }

        [Test]
        public void MapResult_Verify_Int32_Columns_Mapped()
        {
            var dummyStructure = this.CreateDummyStructure(new[] { "PropertyInt32" });

            var targetColumnIndex = dummyStructure.GetColumnIndex("PropertyInt32");

            this.DataReader.Expect(x => x.IsDBNull(targetColumnIndex))
                .Return(false);

            this.DataReader.Expect(x => x.GetInt32(targetColumnIndex))
                .Return(1);

            var mappedObject = this.GetMapper().MapResult(this.DataReader, dummyStructure);
            Assert.AreEqual(1, mappedObject.PropertyInt32, "Did not set value properly");
        }

        [Test]
        public void MapResult_Verify_Int64_Columns_Mapped()
        {
            var dummyStructure = this.CreateDummyStructure(new[] { "PropertyInt64" });

            var targetColumnIndex = dummyStructure.GetColumnIndex("PropertyInt64");

            this.DataReader.Expect(x => x.IsDBNull(targetColumnIndex))
                .Return(false);

            this.DataReader.Expect(x => x.GetInt64(targetColumnIndex))
                .Return(1);

            var mappedObject = this.GetMapper().MapResult(this.DataReader, dummyStructure);
            Assert.AreEqual(1, mappedObject.PropertyInt64, "Did not set value properly");
        }

        [Test]
        public void MapResult_Verify_DateTime_Columns_Mapped()
        {
            var dummyStructure = this.CreateDummyStructure(new[] { "PropertyDateTime" });

            var targetColumnIndex = dummyStructure.GetColumnIndex("PropertyDateTime");

            this.DataReader.Expect(x => x.IsDBNull(targetColumnIndex))
                .Return(false);

            this.DataReader.Expect(x => x.GetDateTime(targetColumnIndex))
                .Return(DateTime.Today);

            var mappedObject = this.GetMapper().MapResult(this.DataReader, dummyStructure);
            Assert.AreEqual(DateTime.Today, mappedObject.PropertyDateTime, "Did not set value properly");
        }

        [Test]
        public void MapResult_Verify_Double_Columns_Mapped()
        {
            var dummyStructure = this.CreateDummyStructure(new[] { "PropertyDouble" });

            var targetColumnIndex = dummyStructure.GetColumnIndex("PropertyDouble");

            this.DataReader.Expect(x => x.IsDBNull(targetColumnIndex))
                .Return(false);

            this.DataReader.Expect(x => x.GetDouble(targetColumnIndex))
                .Return(1);

            var mappedObject = this.GetMapper().MapResult(this.DataReader, dummyStructure);
            Assert.AreEqual(1, mappedObject.PropertyDouble, "Did not set value properly");
        }


        [Test]
        public void MapResult_Verify_Decimal_Columns_Mapped()
        {
            var dummyStructure = this.CreateDummyStructure(new[] { "PropertyDecimal" });

            var targetColumnIndex = dummyStructure.GetColumnIndex("PropertyDecimal");

            this.DataReader.Expect(x => x.IsDBNull(targetColumnIndex))
                .Return(false);

            this.DataReader.Expect(x => x.GetDecimal(targetColumnIndex))
                .Return(1);

            var mappedObject = this.GetMapper().MapResult(this.DataReader, dummyStructure);
            Assert.AreEqual(1, mappedObject.PropertyDecimal, "Did not set value properly");
        }

    }
}

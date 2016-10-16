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

        [Test]
        public void MapResult_Verify_If_Column_Name_Matches_Associated_Property_Should_Be_Set_On_Object()
        {

        }
    }
}

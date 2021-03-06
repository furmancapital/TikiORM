﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurmanCapitalTechGroup.TikiORM.Core.Mappers
{
    [TestFixture]
    public class ObjectFieldMappingCollectionTests
    {
        [Test]
        public void CreateMappingCollection_Verify_All_Properties_Mapped()
        {
            var myObject = new
            {
                Property1 = "a",
                Property2 = "b"
            };

            var result = ObjectFieldMappingCollection.CreateMappingCollection(myObject);
            Assert.NotNull(result.GetFieldInfo("Property1"));
            Assert.NotNull(result.GetFieldInfo("Property2"));
        }

        class MyTestClass
        {
            public string A
            {
                get;set;
            }

            private string B
            {
                get;set;
            } 
        }

        [Test]
        public void CreateMappingCollection_Verify_Private_Properties_Mapped()
        {
            var myObject = new MyTestClass();

            var result = ObjectFieldMappingCollection.CreateMappingCollection(myObject);
            Assert.NotNull(result.GetFieldInfo("B"));
        }

        [Test]
        public void CreateMappingCollection_Verify_NonExistent_Properties_Not_Mapped()
        {
            var myObject = new
            {
                Property1 = "a",
                Property2 = "b"
            };

            var result = ObjectFieldMappingCollection.CreateMappingCollection(myObject);
            Assert.Null(result.GetFieldInfo("Property3"));
        }
    }
}

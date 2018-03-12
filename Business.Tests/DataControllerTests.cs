using System;
using System.Collections.Generic;
using DataAccess;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Business.Tests
{
    [TestClass]
    public class DataControllerTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            // ARRANGE
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CybellesCykler.S2Eksamen;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            // ACT
            DataController dataController = new DataController(connectionString);

            // ASSERT
            Assert.IsNotNull(dataController);
        }

        [TestMethod]
        public void GetEntitiesTest()
        {
            // ARRANGE
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CybellesCykler.S2Eksamen;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            DataController dataController = new DataController(connectionString);
            string entity = ""; // Placeholder !!!

            // ACT
            List<IPersistable> list = dataController.GetEntities(entity);

            // ASSERT
            Assert.IsNotNull(list);
            Assert.Fail("Not fully implemented");
        }

        [TestMethod]
        public void GetEntityTest()
        {
            // ARRANGE
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CybellesCykler.S2Eksamen;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            DataController dataController = new DataController(connectionString);
            string entity = ""; // Placeholder !!!
            int id = 1; // Placeholder !!!

            // ACT
            IPersistable persistable = dataController.GetEntity(entity, id);

            // ASSERT
            Assert.IsNotNull(persistable);
            Assert.Fail("Not fully implemented");
        }

        [TestMethod]
        public void NewEntityTest()
        {
            // ARRANGE
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CybellesCykler.S2Eksamen;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            DataController dataController = new DataController(connectionString);
            IPersistable entity = new Bike(44.3M, "Some description", BikeKind.City, (int)BikeKind.City);

            // ACT
            dataController.NewEntity(entity);

            // ASSERT
            Assert.Fail("Not fully implemented");
        }

        [TestMethod]
        public void UpdateEntity()
        {
            // ARRANGE
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CybellesCykler.S2Eksamen;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            DataController dataController = new DataController(connectionString);
            IPersistable entity = new Bike(44.3M, "Some description", BikeKind.City, (int)BikeKind.City);

            // ACT
            dataController.UpdateEntity(entity);

            // ASSERT
            Assert.Fail("Not fully implemented");
        }
    }
}

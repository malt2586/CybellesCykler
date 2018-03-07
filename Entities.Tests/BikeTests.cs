using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Entities.Tests
{
    [TestClass]
    public class BikeTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            // ARRANGE
            decimal pricePerDay = 20.5M;
            string bikeDescription = "Some description of the bike";
            BikeKind kind = BikeKind.Mountain;
            int id = 1;

            // ACT
            Bike bike = new Bike(pricePerDay, bikeDescription, kind, id);
            decimal actualPricePerDay = bike.PricePerDay;
            string actualBikeDescription = bike.BikeDescription;
            BikeKind actualKind = bike.Kind;
            int actualId = bike.Id;

            // ASSERT
            Assert.IsNotNull(bike, "Bike is null");
            Assert.AreEqual(pricePerDay, actualPricePerDay, "PricePerDay not equal");
            Assert.AreEqual(bikeDescription, actualBikeDescription, "BikeDescription not equal");
            Assert.AreEqual(kind, actualKind, "Kind not equal");
            Assert.AreEqual(id, actualId, "Id not equal");
        }
    }
}

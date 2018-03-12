using System;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccess.Tests
{
    [TestClass]
    public class DBHandlerTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            // ARRANGE
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CybellesCykler.S2Eksamen;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            // ACT
            DBHandler dB = new DBHandler(connectionString);

            // ASSERT
            Assert.IsNotNull(dB, "db is null");
        }

        [TestMethod]
        public void GetRenteeTest()
        {
            // ARRANGE
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CybellesCykler.S2Eksamen;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            DBHandler dB = new DBHandler(connectionString);
            // Creates rentee to retrieve from DB
            Rentee expected = new Rentee("John Doe", "StreetName 101", "12345678", new DateTime(2000, 1, 1), 1); // Has to match rentee in DB

            // ACT
            Rentee actual = dB.GetRentee(1);

            // ASSERT
            Assert.IsNotNull(actual, "Rentee is null");
            Assert.AreEqual(expected.ToString(), actual.ToString(), "Rentee not equal");
        }

        [TestMethod]
        public void GetBikeTest()
        {
            // ARRANGE
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CybellesCykler.S2Eksamen;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            DBHandler dB = new DBHandler(connectionString);
            // Creates bike to retrieve from DB
            Bike expected = new Bike(10.20M, "Some about the mountainbike", BikeKind.Mountain, 1); // Has to match bike in DB

            // ACT
            Bike actual = dB.GetBike(1);

            // ASSERT
            Assert.IsNotNull(actual, "Bike is null");
            Assert.AreEqual(expected.ToString(), actual.ToString(), "Bike not equal");
        }

        [TestMethod]
        public void GetOrderTest()
        {
            // ARRANGE
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CybellesCykler.S2Eksamen;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            DBHandler dB = new DBHandler(connectionString);
            Rentee rentee = new Rentee("John Doe", "StreetName 101", "12345678", new DateTime(2000, 1, 1), 1); // Has to match rentee in DB
            Bike bike = new Bike(20.5M, "Some description of the bike", BikeKind.Mountain, 1); // Has to match bike in DB
            // Creates order to retrieve from DB
            Order expected = new Order(bike, rentee, new DateTime(2001, 1, 1), new DateTime(2001, 1, 5), 1); // Has to match order in DB

            // ACT
            Order actual = dB.GetOrder(1);

            // ASSERT
            Assert.IsNotNull(actual, "Order is null");
            Assert.AreEqual(expected.ToString(), actual.ToString(), "Order not equal");
        }

        [TestMethod]
        public void NewRenteeTest()
        {
            // ARRANGE
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CybellesCykler.S2Eksamen;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            DBHandler dB = new DBHandler(connectionString);
            // Creates rentee to add to DB
            Rentee expected = new Rentee("John Doe", "StreetName 101", "12345678", new DateTime(2003, 5, 2), 1);

            // ACT
            bool isAdded = dB.NewRentee(expected);
            //Rentee actual = dB.GetRentee(1);

            // ASSERT
            Assert.IsTrue(isAdded, "Rentee not added");
            //Assert.AreEqual(expected, actual, "Rentee not equal");
        }

        [TestMethod]
        public void NewBikeTest()
        {
            // ARRANGE
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CybellesCykler.S2Eksamen;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            DBHandler dB = new DBHandler(connectionString);
            // Creates bike to add to DB
            Bike expected = new Bike(20.5M, "Some description of the bike", BikeKind.Mountain, 1);

            // ACT
            bool isAdded = dB.NewBike(expected);
            //Bike actual = dB.GetBike(1);

            // ASSERT
            Assert.IsTrue(isAdded, "Bike not added");
            //Assert.AreEqual(expected, actual, "Bike not equal");
        }

        [TestMethod]
        public void NewOrderTest()
        {
            // ARRANGE
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CybellesCykler.S2Eksamen;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            DBHandler dB = new DBHandler(connectionString);
            Rentee rentee = new Rentee("John Doe", "StreetName 101", "12345678", new DateTime(2000, 1, 1), 1); // Has to match rentee in DB
            Bike bike = new Bike(20.5M, "Some description of the bike", BikeKind.Mountain, 1); // Has to match bike in DB
            // Creates order to add to DB
            Order expected = new Order(bike, rentee, new DateTime(2009, 1, 1), new DateTime(2009, 1, 1), 1);

            // ACT
            bool isAdded = dB.NewOrder(expected);
            //Order actual = dB.GetOrder(1);

            // ASSERT
            Assert.IsTrue(isAdded, "Order not added");
            //Assert.AreEqual(expected, actual, "Order not equal");
        }

        [TestMethod]
        public void UpdateRenteeTest()
        {
            // ARRANGE
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CybellesCykler.S2Eksamen;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            DBHandler dB = new DBHandler(connectionString);
            Rentee rentee = new Rentee("John Doe", "StreetName 101", "12345678", new DateTime(), 1); // Has to match rentee in DB
            // Name changed from "John Doe" to "Jane Doe"
            Rentee expected = new Rentee("Jane Doe", "StreetName 101", "12345678", new DateTime(), 1);

            // ACT
            bool isUpdated = dB.UpdateRentee(expected);
            //Rentee actual = dB.GetRentee(1);

            // ASSERT
            Assert.IsTrue(isUpdated, "Rentee not updated");
            //Assert.AreEqual(expected, actual, "Rentee not equal");
        }

        [TestMethod]
        public void UpdateBikeTest()
        {
            // ARRANGE
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CybellesCykler.S2Eksamen;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            DBHandler dB = new DBHandler(connectionString);
            Bike bike = new Bike(20.5M, "Some description of the bike", BikeKind.Mountain, 1);
            // PricePerDay changed from "20.5M" to "30.5M"
            Bike expected = new Bike(30.5M, "Some description of the bike", BikeKind.Mountain, 1);

            // ACT
            bool isUpdated = dB.UpdateBike(expected);
            //Bike actual = dB.GetBike(1);

            // ASSERT
            Assert.IsTrue(isUpdated, "Bike not updated");
            //Assert.AreEqual(expected, actual, "Bike not equal");
        }

        [TestMethod]
        public void UpdateOrderTest()
        {
            // ARRANGE
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CybellesCykler.S2Eksamen;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            DBHandler dB = new DBHandler(connectionString);
            Rentee rentee = new Rentee("John Doe", "StreetName 101", "12345678", new DateTime(), 1);
            Bike bike = new Bike(20.5M, "Some description of the bike", BikeKind.Mountain, 1);
            Order order = new Order(bike, rentee, new DateTime(), new DateTime(), 1); // Has to match order in DB
            // DeliveryDate changed
            Order expected = new Order(bike, rentee, new DateTime(), new DateTime(), 1); // Change DateTime

            // ACT
            bool isUpdated = dB.UpdateOrder(expected);
            //Order actual = dB.GetOrder(1);

            // ASSERT
            Assert.IsTrue(isUpdated, "Order not updated");
            //Assert.AreEqual(expected, actual, "Order not equal");
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Entities.Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            // ARRANGE
            int id = 1; // Used for constructors (bik, rentee, order)
            DateTime rentDate = new DateTime();
            DateTime deliveryDate = new DateTime();

            // Creates Bike object for the constructor
            decimal pricePerDay = 20.5M;
            string bikeDescription = "Some description of the bike";
            BikeKind kind = BikeKind.Mountain;
            Bike bike = new Bike(pricePerDay, bikeDescription, kind, id);
            
            // Creates Rentee object for the constructor
            string name = "John Doe";
            string address = "StreetName 101";
            string phoneNumber = "12345678";
            DateTime registerDate = new DateTime();
            Rentee rentee = new Rentee(name, address, phoneNumber, registerDate, id);

            // ACT
            Order order = new Order(bike, rentee, rentDate, deliveryDate, id);
            Bike actualBike = order.Bike;
            Rentee actualRentee = order.Rentee;
            DateTime actualRentDate = order.RentDate;
            DateTime actualDeliveryDate = order.DeliveryDate;
            int actualId = order.Id;

            // ASSERT
            Assert.IsNotNull(order, "Order is null");
            Assert.AreEqual(bike, actualBike, "Bike not equal");
            Assert.AreEqual(rentee, actualRentee, "Rentee not equal");
            Assert.AreEqual(rentDate, actualRentDate, "RentDate not equal");
            Assert.AreEqual(deliveryDate, actualDeliveryDate, "DeliveryDate not equal");
        }

        [TestMethod]
        public void GetPriceTest()
        {
            // ARRANGE
            int id = 1; // Used for constructors (bik, rentee, order)

            // Creates Bike object
            decimal pricePerDay = 20.5M;
            string bikeDescription = "Some description of the bike";
            BikeKind kind = BikeKind.Mountain;
            Bike bike = new Bike(pricePerDay, bikeDescription, kind, id);

            // Creates Rentee object
            string name = "John Doe";
            string address = "StreetName 101";
            string phoneNumber = "12345678";
            DateTime registerDate = new DateTime();
            Rentee rentee = new Rentee(name, address, phoneNumber, registerDate, id);

            // Creates Order object
            DateTime rentDate = new DateTime(2018, 1, 1);
            DateTime deliveryDate = new DateTime(2018, 1, 5);
            Order order = new Order(bike, rentee, rentDate, deliveryDate, id);

            TimeSpan daysRented = deliveryDate - rentDate;
            decimal expected = (pricePerDay * daysRented.Days);

            // ACT
            decimal actual = order.GetPrice();

            // ASSERT
            Assert.AreEqual(expected, actual, "Price not equal");
        }

        [TestMethod]
        public void ToStringTest()
        {
            // ARRANGE
            int id = 1; // Used for constructors (bik, rentee, order)

            // Creates Bike object
            decimal pricePerDay = 20.5M;
            string bikeDescription = "Some description of the bike";
            BikeKind kind = BikeKind.Mountain;
            Bike bike = new Bike(pricePerDay, bikeDescription, kind, id);

            // Creates Rentee object
            string name = "John Doe";
            string address = "StreetName 101";
            string phoneNumber = "12345678";
            DateTime registerDate = new DateTime();
            Rentee rentee = new Rentee(name, address, phoneNumber, registerDate, id);

            // Creates Order object
            DateTime rentDate = new DateTime(2018, 1, 1);
            DateTime deliveryDate = new DateTime(2018, 1, 5);
            Order order = new Order(bike, rentee, rentDate, deliveryDate, id);

            string expected = $"Bike: {order.Bike.Kind}, Rentee: {order.Rentee.Name}, Rent Date: {order.RentDate.Date}, Delivery Date: {order.DeliveryDate.Date}, ID: {order.Id}";

            // ACT
            string actual = order.ToString();

            // ASSERT
            Assert.AreEqual(expected, actual, "String not equal");
        }
    }
}

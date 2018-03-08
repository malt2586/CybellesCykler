using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Entities.Tests
{
    [TestClass]
    public class RenteeTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            // ARRANGE
            string name = "John Doe";
            string address = "StreetName 101";
            string phoneNumber = "12345678";
            DateTime registerDate = new DateTime();
            int id = 1;

            // ACT
            Rentee rentee = new Rentee(name, address, phoneNumber, registerDate, id);
            string actualName = rentee.Name;
            string actualAddress = rentee.Address;
            string actualPhoneNumber = rentee.PhoneNumber;
            DateTime actualRegisterDate = rentee.RegisterDate;
            int actualId = rentee.Id;

            // ASSERT
            Assert.IsNotNull(rentee, "Rentee is null");
            Assert.AreEqual(name, actualName, "Name not equal");
            Assert.AreEqual(address, actualAddress, "Address not equal");
            Assert.AreEqual(phoneNumber, actualPhoneNumber, "PhoneNumber not equal");
            Assert.AreEqual(registerDate, actualRegisterDate, "RegisterDate not equal");
            Assert.AreEqual(id, actualId, "Id not equal");
        }

        [TestMethod]
        public void ToStringTest()
        {
            // ARRANGE
            string name = "John Doe";
            string address = "StreetName 101";
            string phoneNumber = "12345678";
            DateTime registerDate = new DateTime();
            int id = 1;
            Rentee rentee = new Rentee(name, address, phoneNumber, registerDate, id);

            string expected = $"Name: {name}, Address: {address}, Phone: {phoneNumber}, Registered: {registerDate.Date}, ID: {id}";

            // ACT
            string actual = rentee.ToString();

            // ASSERT
            Assert.AreEqual(expected, actual, "String not equal");
        }
    }
}

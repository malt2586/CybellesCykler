using System;

namespace Entities
{
    public class Rentee : IPersistable
    {
        // FIELDS
        private string name;
        private string address;
        private string phoneNumber;
        private DateTime registerDate;
        private int id;

        // PROPERTIES
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public DateTime RegisterDate { get => registerDate; set => registerDate = value; }
        public int Id { get => id; set => id = value; }

        // CONSTRUCTORS
        public Rentee(string name, string address, string phoneNumber, DateTime registerDate, int id)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            RegisterDate = registerDate;
            Id = id;
        }

        // METHODS
        public override string ToString()
        {
            return $"Name: {Name}, Address: {Address}, Phone: {PhoneNumber}, Registrered: {RegisterDate.Date}; ID: {Id}";
        }
    }
}
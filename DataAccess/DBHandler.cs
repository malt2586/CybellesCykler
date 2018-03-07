using System;
using Entities;

namespace DataAccess
{
    public class DBHandler : CommonDB
    {
        // CONSTRUCTORS
        public DBHandler(string connectionString) : base(connectionString) { }

        // METHODS
        public Rentee GetRentee(int v)
        {
            throw new NotImplementedException();
        }

        public Bike GetBike(int v)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int v)
        {
            throw new NotImplementedException();
        }

        public bool NewRentee(Rentee expected)
        {
            throw new NotImplementedException();
        }

        public bool NewBike(Bike expected)
        {
            throw new NotImplementedException();
        }

        public bool NewOrder(Order expected)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRentee(Rentee expected)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBike(Bike expected)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrder(Order expected)
        {
            throw new NotImplementedException();
        }
    }
}
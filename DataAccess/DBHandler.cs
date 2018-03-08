using System;
using System.Data;
using Entities;

namespace DataAccess
{
    public class DBHandler : CommonDB
    {
        // CONSTRUCTORS
        public DBHandler(string connectionString) : base(connectionString) { }

        // METHODS
        public Rentee GetRentee(int id)
        {
            DataSet ds = ExecuteQuery("GetRentee", QueryType.StoredProcedure, id);
            Rentee rentee = new Rentee
            (
                ds.Tables[0].Rows[0].Field<string>("Name"),
                ds.Tables[0].Rows[0].Field<string>("PhysAddress"),
                ds.Tables[0].Rows[0].Field<string>("PhoneNumber"),
                ds.Tables[0].Rows[0].Field<DateTime>("RegisterDate"),
                ds.Tables[0].Rows[0].Field<int>("ID")
            );
            return rentee;
        }

        public Bike GetBike(int id)
        {
            DataSet ds = ExecuteQuery("GetBike", QueryType.StoredProcedure, id);
            Bike bike = new Bike
            (
                ds.Tables[0].Rows[0].Field<decimal>("PricePerDay"),
                ds.Tables[0].Rows[0].Field<string>("BikeDescription"),
                (BikeKind)id,
                id
            );
            return bike;
        }

        public Order GetOrder(int id)
        {
            DataSet ds = ExecuteQuery("GetOrder", QueryType.StoredProcedure, id);
            Order order = new Order
            (
                ds.Tables[0].Rows[0].Field<>
            )
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
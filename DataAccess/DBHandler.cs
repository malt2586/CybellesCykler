using System;
using System.Collections.Generic;
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

        public List<IPersistable> GetAllRentee()
        {
            DataSet ds = ExecuteQuery("GetAllRentee", QueryType.StoredProcedure);
            List<IPersistable> list = new List<IPersistable>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new Rentee
                    (
                        row.Field<string>("Name"),
                        row.Field<string>("PhysAddress"),
                        row.Field<string>("PhoneNumber"),
                        row.Field<DateTime>("RegisterDate"),
                        row.Field<int>("ID")
                    ));
            }
            return list;
        }

        public Bike GetBike(int id)
        {
            DataSet ds = ExecuteQuery("GetBike", QueryType.StoredProcedure, id);
            Bike bike = new Bike
            (
                ds.Tables[0].Rows[0].Field<decimal>("PricePerDay"),
                ds.Tables[0].Rows[0].Field<string>("BikeDescription"),
                (BikeKind)ds.Tables[0].Rows[0].Field<int>("ID"),
                ds.Tables[0].Rows[0].Field<int>("ID")
            );
            return bike;
        }

        public List<IPersistable> GetAllBike()
        {
            DataSet ds = ExecuteQuery("GetAllBike", QueryType.StoredProcedure);
            List<IPersistable> list = new List<IPersistable>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new Bike
                    (
                        row.Field<decimal>("PricePerDay"),
                        row.Field<string>("BikeDescription"),
                        (BikeKind)row.Field<int>("ID"),
                        row.Field<int>("ID")
                    ));
            }
            return list;
        }

        public Order GetOrder(int id)
        {
            DataSet ds = ExecuteQuery("GetOrder", QueryType.StoredProcedure, id);
            Order order = new Order
            (
                new Bike(
                    ds.Tables[2].Rows[0].Field<decimal>("PricePerDay"),
                    ds.Tables[2].Rows[0].Field<string>("BikeDescription"),
                    (BikeKind)ds.Tables[2].Rows[0].Field<int>("ID"),
                    ds.Tables[2].Rows[0].Field<int>("ID")
                    ),
                new Rentee(
                    ds.Tables[1].Rows[0].Field<string>("Name"),
                    ds.Tables[1].Rows[0].Field<string>("PhysAddress"),
                    ds.Tables[1].Rows[0].Field<string>("PhoneNumber"),
                    ds.Tables[1].Rows[0].Field<DateTime>("RegisterDate"),
                    ds.Tables[1].Rows[0].Field<int>("ID")
                    ),
                ds.Tables[0].Rows[0].Field<DateTime>("OrderDate"),
                ds.Tables[0].Rows[0].Field<DateTime>("DeliveryDate"),
                id
            );
            return order;
        }

        public List<IPersistable> GetAllOrder()
        {
            DataSet ds = ExecuteQuery("GetAllOrder", QueryType.StoredProcedure);
            List<IPersistable> list = new List<IPersistable>();
            List<Bike> bikes = new List<Bike>();
            List<Rentee> renters = new List<Rentee>();
            foreach (DataRow row in ds.Tables[2].Rows)
            {
                bikes.Add(new Bike
                    (
                        row.Field<decimal>("PricePerDay"),
                        row.Field<string>("BikeDescription"),
                        (BikeKind)row.Field<int>("ID"),
                        row.Field<int>("ID")
                    ));
            }
            foreach (DataRow row in ds.Tables[1].Rows)
            {
                renters.Add(new Rentee
                    (
                        row.Field<string>("Name"),
                        row.Field<string>("PhysAddress"),
                        row.Field<string>("PhoneNumber"),
                        row.Field<DateTime>("RegisterDate"),
                        row.Field<int>("ID")
                    ));
            }
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new Order
                    (
                        bikes.Find(
                            delegate(Bike bike) 
                            {
                                return bike.Id == row.Field<int>("BikeID");
                            }),
                        renters.Find(
                            delegate (Rentee rentee)
                            {
                                return rentee.Id == row.Field<int>("RenteeID");
                            }),
                        row.Field<DateTime>("OrderDate"),
                        row.Field<DateTime>("DeliveryDate"),
                        row.Field<int>("OrderID")
                    ));
            }
            return list;
        }

        public bool NewRentee(Rentee rentee)
        {
            string query = $"INSERT INTO [Renters] VALUES('{rentee.Name}', '{rentee.PhoneNumber}', '{rentee.Address}', '{rentee.RegisterDate}');";
            return ExecuteNonQuery(query) > 0;
        }

        public bool NewBike(Bike bike)
        {
            throw new NotImplementedException();
        }

        public bool NewOrder(Order order)
        {
            string query = $"INSERT INTO [Orders] VALUES({order.Rentee.Id}, {order.Bike.Id}, '{order.RentDate.Date}', '{order.DeliveryDate.Date}');";
            return ExecuteNonQuery(query) > 0;
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
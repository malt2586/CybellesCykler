using DataAccess;
using Entities;
using System;
using System.Collections.Generic;

namespace Business
{
    public class DataController
    {
        // FIELDS
        private DBHandler dBHandler;

        // CONSTRUCTORS
        public DataController(string connectionString)
        {
            dBHandler = new DBHandler(connectionString);
        }

        // METHODS
        public List<IPersistable> GetEntities(string entity)
        {
            List<IPersistable> entityList = null;
            switch (entity)
            {
                case "Rentee":
                    entityList = dBHandler.GetAllRentee();
                    break;
                case "Bike":
                    entityList = dBHandler.GetAllBike();
                    break;
                case "Order":
                    entityList = dBHandler.GetAllOrder();
                    break;
                default:
                    break;
            }
            return entityList;
        }

        public IPersistable GetEntity(string entity, int id)
        {
            IPersistable entityReturned = null;
            switch (entity)
            {
                case "Rentee":
                    entityReturned = dBHandler.GetRentee(id);
                    break;
                case "Bike":
                    entityReturned = dBHandler.GetBike(id);
                    break;
                case "Order":
                    entityReturned = dBHandler.GetOrder(id);
                    break;
                default:
                    break;
            }
            return entityReturned;
        }

        public void NewEntity(IPersistable entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(IPersistable entity)
        {
            throw new NotImplementedException();
        }
    }
}
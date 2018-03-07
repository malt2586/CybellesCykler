using System;

namespace Entities
{
    public class Order : IPersistable
    {
        // FIELDS
        private Bike bike;
        private Rentee rentee;
        private DateTime rentDate;
        private DateTime deliveryDate;
        private int id;

        // PROPERTIES
        public Bike Bike { get => bike; set => bike = value; }
        public Rentee Rentee { get => rentee; set => rentee = value; }
        public DateTime RentDate { get => rentDate; set => rentDate = value; }
        public DateTime DeliveryDate { get => deliveryDate; set => deliveryDate = value; }
        public int Id { get => id; set => id = value; }


        // CONSTRUCTORS
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bike"></param>
        /// <param name="rentee"></param>
        /// <param name="rentDate"></param>
        /// <param name="deliveryDate"></param>
        /// <param name="id"></param>
        public Order(Bike bike, Rentee rentee, DateTime rentDate, DateTime deliveryDate, int id)
        {
            Bike = bike;
            Rentee = rentee;
            RentDate = rentDate;
            DeliveryDate = deliveryDate;
            Id = id;
        }

        // METHODS
        /// <summary>
        /// Returns price as decimal based on number of days from order date to delivery date. (deliveryDate = end of rent period OR start of rent period ??)
        /// </summary>
        /// <returns></returns>
        public decimal GetPrice()
        {
            TimeSpan rentPeriod = (DeliveryDate - RentDate);
            return (Bike.PricePerDay * rentPeriod.Days);
        }

        /// <summary>
        /// Overrides ToString() method and returns a string containing information on attributes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Bike: {Bike.Kind}, Rentee: {Rentee.Name}, Rent Date: {RentDate.Date}, Delivery Date: {DeliveryDate.Date}, ID: {Id}";
        }
    }
}
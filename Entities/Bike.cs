namespace Entities
{
    public class Bike : IPersistable
    {
        // FIELDS
        private decimal pricePerDay;
        private string bikeDescription;
        private BikeKind kind;
        private int id;

        // PROPERTIES
        public decimal PricePerDay { get => pricePerDay; set => pricePerDay = value; }
        public string BikeDescription { get => bikeDescription; set => bikeDescription = value; }
        public BikeKind Kind { get => kind; set => kind = value; }
        public int Id { get => id; set => id = value; }

        // CONSTRUCTORS
        public Bike(decimal pricePerDay, string bikeDescription, BikeKind kind, int id)
        {
            PricePerDay = pricePerDay;
            BikeDescription = bikeDescription;
            Kind = kind;
            Id = id;
        }

        // METHODS
        public override string ToString()
        {
            return $"Kind: {Kind}, Description: {BikeDescription}, Price: {PricePerDay}, ID: {Id}";
        }
    }
}
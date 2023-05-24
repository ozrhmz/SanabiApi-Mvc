namespace App.Core.Models
{
    public class Adress : BaseEntity
    {
        public string Name { get; set; }
        public string Province { get; set; }
        public string Districte { get; set; }
        public string Neighbourhood { get; set; }
        public string Street { get; set; }
        public int BuildingNo { get; set; }
        public int PostCode { get; set; }
        public int ApartmentNumber { get; set; }
        public string adressDetails { get; set; }
        public string numberPhone { get; set; }

        public int CustomerId { get; set; }
        public Customer customer { get; set; }

        public ICollection<Order> orders { get; set; }
    }
}

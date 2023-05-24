namespace App.Core.Models
{
    public class Order : BaseEntity
    {
        public int AdressId { get; set; }
        public Adress adress { get; set; }

        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }

        public int OrderStatusId { get; set; }
        public OrderStatus orderStatus { get; set; }

        public int CustomerId { get; set; }
        public Customer customer { get; set; }

        public double amount { get; set; }

        public ICollection<OrderProduct> products { get; set; }
    }
}

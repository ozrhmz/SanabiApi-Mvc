namespace App.Core.Models
{
    public class OrderStatus : BaseEntity
    {
        public string StatusType { get; set; }

        public ICollection<Order> orders { get; set; }
    }
}

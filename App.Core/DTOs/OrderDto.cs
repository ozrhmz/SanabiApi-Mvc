using App.Core.Models;

namespace App.Core.DTOs
{
    public class OrderDto : BaseEntity
    {

        public int AdressId { get; set; }
        public int PaymentTypeId { get; set; }
        public int OrderStatusId { get; set; }
        public int CustomerId { get; set; }
        public double amount { get; set; }

        public ICollection<OrderProductDto> _Products { get; set; }
        public PaymentTypeDto paymentType { get; set; }
        public OrderStatusDto orderStatus { get; set; }
        public CustomerDto customer { get; set; }
    }
}

namespace App.Core.DTOs
{
    public class OrderUpdateDto
    {
        public int Id { get; set; }
        public int AdressId { get; set; }
        public int PaymentTypeId { get; set; }
        public int OrderStatusId { get; set; }
        public int CustomerId { get; set; }
        public double amount { get; set; }
    }
}

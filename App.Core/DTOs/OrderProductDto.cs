namespace App.Core.DTOs
{
    public class OrderProductDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }

        public ProductDto product { get; set; }
    }
}

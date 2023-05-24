namespace App.Core.DTOs
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}

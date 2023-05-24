namespace App.Core.DTOs
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public string CreateDate { get; set; }
    }
}

namespace App.Core.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }

        public ICollection<OrderProduct> orders { get; set; }
    }
}

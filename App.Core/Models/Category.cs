namespace App.Core.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public ICollection<Product> products { get; set; }
    }
}

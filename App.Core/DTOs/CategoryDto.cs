using App.Core.Models;

namespace App.Core.DTOs
{
    public class CategoryDto : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }
}

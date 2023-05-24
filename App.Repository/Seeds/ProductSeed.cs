using App.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id = 1,
                Name = "Okey Klasik 10'lu Condom",
                Description = "Rezervuar uçlu, vanilya kokulu, baş kısmı daha geniş şeffaf prezervatifler.",
                Price = 59,
                Image = "okeyklasik.png",
                CategoryId = 1,
                CreateDate = DateTime.Now.ToString()
            });
        }
    }
}

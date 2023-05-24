using App.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Repository.Seeds
{
    internal class AdressSeed : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {
            builder.HasData(new Adress
            {
                Id = 1,
                Name = "Ev",
                Province = "İstanbul",
                Districte = "Esenler",
                Neighbourhood = "Havaalanı Mahallesi",
                Street = "Garanti Caddesi",
                BuildingNo = 40,
                ApartmentNumber = 3,
                PostCode = 34230,
                adressDetails = "test",
                numberPhone = "0123456789",
                CustomerId = 1
            });
        }
    }
}

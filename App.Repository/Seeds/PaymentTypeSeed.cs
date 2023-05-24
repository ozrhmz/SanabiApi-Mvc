using App.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Repository.Seeds
{
    internal class PaymentTypeSeed : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            builder.HasData(new PaymentType
            {
                Id = 1,
                TypeName = "Kredi Kartı"
            });
        }
    }
}

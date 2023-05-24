using App.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Repository.Configurations
{
    internal class AdressConfiguration : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Province).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Districte).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Neighbourhood).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Street).IsRequired().HasMaxLength(50);
        }
    }
}

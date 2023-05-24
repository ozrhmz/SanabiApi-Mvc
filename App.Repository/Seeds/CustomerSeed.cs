using App.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Repository.Seeds
{
    internal class CustomerSeed : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(new Customer
            {
                Id = 1,
                Name = "Servet",
                Surname = "Sayar",
                Mail = "test@gmail.com",
                NumberPhone = "05123456789",
                BirtDate = "2001-9-04"
            });
        }
    }
}

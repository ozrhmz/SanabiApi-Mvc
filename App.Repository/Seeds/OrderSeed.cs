using App.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Repository.Seeds
{
    internal class OrderSeed : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(new Order
            {
                Id = 1,
                AdressId = 1,
                CreateDate = DateTime.Now.ToString(),
                OrderStatusId = 1,
                PaymentTypeId = 1,
                CustomerId = 1,
                amount = 59
            });
        }
    }
}

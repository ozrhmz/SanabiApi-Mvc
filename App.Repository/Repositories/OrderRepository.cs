using App.Core.Models;
using App.Core.Repositories;

namespace App.Repository.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task updateOrderStatusAsync(int orderId, int statusId)
        {
            var order = await GetByIdAsync(orderId);
            order.OrderStatusId = statusId;
            await _context.SaveChangesAsync();
        }
    }
}

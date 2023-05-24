using App.Core.Models;

namespace App.Core.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task updateOrderStatusAsync(int orderId, int statusId);
    }
}

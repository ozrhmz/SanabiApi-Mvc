using App.Core.Models;

namespace App.Core.Services
{
    public interface IOrderService : IService<Order>
    {
        public Task OrderStatusUpdateAsync(int orderId, int statusId);
    }
}

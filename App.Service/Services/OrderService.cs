using App.Core.Models;
using App.Core.Repositories;
using App.Core.Services;
using App.Core.UnitOfWorks;
using AutoMapper;

namespace App.Service.Services
{
    public class OrderService : Service<Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IGenericRepository<Order> repository, IMapper mapper, IOrderRepository orderRepository) : base(unitOfWork, repository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task OrderStatusUpdateAsync(int orderId, int statusId)
        {
            await _orderRepository.updateOrderStatusAsync(orderId, statusId);
        }
    }
}

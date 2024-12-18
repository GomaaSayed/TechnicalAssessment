

using Microsoft.EntityFrameworkCore;
using TechnicalAssessment.Contract;
using TechnicalAssessment.Contract.DTOs;
using TechnicalAssessment.Core.Entities;


namespace TechnicalAssessment.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _IOrderRepository;

        public OrderService(IOrderRepository IOrderRepository)
        {
            _IOrderRepository = IOrderRepository;
        }

        public async Task<string> AddOrderAsync(OrderDTO orderDto)
        {
            return await _IOrderRepository.AddOrderAsync(orderDto);
        }

        public async Task<IEnumerable<OrderItemsDTO>> GetAllOrderItemsAsync(Guid OrderId)
        {
            return await _IOrderRepository.GetAllOrderItemsAsync(OrderId);
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync(string UserId)
        {
            return await _IOrderRepository.GetAllOrdersAsync(UserId);
        }

        public Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }
    }
}

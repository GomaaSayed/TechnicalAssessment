using TechnicalAssessment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Contract.DTOs;


namespace TechnicalAssessment.Contract
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<string> AddOrderAsync(OrderDTO orderDto);
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();
        Task<IEnumerable<OrderItemsDTO>> GetAllOrderItemsAsync(Guid OrderId);

        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync(string UserId);
    }

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Contract.DTOs;
using TechnicalAssessment.Core.Entities;

namespace TechnicalAssessment.Contract
{
    public interface IOrderService
    {
        Task<string> AddOrderAsync(OrderDTO orderDto);
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();
        Task<IEnumerable<OrderItemsDTO>> GetAllOrderItemsAsync(Guid OrderId);
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync(string UserId);

    }
}

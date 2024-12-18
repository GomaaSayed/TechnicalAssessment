using Microsoft.EntityFrameworkCore;
using TechnicalAssessment.Contract;
using TechnicalAssessment.Contract.DTOs;
using TechnicalAssessment.Core.Entities;
using TechnicalAssessment.Infrastructure.Contexts;

namespace TechnicalAssessment.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(TechnicalAssessmentDbContext context) : base(context)
        {
        }



        public async Task<string> AddOrderAsync(OrderDTO order)
        {
            if (order == null) throw new ArgumentNullException(nameof(OrderDTO));
            if (order.OrderItems == null || !order.OrderItems.Any()) throw new ArgumentException("Order must contain at least one detail item.", nameof(order.OrderItems));
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // إنشاء الكيان Order من DTO
                var MappedOrder = new Order
                {
                    UserId = order.UserId,
                    OrderDate = DateTime.Now,
                    CreatedOn = DateTime.Now,
                    TotalAmount = order.TotalAmount,
                    CreateBy = order.CreateBy,
                };
                // تحويل عناصر الطلب من DTO إلى الكيان
                foreach (var itemDto in order.OrderItems)
                {
                    var orderItem = new OrderItem
                    {
                        OrderId = order.Id, // سيتم توليده تلقائيًا عند الإضافة
                        ProductId = itemDto.ProductId,
                        Quantity = itemDto.Quantity,
                        UnitPrice = itemDto.UnitPrice,
                        TotalPrice = itemDto.TotalPrice
                    };

                    _context.OrderItem.Add(orderItem);
                }
                await _context.Order.AddAsync(MappedOrder);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return "Your Order has been successfully saved. The Order number is {" + order.OrderNumber + "}. Thank you!"

;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("Error adding the Order. Transaction has been rolled back.", ex);
            }
        }
        public async Task<IEnumerable<OrderItemsDTO>> GetAllOrderItemsAsync(Guid OrderId)
        {

            var OrderItems = await _context.OrderItem.Where(s => s.OrderId == OrderId).ToListAsync();
            var Products = await _context.Product.ToListAsync();
            var OrderItemsMapped = from OItems in OrderItems
                                   join products in Products on OItems.ProductId equals products.Id
                                   select new OrderItemsDTO
                                   {
                                       Id = OItems.Id,
                                       OrderId = OItems.OrderId,
                                       Quantity = OItems.Quantity,
                                       ProductName = "",
                                       UnitPrice = OItems.UnitPrice,
                                       TotalPrice = OItems.TotalPrice,

                                   };

            return OrderItemsMapped;
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            var Orders = await _context.Order.ToListAsync();
            var OrderDTOs = Orders.Select(Order => new OrderDTO
            {
                Id = Order.Id,
                OrderNumber = Order.OrderNumber,
                OrderDate = Order.OrderDate,
                TotalAmount = Order.TotalAmount,
            });

            return OrderDTOs;
        }
        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync(string UserId)
        {
            var Orders = await _context.Order.ToListAsync();
            var OrderDTOs = Orders.Select(Order => new OrderDTO
            {
                Id = Order.Id,
                OrderNumber = Order.OrderNumber,
                OrderDate = Order.OrderDate,
                TotalAmount = Order.TotalAmount,
            });

            return OrderDTOs;
        }
    }
}

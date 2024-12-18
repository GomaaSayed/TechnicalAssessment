using Microsoft.EntityFrameworkCore;
using TechnicalAssessment.Contract;
using TechnicalAssessment.Contract.DTOs;
using TechnicalAssessment.Core.Entities;
using TechnicalAssessment.Infrastructure.Contexts;

namespace TechnicalAssessment.Infrastructure.Repositories
{
    // Repository class for managing orders, inheriting from the GenericRepository<Order> 
    // and implementing the IOrderRepository interface.
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        // Constructor that injects the database context and passes it to the base class constructor.
        public OrderRepository(TechnicalAssessmentDbContext context) : base(context)
        {
        }

        // Adds a new order to the database asynchronously.
        public async Task<string> AddOrderAsync(OrderDTO order)
        {
            // Check if the order DTO is null.
            if (order == null) throw new ArgumentNullException(nameof(OrderDTO));

            // Validate that the order contains at least one item.
            if (order.OrderItems == null || !order.OrderItems.Any())
                throw new ArgumentException("Order must contain at least one detail item.", nameof(order.OrderItems));

            // Start a database transaction for atomic operation.
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Map the DTO to the Order entity.
                var MappedOrder = new Order
                {
                    UserId = order.UserId,
                    OrderDate = DateTime.Now, // Set the order date to the current time.
                    CreatedOn = DateTime.Now, // Set creation time.
                    TotalAmount = order.TotalAmount, // Set the total amount of the order.
                    CreateBy = order.CreateBy // Set the user who created the order.
                };

                // Map each item in the order's items list to the OrderItem entity.
                foreach (var itemDto in order.OrderItems)
                {
                    var orderItem = new OrderItem
                    {
                        OrderId = order.Id, // Link the order item to the order.
                        ProductId = itemDto.ProductId, // Set the product ID.
                        Quantity = itemDto.Quantity, // Set the quantity.
                        UnitPrice = itemDto.UnitPrice, // Set the unit price.
                        TotalPrice = itemDto.TotalPrice // Set the total price.
                    };

                    // Add the order item to the database context.
                    _context.OrderItem.Add(orderItem);
                }

                // Add the order to the database context.
                await _context.Order.AddAsync(MappedOrder);

                // Save changes to the database.
                await _context.SaveChangesAsync();

                // Commit the transaction.
                await transaction.CommitAsync();

                // Return a success message with the order number.
                return "Your Order has been successfully saved. The Order number is {" + order.OrderNumber + "}. Thank you!";
            }
            catch (Exception ex)
            {
                // Roll back the transaction in case of an error.
                await transaction.RollbackAsync();
                throw new Exception("Error adding the Order. Transaction has been rolled back.", ex);
            }
        }

        // Retrieves all order items associated with a specific order ID.
        public async Task<IEnumerable<OrderItemsDTO>> GetAllOrderItemsAsync(Guid OrderId)
        {
            // Get the list of order items for the given order ID.
            var OrderItems = await _context.OrderItem.Where(s => s.OrderId == OrderId).ToListAsync();

            // Get the list of all products from the database.
            var Products = await _context.Product.ToListAsync();

            // Map the order items to DTOs, joining with product data for additional details.
            var OrderItemsMapped = from OItems in OrderItems
                                   join products in Products on OItems.ProductId equals products.Id
                                   select new OrderItemsDTO
                                   {
                                       Id = OItems.Id, // Set the order item ID.
                                       OrderId = OItems.OrderId, // Set the order ID.
                                       Quantity = OItems.Quantity, // Set the quantity.
                                       ProductName = "", // Placeholder for the product name.
                                       UnitPrice = OItems.UnitPrice, // Set the unit price.
                                       TotalPrice = OItems.TotalPrice // Set the total price.
                                   };

            return OrderItemsMapped; // Return the mapped DTOs.
        }

        // Retrieves all orders from the database.
        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            // Get the list of all orders.
            var Orders = await _context.Order.ToListAsync();

            // Map the orders to DTOs.
            var OrderDTOs = Orders.Select(Order => new OrderDTO
            {
                Id = Order.Id, // Set the order ID.
                OrderNumber = Order.OrderNumber, // Set the order number.
                OrderDate = Order.OrderDate, // Set the order date.
                TotalAmount = Order.TotalAmount // Set the total amount.
            });

            return OrderDTOs; // Return the mapped DTOs.
        }

        // Retrieves all orders for a specific user ID.
        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync(string UserId)
        {
            // Get the list of all orders.
            var Orders = await _context.Order.ToListAsync();

            // Map the orders to DTOs.
            var OrderDTOs = Orders.Select(Order => new OrderDTO
            {
                Id = Order.Id, // Set the order ID.
                OrderNumber = Order.OrderNumber, // Set the order number.
                OrderDate = Order.OrderDate, // Set the order date.
                TotalAmount = Order.TotalAmount // Set the total amount.
            });

            return OrderDTOs; // Return the mapped DTOs.
        }
    }

}

using Application.Common;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TechnicalAssessment.Application.Validators;
using TechnicalAssessment.Contract;
using TechnicalAssessment.Contract.DTOs;
using TechnicalAssessment.Core.Entities;

namespace API.Controllers
{
    // [Authorize] // Uncomment this to enable authentication and authorization for the controller
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _OrderService;

        // Constructor to inject the IOrderService dependency
        public OrderController(IOrderService OrderService)
        {
            _OrderService = OrderService;
        }

        /// <summary>
        /// Adds a new order along with its items.
        /// Validates the order and order items before processing.
        /// </summary>
        /// <param name="request">The order data transfer object (DTO) containing order details and items.</param>
        /// <returns>A response indicating success or validation errors.</returns>
        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrderAsync([FromBody] OrderDTO request)
        {
            // Validate the order using OrderValidator
            var OrderValidator = new OrderValidator();
            var OrderValidationResult = OrderValidator.Validate(request);

            // Validate each order item using OrderItemsValidator
            var itemValidator = new OrderItemsValidator();
            var itemValidationResults = new List<ValidationFailure>();

            if (request.OrderItems != null)
            {
                foreach (var item in request.OrderItems)
                {
                    var itemValidationResult = itemValidator.Validate(item);
                    itemValidationResults.AddRange(itemValidationResult.Errors); // Collect all validation errors
                }
            }

            // Combine all validation errors from order and items
            var allValidationErrors = OrderValidationResult.Errors.Concat(itemValidationResults).ToList();

            // If any validation errors exist, return a BadRequest response with error details
            if (allValidationErrors.Any())
            {
                return BadRequest(allValidationErrors);
            }

            // Add the order using the service and return success response
            var result = await _OrderService.AddOrderAsync(request);
            return Ok(new { Message = result });
        }

        /// <summary>
        /// Retrieves all orders from the system.
        /// </summary>
        /// <returns>A list of all orders.</returns>
        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var Orders = await _OrderService.GetAllOrdersAsync();
            return Ok(Orders);
        }

        /// <summary>
        /// Retrieves all orders for a specific user.
        /// </summary>
        /// <param name="UserId">The ID of the user whose orders are to be retrieved.</param>
        /// <returns>A list of orders associated with the specified user.</returns>
        [HttpGet("GetAllOrders/{UserId}")]
        public async Task<IActionResult> GetAllOrders(string UserId)
        {
            var Orders = await _OrderService.GetAllOrdersAsync(UserId);
            return Ok(Orders);
        }

        /// <summary>
        /// Retrieves detailed information about a specific order, including its items.
        /// </summary>
        /// <param name="OrderId">The ID of the order to retrieve details for.</param>
        /// <returns>Details of the specified order, including its items.</returns>
        [HttpGet("GetAllOrderDetails/{OrderId}")]
        public async Task<IActionResult> GetAllOrderDetails(Guid OrderId)
        {
            var OrderDetails = await _OrderService.GetAllOrderItemsAsync(OrderId);
            return Ok(OrderDetails);
        }
    }


}

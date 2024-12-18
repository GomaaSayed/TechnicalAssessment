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
   // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _OrderService;

        public OrderController(IOrderService OrderService)
        {
            _OrderService = OrderService;
        }
        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrderAsync([FromBody] OrderDTO request)
        {
            var OrderValidator = new OrderValidator();
            var OrderValidationResult = OrderValidator.Validate(request);

            var itemValidator = new OrderItemsValidator();
            var itemValidationResults = new List<ValidationFailure>();

            if (request.OrderItems != null)
            {
                foreach (var item in request.OrderItems)
                {
                    var itemValidationResult = itemValidator.Validate(item);
                    itemValidationResults.AddRange(itemValidationResult.Errors);
                }
            }
            var allValidationErrors = OrderValidationResult.Errors.Concat(itemValidationResults).ToList();
            if (allValidationErrors.Any())
            {
                return BadRequest(allValidationErrors);
            }
            var result = await _OrderService.AddOrderAsync(request);

            return Ok(new { Message = result });
        }

        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var Orders = await _OrderService.GetAllOrdersAsync();
            return Ok(Orders);
        }
        [HttpGet("GetAllOrders/{UserId}")]
        public async Task<IActionResult> GetAllOrders(string UserId)
        {
            var Orders = await _OrderService.GetAllOrdersAsync(UserId);
            return Ok(Orders);
        }
        [HttpGet("GetAllOrderDetails/{OrderId}")]
        public async Task<IActionResult> GetAllOrderDetails(Guid OrderId)
        {
            var OrderDetails = await _OrderService.GetAllOrderItemsAsync(OrderId);
            return Ok(OrderDetails);
        }
    }

}

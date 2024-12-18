using Application.Common;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TechnicalAssessment.Application.Services;
using TechnicalAssessment.Application.Validators;
using TechnicalAssessment.Contract;
using TechnicalAssessment.Contract.DTOs;
using TechnicalAssessment.Core.Entities;

namespace API.Controllers
{
    // [Authorize] // Uncomment to enable authorization for this controller
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;

        // Constructor to inject the IProductService dependency
        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        /// <summary>
        /// Adds a new product to the system.
        /// Validates the product data before processing.
        /// </summary>
        /// <param name="request">The product data transfer object (DTO) containing product details.</param>
        /// <returns>A response indicating success or validation errors.</returns>
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProductAsync([FromBody] ProductDTO request)
        {
            // Validate the product using ProductValidator
            var productValidator = new ProductValidator();
            var productValidationResult = productValidator.Validate(request);

            // If validation fails, return a BadRequest with error details
            if (!productValidationResult.IsValid)
            {
                return BadRequest(new
                {
                    Errors = productValidationResult.Errors.Select(e => new
                    {
                        Property = e.PropertyName,
                        Error = e.ErrorMessage
                    })
                });
            }

            // If validation passes, add the product
            var result = await _ProductService.AddProductAsync(request);
            return Ok(new { Message = result });
        }

        /// <summary>
        /// Updates an existing product in the system.
        /// Validates the product data before updating.
        /// </summary>
        /// <param name="request">The product data transfer object (DTO) containing updated product details.</param>
        /// <returns>A response indicating success or validation errors.</returns>
        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProductAsync([FromBody] ProductDTO request)
        {
            // Validate the product using ProductValidator
            var productValidator = new ProductValidator();
            var productValidationResult = productValidator.Validate(request);

            // If validation fails, return a BadRequest with error details
            if (!productValidationResult.IsValid)
            {
                return BadRequest(new
                {
                    Errors = productValidationResult.Errors.Select(e => new
                    {
                        Property = e.PropertyName,
                        Error = e.ErrorMessage
                    })
                });
            }

            // If validation passes, update the product
            var result = await _ProductService.UpdateProductAsync(request);
            return Ok(new { Message = result });
        }

        /// <summary>
        /// Retrieves all products in the system.
        /// </summary>
        /// <returns>A list of all products.</returns>
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var Products = await _ProductService.GetAllProductAsync();
            return Ok(Products);
        }

        /// <summary>
        /// Retrieves all visible products in the system.
        /// </summary>
        /// <returns>A list of visible products.</returns>
        [HttpGet("GetAllVisibleProduct")]
        public async Task<IActionResult> GetAllVisibleProductsAsync()
        {
            var Products = await _ProductService.GetAllVisibleProductsAsync();
            return Ok(Products);
        }

        /// <summary>
        /// Retrieves details of a product by its ID.
        /// </summary>
        /// <param name="ProductId">The ID of the product to retrieve.</param>
        /// <returns>Details of the specified product.</returns>
        [HttpGet("GetByProductId/{ProductId}")]
        public async Task<IActionResult> GetByProductId(Guid ProductId)
        {
            var ProductDetails = await _ProductService.GetByProductIdAsync(ProductId);
            return Ok(ProductDetails);
        }

        /// <summary>
        /// Deletes a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to delete.</param>
        /// <returns>A response indicating success or failure.</returns>
        [HttpDelete("DeleteProduct/{productId}")]
        public async Task<IActionResult> DeleteProductAsync(Guid productId)
        {
            if (productId == Guid.Empty)
            {
                return BadRequest(new { Message = "Invalid Product ID." });
            }

            var result = await _ProductService.DeleteProductAsync(productId);
            return Ok(new { Message = result });
        }

        /// <summary>
        /// Retrieves all product categories in the system.
        /// </summary>
        /// <returns>A list of all product categories.</returns>
        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var Products = await _ProductService.GetAllCategoryAsync();
            return Ok(Products);
        }
    }


}

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
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProductAsync([FromBody] ProductDTO request)
        {
            // التحقق من صحة البيانات باستخدام ProductValidator
            var productValidator = new ProductValidator();
            var productValidationResult = productValidator.Validate(request);
            // إذا كان هناك أخطاء في التحقق
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

            // إضافة المنتج إذا كانت البيانات صالحة
            var result = await _ProductService.AddProductAsync(request);

            return Ok(new { Message = result });
        }
        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProductAsync([FromBody] ProductDTO request)
        {
            // التحقق من صحة البيانات باستخدام ProductValidator
            var productValidator = new ProductValidator();
            var productValidationResult = productValidator.Validate(request);
            // إذا كان هناك أخطاء في التحقق
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
            // إضافة المنتج إذا كانت البيانات صالحة
            var result = await _ProductService.UpdateProductAsync(request);
            return Ok(new { Message = result });
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var Products = await _ProductService.GetAllProductAsync();
            return Ok(Products);
        }
        [HttpGet("GetAllVisibleProduct")]
        public async Task<IActionResult> GetAllVisibleProductsAsync()
        {
            var Products = await _ProductService.GetAllVisibleProductsAsync();
            return Ok(Products);
        }
        [HttpGet("GetByProductId/{ProductId}")]
        public async Task<IActionResult> GetByProductId(Guid ProductId)
        {
            var ProductDetails = await _ProductService.GetByProductIdAsync(ProductId);
            return Ok(ProductDetails);
        }
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
        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var Products = await _ProductService.GetAllCategoryAsync();
            return Ok(Products);
        }
    }

}

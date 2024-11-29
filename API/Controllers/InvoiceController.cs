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
    [Authorize] 
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        [HttpPost("AddInvoice")]
        public async Task<IActionResult> AddInvoiceAsync([FromBody] InvoiceDTO request)
        {
            var invoiceValidator = new InvoiceValidator();
            var invoiceValidationResult = invoiceValidator.Validate(request);

            var itemValidator = new InvoiceDetailsValidator(); 
            var itemValidationResults = new List<ValidationFailure>();

            if (request.Items != null)
            {
                foreach (var item in request.Items)
                {
                    var itemValidationResult = itemValidator.Validate(item);
                    itemValidationResults.AddRange(itemValidationResult.Errors);
                }
            }
            var allValidationErrors = invoiceValidationResult.Errors.Concat(itemValidationResults).ToList();
            if (allValidationErrors.Any())
            {
                return BadRequest(allValidationErrors);
            }
            var result = await _invoiceService.AddInvoiceAsync( request);

            return Ok(new { Message = result });
        }

        [HttpGet("GetAllInvoices")]
        public async Task<IActionResult> GetAllInvoices()
        {
            var invoices = await _invoiceService.GetAllInvoiceAsync();
            return Ok(invoices);
        }
        [HttpGet("GetAllInvoiceDetails/{invoiceId}")]
        public async Task<IActionResult> GetAllInvoiceDetails(Guid invoiceId)
        {
            var invoiceDetails = await _invoiceService.GetAllInvoiceDetailsAsync(invoiceId);
            return Ok(invoiceDetails);
        }
    }

}

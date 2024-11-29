using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Core.Entities;
using TechnicalAssessment.Contract.DTOs;

namespace TechnicalAssessment.Application.Validators
{
    public class InvoiceDetailsValidator : AbstractValidator<InvoiceDetailsDTO>
    {
        public InvoiceDetailsValidator()
        {
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0.").NotEmpty().WithMessage("Price is required."); ;
            RuleFor(x => x.Total).GreaterThan(0).WithMessage("Total must be greater than 0.").NotEmpty().WithMessage("Total is required."); ;
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.").NotEmpty().WithMessage("Quantity is required."); ;
            RuleFor(x => x.ItemId).GreaterThan(0).WithMessage("ItemId must be greater than 0.").NotEmpty().WithMessage("ItemId is required."); ;

        }
    }
}

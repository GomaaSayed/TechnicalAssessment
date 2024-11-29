using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Contract.DTOs;

namespace TechnicalAssessment.Application.Validators
{
    public class InvoiceValidator : AbstractValidator<InvoiceDTO>
    {
        public InvoiceValidator()
        {
          

            RuleFor(x => x.InvoiceDate)
                .NotEmpty().WithMessage("Invoice date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Invoice date cannot be in the future.");

            RuleFor(x => x.TotalAmount)
                .GreaterThan(0).WithMessage("Total amount must be greater than 0.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

        }
    }
}

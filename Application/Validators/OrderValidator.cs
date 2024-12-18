using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Contract.DTOs;

namespace TechnicalAssessment.Application.Validators
{
    public class OrderValidator : AbstractValidator<OrderDTO>
    {
        public OrderValidator()
        {
            RuleFor(x => x.OrderDate)
                .NotEmpty().WithMessage("Order date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Invoice date cannot be in the future.");

            RuleFor(x => x.TotalAmount)
                .GreaterThan(0).WithMessage("Total amount must be greater than 0.");
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required.");

        }
    }
}

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


    public class OrderItemsValidator : AbstractValidator<OrderItemsDTO>
    {
        public OrderItemsValidator()
        {
            // التحقق من UnitPrice
            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("Unit Price must be greater than 0.")
                .NotEmpty().WithMessage("Unit Price is required.");

            // التحقق من TotalPrice
            RuleFor(x => x.TotalPrice)
                .GreaterThan(0).WithMessage("Total Price must be greater than 0.")
                .NotEmpty().WithMessage("Total Price is required.");

            // التحقق من Quantity
            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.")
                .NotEmpty().WithMessage("Quantity is required.");

            // التحقق من ProductId
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId is required.");      
        }
    }

}

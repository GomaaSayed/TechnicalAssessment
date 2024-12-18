using TechnicalAssessment.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using TechnicalAssessment.Contract.Common;

namespace TechnicalAssessment.Contract.DTOs
{
    public class OrderItemsDTO : BaseDTO
    {
        public Guid OrderId { get; set; } // معرف الطلب
        public int OrderNumber { get; set; }
        public Guid ProductId { get; set; } // معرف المنتج
        public string ProductName { get; set; } // معرف المنتج
        public int Quantity { get; set; } // الكمية المطلوبة
        public decimal UnitPrice { get; set; } // سعر الوحدة
        public decimal TotalPrice { get; set; }


    }
}

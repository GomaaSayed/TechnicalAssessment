using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TechnicalAssessment.Core.Common;

namespace TechnicalAssessment.Core.Entities
{
    public class OrderItem : BaseEntity
    {
        [ForeignKey("OrderId")]
        public Guid OrderId { get; set; } // معرف الطلب
        [ForeignKey("ProductId")]
        public Guid ProductId { get; set; } // معرف المنتج
        public int Quantity { get; set; } // الكمية المطلوبة
        public decimal UnitPrice { get; set; } // سعر الوحدة
        public decimal TotalPrice { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}

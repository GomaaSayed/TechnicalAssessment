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
    public class Order : BaseEntity
    {
        public int OrderNumber { get; set; } // المعرف الأساسي للطلب
        [ForeignKey("UserId")]
        public string UserId { get; set; } // معرف العميل
        public DateTime OrderDate { get; set; } = DateTime.Now; // تاريخ الطلب
        public decimal TotalAmount { get; set; } 
        public virtual User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}

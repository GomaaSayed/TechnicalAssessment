using TechnicalAssessment.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Contract.Common;

namespace TechnicalAssessment.Contract.DTOs
{
    public class OrderDTO : BaseDTO
    {
        public int OrderNumber { get; set; } // المعرف الأساسي للطلب
        public string UserId { get; set; } // معرف العميل
        public string UserName { get; set; } // معرف العميل
        public DateTime OrderDate { get; set; } = DateTime.Now; // تاريخ الطلب
        public decimal TotalAmount { get; set; }
        public ICollection<OrderItemsDTO> OrderItems { get; set; }
    }
}

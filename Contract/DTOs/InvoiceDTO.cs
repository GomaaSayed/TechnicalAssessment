using TechnicalAssessment.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssessment.Contract.DTOs
{
    public class InvoiceDTO
    {
        public Guid Id { get; set; }
        public int InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Description { get; set; }
        public List<InvoiceDetailsDTO> Items { get; set; }
    }
}

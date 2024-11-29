using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TechnicalAssessment.Core.Entities
{
    public class Invoice
    {
        [Key]
        public Guid Id { get; set; }
        public int InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Description { get; set; }
        public List<InvoiceDetails> Items { get; set; }
       

    }
}

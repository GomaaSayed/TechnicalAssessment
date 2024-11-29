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
    public class InvoiceDetails
    {
        [Key]
        public Guid Id { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        [ForeignKey("InvoiceId")]
        public Guid InvoiceId { get; set; }
        [JsonIgnore]
        public Invoice Invoice { get; set; }

    }
}

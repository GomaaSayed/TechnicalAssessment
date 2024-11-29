using TechnicalAssessment.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace TechnicalAssessment.Contract.DTOs
{
    public class InvoiceDetailsDTO
    {
        public Guid Id { get; set; }
        public int ItemId { get; set; }
        [JsonIgnore]
        public string ItemName { get; set; } = "";
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public Guid InvoiceId { get; set; }
       
    }
}

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
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsVisible { get; set; }
        public string ImageUrl { get; set; }
        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}

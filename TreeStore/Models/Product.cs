using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TreeStore.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountRate { get; set; }
        public string ImagePath { get; set; }
        public virtual Campaign Campaign { get; set; }
        public long? CampaignId { get; set; }
        public virtual Category Category { get; set; }
    }
}

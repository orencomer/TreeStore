using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TreeStore.Models
{
    public class Product:BaseEntity
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }
        public string CompanyLink { get; set; }
        public virtual ICollection<ProductCampaign> ProductCampaign { get; set; }
        public virtual Category Category { get; set; }
        public long CategoryId { get; set; }
    }
}

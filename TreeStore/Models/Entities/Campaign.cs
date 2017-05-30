using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeStore.Models
{
    public class Campaign:BaseEntity
    {
        public string Description { get; set; }
        public string Slogan { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<ProductCampaign> ProductCampaign { get; set; }
        public virtual ICollection<CategoryCampaign> CategoryCampaign { get; set; }
    }
}

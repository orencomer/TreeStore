using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TreeStore.Models
{
    public class Category:BaseEntity
    {
        public string Description { get; set; }
        public long? CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; }
        public long? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}

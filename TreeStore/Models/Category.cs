using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeStore.Models
{
    public class Category
    {
        public string name { get; set; }
        public string description { get; set; }
        public virtual Campaign Campaing { get; set; }
        public long CampaingId { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeStore.Models
{
    public class Campaign
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slogan { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ImagePath { get; set; }
    }
}

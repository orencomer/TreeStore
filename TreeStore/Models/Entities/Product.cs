﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TreeStore.Models
{
    public class Product:BaseEntity
    {
        
        [Display(Name ="Açıklama")]
        public string Description { get; set; }
        
        [Display(Name = "Ücret")]
        public decimal Price { get; set; }
        
        [Display(Name = "İndirimli Fiyat")]
        public decimal DiscountPrice { get; set; }
        
        [Display(Name = "Resim Kaynağı")]
        public string ImagePath { get; set; }
        
        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }
        
        [Display(Name = "Kampanya Linki")]
        public string CompanyLink { get; set; }
        public virtual ICollection<ProductCampaign> ProductCampaign { get; set; }
        [ForeignKey("CategoryId")]
        [Display(Name = "Kategori")]
        public virtual Category Category { get; set; }
        [Display(Name = "Kategori Id")]
        public long? CategoryId { get; set; }
    }
}

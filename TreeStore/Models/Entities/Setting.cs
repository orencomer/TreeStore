﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TreeStore.Models.Entities
{
    public class Setting:BaseEntity
    {
        [Display(Name = "Hoşgeldiniz Metni")]
        public string WelcomeText { get; set; }
        [Display(Name = "Üyelik Sözleşmesi")]
        public string MembershipAgreement { get; set; }
        [Display(Name = "SEO Başlık")]
        public string SeoTitle { get; set; }
        [Display(Name = "SEO Açıklama")]
        public string SeoDescription { get; set; }
        [Display(Name = "Anahtar Kelimeler")]
        public string SeoKeywords { get; set; }
        [Display(Name = "Hakkında")]
        public string About { get; set; }
        [Display(Name = "Gizlilik Prensipleri")]
        public string PrivacyPolicy { get; set; }
        [Display(Name = "Kullanım Koşulları")]
        public string TermsOfUse { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeStore.Models.Entities;

namespace TreeStore.Data
{
    public static class ApplicationDbContextSeed
    {
        public static void Seed(this ApplicationDbContext context)
        {
            context.Database.Migrate();
            AddSettings(context);
        }

        public static void AddSettings(ApplicationDbContext context)
        {
            var s = new Setting();
            s.SeoTitle = "İndirimli Ürünler Sitesi";
            s.SeoDescription = s.SeoTitle;
            s.SeoKeywords = "indirim, discount, alışveriş";
            s.Address = "Kadıköy";
            s.Phone = "02122121212";
            s.Fax = "02122122121";
            s.Mail = "ornek@mail.com";
            s.WelcomeText = "Hoşgeldiniz";
            context.Settings.Add(s);
            context.SaveChanges();
        }
    }
}

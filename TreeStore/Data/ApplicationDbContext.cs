using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TreeStore.Models;
using TreeStore.Models.EntityBuilders;

namespace TreeStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCampaign> ProductCampaigns { get; set; }
        public DbSet<CategoryCampaign> CategoryCampaigns { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            new CategoryBuilder(builder.Entity<Category>());
            new CategoryCampaignBuilder(builder.Entity<CategoryCampaign>());
            new ProductCampaignBuilder(builder.Entity<ProductCampaign>());
            new ProductBuilder(builder.Entity<Product>());
        }
    }
}

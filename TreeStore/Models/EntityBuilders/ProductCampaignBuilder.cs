using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeStore.Models.EntityBuilders
{
    public class ProductCampaignBuilder
    {
        public ProductCampaignBuilder(EntityTypeBuilder<ProductCampaign> entityBuilder)
        {

            entityBuilder.HasKey(pc => new { pc.CampaignId, pc.ProductId });
            entityBuilder.HasOne(pc => pc.Campaign)
                .WithMany(c => c.ProductCampaign)
                .HasForeignKey(pc => pc.CampaignId);
            entityBuilder.HasOne(pc => pc.Product)
                .WithMany(p => p.Campaign.ProductCampaign) // p.ProductCampaign idi p.Campaign.ProductCampaign haline getirildi.
                .HasForeignKey(pc => pc.ProductId);

        }
    }
}

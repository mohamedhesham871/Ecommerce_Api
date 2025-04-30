using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.Config.ProductConfig
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.Property(p =>p.Price).HasColumnType("decimal(10,3)");
            builder.HasOne(p => p.ProductBrand).WithMany().HasForeignKey(p => p.BrandID);
            builder.HasOne(p => p.ProductType).WithMany().HasForeignKey(p => p.ProductTypeId);
        }
    }
    
}

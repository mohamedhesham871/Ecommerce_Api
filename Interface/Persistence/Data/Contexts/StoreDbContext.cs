using Domain.Models.productMoulde;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.Contexts
{
    public  class StoreDbContext(DbContextOptions<StoreDbContext> options): DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        
        DbSet<Product> Products { get; set; }
        DbSet<ProductBrand> ProductBrands { get; set; }
        DbSet<ProductType> ProductTypes { get; set; }

       
    }
   
}

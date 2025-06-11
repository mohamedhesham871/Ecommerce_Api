using Domain.Contract;
using Domain.Models.productMoulde;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Formats.Tar;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence
{
    public class DbInitializer(StoreDbContext _storeDbContext) : IDbInitializer
    {
        public async Task InitializeAsync()
        {
            // Initialize the database with default data
            // This method should be called at application startup

            #region In Deployment 

            //Using  =>  GetPendingMigrationsAsync

            //if (!(await  _storeDbContext.Database.GetPendingMigrationsAsync()).Any())
            //{
            //    // Database need to initialize
            //   await _storeDbContext.Database.MigrateAsync();
            //    return;
            //} 
            #endregion

            #region In Development
            //For Brands
            try
            {

                if (!_storeDbContext.Set<ProductBrand>().Any())
                {
                    var data = await File.ReadAllTextAsync(@"..\Interface\Persistence\DataSeeding\brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(data);
                    if (brands is not null && brands.Any())
                    {
                        await _storeDbContext.Set<ProductBrand>().AddRangeAsync(brands);
                    }
                    await _storeDbContext.SaveChangesAsync();
                }
                //For ProductType
                if (!_storeDbContext.Set<ProductType>().Any())
                {
                    var data = await File.ReadAllTextAsync(@"..\Interface\Persistence\DataSeeding\types.json");

                    var Types = JsonSerializer.Deserialize<List<ProductType>>(data);
                    if (Types is not null && Types.Any())
                    {
                        await _storeDbContext.Set<ProductType>().AddRangeAsync(Types);
                    }
                    await _storeDbContext.SaveChangesAsync();
                }
                //for Products 
                if (!_storeDbContext.Set<Product>().Any())
                {
                    var data = await File.ReadAllTextAsync(@"..\Interface\Persistence\DataSeeding\products.json");

                    var Product = JsonSerializer.Deserialize<List<Product>>(data);
                    if (Product is not null && Product.Any())
                    {
                        await _storeDbContext.Set<Product>().AddRangeAsync(Product);
                    }
                    await _storeDbContext.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion
        }
    }
   
}

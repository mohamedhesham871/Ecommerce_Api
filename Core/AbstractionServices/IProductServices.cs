using Shared.Dtos.Prodcut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionServices
{
    public interface IProductServices
    {
        //Get All products
        Task<IEnumerable<ProdcutResponse>> GetAllProductsAsync();
        //Get Product With Id
        Task<ProdcutResponse> GetProductByIdAsync(int id);
        //Get All Brands
        Task<IEnumerable<BrandResponse>> GetAllBrandsAsync();
        //Get All Types
        Task<IEnumerable<TypeResponse>> GetAllTypesAsync();
    }
}

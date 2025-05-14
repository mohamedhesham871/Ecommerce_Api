using AbstractionServices;
using Domain.Contract;
using Shared.Dtos.Prodcut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Models;
namespace Services

{
     public class ProductServices(IUnitOfwork _unitOfwork, IMapper mapper) : IProductServices
    {

        public async Task<IEnumerable<BrandResponse>> GetAllBrandsAsync()
        {
            var Repo = _unitOfwork.GetRepository<ProductBrand,int>();
            var brands = await Repo.GetAllAsync();
            var BrandResult = mapper.Map<IEnumerable<BrandResponse>>(brands);

            return BrandResult;
        }

        public async  Task<IEnumerable<TypeResponse>> GetAllTypesAsync()
        {
            var Repo = _unitOfwork.GetRepository<ProductType, int>();
            var types = await Repo.GetAllAsync();
            var TypesResult = mapper.Map<IEnumerable<TypeResponse>>(types);

            return TypesResult;
        }
        public async Task<IEnumerable<ProdcutResponse>> GetAllProductsAsync()
        {
            var  Repo= _unitOfwork.GetRepository<Product, int>();
            var products = await Repo.GetAllAsync();

            var ProductResult = mapper.Map<IEnumerable<ProdcutResponse>>(products);

            return ProductResult;
        }

       

        public async Task<ProdcutResponse> GetProductByIdAsync(int id)
        {
           var Product=_unitOfwork.GetRepository<Product, int>().GetByIdAsync;

          return mapper.Map<ProdcutResponse>(Product);

        }
    }
}

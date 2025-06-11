using AbstractionServices;
using Domain.Contract;
using Shared.Dtos.Prodcut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Services.Specifications;
using Shared.Enums;
using Shared;
using Domain.Exceptions;
using Domain.Models.productMoulde;
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
        public async Task<PaginationResponse<ProdcutResponse>> GetAllProductsAsync(ProductFilteration productFilteration)
        {
            // for Specification
            var spec = new  ProdcutSpecificationWithBrandAndType( productFilteration); //With no Filters
            var Repo = _unitOfwork.GetRepository<Product, int>();
            var products = await Repo.GetAllAsync(spec);
            var SpecCount = new ProductSpecificationCount(productFilteration);
            var ProductCount =await _unitOfwork.GetRepository<Product,int>().TotalCountQueryAsync(SpecCount);
            var prodRes = mapper.Map<IEnumerable<ProdcutResponse>>(products);
            var paginationMetaData = new PaginationResponse<ProdcutResponse>()//Constructor
            {
                  PageSize= productFilteration.PageSize,
                  PageIndex= productFilteration.PageIndex,
                  TotalCount= ProductCount,
                Data = prodRes,
            };
            return paginationMetaData;
        }

       

        public async Task<ProdcutResponse> GetProductByIdAsync(int id)
        {
            var spec = new ProdcutSpecificationWithBrandAndType(id);// Filter With Id
            var Product=await  _unitOfwork.GetRepository<Product, int>().GetByIdAsync(spec);
            if (Product == null)
            {
                throw new ProductNotFoundResponse(id);
            }

            return  mapper.Map<ProdcutResponse>(Product);

        }
    }
}

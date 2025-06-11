using Domain.Models.productMoulde;
using Shared.Dtos.Prodcut;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    // Look at this class As Set Static Query for Product Like include<ProductBrand> and include<ProductType>
    // Have Two Funtion one For GEt all Product and Other for Getting Specific Id  
    public class ProdcutSpecificationWithBrandAndType:BaseSpecification<Product>
    {
        //Get All Product With Brand And Type With Id
        public ProdcutSpecificationWithBrandAndType(int id) : base(x => x.id == id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
        //Get All Product With Brand And Type
        //Chain on Base Class{Criteria}
        public ProdcutSpecificationWithBrandAndType(ProductFilteration productFilterationg) : base(Criteria(productFilterationg)) //Why i make not (brandId.HasValue) Because i in OR table to check {pro.BrandID==brandId}

        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            //Sorting
            Sorting(productFilterationg);
            //Pagination
            if (productFilterationg.PageSize > 0 && productFilterationg.PageIndex > 0)
            {
                Applypagination(productFilterationg.PageIndex, productFilterationg.PageSize);
            }

        }
        //Method for Critera 
        private static Expression<Func<Product, bool>> Criteria(ProductFilteration productFilteration)
        {
            return (pro =>
             (!productFilteration.BrandId.HasValue || pro.BrandID == productFilteration.BrandId) &&
             (!productFilteration.TypeId.HasValue || pro.ProductTypeId == productFilteration.TypeId) &&
             (string.IsNullOrWhiteSpace(productFilteration.Search)||pro.Name.ToLower().Contains(productFilteration.Search.ToLower())));
        }
        //Method for Sorting
        private void  Sorting(ProductFilteration productFilteration)
        {
           switch (productFilteration.sorting)
            {
                case SortingExpression.NameAscending:
                    AddOrderBy(x => x.Name);
                    break;
                case SortingExpression.NameDescending:
                    AddOrderByDesc(x => x.Name);
                    break;
                case SortingExpression.PriceAscending:
                    AddOrderBy(x => x.Price);
                    break;
                case SortingExpression.PriceDescending:
                    AddOrderByDesc(x => x.Price);
                    break;
            }
        }
    }

}

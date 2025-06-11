using Domain.Models.productMoulde;
using Shared.Dtos.Prodcut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    public class ProductSpecificationCount(ProductFilteration productFilteration): BaseSpecification<Product>(Criteria(productFilteration))
    {
        private static Expression<Func<Product, bool>> Criteria(ProductFilteration productFilteration)
        {
            return (pro =>
             (!productFilteration.BrandId.HasValue || pro.BrandID == productFilteration.BrandId) &&
             (!productFilteration.TypeId.HasValue || pro.ProductTypeId == productFilteration.TypeId) &&
             (string.IsNullOrWhiteSpace(productFilteration.Search) || pro.Name.ToLower().Contains(productFilteration.Search.ToLower())));
        }
    }
}

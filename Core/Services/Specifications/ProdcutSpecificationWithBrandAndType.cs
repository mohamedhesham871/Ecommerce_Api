using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    // Look at this class As Set Static Query for Product Like include<ProductBrand> and include<ProductType>
    // Have Two Funtion one For GEt all Product and Other for Getting Specific Id  
    public class ProdcutSpecificationWithBrandAndType:SpecificationProduct<Product>
    {
        //Get All Product With Brand And Type With Id
        public ProdcutSpecificationWithBrandAndType(int id) : base(x => x.id == id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
        //Get All Product With Brand And Type
        public ProdcutSpecificationWithBrandAndType() : base(null)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Product : BaseEntity<int>
    {
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public string PictureUrl { get; set; } = default!;
       
        #region Relation With Brand table 
        public int BrandID { set; get; }
        //nae the navigation property to Brand table 
        public ProductBrand ProductBrand { get; set; } = default!;
        #endregion

        #region Relation With Productype Table 
        public int ProductTypeId { set; get; }
        //nae the navigation property to ProductType table
        public ProductType ProductType { get; set; } = default!;
        #endregion



    }


}

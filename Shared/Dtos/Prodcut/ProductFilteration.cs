using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Prodcut
{
    public  class ProductFilteration
    {
        public  int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public   SortingExpression? sorting { get; set; }
        public string? Search { get; set; }

        private const int defaultPageSize = 5; //Default value
        private const int maxPageSize = 10; //Max value

        private int pageSize { get; set; }
        public  int PageSize
        {
            get { return pageSize; } 
            set
            {
                if (value > 0&&value<= maxPageSize) pageSize = value;
                else pageSize =defaultPageSize;
            }
        }
      
        public int PageIndex { get; set; } = 1;
    }
}

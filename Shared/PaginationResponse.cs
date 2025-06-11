using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public  class PaginationResponse<T> where T : class
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; }
        public IEnumerable<T> Data { get; set; }//Items 

        //public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        //public bool HasPrevious => PageIndex > 1;
        //public bool HasNext => PageIndex < TotalPages;

        ///..constructor 
        //public PaginationResponse(int pageIndex, int pageSize, int totalCount)
        //{
        //    PageIndex = pageIndex;
        //    PageSize = pageSize;
        //    TotalCount = totalCount;
        //}
    }
}

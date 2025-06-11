using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ProductNotFoundResponse(int id) : NotFoundException($"Product With {id} is not Found ")
    {
        
        
    }
}

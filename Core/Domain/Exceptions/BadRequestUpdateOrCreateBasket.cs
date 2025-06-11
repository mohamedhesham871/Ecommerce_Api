using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public  class BadRequestUpdateOrCreateBasket(string id) : BadRequestException($"Basket with ID '{id}' cannot be updated or created due to invalid data or state.")
    {
    }
}

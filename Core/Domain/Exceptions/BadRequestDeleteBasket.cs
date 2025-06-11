using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public  class BadRequestDeleteBasket(): BadRequestException("Bad Request Happen While Deleteing this Basket !!")
    {

    }
}

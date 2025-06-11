using Domain.Models.BasketModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract
{
    public interface IBasketRepo
    {
        Task<CustomerBasket> GetBasketAsync(string basketId);
        Task<CustomerBasket> UpdateOrCreateBasketAsync(CustomerBasket basket,TimeSpan? TimeToLive=null);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}

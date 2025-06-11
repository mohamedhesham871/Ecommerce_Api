using Shared.Dtos.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionServices
{
    public interface IBasketServices
    {
        public Task<BasketDto?> GetBasketAsync(string basketId);
        public Task<BasketDto?> UpdateOrCreateBasketAsync(BasketDto basket, TimeSpan? TimeToLive = null);
        public Task<bool> DeleteBasketAsync(string basketId);
    }
}

using Domain.Contract;
using Domain.Models.BasketModule;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using System.Text.Json;

namespace Persistence.Repo
{
    public class BasketRepo(IConnectionMultiplexer connection) : IBasketRepo
    {
        //Injecytion of Redis connection 
        //make Register of this Connection [Redis]
        private readonly IDatabase _database = connection.GetDatabase();

        public  async Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            var basket = await _database.StringGetAsync(basketId);//this is Json Not Class 
            if (basket.IsNullOrEmpty)
            {
                return null!; 
            }
            //Deserialize the Json to Class
            var result =JsonSerializer.Deserialize<CustomerBasket>(basket!);
            if (result == null)
            {
                return null!; //if deserialization fails, return null
            }

            return result!;
        }

        public  async Task<CustomerBasket?> UpdateOrCreateBasketAsync(CustomerBasket basket, TimeSpan? TimeToLive = null)
        {
            //1- convert class to JSon File   [this is Value ]
            var basketJson = JsonSerializer.Serialize(basket);
            if (basketJson == null) return null;
            //2- Save the Json to Redis             key        valut         time it be store 
            var created = await _database.StringSetAsync(basket.Id, basketJson, TimeToLive ?? TimeSpan.FromDays(30));
            return created ? await GetBasketAsync(basket.Id): null; //if created is true return the basket else return null

        }


        public Task<bool> DeleteBasketAsync(string basketId)
        {
          return _database.KeyDeleteAsync(basketId); //delete the basket by key
        }

    }
}

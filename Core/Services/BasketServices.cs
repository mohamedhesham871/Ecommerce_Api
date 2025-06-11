using AbstractionServices;
using AutoMapper;
using Domain.Contract;
using Domain.Exceptions;
using Domain.Models.BasketModule;
using Shared.Dtos.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services
{
    public class BasketServices(IBasketRepo basketRepo,IMapper mapper) : IBasketServices
    {
        private readonly IBasketRepo basketRepo = basketRepo;

        public async Task<BasketDto?> GetBasketAsync(string basketId)
        {
            var basket = await basketRepo.GetBasketAsync(basketId);
            if (basket is null)
            {
                throw new BasketNotFoundException(basketId);
            } 
            //convet from CustomerBasket to BasketDto
            var result =mapper.Map<BasketDto>(basket);
           
            return result;
        }

        public async Task<BasketDto?> UpdateOrCreateBasketAsync(BasketDto basket, TimeSpan? TimeToLive = null)
        {
            // 1- convert from BasketDto to CustomerBasket
            var customerBasket =  mapper.Map<CustomerBasket>(basket);
            // 2- call the repo to update or create
            var updatedOrCreateBasket = await basketRepo.UpdateOrCreateBasketAsync(customerBasket, TimeToLive);
            if (updatedOrCreateBasket is null) //Bad Request exception
            {
                    throw new BadRequestUpdateOrCreateBasket(basket.Id);
            }
            // 3- convert from CustomerBasket to BasketDto
            var result = mapper.Map<BasketDto>(updatedOrCreateBasket);
            return result;

        }
        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            var IsDeleted = await basketRepo.DeleteBasketAsync(basketId);
          
            return IsDeleted? true :throw new BadRequestDeleteBasket ();

        }
    }
}

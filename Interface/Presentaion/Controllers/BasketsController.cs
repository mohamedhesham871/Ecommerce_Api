using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractionServices;
using Shared.Dtos.Basket;
namespace Presentaion.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public  class BasketsController(IServicesManager _servicesManager):ControllerBase
    {
        private readonly IServicesManager servicesManager = _servicesManager;

        [HttpGet]
        public async Task<IActionResult> GetBasket(string Id)
        {
            var basket = await servicesManager.BasketServices.GetBasketAsync(Id);
            // Will Handle Error in Services 
            return Ok(basket);

        }
        [HttpPost]
        public async  Task<IActionResult> UpdateOrCreateBasket(BasketDto basket)
        {
           
            var updatedBasket = await servicesManager.BasketServices.UpdateOrCreateBasketAsync(basket);
            return Ok(updatedBasket);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(string Id)
        {
            var isDeleted = await servicesManager.BasketServices.DeleteBasketAsync(Id);
            
            return NoContent(); // NoContent is 204 status code, which means the request was successful but there is no content to return
        }
    }
}

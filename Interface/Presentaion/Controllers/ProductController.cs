using AbstractionServices;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Prodcut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentaion.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController (IServicesManager _servicesManager):ControllerBase
    {
        // Get All Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdcutResponse>>> GetAllProducts()
        {
            var products= await _servicesManager.ProductServices.GetAllProductsAsync();

            return Ok(products);
        }
        // Get Product By Id
        [HttpGet("{id:int}")]  //BaseUrl/Product/{id}
        public async Task<ActionResult<ProdcutResponse>> GetProductById(int id)
        {
            var result = _servicesManager.ProductServices.GetProductByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        // Get All Brands
        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<BrandResponse>>> GetAllBrands()
        {
            var brands = await _servicesManager.ProductServices.GetAllBrandsAsync();

            return Ok(brands);
        }
        // Get All Types
        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<TypeResponse>>> GetAllTypes()
        {
            var types = await _servicesManager.ProductServices.GetAllTypesAsync();

            return Ok(types);
        }
    }
}

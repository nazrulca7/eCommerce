using eCommerce.Api.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eCommerce.Api.Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductProvider prodcutsProvider;
        public ProductsController(IProductProvider productsProvider) {

            this.prodcutsProvider = productsProvider;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public  async Task<IActionResult> GetProductAsync()
        {

            var result = await prodcutsProvider.GetProductsAsync();
            if (result.IsSuccess) {

                return Ok(result.Product);
            
            }
            return NotFound();
            
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            var result = await prodcutsProvider.GetProductAsync(id);
            if (result.IsSuccess)
            {

                return Ok(result.Product);

            }
            return NotFound();

        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

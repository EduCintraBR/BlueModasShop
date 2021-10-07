using BlueModasShop.Entities;
using BlueModasShop.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BlueModasShop.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductContract _contract;

        public ProductController(IProductContract contract)
        {
            this._contract = contract;
        }

        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await this._contract.GetAllProducts();
           
                return Ok(products);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error to retrieving products. Error: {e.Message}");
            }
        }

        [HttpGet]
        [Route("products/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await this._contract.GetProductById(id);
                if (product == null) return BadRequest($"Doesn't exist any product with this Id: {id}");

                return Ok(product);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error to retrieving product. Error: {e.Message}");
            }
        }

        [HttpPost]
        [Route("products")]
        public async Task<IActionResult> Save([FromBody] Product model)
        {
            try
            {
                var productSaved = await this._contract.SaveProduct(model);
                return Ok(productSaved);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error to save product. Error: {e.Message}");
            }
        }

        [HttpPut]
        [Route("products/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product model)
        {
            try
            {
                var productUpdated = await this._contract.UpdateProduct(id, model);
                return Ok(productUpdated);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error to update product. Error: {e.Message}");
            }
        }

        [HttpDelete]
        [Route("products/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                var result = await this._contract.RemoveProduct(id);
                if (result)
                    return Ok("Product Successfuly Deleted");
                else
                    return BadRequest("Product wasn't deleted");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error to delete product. Error: {e.Message}");
            }
        }
    }
}

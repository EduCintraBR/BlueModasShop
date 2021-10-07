using BlueModasShop.Repositories.Contracts;
using BlueModasShop.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueModasShop.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartContract _repository;

        public CartController(ICartContract repository)
        {
            this._repository = repository;
        }

        [HttpPost]
        [Route("cart/save-cart")]
        public async Task<IActionResult> Save([FromBody] List<CartProduct> models)
        {
            try
            {
                var cart = await this._repository.SaveCartCheckout(models);

                return Ok(cart);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                                    $"Error to save a cart. Error: {e.Message}");
            }
        }

        [HttpGet]
        [Route("cart/get-by-client-id/{clientId}")]
        public async Task<IActionResult> GetCartByClientId(int clientId)
        {
            try
            {
                var cart = await this._repository.GetProductCartByClientId(clientId);

                return Ok(cart);

            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                                    $"Error to retrieving a cart. Error: {e.Message}");
            }
        }
    }
}

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
    public class OrderController : ControllerBase
    {
        private readonly IOrderContract _repository;

        public OrderController(IOrderContract repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        [Route("order/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var order = await this._repository.GetOrderById(id);

                if (order == null) return BadRequest($"Doesn't exist any Order with this Id: {id}");

                return Ok(order);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error to retrieve Order. Error: {e.Message}");
            }
        }

        [HttpPost]
        [Route("order")]
        public async Task<IActionResult> Save([FromBody] Order model)
        {
            try
            {
                var orderModel = new Order
                {
                    ClientId = model.ClientId,
                    Client = model.Client,
                    Cart = model.Cart
                };

                var orderSaved = await this._repository.SaveOrder(orderModel);
                var order = await this.GetById(model.Id);

                return Ok(order);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error to save order. Error: {e.Message}");
            }
        }
    }
}

using BlueModasShop.Entities;
using BlueModasShop.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModasShop.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientContract _repository;

        public ClientController(IClientContract repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        [Route("clients/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var cli = await this._repository.GetClientById(id);

                if(cli == null) return BadRequest($"Doesn't exist any client with this Id: {id}");

                return Ok(cli);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error to retrieving client. Error: {e.Message}");
            }
        }

        [HttpPost]
        [Route("clients")]
        public async Task<IActionResult> Save([FromBody] Client model)
        {
            try
            {
                var clientSaved = await this._repository.SaveClient(model);
                return Ok(clientSaved);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                    $"Error to save client. Error: {e.Message}");
            }
        }
    }
}

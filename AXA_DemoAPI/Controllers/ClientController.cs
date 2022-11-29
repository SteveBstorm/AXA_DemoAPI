using AXA_DemoAPI.DTO;
using AXA_DemoAPI_BLL.Abstractions;
using Axa_DemoAPI_Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AXA_DemoAPI.Controllers
{
    [Authorize("isConnected")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_clientService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_clientService.GetById(id));
        }
        [Authorize("AdminPolicy")]
        [HttpPost]
        public IActionResult Insert(NewClientForm form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _clientService.Insert(new Client
            {
                Email = form.Email,
                Firstname = form.Firstname,
                Lastname = form.Lastname
            });
            return StatusCode(201);
        }
    }
}

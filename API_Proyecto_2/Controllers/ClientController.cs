using API_Proyecto_2.Helpers;
using API_Proyecto_2.Interfaces;
using API_Proyecto_2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Proyecto_2.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        public IClientService _clientService;

        public ClientController(IClientService clientServiceService)
        {
            _clientService = clientServiceService;
        }

        // GET: api/<ClientController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Client>>> Get(int id)
        {
            var response = await this._clientService.GetClient(id);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Client>>> Post([FromBody] Client client)
        {
            var response = await this._clientService.AddClient(client);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }

        // GET api/<ClientController>/allClients
        [HttpGet("allClients")]
        public async Task<ActionResult<ServiceResponse<List<Dispatcher>>>> GetAllClients()
        {
            var response = await this._clientService.GetAllClients();
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
        {
            var response = await this._clientService.DeleteClient(id);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }
    }
}

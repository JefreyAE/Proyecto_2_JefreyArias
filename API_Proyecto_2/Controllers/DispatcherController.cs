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
    public class DispatcherController : ControllerBase
    {

        public IDispatcherService _dispatcherService;

        public DispatcherController(IDispatcherService dispatcherService)
        {
            _dispatcherService = dispatcherService;
        }

        // GET: api/<DispatcherController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DispatcherController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Dispatcher>>> Get(int id)
        {
            var response = await this._dispatcherService.GetDispatcher(id);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }

        // POST api/<DispatcherController>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Dispatcher>>> Post([FromBody] Dispatcher dispatcher)
        {
            var response = await this._dispatcherService.AddDispatcher(dispatcher);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }

        // GET api/<AppointmentController>/allappointments
        [HttpGet("allDispatchers")]
        public async Task<ActionResult<ServiceResponse<List<Dispatcher>>>> GetAllAppointments()
        {
            var response = await this._dispatcherService.GetAllDispatchers();
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }


        // PUT api/<DispatcherController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DispatcherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

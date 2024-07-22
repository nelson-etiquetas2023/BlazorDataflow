using Dataflow.Server.Service.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dataflow.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IServiceManager service) : ControllerBase
    {
        private readonly IServiceManager _service = service;

        [HttpGet("id:int")]
        public IActionResult GetUserById(int id) 
        {
            var user = _service.UserService.GetUserById(id, trackChanges: false);
            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetUsers() 
        {
            try
            {
                var users = _service.UserService.GetAllUsers(trackChanges:false);
                return Ok(users);
            }
            catch
            {
                return StatusCode(500, "Error Interno del Servidor...");
            }
        }
   
    }
}

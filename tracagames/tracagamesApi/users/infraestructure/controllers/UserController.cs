using Microsoft.AspNetCore.Mvc;
using tracagamesApi.users.application;
using tracagamesApi.users.application.dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tracagamesApi.users.infraestructure.controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("signIn")]
        public User signIn([FromBody] User user)
        {
            return new UserLoggingApp().login(user);
        }

        [HttpPost]
        [Route("signUp")]
        public User signUp([FromBody] User user)
        {
            return new UserLoggingApp().signUp(user);
        }

        [HttpPost]
        [Route("logout")]
        public User logout([FromBody] User user)
        {
            return new UserLoggingApp().logout(user);
        }

        // GET: api/<UserController>       
    }
}

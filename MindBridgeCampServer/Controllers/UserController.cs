using Application.Services.User;
using Application.Services.User.Contracts;
using Application.User;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MindBridgeCampServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/<UserController>/5
        [HttpGet("{userId}")]
        public IActionResult Get(string userId)
        {
            var response = _userService.Get(new GetByIdRequest 
            {
                UserId = userId
            });

            return Ok(JsonConvert.SerializeObject(response.User));
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserModel userModel)
        {
            _userService.Add(userModel);

            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateUser([FromBody] UserModel userModel)
        {
            _userService.Update(userModel);

            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{userId}")]
        public void Delete(int id)
        {
        }
    }
}

using Application.Services.User;
using Application.Services.User.Contracts;
using Application.User;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MindBridgeCampServer.Controllers
{
    [Route("api/[controller]/")]
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

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] UserModel userModel)
        {
            var response = _userService.Add(userModel);
        }

        // PUT api/<UserController>/5
        [HttpPut("{userId}")]
        public void Put(string userId, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{userId}")]
        public void Delete(int id)
        {
        }
    }
}

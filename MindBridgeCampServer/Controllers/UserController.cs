using Application.Services.User;
using Application.Services.User.Contracts;
using Application.User;
using Common.Core.LogService;
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
            LogService.Info<UserController>("Get");
            LogService.Info<UserController>("User ID: " + userId);

            var response = _userService.Get(new GetByIdRequest 
            {
                UserId = userId
            });

            return Ok(JsonConvert.SerializeObject(response.User));
        }

        [HttpGet("{loginToken}")]
        public IActionResult GetByToken(string loginToken)
        {
            LogService.Info<UserController>("Get By Token");
            LogService.Info<UserController>("Login Token: " + loginToken);

            var response = _userService.Get(new GetByLoginTokenRequest
            {
                LoginToken = loginToken
            });

            return Ok(JsonConvert.SerializeObject(response.User));
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserModel userModel)
        {
            LogService.Info<UserController>("Add User");
            LogService.Info<UserController>("User Model: " + JsonConvert.SerializeObject(userModel));

            _userService.Add(userModel);

            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateUser([FromBody] UserModel userModel)
        {
            LogService.Info<UserController>("Update User");
            LogService.Info<UserController>("User Model: " + JsonConvert.SerializeObject(userModel));

            _userService.Update(userModel);

            return Ok();
        }
    }
}

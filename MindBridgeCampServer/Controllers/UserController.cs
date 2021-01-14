using Application.Services.User;
using Application.Services.User.Contracts;
using Application.User;
using Common.Core.LogService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

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
            LogService.Info<UserController>("Get" + Environment.NewLine + "User ID: " + userId);

            var response = _userService.Get(new GetByIdRequest 
            {
                UserId = userId
            });

            return Ok(JsonConvert.SerializeObject(response.User));
        }

        [HttpGet("{loginToken}")]
        public IActionResult GetByToken(string loginToken)
        {
            LogService.Info<UserController>(
                "GetByToken" + Environment.NewLine + 
                "Login Token: " + loginToken);
            try
            {
                var response = _userService.Get(new GetByLoginTokenRequest
                {
                    LoginToken = loginToken
                });

                return Ok(JsonConvert.SerializeObject(response.User));
            }
            catch(Exception e)
            {
                LogService.Info<UserController>(
                    e.Message + Environment.NewLine + 
                    e.StackTrace);
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserModel userModel)
        {
            LogService.Info<UserController>(
                "AddUser" + Environment.NewLine + 
                "User Model: " + JsonConvert.SerializeObject(userModel));

            _userService.Add(userModel);

            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateUser([FromBody] UserModel userModel)
        {
            LogService.Info<UserController>(
                "UpdateUser" + Environment.NewLine + 
                "User Model: " + JsonConvert.SerializeObject(userModel));

            _userService.Update(userModel);

            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateUserInfo([FromBody] UserModel userModel)
        {
            LogService.Info<UserController>(
                "UpdateUser" + Environment.NewLine +
                "User Model: " + JsonConvert.SerializeObject(userModel));

            _userService.Update(userModel);

            return Ok();
        }
    }
}

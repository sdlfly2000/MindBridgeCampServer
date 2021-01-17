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
            catch (Exception e)
            {
                LogService.Info<UserController>(
                    e.Message + Environment.NewLine + 
                    e.StackTrace);
                return BadRequest(e.Message);
            }
        }

        [HttpPost("{loginToken}")]
        public IActionResult AddUser(string loginToken, [FromBody] UserModel userModel)
        {
            LogService.Info<UserController>(
                "AddUser" + Environment.NewLine +
                "loginToken: " + loginToken + Environment.NewLine +
                "userModel: " + JsonConvert.SerializeObject(userModel));
            try
            {
                _userService.Add(loginToken, userModel);
                return Ok();
            }
            catch (Exception e)
            {
                LogService.Info<UserController>(e.Message + Environment.NewLine + e.StackTrace);
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] UserModel userModel)
        {
            LogService.Info<UserController>(
                "UpdateUser" + Environment.NewLine + 
                "User Model: " + JsonConvert.SerializeObject(userModel));

            _userService.Update(userModel);

            return Ok();
        }

        [HttpPost("{loginToken}")]
        public IActionResult UpdateUserInfo(string loginToken, [FromBody] UserModel userModel)
        {
            LogService.Info<UserController>(
                "UpdateUserInfo" + Environment.NewLine +
                "loginToken: " + loginToken + Environment.NewLine +
                "userModel: " + JsonConvert.SerializeObject(userModel));
            try
            {
                _userService.UpdateUserInfo(loginToken, userModel);
                return Ok();
            }
            catch (Exception e)
            {
                LogService.Info<UserController>(e.Message + Environment.NewLine + e.StackTrace);
                return BadRequest(e.Message);
            }
        }

        [HttpPost("{loginToken}")]
        public IActionResult UpdateUser(string loginToken, [FromBody] UserModel userModel)
        {
            LogService.Info<UserController>(
                "UpdateUser" + Environment.NewLine +
                "loginToken: " + loginToken + Environment.NewLine +
                "userModel: " + JsonConvert.SerializeObject(userModel));
            try
            {
                _userService.UpdateUser(loginToken, userModel);
                return Ok();
            }
            catch (Exception e)
            {
                LogService.Info<UserController>(e.Message + Environment.NewLine + e.StackTrace);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{loginToken}")]
        public IActionResult IsUserExist(string loginToken)
        {
            LogService.Info<UserController>(
                "IsUserExsit" + Environment.NewLine +
                "loginToken: " + loginToken);
            try
            {
                var isExist = _userService.IsUserExist(loginToken);

                if (!isExist)
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception e)
            {
                LogService.Info<UserController>(e.Message + Environment.NewLine + e.StackTrace);
                return BadRequest(e.Message);
            }
        }
    }
}

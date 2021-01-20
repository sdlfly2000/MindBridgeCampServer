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
        [LogService]
        public IActionResult Get(string userId)
        {
            try
            {
                var response = _userService.Get(new GetByIdRequest
                {
                    UserId = userId
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

        [HttpGet("{loginToken}")]
        [LogService]
        public IActionResult GetByToken(string loginToken)
        {
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
        [LogService]
        public IActionResult AddUser(string loginToken, [FromBody] UserModel userModel)
        {
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

        [HttpPost("{loginToken}")]
        [LogService]
        public IActionResult UpdateUserInfo(string loginToken, [FromBody] UserModel userModel)
        {
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
        [LogService]
        public IActionResult UpdateUser(string loginToken, [FromBody] UserModel userModel)
        {
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
        [LogService]
        public IActionResult IsUserExist(string loginToken)
        {
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

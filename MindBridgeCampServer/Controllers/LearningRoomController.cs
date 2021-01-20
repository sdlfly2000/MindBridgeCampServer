using System;
using System.Threading.Tasks;
using Application.Services.LearningRoom;
using Common.Core.LogService;
using Core;
using Microsoft.AspNetCore.Mvc;
using MindBridgeCampServer.Models;
using Newtonsoft.Json;

namespace MindBridgeCampServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LearningRoomController : ControllerBase
    {
        private readonly ILearningRoomService _learningRoomService;

        public LearningRoomController(
            ILearningRoomService learningRoomService)
        {
            _learningRoomService = learningRoomService;
        }

        [HttpGet]
        [LogService]
        public async Task<IActionResult> GetAvailableRooms()
        {
            var task = Task.Run<IActionResult>(
            () =>
                   {
                       try
                       {
                           var availableRooms = _learningRoomService.GetAvailableRooms();

                           var response = JsonConvert.SerializeObject(availableRooms.LearningRooms);

                           return Ok(response);
                       }
                       catch (Exception e)
                       {
                           LogService.Info<LearningRoomController>(e.StackTrace);
                           return BadRequest(e.Message);
                       }
                   });
            return await task;
        }

        [HttpPost("{loginToken}")]
        [LogService]
        public IActionResult CreateRoom(string loginToken, [FromBody] LearningRoomRequestModel request)
        {
            try
            {
                _learningRoomService.CreateRoom(loginToken, request.Model);
            }
            catch (Exception e)
            {
                LogService.Info<LearningRoomController>(e.StackTrace);
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpGet("{loginToken}/{roomId}")]
        [LogService]
        public IActionResult JoinRoom(string loginToken, string roomId)
        {
            try
            {
                var response = _learningRoomService.JoinRoom(loginToken, roomId);

                var responseMessage = JsonConvert.SerializeObject(response.LearningRooms);

                return Ok(responseMessage);
            }
            catch (Exception e)
            {
                LogService.Info<LearningRoomController>(e.StackTrace);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{roomId}")]
        [LogService]
        public IActionResult GetParticipants(string roomId)
        {
            var participants = _learningRoomService.GetParticipants(roomId);

            var responseMessage = JsonConvert.SerializeObject(participants);

            return Ok(responseMessage);
        }

        [HttpGet("{loginToken}")]
        [LogService]
        public IActionResult GetRoomsParticipated(string loginToken)
        {
            try
            {
                var models = _learningRoomService.GetRoomsParticipated(loginToken);

                var responseMessage = JsonConvert.SerializeObject(models);

                return Ok(responseMessage);
            }
            catch (Exception e)
            {
                LogService.Info<LearningRoomController>(e.StackTrace);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{loginToken}/{roomId}")]
        [LogService]
        public IActionResult SignInRoom(string loginToken, string roomId)
        {
            try
            {
                _learningRoomService.SignInRoom(loginToken, roomId);
                return Ok();
            }
            catch (Exception e)
            {
                LogService.Info<LearningRoomController>(e.StackTrace);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{loginToken}/{roomId}")]
        [LogService]
        public IActionResult IsJoinRoom(string loginToken, string roomId)
        {
            try
            {
                var isJoinRoom = _learningRoomService.IsJoinRoom(loginToken, roomId);
                return isJoinRoom ? Ok() : (IActionResult)BadRequest();
            }
            catch (Exception e)
            {
                LogService.Info<LearningRoomController>(e.StackTrace);
                return BadRequest(e.Message);
            }
        }
    }
}

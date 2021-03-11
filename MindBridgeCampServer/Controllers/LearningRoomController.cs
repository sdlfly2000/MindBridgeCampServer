using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Application.Services.LearningRoom;
using Common.Core.LogService;
using Microsoft.AspNetCore.Mvc;
using MindBridgeCampServer.Hubs;
using MindBridgeCampServer.Models;
using Newtonsoft.Json;

namespace MindBridgeCampServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LearningRoomController : ControllerBase
    {
        private readonly ILearningRoomService _learningRoomService;
        private readonly IChatMessageHub _chatMessageHub;

        public LearningRoomController(
            ILearningRoomService learningRoomService,
            IChatMessageHub chatMessageHub)
        {
            _learningRoomService = learningRoomService;
            _chatMessageHub = chatMessageHub;
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

            return Ok("Create Room Successfully.");
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
            try
            {
                var participants = _learningRoomService.GetParticipants(roomId);

                var responseMessage = JsonConvert.SerializeObject(participants);

                return Ok(responseMessage);
            }
            catch(Exception e)
            {
                LogService.Info<LearningRoomController>(e.StackTrace);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{roomId}")]
        [LogService]
        public IActionResult GetParticipantsOnlineCount(string roomId)
        {
            try
            {
                var count = _chatMessageHub.GetParticpantsOnlineCount(roomId);

                return Ok(count);
            }
            catch (Exception e)
            {
                LogService.Info<LearningRoomController>(e.StackTrace);
                return BadRequest(e.Message);
            }
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
                return Ok("Sign In Successfully.");
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
                return isJoinRoom ? Ok("Joined") : (IActionResult)BadRequest("Not Join");
            }
            catch (Exception e)
            {
                LogService.Info<LearningRoomController>(e.StackTrace);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{loginToken}/{roomId}")]
        [LogService]
        public IActionResult GetAllMessagesByRoom(string loginToken, string roomId)
        {
            try
            {
                var messageModels = _learningRoomService.GetMessagesByRoom(loginToken, roomId);

                return Ok(JsonConvert.SerializeObject(messageModels));
            }
            catch (Exception e)
            {
                LogService.Info<LearningRoomController>(e.StackTrace);
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [LogService]
        public async Task<IActionResult> SaveMessage([FromBody] NewMessageRequestModel model)
        {
            try
            {
                await _learningRoomService.CreateChatMessage(model.loginToken, model.roomId, model.content);
                return Ok(@"Save Message successfully.");
            }
            catch (Exception e)
            {
                LogService.Info<ChatMessageHub>(
                    e.Message + Environment.NewLine +
                    e.StackTrace);
                return BadRequest(e.Message);
            }
        }
    }
}

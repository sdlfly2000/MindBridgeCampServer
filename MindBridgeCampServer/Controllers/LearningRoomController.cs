using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Application.Services.LearningRoom;
using MindBridgeCampServer.Models;
using Common.Core.LogService;
using System;

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
        public IActionResult GetAvailableRooms()
        {
            LogService.Info<LearningRoomController>("Get Available Rooms");

            var availableRooms = _learningRoomService.GetAvailableRooms();

            return Ok(JsonConvert.SerializeObject(availableRooms.LearningRooms));
        }

        [HttpPost("{loginToken}")]
        public IActionResult CreateRoom(string loginToken, [FromBody] LearningRoomRequestModel request)
        {
            LogService.Info<LearningRoomController>(
                "Create Room" + Environment.NewLine + 
                "Login Token: " + loginToken + Environment.NewLine + 
                "Model: " + JsonConvert.SerializeObject(request));

            _learningRoomService.CreateRoom(loginToken, request.Model);

            return Ok();
        }

        [HttpGet("{loginToken}/{roomId}")]
        public IActionResult JoinRoom(string loginToken, string roomId)
        {
            LogService.Info<LearningRoomController>("Join Room" + Environment.NewLine +
                                                    "Login Token: " + loginToken + Environment.NewLine +
                                                    "Room ID: " + roomId);

            var response = _learningRoomService.JoinRoom(loginToken, roomId);

            return Ok(JsonConvert.SerializeObject(response.LearningRooms));
        }

        [HttpGet("{roomId}")]
        public IActionResult GetParticipants(string roomId)
        {
            LogService.Info<LearningRoomController>(
                "Join Room" + Environment.NewLine + 
                "Room ID: " + roomId);

            var participants = _learningRoomService.GetParticipants(roomId);

            return Ok(JsonConvert.SerializeObject(participants));
        }

        [HttpGet("{loginToken}")]
        public IActionResult GetRoomsParticipated(string loginToken)
        {
            LogService.Info<LearningRoomController>(
                "GetRoomsParticipated" + Environment.NewLine +
                "login Token: " + loginToken);

            var response = _learningRoomService.GetRoomsParticipated(loginToken);

            return Ok(JsonConvert.SerializeObject(response.LearningRooms));
        }
    }
}

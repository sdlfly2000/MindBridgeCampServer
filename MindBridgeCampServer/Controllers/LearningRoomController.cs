using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Application.Services.LearningRoom;
using MindBridgeCampServer.Models;
using Common.Core.LogService;

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
            LogService.Info<LearningRoomController>("Create Room");
            LogService.Info<LearningRoomController>("Login Token: " + loginToken);
            LogService.Info<LearningRoomController>("Model: " + JsonConvert.SerializeObject(request));

            _learningRoomService.CreateRoom(loginToken, request.Model);

            return Ok();
        }

        [HttpGet("{loginToken}/{roomId}")]
        public IActionResult JoinRoom(string loginToken, string roomId)
        {
            LogService.Info<LearningRoomController>("Join Room");
            LogService.Info<LearningRoomController>("Login Token: " + loginToken);
            LogService.Info<LearningRoomController>("Room ID: " + roomId);

            var response = _learningRoomService.JoinRoom(loginToken, roomId);

            return Ok(JsonConvert.SerializeObject(response.LearningRooms));
        }

        [HttpGet("{roomId}")]
        public IActionResult GetParticipants(string roomId)
        {
            LogService.Info<LearningRoomController>("Join Room");
            LogService.Info<LearningRoomController>("Room ID: " + roomId);

            var participants = _learningRoomService.GetParticipants(roomId);

            return Ok(JsonConvert.SerializeObject(participants));
        }
    }
}

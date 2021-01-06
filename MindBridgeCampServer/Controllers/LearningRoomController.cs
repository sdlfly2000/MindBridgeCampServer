using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Application.Services.LearningRoom;
using MindBridgeCampServer.Models;
using Microsoft.Extensions.Logging;

namespace MindBridgeCampServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LearningRoomController : ControllerBase
    {
        private readonly ILogger<LearningRoomController> _logger;
        private readonly ILearningRoomService _learningRoomService;

        public LearningRoomController(
            ILogger<LearningRoomController> logger,
            ILearningRoomService learningRoomService)
        {
            _logger = logger;
            _learningRoomService = learningRoomService;
        }

        [HttpGet]
        public IActionResult GetAvailableRooms()
        {
            var availableRooms = _learningRoomService.GetAvailableRooms();

            return Ok(JsonConvert.SerializeObject(availableRooms.LearningRooms));
        }

        [HttpPost("{loginToken}")]
        public IActionResult CreateRoom(string loginToken, [FromBody] LearningRoomRequestModel request)
        {
            _logger.LogInformation("Login Token: " + loginToken);
            _logger.LogInformation("Model: " + JsonConvert.SerializeObject(request));

            _learningRoomService.CreateRoom(loginToken, request.Model);

            return Ok();
        }

        [HttpGet("{loginToken}/{roomId}")]
        public IActionResult JoinRoom(string loginToken, string roomId)
        {
            var response = _learningRoomService.JoinRoom(loginToken, roomId);

            return Ok(JsonConvert.SerializeObject(response.LearningRooms));
        }

        [HttpGet("{roomId}")]
        public IActionResult GetParticipants(string roomId)
        {
            _logger.LogInformation("Room Id: " + roomId);

            var participants = _learningRoomService.GetParticipants(roomId);

            return Ok(JsonConvert.SerializeObject(participants));
        }
    }
}

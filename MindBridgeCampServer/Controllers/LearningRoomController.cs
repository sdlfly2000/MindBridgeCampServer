using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Application.Services.LearningRoom;
using MindBridgeCampServer.Models;

namespace MindBridgeCampServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LearningRoomController : ControllerBase
    {
        private readonly ILearningRoomService _learningRoomService;

        public LearningRoomController(ILearningRoomService learningRoomService)
        {
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
            _learningRoomService.CreateRoom(loginToken, request.Model);

            return Ok();
        }

        [HttpGet("{loginToken}/{roomId}")]
        public IActionResult JoinRoom(string loginToken, string roomId)
        {
            var response = _learningRoomService.JoinRoom(loginToken, roomId);

            return Ok(JsonConvert.SerializeObject(response.LearningRooms));
        }
    }
}

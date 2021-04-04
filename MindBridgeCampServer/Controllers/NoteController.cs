using Application.Note;
using Application.Services.Note;
using Common.Core.LogService;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MindBridgeCampServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpPost("{loginToken}")]
        [LogService]
        public IActionResult Create(string loginToken, [FromBody] NoteModel model)
        {
            try
            {
                _noteService.CreateNote(loginToken, model);
            }
            catch (Exception e)
            {
                LogService.Info<NoteController>(e.StackTrace);
                return BadRequest(e.Message);
            }

            return Ok("Create Note Successfully.");
        }
    }
}

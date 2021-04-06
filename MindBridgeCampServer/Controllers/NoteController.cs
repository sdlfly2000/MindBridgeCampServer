using Application.Services.Note;
using Common.Core.LogService;
using Microsoft.AspNetCore.Mvc;
using MindBridgeCampServer.Models;
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
        public IActionResult Create(string loginToken, [FromBody] CreateNoteRequest request)
        {
            try
            {
                _noteService.CreateNote(loginToken, request.model);
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

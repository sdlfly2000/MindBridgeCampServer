using Application.Services.Note;
using Common.Core.LogService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindBridgeCampServer.Models;
using System;
using SysFile = System.IO.File;

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

        [HttpPost]
        [LogService]
        public IActionResult UploadImage(IFormFile image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Upload Image Error.");
            }

            var message = "Image Name: " + image.Name + Environment.NewLine;
            message += "Image FileName: " + image.FileName + Environment.NewLine;
            message += "Image ContentType: " + image.ContentType + Environment.NewLine;
            message += "Image ContentDisposition: " + image.ContentDisposition + Environment.NewLine;

            using (var file = SysFile.Create("image.jpg"))
            {
                image.OpenReadStream().CopyTo(file);
                file.Close();
            }

            LogService.Info<NoteController>(message);            

            return Ok("Upload Image.");
        }
    }
}

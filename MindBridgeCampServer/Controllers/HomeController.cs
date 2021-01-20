using Microsoft.AspNetCore.Mvc;
using Common.Core.LogService;

namespace MindBridgeCampServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [LogService]
        public IActionResult IsAlive()
        {
            return Ok("Mind Bridge Camp Service is alive.");
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace MindBridgeCampServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult IsAlive()
        {
            return Ok("Mind Bridge Camp Service is alive.");
        }
    }
}
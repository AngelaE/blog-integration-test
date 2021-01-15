using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        [HttpGet]
        [Route("ping")]
        public ActionResult Ping()
        {
            return Ok("Service is up");
        }
    }
}

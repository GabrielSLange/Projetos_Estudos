using Blog.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Get([FromServices] IConfiguration config)
        {
            var env = config.GetValue<string>("env");
            return Ok(new { servidor = "Em funcionamento...", Ambiente = env});
        }
    }
}

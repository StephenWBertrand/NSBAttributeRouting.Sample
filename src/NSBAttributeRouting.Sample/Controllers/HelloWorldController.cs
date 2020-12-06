using Microsoft.AspNetCore.Mvc;

namespace NSBAttributeRouting.Sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        public HelloWorldController()
        {
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}

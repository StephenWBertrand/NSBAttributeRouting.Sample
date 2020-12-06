using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSBAttributeRouting.Sample.Messages;
using NServiceBus;

namespace NSBAttributeRouting.Sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        private readonly IMessageSession _messageSession;

        public HelloWorldController(IMessageSession messageSession)
        {
            _messageSession = messageSession;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var message = new PingHelloWordCommand
            {
                Name = "My Name"
            };

            await _messageSession.Send(message);

            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.Models;
using System;
using System.Threading.Tasks;

namespace SignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private IHubContext<MessageHub> _hub;

        public ChatController(IHubContext<MessageHub> hub)
        {

            _hub = hub;
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            Message message = new Message
            {
                date = DateTime.Now,
                message = "test"
            };
            await _hub.Clients.All.SendAsync("NewMessage", message);
            return Ok("Update message sent.");
        }

        [HttpGet]
        [Route("MessageIndividual/{id}")]
        public async Task<IActionResult> MessageIndividual(string id)
        {
            Message message = new Message
            {
                date = DateTime.Now,
                message = "test"
            };
            string Id = id;
            var newId = _hub.Clients.Client(Id);
            await _hub.Clients.Client(Id).SendAsync("SendToIndividual", message);
            return Ok("Update message sent.");
        }
    }
}

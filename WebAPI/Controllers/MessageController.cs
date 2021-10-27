using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Hubs;

namespace WebAPI.Controllers
{
    [Route("api/message")]
    public class MessageController : Controller
    {
        private IHubContext<ChatHub> _messageHubContext;
        public MessageController(IHubContext<ChatHub> messageHubContext)
        {
            _messageHubContext = messageHubContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello");
        }

        [HttpPost]
        public IActionResult Post()
        {
            //broadcast message
            _messageHubContext.Clients.All.SendAsync("send", "Hello!");

            return Ok();
        }
    }
}

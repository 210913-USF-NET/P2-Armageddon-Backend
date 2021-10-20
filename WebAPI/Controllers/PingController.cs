using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/ping")]
    [ApiController]
    public class PingController : Controller
    {
        public void Index()
        {
            Console.WriteLine("Pong!");
        }
    }
}

using Microsoft.AspNetCore.SignalR;                                         // using this
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Hubs
{
    public class ChatHub : Hub                                      
    {
        public Task SendMessage1(string user, string message)        
        {
            return Clients.All.SendAsync("ReceiveOne", user, message);    
        }
    }
}
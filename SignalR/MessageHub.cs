using Microsoft.AspNetCore.SignalR;
using SignalR.Models;
using System.Threading.Tasks;

namespace SignalR
{
    public class MessageHub : Hub
    {
        public async Task NewMessage(Message msg)
        {
            await Clients.All.SendAsync("NewMessage", msg);
        }

        public async Task GroupTest(Message msg)
        {
            await Clients.Others.SendAsync("GroupTest", msg);
        }
        public async Task SendToIndividual(string connectionId, Message msg)
        {
            await Clients.Client(connectionId).SendAsync("SendToIndividual", msg);
        }

        public string GetConnectionId()
        {

            return Context.ConnectionId;
        }
    }
}

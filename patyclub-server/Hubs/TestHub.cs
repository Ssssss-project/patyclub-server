using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRTest.Hubs
{
    public class TestHub : Hub<ITestHub>
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendMessageToClient(user, message);
        }
    }
}
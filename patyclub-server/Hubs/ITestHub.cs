using System.Threading.Tasks;

namespace SignalRTest.Hubs
{
    public interface ITestHub
    {
        Task SendMessageToClient(string user, string message);
    }
}
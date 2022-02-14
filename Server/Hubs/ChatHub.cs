using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace CryptoChat.Server.Hubs
{
    public class ChatHub : Hub
    {
        private static Dictionary<string, IClientProxy> chats = new Dictionary<string, IClientProxy>();
        public async Task SendMessage(string userTo, string message, string userFrom)
        {
            if(chats.ContainsKey(userTo))
            {
                await chats[userTo].SendAsync("ReceiveMessage", userFrom, message);
            }
        }
        public void Register(string user)
        {
            if(!chats.ContainsKey(user))
            {
                chats.Add(user, Clients.Caller);
            }
        }
    }
}
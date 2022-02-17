using System.Security.Claims;
using System.Threading.Tasks;
using CryptoChat.Shared.Models;
using Microsoft.AspNetCore.SignalR;

namespace CryptoChat.Server.Hubs
{
	public class ChatHub : Hub
	{
		private static Dictionary<User, IClientProxy> chats = new Dictionary<User, IClientProxy>();
		public async Task SendMessage(string userFrom, string message, string userTo)
		{
			if (chats.Keys.Any(x => x.address == userTo))
			{
				List<Task> tasks = chats.Keys.Where(x => x.address == userTo).Select(y =>
								chats[y].SendAsync("ReceiveMessage", chats.Keys.FirstOrDefault(
									z => z.address == userFrom), message)).ToList();
				await Task.WhenAll(tasks);
			}
		}
		public void Register(User usr)
		{
			if (!chats.ContainsKey(usr))
			{
				chats.Add(usr, Clients.Caller);
			}
		}
		public async Task GetChat(string address)
		{
			await Clients.Caller.SendAsync("GetChat", chats.Keys.FirstOrDefault(x => x.address == address));
		}
		public override async Task OnDisconnectedAsync(Exception? exception)
		{
			User usr = chats.Keys.FirstOrDefault(x => chats[x] == Clients.Caller);
			if (usr != null) chats.Remove(usr);
		}
	}
}
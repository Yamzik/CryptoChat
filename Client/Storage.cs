using CryptoChat.Shared.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace CryptoChat.Client
{
	public class Storage
	{
		public string BaseAddress { get; set; } = "";
		public List<Chat> chats { get; set; } = new List<Chat> { };
		public User user { get; set; } = new User();
		public Chat currentChat { get; set; } = new Chat();

		public event Action<Message> OnMessageSent;
		public event Action<Chat, Message> OnMessageReceived;
		public event Action<User> OnInit;
		public event Action<Chat> OnChatClicked;
		public void InvokeOnChatClicked(Chat chat)
		{
			currentChat = chat;
			OnChatClicked.Invoke(chat);
		}
		public async void InvokeOnMessageSent(Message message)
		{
			await hub.SendAsync("SendMessage", user.address, message.text, message.to);
			currentChat.messages.Add(message);
			OnMessageSent.Invoke(message);
		}

		public HubConnection hub;

		public Storage(string baseAddess)
		{
			BaseAddress = baseAddess;
		}
		public async void Init(User _user)
		{
			user = _user;
			hub = new HubConnectionBuilder().WithUrl(BaseAddress).Build();
			await hub.StartAsync();
			if (hub.State == HubConnectionState.Connected)
			{
				await hub.SendAsync("Register", user);
			}
			hub.On<User, string>("ReceiveMessage", (userFrom, message) =>
			{
				Message msg = new Message
				{
					id = 0,
					from = userFrom.address,
					text = message,
					to = "me",
					date = DateTime.Now,
					route = MsgRoute.income,
					is_read = false
				};
				Chat ch = chats.FirstOrDefault(x => x.companion.address == userFrom.address);
				if (ch is null)
				{
					ch = new Chat { messages = new List<Message>(), companion = userFrom };
					chats.Add(ch);
				}
				ch.messages.Add(msg);
				OnMessageReceived.Invoke(ch, msg);
			});
			OnInit.Invoke(user);
		}
	}
}

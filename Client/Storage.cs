using CryptoChat.Shared.Models;

namespace CryptoChat.Client
{
	public class Storage
	{
		public List<Chat> chats { get; set; } = new List<Chat> { };

		public delegate void MsgSend();
		public event MsgSend SendMessage;
		public Chat currentChat;
		public User user { get; set; } = new User();
		public void InvokeSend()
        {
			SendMessage?.Invoke();
        }
	}
}

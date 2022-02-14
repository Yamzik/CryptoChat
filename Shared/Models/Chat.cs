using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoChat.Shared.Models
{
	public class Chat
	{
		public List<Message> messages { get; set; }
		public User companion { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoChat.Shared.Models
{
	public class Message
	{
		[Key]
		public long id { get; set; }
		public string from { get; set; } = "";
		public string to { get; set; } = "";
		public string text { get; set; } = "";
		public DateTime date { get; set; }
		public MsgRoute route { get; set; }
		public bool is_read { get; set; } = true;
	}

	public enum MsgRoute
    {
		income, outcome
    }
}

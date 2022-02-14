﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoChat.Shared.Models
{
	public class Message
	{
		public long id { get; set; }
		public string from { get; set; } = "";
		public string to { get; set; } = "";
		public string text { get; set; } = "";
		public DateTime date { get; set; }
		public MsgRoute route { get; set; }
	}

	public enum MsgRoute
    {
		income, outcome
    }
}
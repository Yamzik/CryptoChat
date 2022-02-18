using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace CryptoChat.Client
{
	public class MobileChatSwap
	{
		public event Action OnChatOpened;
		public event Action OnChatClosed;
		public async Task<BrowserDimension> GetDimensions(IJSRuntime js)
		{
			return await js.InvokeAsync<BrowserDimension>("getDimensions");
		}

		public void InvokeOpened() => OnChatOpened.Invoke();
		public void InvokeClosed() => OnChatClosed.Invoke();
	}
	public class BrowserDimension
	{
		public int Width { get; set; }
		public int Height { get; set; }
	}
}

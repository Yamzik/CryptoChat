using CryptoChat.Server.Identicons;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoChat.Server.Controllers
{
	[Route("api")]
	[ApiController]
	public class ApiController : ControllerBase
	{
		// GET: api/<ApiController>
		[Route("photo/{address}")]
		[HttpGet]
		public async Task<string> GetPhoto(string address)
		{
			return await Generator.GenerateUserPhoto(address, 64);
		}
	}
}

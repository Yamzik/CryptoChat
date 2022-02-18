using Newtonsoft.Json;

namespace CryptoChat.Server.Identicons
{
    public class Generator
    {
		public static HttpClient http = new HttpClient();
		public static string ipfsLoadApi = "https://ipfs.infura.io:5001/api/v0/add";

		public static async Task<string> LoadFileIpfs(byte[] data)
		{
			MultipartFormDataContent form = new MultipartFormDataContent();
			form.Add(new ByteArrayContent(data), "profile_pic", "img.bmp");
			HttpResponseMessage response = await http.PostAsync(ipfsLoadApi, form);
			//response.EnsureSuccessStatusCode();
			string sd = response.Content.ReadAsStringAsync().Result;
			return JsonConvert.DeserializeObject<Dictionary<string, string>>(sd).ContainsKey("Hash") ?
				"https://ipfs.io/ipfs/" + JsonConvert.DeserializeObject<Dictionary<string, string>>(sd)["Hash"] :
				"";
		}

		public static byte[] GenerateBlockie(string address, int size)
		{
			Identicon identicon = new Identicon(address, 8);
			identicon.GetBitmap(size);
			using (var stream = new MemoryStream())
			{
				identicon.GetBitmap(size).Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
				return stream.ToArray();
			}
		}

		public static async Task<string> GenerateUserPhoto(string address, int size)
		{
			byte[] data = GenerateBlockie(address, size);
			return await LoadFileIpfs(data);
		}
	}
}

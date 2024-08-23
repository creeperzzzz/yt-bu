using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace YouTubeDataAPIv3
{
	class Api
	{
		static HttpClient s_client;
		public static void Initialize(string apiKey)
		{
			API_KEY = apiKey;
			s_client = new HttpClient();
		}

		public static string API_KEY { get; private set; }
		public static JsonSerializerOptions JsonOption
		{
			get
			{
				var opt = new JsonSerializerOptions();
				opt.WriteIndented = true;
				opt.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
				return opt;
			}
		}

		public static async Task<HttpResponseMessage> GetAsync(string apiName, params string[] args)
		{
			if (s_client == null) throw new InvalidOperationException();

			var request = $"https://www.googleapis.com/youtube/v3/{apiName}?key={Api.API_KEY}";
			foreach (var a in args)
			{
				if (string.IsNullOrEmpty(a)) continue;
				request = request + "&" + a;
			}
			Console.WriteLine(request);
			return await s_client.GetAsync(request);
		}
	}
}

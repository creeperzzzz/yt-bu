using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace YouTubeDataAPIv3
{
	public class Channels
	{
		public class JsonData
		{
			public class PageInfo
			{
				public int totalResults { get; set; }
				public int resultsPerPage { get; set; }
			};
			public class Item
			{
				public class Snippet
				{
					public string title { get; set; }
					public string description { get; set; }
					public string customUrl { get; set; }
					public DateTime publishedAt { get; set; }
				};
				public class ContentDetails
				{
					public class RelatedPlaylists
					{
						public string likes { get; set; }
						public string uploads { get; set; }
					};

					public RelatedPlaylists relatedPlaylists { get; set; }
				};
				public class Statistics
				{
					public string viewCount { get; set; }
					public string subscriberCount { get; set; }
					public bool hiddenSubscriberCount { get; set; }
					public string videoCount { get; set; }
				};
				public class Status
				{
					public string privacyStatus { get; set; }
					public bool isLinked { get; set; }
					public string longUploadsStatus { get; set; }
				}


				public string kind { get; set; }
				public string etag { get; set; }
				public string id { get; set; }
				public Snippet snippet { get; set; }
				public ContentDetails contentDetails { get; set; }
				public Statistics statistics { get; set; }
				public Status status { get; set; }
			};

			public PageInfo pageInfo { get; set; }
			public Item[] items { get; set; }

			public string json { get; set; }
		};

		public static async Task<JsonData> GetChannelInfo(string channelId)
		{
			var part = "part=snippet,contentDetails,statistics,status";
			string channelRequest;
			if (channelId.StartsWith("@")) channelRequest = $"forHandle={channelId}";
			else channelRequest = $"id={channelId}";

			var resource = await Api.GetAsync("channels", part, channelRequest);
			var resp = await resource.Content.ReadAsStringAsync();
			//Console.WriteLine(resp);
			var opt = new JsonSerializerOptions();
			opt.IgnoreNullValues = true;
			var json = JsonSerializer.Deserialize<JsonData>(resp, opt);
			json.json = resp;
			return json;
		}
	}
}

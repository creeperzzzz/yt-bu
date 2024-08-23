using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;

namespace YouTubeDataAPIv3
{
	class Playlist
	{
		public class JsonData
		{
			public string kind { get; set; }
			public string etag { get; set; }
			public string nextPageToken { get; set; }
			public List<Item> items { get; set; }

			public class Item
			{
				public string kind { get; set; }
				public string etag { get; set; }
				public string id { get; set; }
				public Snippet snippet { get; set; }

				public class Snippet
				{
					public DateTime publishedAt { get; set; }
					public string channelId { get; set; }
					public string title { get; set; }
					public string description { get; set; }
					public Thumbnails thumbnails { get; set; }

					public class Thumbnails
					{
						public class ThumbnailInfo
						{
							public string url { get; set; }
							public int width { get; set; }
							public int height { get; set; }
						};
						//public ThumbnailInfo default { get; set; }
						public ThumbnailInfo medium { get; set; }
						public ThumbnailInfo high { get; set; }
						public ThumbnailInfo standard { get; set; }
						public ThumbnailInfo maxres { get; set; }
					};
					public string channelTitle { get; set; }
					public string playlistId { get; set; }
					public int position { get; set; }

					public ResourceId resourceId { get; set; }
					public class ResourceId
					{
						public string kind { get; set; }
						public string videoId { get; set; }
					};
					public string videoOwnerChannelTitle { get; set; }
					public string videoOwnerChannelId { get; set; }
				};
			};
		};
		public const int MAX_RESULTS = 50;
		public static async Task<JsonData> GetPlaylistItems(string playlistId, int maxResults = MAX_RESULTS, string pageToken = null)
		{
			var resource = await Api.GetAsync("playlistItems",
				$"playlistId={playlistId}",
				"part=snippet",
				$"maxResults={maxResults}",
				string.IsNullOrEmpty(pageToken) ? null : $"pageToken={pageToken}"
				);
			var resp = await resource.Content.ReadAsStringAsync();
			//Console.WriteLine(resp);
			var opt = new JsonSerializerOptions();
			opt.IgnoreNullValues = true;
			var json = JsonSerializer.Deserialize<JsonData>(resp, opt);
			return json;
		}
		public static async Task<JsonData> GetPlaylistItemsAll(string playlistId)
		{
			var data0 = await GetPlaylistItems(playlistId);
			var current = data0;
			while (!string.IsNullOrEmpty(current.nextPageToken))
			{
				current = await GetPlaylistItems(playlistId, MAX_RESULTS, current.nextPageToken);
				data0.items.AddRange(current.items);
			}
			return data0;
		}
	}
}

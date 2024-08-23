using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;

namespace YouTubeDataAPIv3
{
	class LiveChatMessages
	{
		public class JsonData
		{
			public string kind { get; set; }
			public string etag { get; set; }
			public string id { get; set; }
			public string nextPageToken { get; set; }
			public List<Item> items { get; set; }

			public class Item
			{
				public string kind { get; set; }
				public string etag { get; set; }
				public string id { get; set; }
				public Snippet snippet { get; set; }
				public Replies replies { get; set; }

				public class Snippet
				{
					public string channelId { get; set; }
					public string videoId { get; set; }
					public Comment topLevelComment { get; set; }
					public bool canReply { get; set; }
					public int totalReplyCount { get; set; }
					public bool isPublic { get; set; }
				};
				public class Replies
				{
					public Comment[] comments { get; set; }
				};
				public class Comment
				{
					public string kind { get; set; }
					public string etag { get; set; }
					public string id { get; set; }
					public Snippet snippet { get; set; }

					public class Snippet
					{
						public string authorDisplayName { get; set; }
						public string authorProfileImageUrl { get; set; }
						public string authorChannelUrl { get; set; }
						//public AuthorChannelId authorChannelId { get; set; }
						public string channelId { get; set; }
						public string textDisplay { get; set; }
						public string textOriginal { get; set; }
						public string parentId { get; set; }
						public bool canRate { get; set; }
						public string viewerRating { get; set; }
						public int likeCount { get; set; }
						public string moderationStatus { get; set; }
						public DateTime publishedAt { get; set; }
						public DateTime updatedAt { get; set; }
					};
				};
			};
		};

		const int MAX_RESULTS = 2000;
		public static async Task<JsonData> GetMessages(string liveChatId, int maxResults = MAX_RESULTS, string nextPageToken = null)
		{
			var resource = await Api.GetAsync("liveChat/messages",
				$"liveChatId={liveChatId}",
				"part=id,snippet,authorDetails",
				$"maxResults={maxResults}",
				string.IsNullOrEmpty(nextPageToken) ? null : $"nextPageToken={nextPageToken}"
				);
			var resp = await resource.Content.ReadAsStringAsync();
			//Console.WriteLine(resp);
			var opt = new JsonSerializerOptions();
			opt.IgnoreNullValues = true;
			var json = JsonSerializer.Deserialize<JsonData>(resp, opt);
			return json;
		}
		public static async Task<JsonData> GetMessagesAll(string liveChatId)
		{
			var data0 = await GetMessages(liveChatId);
			var current = data0;
			while (!string.IsNullOrEmpty(current.nextPageToken))
			{
				current = await GetMessages(liveChatId, MAX_RESULTS, current.nextPageToken);
				data0.items.AddRange(current.items);
			}
			return data0;
		}
	};
}

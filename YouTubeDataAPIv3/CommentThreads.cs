using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;

namespace YouTubeDataAPIv3
{
	class CommentThreads
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

		const int MAX_RESULTS = 100;
		public static async Task<JsonData> GetCommentThreads(string videoId, int maxResults = MAX_RESULTS, string pageToken = null)
		{
			var resource = await Api.GetAsync("commentThreads",
				"part=id,replies,snippet",
				$"maxResults={maxResults}",
				$"videoId={videoId}",
				string.IsNullOrEmpty(pageToken) ? null : $"pageToken={pageToken}"
				);
			var resp = await resource.Content.ReadAsStringAsync();
			//Console.WriteLine(resp);
			var opt = new JsonSerializerOptions();
			opt.IgnoreNullValues = true;
			var json = JsonSerializer.Deserialize<JsonData>(resp, opt);
			return json;
		}
		public static async Task<JsonData> GetCommentThreadsAll(string videoId)
		{
			var data0 = await GetCommentThreads(videoId);
			var current = data0;
			while (!string.IsNullOrEmpty(current.nextPageToken))
			{
				current = await GetCommentThreads(videoId, MAX_RESULTS, current.nextPageToken);
				data0.items.AddRange(current.items);
				//bool found = false;
				//foreach (var item in current.items)
				//{
				//	if (data0.items.FindIndex(a => a.id == item.id) == -1)
				//	{
				//		found = true;
				//		data0.items.Add(item);
				//	}
				//}
				//if (!found) break; //nextPageTokenをたどっていっても永遠に終わらない場合がある…？ 新規のコメントが取得できなくなったら取得を辞める
			}
			return data0;
		}
	};
}

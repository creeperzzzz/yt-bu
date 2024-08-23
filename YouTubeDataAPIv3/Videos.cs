using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;

namespace YouTubeDataAPIv3
{
	public class Videos
	{
        public class JsonData
        {
            public class Item
            {
                public string kind { get; set; }
                public string etag { get; set; }
                public string id { get; set; }
                public Snippet snippet { get; set; }
                //public ContentDetails contentDetails { get; set; }
                //public Status status { get; set; }
                public Statistics statistics { get; set; }
                //public Player player { get; set; }
                //public TopicDetails topicDetails { get; set; }
                //public RecordingDetails recordingDetails { get; set; }
                public FileDetails fileDetails { get; set; }
                //public ProcessingDetails processingDetails { get; set; }
                //public Suggestions suggestions { get; set; }
                public LiveStreamingDetails liveStreamingDetails { get; set; }
                //public Localizations localizations { get; set; }

                public class Snippet
                {
                    public DateTime publishedAt { get; set; }
                    public string channelId { get; set; }
                    public string title { get; set; }
                    public string description { get; set; }
                    //"thumbnails": {
                    public string channelTitle { get; set; }
                    public string[] tags { get; set; }
                    public string categoryId { get; set; }
                    public string liveBroadcastContent { get; set; }
                    public string defaultLanguage { get; set; }
                    //"localized"
                    public string defaultAudioLanguage { get; set; }
                };
                public class ContentDetails
                {
                    public string duration { get; set; }
                    public string dimension { get; set; }
                    public string definition { get; set; }
                    public string caption { get; set; }
                    public bool licensedContent { get; set; }
                    //"regionRestriction":
                    //"contentRating": 
                    public string projection { get; set; }
                    public bool hasCustomThumbnail { get; set; }
                };
                public class Statistics
                {
                    public string viewCount { get; set; }
                    public string likeCount { get; set; }
                    public string dislikeCount { get; set; }
                    public string favoriteCount { get; set; }
                    public string commentCount { get; set; }
                };

                public class FileDetails
                {
                    public string fileName { get; set; }
                    public int fileSize { get; set; }
                    public string fileType { get; set; }
                    public string container { get; set; }
                    public VideoStream[] videoStreams { get; set; }
                    public AudioStream[] audioStreams { get; set; }
                    public int durationMs { get; set; }
                    public int bitrateBps { get; set; }
                    public string creationTime { get; set; }

                    public class VideoStream
                    {
                        public int widthPixels { get; set; }
                        public int heightPixels { get; set; }
                        public double frameRateFps { get; set; }
                        public double aspectRatio { get; set; }
                        public string codec { get; set; }
                        public int bitrateBps { get; set; }
                        public string rotation { get; set; }
                        public string vendor { get; set; }
                    };
                    public class AudioStream
                    {
                        public int channelCount { get; set; }
                        public string codec { get; set; }
                        public int bitrateBps { get; set; }
                        public string vendor { get; set; }
                    };
                };
                public class LiveStreamingDetails
                {
                    public DateTime actualStartTime { get; set; }
                    public DateTime actualEndTime { get; set; }
                    public DateTime scheduledStartTime { get; set; }
                    public DateTime scheduledEndTime { get; set; }
                    public int concurrentViewers { get; set; }
                    public string activeLiveChatId { get; set; }
                };
            };

            public List<Item> items { get; set; }
        };

		const int MAX_RESULTS = 50;
		public static async Task<JsonData> GetVideo(string videoId)
		{
			return await GetVideos(new string[] { videoId });
		}
        public static async Task<JsonData> GetVideos(IList<string> videoIds)
        {
            int s = 0;
            JsonData ret = null;
            while (s < videoIds.Count)
            {
                List<string> ids = new List<string>();
                for (int i = 0; i < MAX_RESULTS; i++)
                {
                    if (s + i >= videoIds.Count) break;
                    ids.Add(videoIds[s + i]);
                }

                var resource = await Api.GetAsync("videos",
                    //"part=contentDetails,fileDetails,id,liveStreamingDetails,localizations,player,processingDetails,recordingDetails,snippet,statistics,status,suggestions,topicDetails",
                    "part=id,liveStreamingDetails,snippet,statistics",
                    "maxResults=50",
                    "id=" + string.Join(",", ids)
                    );
                var resp = await resource.Content.ReadAsStringAsync();
                //Console.WriteLine(resp);
                var opt = new JsonSerializerOptions();
                opt.IgnoreNullValues = true;
                var json = JsonSerializer.Deserialize<JsonData>(resp, opt);
                if (ret == null) ret = json;
                else ret.items.AddRange(json.items);

                s += MAX_RESULTS;
            }
            return ret;
        }
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;

using YouTubeDataAPIv3;

namespace yt_bu
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		class ChannelListItem
		{
			public Channels.JsonData json;
			public string channelId;
			public override string ToString()
			{
				if (json != null) return json.items[0].snippet.title;
				else return channelId;
			}
		}
		class VideoListItem
		{
			public Videos.JsonData videoData;
			public CommentThreads.JsonData commentData;
			public string videoId;
			public override string ToString()
			{
				if (videoData != null) return videoData.items[0].snippet.title;
				else return videoId;
			}
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			if (File.Exists("API_KEY.txt"))
			{
				Api.Initialize(File.ReadAllText("API_KEY.txt"));
			}
			else
			{
				MessageBox.Show("API_KEY.txt", "error");
				Close();
			}

			if (Directory.Exists("channels"))
			{
				foreach (var dir in Directory.GetDirectories("channels"))
				{
					var channelInfo = JsonSerializer.Deserialize<Channels.JsonData>(File.ReadAllText(Path.Combine(dir, "channels.json")));
					var item = new ChannelListItem();
					item.channelId = Path.GetFileName(dir);
					item.json = channelInfo;
					this.channelList.Items.Add(item);
				}
			}

			//GetChannelInfo("UCYP7NdjVbGwCHXfI-1Zrhig");
			//GetChannelInfo("@aoi_sakura3");
		}

		void UpdateVideoList(ChannelListItem channel)
		{
			videoList.Items.Clear();
			if (channel == null) return;
			List<VideoListItem> items = new List<VideoListItem>();
			foreach (var videoDir in Directory.GetDirectories(Path.Combine("channels", channel.channelId)))
			{
				var item = new VideoListItem();
				item.videoId = Path.GetFileName(videoDir);
				var path = Path.Combine(videoDir, "videos.json");
				if (File.Exists(path))
				{
					item.videoData = JsonSerializer.Deserialize<Videos.JsonData>(File.ReadAllText(path));
				}
				path = Path.Combine(videoDir, "commentThreads.json");
				if (File.Exists(path))
				{
					item.commentData = JsonSerializer.Deserialize<CommentThreads.JsonData>(File.ReadAllBytes(path));
				}
				items.Add(item);
			}
			items.Sort((a, b) =>
			{
				return b.videoData.items[0].snippet.publishedAt.CompareTo(
						a.videoData.items[0].snippet.publishedAt
					);
			});
			videoList.BeginUpdate();
			foreach(var i in items) videoList.Items.Add(i);
			videoList.EndUpdate();
		}
		void UpdateVideoInfo(VideoListItem video)
		{
			txtDescription.Text = "";
			txtComment.Text = "";
			txtChat.Text = "";
			if (video == null || video.videoData == null) return;

			StringBuilder sb = new StringBuilder();

			sb.AppendLine("publishedAt:");
			sb.AppendLine(video.videoData.items[0].snippet.publishedAt.ToString("yyyy/MM/dd HH:mm"));
			sb.AppendLine();
			sb.AppendLine(video.videoData.items[0].snippet.description.Replace("\n", "\r\n"));
			txtDescription.Text = sb.ToString();


			sb.Clear();
			if (video.commentData != null)
			{
				foreach (var c in video.commentData.items)
				{
					sb.AppendLine(c.snippet.topLevelComment.snippet.authorDisplayName);
					sb.AppendLine(c.snippet.topLevelComment.snippet.textOriginal.Replace("\n", "\r\n"));
					sb.AppendLine();
				}
			}
			txtComment.Text = sb.ToString();
			//txtChat.Text = "";
		}

		static async void GetChannelInfo(string channelId)
		{
			var channelInfo = await Channels.GetChannelInfo(channelId);
			var playlistInfo = await Playlist.GetPlaylistItemsAll(channelInfo.items[0].contentDetails.relatedPlaylists.uploads);
			List<string> videoIds = new List<string>();
			foreach (var v in playlistInfo.items)
			{
				videoIds.Add(v.snippet.resourceId.videoId);
				Console.WriteLine($"[{v.snippet.position}:{v.snippet.resourceId.videoId}]{v.snippet.title}");
				var comments = await CommentThreads.GetCommentThreadsAll(v.snippet.resourceId.videoId);
				foreach (var c in comments.items)
				{
					Console.WriteLine($"{c.snippet.topLevelComment.snippet.authorDisplayName}: {c.snippet.topLevelComment.snippet.textDisplay}");
				}
			}
		}

		private void addChannelButton_Click(object sender, EventArgs e)
		{
			var dialog = new AddChannelDialog();
			dialog.ShowDialog(this);
			Console.WriteLine(dialog.DialogResult);
			if (dialog.DialogResult == DialogResult.OK)
			{
				addChannel(dialog.ChannelId, dialog.GetVideos);
			}
		}

		async void addChannel(string channelId, bool getVideos)
		{
			var channelInfo = await Channels.GetChannelInfo(channelId);
			if (channelInfo.items == null || channelInfo.items.Length == 0)
			{
				MessageBox.Show("チャンネルが見つかりません", "error");
				return;
			}
			string dir = "channels";
			if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
			dir = Path.Combine(dir, channelId);
			if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
			string path = Path.Combine(dir, "channels.json");
			File.WriteAllText(path, channelInfo.json);

			var item = new ChannelListItem();
			item.channelId = channelId;
			item.json = channelInfo;
			channelList.Items.Add(item);

			if (getVideos) await this.getVideos(channelInfo.items[0].contentDetails.relatedPlaylists.uploads, dir);
		}

		async Task<int> getChannel(ChannelListItem channel)
		{
			var channelInfo = await Channels.GetChannelInfo(channel.channelId);
			channel.json = channelInfo;

			string dir = "channels";
			if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
			dir = Path.Combine(dir, channel.channelId);
			if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
			string path = Path.Combine(dir, "channels.json");
			File.WriteAllText(path, channelInfo.json);

			await getVideos(channelInfo.items[0].contentDetails.relatedPlaylists.uploads, dir);

			UpdateVideoList(channel);

			return 0;
		}

		async Task<int> getVideos(string playlistId, string directory)
		{
			var playlistInfo = await Playlist.GetPlaylistItemsAll(playlistId);
			var path = Path.Combine(directory, "playlistItems.json");
			var data = JsonSerializer.SerializeToUtf8Bytes(playlistInfo, Api.JsonOption);
			File.WriteAllBytes(path, data);

			int progress = 0;
			foreach (var video in playlistInfo.items)
			{
				Console.WriteLine($"[{++progress}/{playlistInfo.items.Count}] {video.snippet.title}");

				var videoId = video.snippet.resourceId.videoId;
				path = Path.Combine(directory, videoId);
				if (!Directory.Exists(path)) Directory.CreateDirectory(path);
				var videoInfo = await Videos.GetVideo(videoId);
				data = JsonSerializer.SerializeToUtf8Bytes(videoInfo, Api.JsonOption);
				File.WriteAllBytes(Path.Combine(path, "videos.json"), data);

				var comments = await CommentThreads.GetCommentThreadsAll(videoId);
				data = JsonSerializer.SerializeToUtf8Bytes(comments, Api.JsonOption);
				File.WriteAllBytes(Path.Combine(path, "commentThreads.json"), data);
			}
			return 0;
		}

		private async void btnReload_Click(object sender, EventArgs e)
		{
			try
			{
				this.Enabled = false;
				foreach (var item in channelList.SelectedItems)
				{
					await getChannel((ChannelListItem)item);
				}
			}
			finally
			{
				this.Enabled = true;
			}
		}

		private void channelList_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateVideoList((ChannelListItem)channelList.SelectedItem);
		}

		private void videoList_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateVideoInfo((VideoListItem)videoList.SelectedItem);
		}
	}
}

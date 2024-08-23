
namespace yt_bu
{
	partial class MainWindow
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.channelList = new System.Windows.Forms.CheckedListBox();
			this.videoList = new System.Windows.Forms.CheckedListBox();
			this.tabItemInformation = new System.Windows.Forms.TabControl();
			this.tabPageDescription = new System.Windows.Forms.TabPage();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.tabPageComment = new System.Windows.Forms.TabPage();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.tabPageChat = new System.Windows.Forms.TabPage();
			this.txtChat = new System.Windows.Forms.TextBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.addChannelButton = new System.Windows.Forms.ToolStripButton();
			this.btnReload = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.tabItemInformation.SuspendLayout();
			this.tabPageDescription.SuspendLayout();
			this.tabPageComment.SuspendLayout();
			this.tabPageChat.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 25);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tabItemInformation);
			this.splitContainer1.Size = new System.Drawing.Size(800, 425);
			this.splitContainer1.SplitterDistance = 466;
			this.splitContainer1.TabIndex = 0;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.channelList);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.videoList);
			this.splitContainer2.Size = new System.Drawing.Size(466, 425);
			this.splitContainer2.SplitterDistance = 146;
			this.splitContainer2.TabIndex = 0;
			// 
			// channelList
			// 
			this.channelList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.channelList.FormattingEnabled = true;
			this.channelList.Location = new System.Drawing.Point(0, 0);
			this.channelList.Name = "channelList";
			this.channelList.Size = new System.Drawing.Size(466, 146);
			this.channelList.TabIndex = 0;
			this.channelList.SelectedIndexChanged += new System.EventHandler(this.channelList_SelectedIndexChanged);
			// 
			// videoList
			// 
			this.videoList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.videoList.FormattingEnabled = true;
			this.videoList.Location = new System.Drawing.Point(0, 0);
			this.videoList.Name = "videoList";
			this.videoList.Size = new System.Drawing.Size(466, 275);
			this.videoList.TabIndex = 1;
			this.videoList.SelectedIndexChanged += new System.EventHandler(this.videoList_SelectedIndexChanged);
			// 
			// tabItemInformation
			// 
			this.tabItemInformation.Controls.Add(this.tabPageDescription);
			this.tabItemInformation.Controls.Add(this.tabPageComment);
			this.tabItemInformation.Controls.Add(this.tabPageChat);
			this.tabItemInformation.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabItemInformation.Location = new System.Drawing.Point(0, 0);
			this.tabItemInformation.Name = "tabItemInformation";
			this.tabItemInformation.SelectedIndex = 0;
			this.tabItemInformation.Size = new System.Drawing.Size(330, 425);
			this.tabItemInformation.TabIndex = 0;
			// 
			// tabPageDescription
			// 
			this.tabPageDescription.Controls.Add(this.txtDescription);
			this.tabPageDescription.Location = new System.Drawing.Point(4, 22);
			this.tabPageDescription.Name = "tabPageDescription";
			this.tabPageDescription.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDescription.Size = new System.Drawing.Size(322, 399);
			this.tabPageDescription.TabIndex = 0;
			this.tabPageDescription.Text = "概要";
			this.tabPageDescription.UseVisualStyleBackColor = true;
			// 
			// txtDescription
			// 
			this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtDescription.Location = new System.Drawing.Point(3, 3);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtDescription.Size = new System.Drawing.Size(316, 393);
			this.txtDescription.TabIndex = 0;
			// 
			// tabPageComment
			// 
			this.tabPageComment.Controls.Add(this.txtComment);
			this.tabPageComment.Location = new System.Drawing.Point(4, 22);
			this.tabPageComment.Name = "tabPageComment";
			this.tabPageComment.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageComment.Size = new System.Drawing.Size(322, 399);
			this.tabPageComment.TabIndex = 1;
			this.tabPageComment.Text = "コメント";
			this.tabPageComment.UseVisualStyleBackColor = true;
			// 
			// txtComment
			// 
			this.txtComment.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtComment.Location = new System.Drawing.Point(3, 3);
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtComment.Size = new System.Drawing.Size(316, 393);
			this.txtComment.TabIndex = 1;
			// 
			// tabPageChat
			// 
			this.tabPageChat.Controls.Add(this.txtChat);
			this.tabPageChat.Location = new System.Drawing.Point(4, 22);
			this.tabPageChat.Name = "tabPageChat";
			this.tabPageChat.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageChat.Size = new System.Drawing.Size(322, 399);
			this.tabPageChat.TabIndex = 2;
			this.tabPageChat.Text = "チャット";
			this.tabPageChat.UseVisualStyleBackColor = true;
			// 
			// txtChat
			// 
			this.txtChat.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtChat.Location = new System.Drawing.Point(3, 3);
			this.txtChat.Multiline = true;
			this.txtChat.Name = "txtChat";
			this.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtChat.Size = new System.Drawing.Size(316, 393);
			this.txtChat.TabIndex = 1;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addChannelButton,
            this.btnReload});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(800, 25);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// addChannelButton
			// 
			this.addChannelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.addChannelButton.Image = ((System.Drawing.Image)(resources.GetObject("addChannelButton.Image")));
			this.addChannelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.addChannelButton.Name = "addChannelButton";
			this.addChannelButton.Size = new System.Drawing.Size(23, 22);
			this.addChannelButton.Text = "toolStripButton1";
			this.addChannelButton.ToolTipText = "チャンネルを追加";
			this.addChannelButton.Click += new System.EventHandler(this.addChannelButton_Click);
			// 
			// btnReload
			// 
			this.btnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
			this.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnReload.Name = "btnReload";
			this.btnReload.Size = new System.Drawing.Size(23, 22);
			this.btnReload.Text = "再取得";
			this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.tabItemInformation.ResumeLayout(false);
			this.tabPageDescription.ResumeLayout(false);
			this.tabPageDescription.PerformLayout();
			this.tabPageComment.ResumeLayout(false);
			this.tabPageComment.PerformLayout();
			this.tabPageChat.ResumeLayout(false);
			this.tabPageChat.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.CheckedListBox channelList;
		private System.Windows.Forms.CheckedListBox videoList;
		private System.Windows.Forms.TabControl tabItemInformation;
		private System.Windows.Forms.TabPage tabPageDescription;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.TabPage tabPageComment;
		private System.Windows.Forms.TextBox txtComment;
		private System.Windows.Forms.TabPage tabPageChat;
		private System.Windows.Forms.TextBox txtChat;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton addChannelButton;
		private System.Windows.Forms.ToolStripButton btnReload;
	}
}


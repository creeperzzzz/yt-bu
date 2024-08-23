using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yt_bu
{
	public partial class AddChannelDialog : Form
	{
		public AddChannelDialog()
		{
			InitializeComponent();
		}

		public string ChannelId
		{
			get
			{
				return textBox1.Text;
			}
		}
		public bool GetVideos
		{
			get { return chkGetVideos.Checked; }
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}

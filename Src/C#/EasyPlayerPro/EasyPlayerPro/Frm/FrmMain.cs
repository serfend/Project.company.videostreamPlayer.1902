using DotNet4.Utilities.UtilReg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using  EasyPlayerPro;
using EasyPlayerPro.Frm.Setting;

namespace SfPlayer.Frm.Main
{
	public partial class FrmMain : Form
	{

		public FrmMain()
		{
			InitializeComponent();
			
			var bound = RegUtil.GetFormPos(this);
			this.Load += (x, xx) => {
				SetBounds(0,0,Screen.PrimaryScreen.Bounds.Width,Screen.PrimaryScreen.Bounds.Height);
				Program.ShowNotice(5000,
				 $"{EasyPlayerPro.Properties.Settings.Default.Title}已启动",
				"此版本为测试版本，待优化"
				);
				Program.manager = new EasyPlayerManager(this.Handle);
				Program.frmSetting = new FrmSetting();
				Program.frmSetting.Icon = this.Icon;
				Program.frmSetting.Show();
				Program.frmMain.WindowState = FormWindowState.Minimized;
			};
		}

		internal void FrmHide(object v, EventArgs eventArgs)
		{
			this.ShowInTaskbar = false;
			this.Hide();
			var info =   $"{EasyPlayerPro.Properties.Settings.Default.Title}已隐藏并持续在后台运行";
			Program.ShowNotice(5000, info, $"{info},您可以在托盘中双击重新显示", ToolTipIcon.Info);
			Program.Running = false;
		}

		private void InfoShow_DoubleClick(object sender, EventArgs e)
		{
			this.ShowInTaskbar = true;
			this.Show();
			this.Activate();
			Program.Running = true;
		}

		private bool onClosing = false;
		private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!onClosing)
			{
				e.Cancel = true;
				onClosing = true;
				Program.Running = false;
				var t = new Thread(() => {
					this.Invoke((EventHandler)delegate {
						while (this.Opacity > 0.04)
						{
							this.Opacity = this.Opacity * 0.8;
							Thread.Sleep(50);
						}
						this.Close();
					});
				});
				t.Start();
			}

		}

		private void FrmMain_MouseDown(object sender, MouseEventArgs e)
		{
			EasyPlayerAPI.MoveControl(this,e);
		}

		private void FrmMain_DoubleClick(object sender, EventArgs e)
		{
			SetBounds(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
		}
	}
}

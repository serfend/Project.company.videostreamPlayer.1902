using DotNet4.Utilities.UtilInput;
using DotNet4.Utilities.UtilReg;
using Inst;
using Newtonsoft.Json;
using SfPlayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPlayerPro.Frm.Setting
{
	public partial class FrmSetting : Form
	{
		public FrmSetting()
		{
			InitializeComponent();
			this.Load += FrmSetting_Load;
		}

		private void FrmSetting_Load(object sender, EventArgs e)
		{
			for(int i = 1; i <= 16; i++)
			{
				OptPrivilege.Items.Add(i);
			}
			OptPrivilege.SelectedIndex = 0;
			foreach (var i in Enum.GetValues(typeof(EasyPlayerAPI.EASY_STREAM_LINK_MODE))){
				OptProtocal.Items.Add(i);
			}
			OptProtocal.SelectedIndex = 0;
			foreach (var i in Enum.GetValues(typeof(EasyPlayerAPI.EASY_VIDEO_RENDER_TYPE)))
			{
				OptVideoRenderType.Items.Add(i);
			}
			OptVideoRenderType.SelectedIndex = 0;
			foreach (var i in Enum.GetValues(typeof(EasyPlayerAPI.EASY_VIDEO_SCALE_MODE)))
			{
				OptVideoClipType.Items.Add(i);
			}
			OptVideoClipType.SelectedIndex =1;
			var settingVideoFile = Program.manager.RegSetting.In("VideoStream").GetInfo("historyFile");
			if (settingVideoFile.Length>0)
			{
				LoadVideoStreamFromFile(settingVideoFile);
			}
			var settingStageLayoutFile = Program.manager.RegSetting.In("StageLayout").GetInfo("historyFile");
			if (settingStageLayoutFile.Length > 0)
			{
				LoadLayoutStageSettingFromFile(settingStageLayoutFile);
			}
			var frmBound = RegUtil.GetFormPos(this);
			this.SetBounds(frmBound[0], frmBound[1], frmBound[2], frmBound[3]);
		}



		private void FrmSetting_MouseDown(object sender, MouseEventArgs e)
		{
			EasyPlayerAPI.MoveControl(this, e);
		}

		private void FrmSetting_FormClosing(object sender, FormClosingEventArgs e)
		{
			RegUtil.SetFormPos(this);
			e.Cancel = true;
			InfoShower.ShowOnce(new InfoShower()
			{
				ExistTime = 10000,
				Title="无效的操作",
				Info= "如果需要关闭程序，点击此处",
				TitleColor=Color.PaleVioletRed,
				CallBack = () => {
					this.Hide();
					Program.frmMain.Close();
				}
			});
		}


		#region 实现窗体

		private const int Guying_HTLEFT = 10;
		private const int Guying_HTRIGHT = 11;
		private const int Guying_HTTOP = 12;
		private const int Guying_HTTOPLEFT = 13;
		private const int Guying_HTTOPRIGHT = 14;
		private const int Guying_HTBOTTOM = 15;
		private const int Guying_HTBOTTOMLEFT = 0x10;
		private const int Guying_HTBOTTOMRIGHT = 17;
		private const int HTCAPTION = 0x2;
		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case WM_NCPAINT:                        // box shadow
					if (m_aeroEnabled)
					{
						var v = 2;
						DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
						MARGINS margins = new MARGINS()
						{
							bottomHeight = 1,
							leftWidth = 1,
							rightWidth = 1,
							topHeight = 1
						};
						DwmExtendFrameIntoClientArea(this.Handle, ref margins);

					}
					break;
				default:
					base.WndProc(ref m);
					break;
			}
			//base.WndProc(ref m);
		}

		[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
		private static extern IntPtr CreateRoundRectRgn
			(
				int nLeftRect, // x-coordinate of upper-left corner
				int nTopRect, // y-coordinate of upper-left corner
				int nRightRect, // x-coordinate of lower-right corner
				int nBottomRect, // y-coordinate of lower-right corner
				int nWidthEllipse, // height of ellipse
				int nHeightEllipse // width of ellipse
			 );

		[DllImport("dwmapi.dll")]
		public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

		[DllImport("dwmapi.dll")]
		public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

		[DllImport("dwmapi.dll")]
		public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

		private bool m_aeroEnabled;                     // variables for box shadow
		private const int CS_DROPSHADOW = 0x00020000;
		private const int WM_NCPAINT = 0x0085;
		private const int WM_ACTIVATEAPP = 0x001C;

		public struct MARGINS                           // struct for box shadow
		{
			public int leftWidth;
			public int rightWidth;
			public int topHeight;
			public int bottomHeight;
		}

		private const int WM_NCHITTEST = 0x84;          // variables for dragging the form
		private const int HTCLIENT = 0x1;

		protected override CreateParams CreateParams
		{
			get
			{
				m_aeroEnabled = CheckAeroEnabled();

				CreateParams cp = base.CreateParams;
				if (!m_aeroEnabled)
					cp.ClassStyle |= CS_DROPSHADOW;

				return cp;
			}
		}

		private bool CheckAeroEnabled()
		{
			if (Environment.OSVersion.Version.Major >= 6)
			{
				int enabled = 0;
				DwmIsCompositionEnabled(ref enabled);
				return (enabled == 1) ? true : false;
			}
			return false;
		}

		#endregion


	}
}

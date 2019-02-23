using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace EasyPlayerPro.Frm.Setting
{
	public partial class CtlStage : UserControl
	{
		public CtlStage()
		{
			InitializeComponent();
			OnForeColorChanged(EventArgs.Empty);
		}
		private SolidBrush fontBrush;
		protected override void OnForeColorChanged(EventArgs e)
		{
			base.OnForeColorChanged(e);
			fontBrush = new SolidBrush(this.ForeColor);
		}
		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			SynTextPos();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			SynTextPos();
		}
		private void SynTextPos()
		{
			fontModefied = true;
		}
		private bool fontModefied = true;
		private PointF stringPoint=new PointF();
		public override string Text { get => base.Text; set { base.Text = value; SynTextPos(); } }
		protected override void OnPaint(PaintEventArgs e)
		{
			if (fontModefied)
			{
				var strSize = e.Graphics.MeasureString(Text,Font);
				stringPoint = new PointF((Width - strSize.Width)*0.5f, (Height - strSize.Height) * 0.5f);
			}
			e.Graphics.DrawString(this.Text, this.Font, fontBrush, stringPoint.X, stringPoint.Y);
		}

		private void CtlStage_MouseDown(object sender, MouseEventArgs e)
		{
			EasyPlayerAPI.MoveControl((Control)sender, e);
		}
		
		private void CtlStage_MouseUp(object sender, MouseEventArgs e)
		{
			this.OnResize(e);
		}





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
				case 0x0084:
					base.WndProc(ref m);
					Point vPoint = new Point((int)m.LParam & 0xFFFF,
						(int)m.LParam >> 16 & 0xFFFF);
					vPoint = PointToClient(vPoint);
					if (vPoint.X <= 5)
						if (vPoint.Y <= 5)
							m.Result = (IntPtr)Guying_HTTOPLEFT;
						else if (vPoint.Y >= ClientSize.Height - 5)
							m.Result = (IntPtr)Guying_HTBOTTOMLEFT;
						else m.Result = (IntPtr)Guying_HTLEFT;
					else if (vPoint.X >= ClientSize.Width - 5)
						if (vPoint.Y <= 5)
							m.Result = (IntPtr)Guying_HTTOPRIGHT;
						else if (vPoint.Y >= ClientSize.Height - 5)
							m.Result = (IntPtr)Guying_HTBOTTOMRIGHT;
						else m.Result = (IntPtr)Guying_HTRIGHT;
					else if (vPoint.Y <= 5)
						m.Result = (IntPtr)Guying_HTTOP;
					else if (vPoint.Y >= ClientSize.Height - 5)
						m.Result = (IntPtr)Guying_HTBOTTOM;
					else
					{
						m.Result = (IntPtr)HTCAPTION;
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



	}
}

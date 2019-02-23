
using DotNet4.Utilities.UtilReg;
using EasyPlayerPro;
using EasyPlayerPro.Frm.Setting;
using Inst;
using SfPlayer.Frm.Main;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SfPlayer
{
    static class Program
    {

		public static EasyPlayerManager manager;

		public static FrmMain frmMain;
		public static FrmSetting frmSetting;
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
        static void Main()
        {
			if (CheckMutiProcess()) { return; };
			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			frmMain = new FrmMain();
			Application.Run(frmMain);
        }
		internal static void HideProgram()
		{
			frmMain.FrmHide(new object(), new EventArgs());
		}

		public static void ExitProgram()
		{
			try
			{
				newMutex.ReleaseMutex();
				Application.Exit();
			}
			catch (Exception ex)
			{
				Console.WriteLine("ExitProgram()" + ex.Message);

			}
		}
		public static void ShowNotice(int time, string title, string info, ToolTipIcon icon = ToolTipIcon.Info, Action CallBack = null, bool showNoticeInSystem = true)
		{
			if (OnDND) return;
			if (Environment.OSVersion.Version.Major >= 10)
			{
				if (showNoticeInSystem)
				{
					frmMain.InfoShow.ShowBalloonTip(time, title, info, icon);
					nowCallBack = CallBack;
				}

			}
			try
			{
				Program.frmMain.Invoke((EventHandler)delegate
				{//务必给主线程去调用
					var f = new InfoShower() { Title = title, Info = info, ExistTime = time, ToolTip = icon };
					f.CallBack = CallBack;
					InfoShower.ShowOnce(f);
				});
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

		}
		private static Action nowCallBack = null;
		public static void ResponseNoticeClick(object sender, EventArgs e)
		{
			nowCallBack?.Invoke();
		}
		
		public static bool Running { set; get; }
		public static bool UsedFlash { set; get; }
		public static bool OnDND
		{
			set
			{
				EasyPlayerPro.Properties.Settings.Default.DND=value;
			}
			get
			{
				return EasyPlayerPro.Properties.Settings.Default.DND;
			}
		}

		public static bool NowDateIsValid { get; set; }
		public static bool AutoCurrentVersion
		{
			get
			{
				if (CheckAdminUAC())
					return RegUtil.SetRunCurrentVersion(false, true);
				else return false;
			}
			set
			{
				if (CheckAdminUAC())
				{
					ShowNotice(30000, "开机启动", "已" + (value ? "开启" : "关闭") + "开机自动启动\n点击此处取消设置", ToolTipIcon.Warning, () => { AutoCurrentVersion = !value; });
					RegUtil.SetRunCurrentVersion(value);
				}
			}
		}

		public static string ProgramName { get; set; }
		
		public static bool CheckIfWinVistaAbove()
		{
			return (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6);
		}

		internal static void RunAsAdministrator()
		{
			ProcessStartInfo psi = new ProcessStartInfo
			{
				FileName = Application.ExecutablePath,
				Verb = "runas"
			};

			try
			{
				EasyPlayerPro.Properties.Settings.Default.AdminMutiProcessOnce = true;
				Process.Start(psi);
				Application.Exit();
			}
			catch (Exception eee)
			{
				CheckMutiProcess();
				MessageBox.Show(eee.Message, "请求权限失败");
			}
		}
		public static System.Threading.Mutex newMutex;
		public static bool CheckMutiProcess()
		{
			newMutex = new System.Threading.Mutex(true, "sfPlayer", out bool Exist);
			if (Exist)
			{
				newMutex.ReleaseMutex();
			}
			else
			{

				if (EasyPlayerPro.Properties.Settings.Default.AdminMutiProcessOnce)
				{
					EasyPlayerPro.Properties.Settings.Default.AdminMutiProcessOnce = false;
					return false;
				}

				MessageBox.Show("已正在运行,请勿多次开启", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return true;

			}
			return false;
		}

		private static int UACnow = 0;
		public static bool CheckAdminUAC()
		{
			if (Environment.OSVersion.Version.Major >= 6)
			{
				if (UACnow != 0)
				{
					return UACnow == 1;
				}
				WindowsIdentity identity = WindowsIdentity.GetCurrent();
				WindowsPrincipal principal = new WindowsPrincipal(identity);
				bool UAC = principal.IsInRole(WindowsBuiltInRole.Administrator);
				UACnow = UAC ? 1 : -1;
				return UAC;
			}
			else return true;

		}

		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, IntPtr lParam);
		public const UInt32 BCM_SETSHIELD = 0x160C;
		public static void SetControlUACFlag(Control ctl)
		{
			SendMessage(ctl.Handle, BCM_SETSHIELD, 0, (IntPtr)1);
		}
	}
}

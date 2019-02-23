using DotNet4.Utilities;
using DotNet4.Utilities.UtilReg;
using Inst;
using Newtonsoft.Json;
using SfPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPlayerPro
{
	/// <summary>
	/// 用于自动化的布局视频流
	/// </summary>
	public class EasyPlayerManager
	{
		private readonly IntPtr handle;
		private Dictionary<string, Monitor> videoStream;
		private Dictionary<string, LayoutStage> layoutStage;
		private readonly Reg regSetting;
		/// <summary>
		/// 创建新的布局
		/// </summary>
		/// <param name="Handle">视频输出的句柄</param>
		public EasyPlayerManager(IntPtr Handle)
		{
			this.handle = Handle;
			regSetting = new Reg().In("Main").In("Setting").In("EasyPlayerManager");

			VideoStream = new Dictionary<string, Monitor>();
			LayoutStage = new Dictionary<string, LayoutStage>();
		}

		public Dictionary<string, Monitor> VideoStream { get => videoStream; set => videoStream = value; }
		public Dictionary<string, LayoutStage> LayoutStage { get => layoutStage; set => layoutStage = value; }
		[JsonIgnore()]
		public Reg RegSetting => regSetting;

		public bool AddStream(string id,int privilege,EasyPlayer player)
		{
			if (videoStream.ContainsKey(id)) return false;
			player.Hdl = handle;
			var item = new Monitor()
			{
				Id = id,
				Privilege = privilege,
				Player = player
			};
			videoStream.Add(id, item);
			PutVideoStreamItem(item);
			return true;
		}
		public void OnMonitorPrivilegeChanged(Monitor monitor,int privilege)
		{
			VideoStreamPrivilegeQueue.Remove(monitor.Privilege);
			monitor.Privilege = privilege;
			PutVideoStreamItem(monitor);
		}
		public SortedList<int,Monitor> VideoStreamPrivilegeQueue=new SortedList<int,Monitor>();
		public class Monitor
		{
			private string id;
			private EasyPlayer player;
			private int privilege;

			public EasyPlayer Player { get => player; set => player = value; }
			public int Privilege { get => privilege; set {privilege = value;
				} }
			[JsonIgnore()]
			public string Id { get => id; set => id = value; }


		}
		/// <summary>
		/// 通过原始值重新加载列表
		/// </summary>
		/// <param name="info">json数据</param>
		internal void ResetVideoStreamDic(string info)
		{
			try
			{
				VideoStreamPrivilegeQueue = new SortedList<int, Monitor>();
				videoStream = JsonConvert.DeserializeObject<Dictionary<string, Monitor>>(info);
				InfoShower.ShowOnce(new InfoShower()
				{
					Title = "加载视频流预设",
					Info = $"预设文件读取成功,共计:{videoStream.Count}条",
					ExistTime = 5000,
					TitleColor = System.Drawing.Color.LawnGreen
				});

				foreach(var item in videoStream)
				{
					item.Value.Id = item.Key;
					item.Value.Player.Hdl = this.handle;
					PutVideoStreamItem(item.Value);
				}
			}
			catch (Exception ex)
			{
				InfoShower.ShowOnce(new InfoShower() {
					Title="加载视频流预设",
					Info=$"预设文件读取失败:{ex.Message}",
					ExistTime=5000,
					TitleColor=System.Drawing.Color.Red
				});
			}
			Program.frmSetting.ReloadLstVideoStream();
		}

		private void PutVideoStreamItem(Monitor value,bool isRoot=true)
		{
			while (VideoStreamPrivilegeQueue.ContainsKey(value.Privilege))
			{
				var item = VideoStreamPrivilegeQueue[value.Privilege];
				VideoStreamPrivilegeQueue.Remove(value.Privilege);
				item.Privilege++;
				PutVideoStreamItem(item, false);
			}
			VideoStreamPrivilegeQueue.Add(value.Privilege, value);

		}
	}
}

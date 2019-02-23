using EasyPlayerPro.EasyPlayerPro;
using Newtonsoft.Json;
using SfPlayer.Frm.Main;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyPlayerPro
{
	public class EasyPlayer:IPlayer
	{
		static EasyPlayer()
		{
			try
			{
				int nRet = EasyPlayerAPI.Authorize(ACTIVE_KEY);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"初始化EasyPlayer失败:{ex.Message}");
			}
			
		}
		#region 标准
		private const string ACTIVE_KEY = "64687538665969576B5A754144474A636F35337A4A65354659584E35554778686557567955484A764C6D56345A56634D5671442F70654E4659584E355247467964326C755647566862556C7A5647686C516D567A644541794D4445345A57467A65513D3D";
		private EasyPlayerAPI.EASY_VIDEO_RENDER_TYPE renderType;
		private EasyPlayerAPI.EASY_VIDEO_SCALE_MODE scaleMode;
		private EasyPlayerAPI.EASY_STREAM_LINK_MODE linkMode;
		private string path;
		private IntPtr hdl;
		private int speed = 100;
		private int volume = 0;
		private IntPtr player;

		public EasyPlayer(EasyPlayerAPI.EASY_VIDEO_RENDER_TYPE renderType, EasyPlayerAPI.EASY_VIDEO_SCALE_MODE scaleMode, EasyPlayerAPI.EASY_STREAM_LINK_MODE linkMode, string path, IntPtr hdl)
		{
			this.renderType = renderType;
			this.scaleMode = scaleMode;
			this.linkMode = linkMode;
			this.path = path;
			this.hdl = hdl;
			this.player = EasyPlayerAPI.Create();
			nowRect = new Rectangle();
			EaseoutMoving(nowRect);
		}
		public void Init()
		{
			player = EasyPlayerAPI.Open(player, path, hdl, EasyPlayerAPI.EASY_VIDEO_RENDER_TYPE.EASY_VIDEO_RENDER_TYPE_GDI,
   EasyPlayerAPI.EASY_VIDEO_SCALE_MODE.EASY_VIDEO_MODE_LETTERBOX, EasyPlayerAPI.EASY_STREAM_LINK_MODE.EASY_STREAM_LINK_TCP, Speed, Volume);
			IsInit = true;
		}
		public void Play()
		{
			EasyPlayerAPI.Play(player);
			IsPlaying = true;
		}
		~EasyPlayer()
		{
			Dispose();
		}
		private bool isPlaying = false;
		private bool isInit;
		public void Dispose()
		{
			if (IsPlaying)
				EasyPlayerAPI.Close(player);
			if (IsInit)
				EasyPlayerAPI.Release(player);
			player = IntPtr.Zero;
			IsInit = false;
		}

		public void Pause()
		{
			EasyPlayerAPI.Pause(player);
		}

		public void Stop()
		{
			EasyPlayerAPI.Close(player);
			IsPlaying = false;
		}

		public void SetBounds(int x, int y, int width, int height)
		{
			
			nowRect.X = x;
			nowRect.Y = y;
			nowRect.Width = width;
			nowRect.Height = height;
			Console.WriteLine(nowRect);
			EasyPlayerAPI.Resize(player, 0, x, y, width, height);
		}

		/// <summary>
		/// 视频播放截图
		/// </summary>
		/// <param name="file"> 图片存放路径，以.xxx结束（xxx 目前只支持 jpeg 格式）</param>
		/// <param name="width">指定图片宽高，如果 <= 0 则默认使用视频宽高</param>
		/// <param name="height">指定图片宽高，如果 <= 0 则默认使用视频宽高</param>
		/// <param name="waitTime">是否等待截图完成 0 - 不等待，>0 等待超时 ms 为单位</param>
		public void SnapShot(string file, int width = 0, int height = 0, int waitTime = 0)
		{
			EasyPlayerAPI.Snapshot(player, file, width, height, waitTime);
		}

		public EasyPlayerAPI.EASY_VIDEO_RENDER_TYPE RenderType { get => renderType; set => renderType = value; }
		public EasyPlayerAPI.EASY_VIDEO_SCALE_MODE ScaleMode { get => scaleMode; set => scaleMode = value; }
		public EasyPlayerAPI.EASY_STREAM_LINK_MODE LinkMode { get => linkMode; set => linkMode = value; }
		public string Path { get => path; }
		[JsonIgnore()]
		public IntPtr Hdl { get => hdl; set => hdl = value; }
		[JsonIgnore()]
		public IntPtr Player { get => player; }
		[JsonIgnore()]
		public bool IsPlaying { get => isPlaying; set => isPlaying = value; }
		[JsonIgnore()]
		public bool IsInit { get => isInit; private set => isInit = value; }
		/// <summary>
		/// 播放速度，0-100慢放，100以上快放
		/// </summary>
		public int Speed
		{
			get => speed; set
			{
				IntPtr ptr = (IntPtr)value;
				speed = value;
				EasyPlayerAPI.Setparam(player, EasyPlayerAPI.EASY_PARAM_ID.EASY_PARAM_PLAY_SPEED, ref ptr);
			}
		}
		/// <summary>
		/// 播放音量，-255 - +255
		/// </summary>
		public int Volume
		{
			get => volume; set
			{
				unsafe
				{
					volume = value;
					IntPtr p = new IntPtr(&value);
					EasyPlayerAPI.Setparam(player, EasyPlayerAPI.EASY_PARAM_ID.EASY_PARAM_AUDIO_VOLUME, ref p);
				}


			}
		}
		#endregion
		#region 平滑移动
		private Rectangle nowRect;
		private const int flashInterval = 30;
		/// <summary>
		/// 动画移动视频
		/// 0.5*a*t^2=s  =>  a=2s/t^2  pos(t)=pos(0)+s/T^2*t^2
		/// </summary>
		/// <param name="target">目标位置</param>
		/// <param name="duration">动画总时间ms</param>
		public void EaseoutMoving(Rectangle target,int duration=500) {
			var movingThread = new Thread(() => {
				int startTime = Environment.TickCount;
				Rectangle startRect = new Rectangle(nowRect.X,nowRect.Y,nowRect.Width,nowRect.Height);
				double dx = (startRect.X - target.X);
				double dy = (startRect.Y - target.Y);
				double dw = (startRect.Width - target.Width);
				double dh = (startRect.Height - target.Height);
				bool ending = false;
				do
				{
					int nowTimeStamp = duration- Environment.TickCount+ startTime;
					if (nowTimeStamp <0)
					{
						//SetBounds(target.X, target.Y, target.Width, target.Height);
						ending = true;
					}
					else
					{
						SetBounds(
							(int)(target.X + dx * Math.Pow(nowTimeStamp / (double)duration, 2)),
							(int)(target.Y + dy * Math.Pow(nowTimeStamp/ (double)duration, 2)),
							(int)(target.Width + dw * Math.Pow(nowTimeStamp/ (double)duration, 2)),
							(int)(target.Height + dh * Math.Pow(nowTimeStamp/(double)duration, 2))
							);
					}
					Thread.Sleep(flashInterval);
				} while (!ending);
			}) { IsBackground=true};
			movingThread.Start();
		}
		#endregion
	}
}

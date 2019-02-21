using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPlayerPro
{
	public class EasyPlayer
	{
		static EasyPlayer()
		{
			int nRet = EasyPlayerAPI.Authorize(ACTIVE_KEY);
		}
		private  const string ACTIVE_KEY = "64687538665969576B5A754144474A636F35337A4A65354659584E35554778686557567955484A764C6D56345A56634D5671442F70654E4659584E355247467964326C755647566862556C7A5647686C516D567A644541794D4445345A57467A65513D3D";
		private EasyPlayerAPI.EASY_VIDEO_RENDER_TYPE renderType;
		private EasyPlayerAPI.EASY_VIDEO_SCALE_MODE scaleMode;
		private EasyPlayerAPI.EASY_STREAM_LINK_MODE linkMode;
		private string path;
		private IntPtr hdl;
		private int speed=100;
		private int volume = 100;
		private IntPtr player;

		public EasyPlayer(EasyPlayerAPI.EASY_VIDEO_RENDER_TYPE renderType, EasyPlayerAPI.EASY_VIDEO_SCALE_MODE scaleMode, EasyPlayerAPI.EASY_STREAM_LINK_MODE linkMode, string path, IntPtr hdl)
		{
			this.renderType = renderType;
			this.scaleMode = scaleMode;
			this.linkMode = linkMode;
			this.path = path;
			this.hdl = hdl;
			this.player = EasyPlayerAPI.Create();
			player = EasyPlayerAPI.Open(player, path, hdl, EasyPlayerAPI.EASY_VIDEO_RENDER_TYPE.EASY_VIDEO_RENDER_TYPE_GDI,
   EasyPlayerAPI.EASY_VIDEO_SCALE_MODE.EASY_VIDEO_MODE_LETTERBOX, EasyPlayerAPI.EASY_STREAM_LINK_MODE.EASY_STREAM_LINK_TCP,Speed, volume);
		}

		private bool isPlaying = false;
		private bool isInit;
		~EasyPlayer()
		{
			if (isPlaying)
				EasyPlayerAPI.Close(player);
			if (IsInit)
				EasyPlayerAPI.Release(player);
			player = IntPtr.Zero;
			IsInit = false;
		}
		public EasyPlayerAPI.EASY_VIDEO_RENDER_TYPE RenderType { get => renderType;}
		public EasyPlayerAPI.EASY_VIDEO_SCALE_MODE ScaleMode { get => scaleMode; }
		public EasyPlayerAPI.EASY_STREAM_LINK_MODE LinkMode { get => linkMode; }
		public string Path { get => path; }
		public IntPtr Hdl { get => hdl;  }
		public IntPtr Player { get => player; }
		public bool IsInit { get => isInit;private set => isInit = value; }
		public int Speed { get => speed; set => speed = value; }
	}
}

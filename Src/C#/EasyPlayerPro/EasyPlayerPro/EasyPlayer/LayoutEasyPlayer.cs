using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace EasyPlayerPro
{
	public class LayoutEasyPlayer : EasyPlayer
	{
		public LayoutEasyPlayer(EasyPlayerAPI.EASY_VIDEO_RENDER_TYPE renderType, EasyPlayerAPI.EASY_VIDEO_SCALE_MODE scaleMode, EasyPlayerAPI.EASY_STREAM_LINK_MODE linkMode, string path, IntPtr hdl) : base(renderType, scaleMode, linkMode, path, hdl)
		{

		}
		
	}

	/// <summary>
	/// 实现依据布局自动规划
	/// </summary>
	public class LayoutStage:ICloneable
	{
		

		private List<Stage> list;

		private string name;
		private string structPath;
		[JsonProperty("structPath")]
		public string StructPath { get => structPath; set => structPath = value; }
		[JsonProperty("name")]
		public string Name { get => name; set => name = value; }
		[JsonProperty("stages")]
		public List<Stage> List { get => list; set => list = value; }

		public object Clone()
		{
			var result= new LayoutStage() {
				List = new List<Stage>(),
				StructPath=structPath,
				Name=name
			};
			foreach(var item in list)
			{
				result.list.Add((Stage)item.Clone());
			}
			return result;
		}

		public class Stage:ICloneable
		{
			private int index;
			private float x, y, w, h;

			public float X { get => x; set => x = value; }
			public float Y { get => y; set => y = value; }
			public float W { get => w; set => w = value; }
			public float H { get => h; set => h = value; }
			public int Index { get => index; set => index = value; }

			public object Clone()
			{
				return new Stage() {
					x=x,
					y=y,
					w=w,
					h=h,
					index=index
				};
			}
		}

	}
}

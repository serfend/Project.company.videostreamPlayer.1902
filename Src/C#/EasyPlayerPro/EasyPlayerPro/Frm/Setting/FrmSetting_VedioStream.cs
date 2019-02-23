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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPlayerPro.Frm.Setting
{
	public partial class FrmSetting
	{

		private void OptProtocal_SelectedIndexChanged(object sender, EventArgs e)
		{
			var raw = OptProtocal.Items[OptProtocal.SelectedIndex].ToString().ToLower();
			if (raw.Contains("tcp"))
			{
				ReplaceSrcProtocal("rtmp://");
			}
			else if (raw.Contains("udp"))
			{
				ReplaceSrcProtocal("udp://");
			}
			else if (raw.Contains("num"))
			{
				ReplaceSrcProtocal("src://");
			}
		}

		private void ReplaceSrcProtocal(string v)
		{
			int index = IPStreamSrc.Text.IndexOf("://");
			if (index > 0)
			{
				index += 3;
			}
			else
			{
				index = 0;
			}
			IPStreamSrc.Text = $"{v}{IPStreamSrc.Text.Substring(index)}";
		}

		internal void ReloadLstVideoStream()
		{
			LstVideoStream.Items.Clear();
			foreach (var item in Program.manager.VideoStream)
			{
				LoadDataFromItem(item.Key, item.Value);
			}
		}

		private void LstVideoStream_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (LstVideoStream.SelectedItems.Count == 0) return;
			var item = LoadDataFromEntity(LstVideoStream.SelectedItems[0].SubItems[0].Text);
			IpStreamID.Text = item.Id;
			IPStreamSrc.Text = item.Player.Path;
			OptProtocal.SelectedIndex = (int)item.Player.LinkMode;
			OptVideoClipType.SelectedIndex = (int)item.Player.ScaleMode;
			OptVideoRenderType.SelectedIndex = (int)item.Player.RenderType;
			OptPrivilege.SelectedIndex = (item.Privilege <1?1:item.Privilege)  -1;
			IpStreamVolume.Value = (int)(((item.Player.Volume+255) / (double)510) * 100 );
		}

		private void CmdAddItem_Click(object sender, EventArgs e)
		{
			SynItem();
		}
		/// <summary>
		/// 依据id，从当前已加载的库中加载视频流
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		private EasyPlayerManager.Monitor LoadDataFromEntity(string id)
		{
			if (Program.manager.VideoStream.ContainsKey(id))
			{

				return Program.manager.VideoStream[id];

			}
			return null;
		}

		/// <summary>
		/// 从实体新增新的视频流项
		/// </summary>
		/// <param name="id"></param>
		/// <param name="item"></param>
		private void LoadDataFromItem(string id, EasyPlayerManager.Monitor item)
		{
			int index = GetLstStreamItem(id);
			if (index >= 0)
			{
				LstVideoStream.Items.RemoveAt(index);
			}
			var data = new string[4] {
					id,
					item.Player.Path,
					item.Player.LinkMode.ToString().Substring(item.Player.LinkMode.ToString().LastIndexOf("_")+1),
					item.Privilege.ToString()
				};
			LstVideoStream.Items.Add(new ListViewItem(data));
		}

		/// <summary>
		/// 依据id在列表中搜索视频流
		/// </summary>
		/// <param name="id"></param>
		/// <param name="keyIndex"></param>
		/// <returns></returns>
		private int GetLstStreamItem(string id, int keyIndex = 0)
		{
			for (int i = 0; i < LstVideoStream.Items.Count; i++)
			{
				if (LstVideoStream.Items[i].SubItems[keyIndex].Text == id)
				{
					return i;
				}
			}
			return -1;
		}
		/// <summary>
		/// 保存当前视频流
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CmdSaveItem_Click(object sender, EventArgs e)
		{
			SynItem(true);
		}

		/// <summary>
		/// 同步视频流信息
		/// </summary>
		/// <param name="isEdit"></param>
		private void SynItem(bool isEdit = false)
		{
			string id = string.Empty;
			if (isEdit)
			{
				id = GetNowSelectedStreamItem();
			}
			else
			{
				id = IpStreamID.Text;
			}
			if (id == null) return;
			if (id.Length == 0)
			{
				Program.ShowNotice(5000, "编辑流信息", "流的ID不能为空，已为您设置为默认值", ToolTipIcon.Warning);
				IpStreamID.Text = "默认的输入源";
				return;
			}
			var item = new EasyPlayer((EasyPlayerAPI.EASY_VIDEO_RENDER_TYPE)OptVideoRenderType.SelectedIndex, (EasyPlayerAPI.EASY_VIDEO_SCALE_MODE)OptVideoClipType.SelectedIndex, (EasyPlayerAPI.EASY_STREAM_LINK_MODE)OptProtocal.SelectedIndex, IPStreamSrc.Text, IntPtr.Zero)
			{
				//Speed=Convert.ToInt32()
				Volume = (int)(IpStreamVolume.Value * 5.1 - 255)
			};
			if (!isEdit || id != IpStreamID.Text)
			{
				if (Program.manager.AddStream(IpStreamID.Text, Convert.ToInt32(OptPrivilege.SelectedIndex)+1, item))
				{
					var entity = LoadDataFromEntity(IpStreamID.Text);
					if (entity != null) LoadDataFromItem(IpStreamID.Text, entity);
					Program.ShowNotice(5000, "编辑流信息", $"已新增ID为{IpStreamID.Text}的流", ToolTipIcon.Info);
				}
				else
				{
					Program.ShowNotice(5000, "编辑流信息", $"编辑失败,已存在ID为{IpStreamID.Text}的流", ToolTipIcon.Warning);
				};
			}
			else if (isEdit)
			{
				Program.manager.VideoStream[id].Player = item;
				Program.manager.OnMonitorPrivilegeChanged(Program.manager.VideoStream[id], Convert.ToInt32(OptPrivilege.SelectedIndex)+1);
				var entity = LoadDataFromEntity(id);
				if (entity != null) LoadDataFromItem(id, entity);
				Program.ShowNotice(5000, "编辑流信息", $"编辑成功,已编辑ID为{IpStreamID.Text}的流", ToolTipIcon.Warning);
			}
			ReloadLstVideoStream();
			RelocateLstVideoStream();	
		}
		private class LstVideoCmpByPrivilege :System.Collections.IComparer
		{
			public int Compare(object x, object y)
			{
				var result= Convert.ToInt32(((ListViewItem)x).SubItems[3].Text) - Convert.ToInt32(((ListViewItem)y).SubItems[3].Text); 
				return result;
			}

		}
		private void RelocateLstVideoStream()
		{
			LstVideoStream.ListViewItemSorter = new LstVideoCmpByPrivilege();
			LstVideoStream.Sort();
		}

		private string GetNowSelectedStreamItem()
		{
			if (LstVideoStream.SelectedItems.Count == 0)
			{
				var lstCount = LstVideoStream.Items.Count;
				Program.ShowNotice(5000, "编辑流信息", $"未选中需要编辑的流，{(lstCount > 0 ? "已为您选中第一项" : "当前无任何流信息，请先添加")}", ToolTipIcon.Warning);
				if (lstCount > 0)
				{
					LstVideoStream.Focus();
					LstVideoStream.Items[0].Selected = true;
				}
				return null;
			}
			return LstVideoStream.SelectedItems[0].SubItems[0].Text;
		}

		private void CmdRemoveItem_Click(object sender, EventArgs e)
		{
			var id = GetNowSelectedStreamItem();
			if (id == null) return;
			InfoShower.ShowOnce(new InfoShower()
			{
				ExistTime = 10000,
				Title = "删除流信息",
				Info = $"确定要删除流:{id}吗？\n删除后您仍然可以从旧的文件中重新加载",
				TitleColor = Color.PaleVioletRed,
				CallBack = () =>
				{
					Program.manager.VideoStream.Remove(id);
					LstVideoStream.Items.RemoveAt(GetLstStreamItem(id));
					InfoShower.ShowOnce(new InfoShower()
					{
						ExistTime = 5000,
						Title = "删除流信息",
						Info = $"已成功删除流:{id}",
						TitleColor = Color.LightSeaGreen
					});
				}
			});
		}
		private const string vedioStreamListTypeName = "vl";
		private void CmdSaveSetting_Click(object sender, EventArgs e)
		{

			var f = new SaveFileDialog()
			{
				Title = "保存流信息组",
				Filter = $"{vedioStreamListTypeName}|*.{vedioStreamListTypeName}",
				FileName = $"{DateTime.Now.ToString("yyyyMMdd_hhmmss")}.{vedioStreamListTypeName}"
			};
			if (f.ShowDialog() == DialogResult.OK)
			{
				var info = JsonConvert.SerializeObject(Program.manager.VideoStream);
				File.WriteAllText(f.FileName.EndsWith($".{vedioStreamListTypeName}") ? f.FileName : $"{f.FileName}.{vedioStreamListTypeName}", info);
			}
		}

		private void CmdLoadSetting_Click(object sender, EventArgs e)
		{
			var f = new OpenFileDialog()
			{
				Title = "载入流信息组",
				Filter = $"{vedioStreamListTypeName}|*.{vedioStreamListTypeName}",
				FileName = $"{DateTime.Now.ToString("yyyyMMdd_hhmmss")}.{vedioStreamListTypeName}"
			};
			if (f.ShowDialog() == DialogResult.OK)
			{
				LoadVideoStreamFromFile(f.FileName);
			}
		}
		private void LoadVideoStreamFromFile(string fileName)
		{
			var info = File.ReadAllText(fileName);
			Program.manager.ResetVideoStreamDic(info);
			Program.manager.RegSetting.In("VideoStream").SetInfo("historyFile", fileName);
			RelocateLstVideoStream();
		}
	}
}

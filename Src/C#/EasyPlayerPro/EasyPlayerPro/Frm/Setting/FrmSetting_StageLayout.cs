using DotNet4.Utilities.UtilInput;
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
		private void NewStageLayout(string id=null,string path=null, LayoutStage layoutStage =null)
		{
			if(id==null)id = InputBox.ShowInputBox("新增布局", "输入布局的名称", "默认的布局");
			if(path==null)path = InputBox.ShowInputBox("新增布局", "输入布局的位置[可选]", LstLayout.SelectedNode == null ? "Root" : LstLayout.SelectedNode.FullPath);
			path = path.StartsWith("Root\\") ? path.Substring(5) : path;
			if (path.Equals("Root")) path = string.Empty;
			var realPath = $"Root{(path.Equals(string.Empty) ? "" : "\\")}{path}\\{id}";
			if (Program.manager.LayoutStage.ContainsKey(realPath))
			{
				InfoShower.ShowOnce(new InfoShower()
				{
					Title = "新增布局",
					Info = $"已存在布局:{realPath}\n已为您切换到此布局",
					ExistTime = 5000,
					TitleColor = Color.PaleVioletRed
				});
				LoadPreviewStageLayout(realPath);
				return;
			};
			LoadLayoutStageToLst(id, path);
			Program.manager.LayoutStage.Add(realPath, layoutStage);
		}
		 
		private void CmdSaveNewStageLayout_Click(object sender, EventArgs e)
		{
			if(!CheckFocusStageLayout("依据现有项新增"))return;
			NewStageLayout(null, nowFocusStage.StructPath, (LayoutStage)nowFocusStage.Clone());
		}
		private void CmdLayoutNew_Click(object sender, EventArgs e)
		{
			NewStageLayout();
		}
		/// <summary>
		/// 通过路径和id加载到StageLayout界面列表中
		/// </summary>
		/// <param name="id"></param>
		/// <param name="path"></param>
		private void LoadLayoutStageToLst(string id,string path)
		{
			path = path.StartsWith("Root\\") ? path.Substring(5) : path;
			if (path.Equals("Root")) path = string.Empty;
			var paths = path.Split('\\');
			var resultNode = LstLayout.Nodes["Root"];
			foreach (var p in paths)
			{
				if (p.Equals(string.Empty)) continue;
				var tmpNode = resultNode.Nodes[p];
				if (tmpNode == null) tmpNode = resultNode.Nodes.Add(p,p);
				resultNode = tmpNode;
			}
			resultNode.Nodes.Add(id, id);
		}

		private const string StageLayoutListTypeName = "sll";
		private void CmdLayoutSave_Click(object sender, EventArgs e)
		{
			var f = new SaveFileDialog() {
				Title = "保存布局",
				Filter = $"{StageLayoutListTypeName}|*.{StageLayoutListTypeName}",
				FileName=$"{DateTime.Now.ToString("yyyyMMdd_hhmmss")}.{StageLayoutListTypeName}"
			};
			if (f.ShowDialog() == DialogResult.OK)
			{
				if (!f.FileName.EndsWith($".{StageLayoutListTypeName}")) f.FileName = $"{f.FileName}.{StageLayoutListTypeName}";
				File.WriteAllText(f.FileName,JsonConvert.SerializeObject(Program.manager.LayoutStage));
				InfoShower.ShowOnce(new InfoShower() {
					Title="保存布局成功",
					Info=$"已存储{Program.manager.LayoutStage.Count}条到\n{f.FileName}",
					ExistTime=5000,
					TitleColor=Color.LawnGreen
				});
			}
		}

		private void CmdLayoutLoad_Click(object sender, EventArgs e)
		{
			var f = new OpenFileDialog() {
				Title = "载入布局",
				Filter = $"{StageLayoutListTypeName}|*.{StageLayoutListTypeName}",
				FileName = $"{DateTime.Now.ToString("yyyyMMdd_hhmmss")}.{StageLayoutListTypeName}"
			};
			if (f.ShowDialog() == DialogResult.OK)
			{
				LoadLayoutStageSettingFromFile(f.FileName);
			}
		}

		private void LoadLayoutStageSettingFromFile(string fileName)
		{
			if (!fileName.EndsWith($".{StageLayoutListTypeName}")) fileName = $"{fileName}.{StageLayoutListTypeName}";
			var info = File.ReadAllText(fileName);
			try
			{
				Program.manager.LayoutStage = JsonConvert.DeserializeObject<Dictionary<string, LayoutStage>>(info);
				ReloadLstLayoutStage();
			}
			catch (Exception ex)
			{
				InfoShower.ShowOnce(new InfoShower()
				{
					Title = "载入布局失败",
					Info = $"发生错误:{ex.Message}",
					ExistTime = 5000,
					TitleColor = Color.PaleVioletRed
				});
			}
			InfoShower.ShowOnce(new InfoShower()
			{
				Title = "载入布局成功",
				Info = $"预设文件读取成功,共计:{Program.manager.LayoutStage.Count}条",
				ExistTime = 5000,
				TitleColor = Color.LawnGreen
			});
			Program.manager.RegSetting.In("StageLayout").SetInfo("historyFile",fileName);
		}

		private void ReloadLstLayoutStage()
		{
			LstLayout.Nodes.Clear();
			LstLayout.Nodes.Add("Root", "Root");
			foreach(var item in Program.manager.LayoutStage)
			{
				var endPos = item.Key.LastIndexOf($"\\{item.Value.Name}",StringComparison.CurrentCulture);
				LoadLayoutStageToLst(item.Value.Name, item.Key.Substring(0,endPos));
			}
		}

		/// <summary>
		/// 删除当前选中的布局
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CmdRemoveLayout_Click(object sender, EventArgs e)
		{
			if (!CheckFocusStageLayout("删除布局")) return;
			RemoveStageLayout(LstLayout.SelectedNode.FullPath);
			LstLayout.SelectedNode.Remove();
		}

		private void RemoveStageLayout(string fullPath)
		{
			if (!CheckExistStageLayout(fullPath)) return;
			//var item = Program.manager.LayoutStage[fullPath];
			Program.manager.LayoutStage.Remove(fullPath);
		}

		private void LstLayout_AfterSelect(object sender, TreeViewEventArgs e)
		{
			LoadPreviewStageLayout(e.Node.FullPath);
		}

		/// <summary>
		/// 应用当前布局到显示
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CmdStageApply_Click(object sender, EventArgs e)
		{
			int countCanPlay = nowFocusStage.List.Count;
			int nowIndex = 1;
			foreach (var item in Program.manager.VideoStreamPrivilegeQueue)
			{
				var p = item.Value.Player;
				if (countCanPlay<nowIndex)
				{
					//在可用范围以后的视频均不允许播放 
					if (p.IsInit && p.IsPlaying) p.Stop();
				}
				else
				{
					if(!p.IsInit)
						p.Init();
					var targetStage = nowFocusStage.List.Find((x)=> x.Index == nowIndex );
					if(!p.IsPlaying)
						p.Play();
					p.EaseoutMoving(
						new Rectangle(
							(int)(Program.frmMain.Width * targetStage.X),
							(int)(Program.frmMain.Height * targetStage.Y),
							(int)(Program.frmMain.Width * targetStage.W),
							(int)(Program.frmMain.Height * targetStage.H)
						));
				}
				nowIndex++;
			}
		}

	}
}

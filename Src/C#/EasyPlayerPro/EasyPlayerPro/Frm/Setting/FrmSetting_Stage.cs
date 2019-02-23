using Inst;
using SfPlayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EasyPlayerPro.EasyPlayerManager;

namespace EasyPlayerPro.Frm.Setting
{
	public partial class FrmSetting
	{
		private LayoutStage nowFocusStage;
		private void LoadPreviewStageLayout(string text)
		{
			if (!CheckExistStageLayout(text)) return;
			nowFocusStage = Program.manager.LayoutStage[text];
			SynStage(nowFocusStage);
		}

		private bool CheckExistStageLayout(string text)
		{
			if (!Program.manager.LayoutStage.ContainsKey(text))
			{
				InfoShower.ShowOnce(new InfoShower()
				{
					Title = "切换布局",
					Info = $"未能在已加载项中找到布局：\n{text}",
					ExistTime = 10000,
					TitleColor = Color.PaleVioletRed
				});
				return false;
			}
			return true;
		}

		private void CmdStageAdd_Click(object sender, EventArgs e)
		{
			if (!CheckFocusStageLayout("新增机位")) return;
			nowFocusStage.List.Add(new LayoutStage.Stage() {
				X=0.4f,
				Y=0.4f,
				W=0.2f,
				H=0.2f,
				Index=nowFocusStage.List.Count+1
			});
			SynStage(nowFocusStage);
		}

		private bool CheckFocusStageLayout(string actionName)
		{
			if (nowFocusStage == null)
			{
				InfoShower.ShowOnce(new InfoShower()
				{
					Title = "编辑布局",
					Info = $"{actionName}失败:当前未选中布局",
					ExistTime = 5000,
					TitleColor = Color.PaleVioletRed
				});
				return false;
			}
			return true;
		}

		/// <summary>
		/// 将Stage展现
		/// </summary>
		/// <param name="stage"></param>
		private void SynStage(LayoutStage stage)
		{
			OpStageLayoutName.Text = stage.Name;
			OpPreview.Controls.Clear();
			foreach (var item in stage.List)
			{
				var ctl = new CtlStage()
				{
					Text = item.Index.ToString(),
					Left = (int)(item.X * OpPreview.Width),
					Top = (int)(item.Y * OpPreview.Height),
					Width = (int)(item.W * OpPreview.Width),
					Height = (int)(item.H * OpPreview.Height),
					Parent = OpPreview,
					BackColor = Color.LawnGreen,
					Tag=item,
					
				};
				ctl.Resize += Ctl_Resize;
				ctl.Move += Ctl_Resize;
			}

		}

		private void Ctl_Resize(object sender, EventArgs e)
		{
			SynNewCtrlStage(sender);
		}

		//private Queue 用于用户操作队列


		private void SynNewCtrlStage(object sender)
		{
			var ctl = (Control)sender;
			var item = (LayoutStage.Stage)(ctl).Tag;
			item.X = ctl.Left / (float)OpPreview.Width;
			item.Y = ctl.Top / (float)OpPreview.Height;
			item.W = ctl.Width / (float)OpPreview.Width;
			item.H = ctl.Height / (float)OpPreview.Height;
		}

		
	}
}

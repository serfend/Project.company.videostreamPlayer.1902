﻿namespace EasyPlayerPro.Frm.Setting
{
	partial class CtlStage
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// CtlStage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(5);
			this.Name = "CtlStage";
			this.Size = new System.Drawing.Size(346, 133);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CtlStage_MouseDown);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CtlStage_MouseUp);
			this.ResumeLayout(false);

		}

		#endregion
	}
}

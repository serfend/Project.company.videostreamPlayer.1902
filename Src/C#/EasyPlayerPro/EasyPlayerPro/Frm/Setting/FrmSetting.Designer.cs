namespace EasyPlayerPro.Frm.Setting
{
	partial class FrmSetting
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Root");
			this.LstVideoStream = new System.Windows.Forms.ListView();
			this.LstVideoStream_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.LstVideoStream_Src = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.LstVideoStream_Protocol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.LstVideoStream_Privilege = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.CmdSaveItem = new System.Windows.Forms.Button();
			this.CmdRemoveItem = new System.Windows.Forms.Button();
			this.GrpDetail = new System.Windows.Forms.GroupBox();
			this.IpStreamVolume = new System.Windows.Forms.TrackBar();
			this.label7 = new System.Windows.Forms.Label();
			this.OptVideoClipType = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.OptVideoRenderType = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.OptPrivilege = new System.Windows.Forms.ComboBox();
			this.OptProtocal = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.IPStreamSrc = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.IpStreamID = new System.Windows.Forms.TextBox();
			this.CmdLoadSetting = new System.Windows.Forms.Button();
			this.CmdSaveSetting = new System.Windows.Forms.Button();
			this.LstLayout = new System.Windows.Forms.TreeView();
			this.CmdLayoutLoad = new System.Windows.Forms.Button();
			this.CmdLayoutSave = new System.Windows.Forms.Button();
			this.CmdRemoveLayout = new System.Windows.Forms.Button();
			this.OpPreview = new System.Windows.Forms.Panel();
			this.CmdAddItem = new System.Windows.Forms.Button();
			this.CmdLayoutNew = new System.Windows.Forms.Button();
			this.CmdStageAdd = new System.Windows.Forms.Button();
			this.CmdStageRemove = new System.Windows.Forms.Button();
			this.OpStageLayoutName = new System.Windows.Forms.Label();
			this.CmdSaveNewStageLayout = new System.Windows.Forms.Button();
			this.CmdStageApply = new System.Windows.Forms.Button();
			this.GrpDetail.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.IpStreamVolume)).BeginInit();
			this.SuspendLayout();
			// 
			// LstVideoStream
			// 
			this.LstVideoStream.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LstVideoStream_Name,
            this.LstVideoStream_Src,
            this.LstVideoStream_Protocol,
            this.LstVideoStream_Privilege});
			this.LstVideoStream.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.LstVideoStream.Location = new System.Drawing.Point(11, 267);
			this.LstVideoStream.Name = "LstVideoStream";
			this.LstVideoStream.Size = new System.Drawing.Size(375, 322);
			this.LstVideoStream.TabIndex = 0;
			this.LstVideoStream.UseCompatibleStateImageBehavior = false;
			this.LstVideoStream.View = System.Windows.Forms.View.Details;
			this.LstVideoStream.SelectedIndexChanged += new System.EventHandler(this.LstVideoStream_SelectedIndexChanged);
			// 
			// LstVideoStream_Name
			// 
			this.LstVideoStream_Name.Text = "ID";
			this.LstVideoStream_Name.Width = 120;
			// 
			// LstVideoStream_Src
			// 
			this.LstVideoStream_Src.Text = "地址";
			this.LstVideoStream_Src.Width = 180;
			// 
			// LstVideoStream_Protocol
			// 
			this.LstVideoStream_Protocol.Text = "协议";
			this.LstVideoStream_Protocol.Width = 40;
			// 
			// LstVideoStream_Privilege
			// 
			this.LstVideoStream_Privilege.Text = "优先级";
			this.LstVideoStream_Privilege.Width = 40;
			// 
			// CmdSaveItem
			// 
			this.CmdSaveItem.Location = new System.Drawing.Point(729, 458);
			this.CmdSaveItem.Name = "CmdSaveItem";
			this.CmdSaveItem.Size = new System.Drawing.Size(107, 37);
			this.CmdSaveItem.TabIndex = 2;
			this.CmdSaveItem.Text = "保存";
			this.CmdSaveItem.UseVisualStyleBackColor = true;
			this.CmdSaveItem.Click += new System.EventHandler(this.CmdSaveItem_Click);
			// 
			// CmdRemoveItem
			// 
			this.CmdRemoveItem.Location = new System.Drawing.Point(729, 501);
			this.CmdRemoveItem.Name = "CmdRemoveItem";
			this.CmdRemoveItem.Size = new System.Drawing.Size(107, 37);
			this.CmdRemoveItem.TabIndex = 3;
			this.CmdRemoveItem.Text = "删除";
			this.CmdRemoveItem.UseVisualStyleBackColor = true;
			this.CmdRemoveItem.Click += new System.EventHandler(this.CmdRemoveItem_Click);
			// 
			// GrpDetail
			// 
			this.GrpDetail.Controls.Add(this.IpStreamVolume);
			this.GrpDetail.Controls.Add(this.label7);
			this.GrpDetail.Controls.Add(this.OptVideoClipType);
			this.GrpDetail.Controls.Add(this.label6);
			this.GrpDetail.Controls.Add(this.OptVideoRenderType);
			this.GrpDetail.Controls.Add(this.label5);
			this.GrpDetail.Controls.Add(this.OptPrivilege);
			this.GrpDetail.Controls.Add(this.OptProtocal);
			this.GrpDetail.Controls.Add(this.label4);
			this.GrpDetail.Controls.Add(this.label3);
			this.GrpDetail.Controls.Add(this.label2);
			this.GrpDetail.Controls.Add(this.IPStreamSrc);
			this.GrpDetail.Controls.Add(this.label1);
			this.GrpDetail.Controls.Add(this.IpStreamID);
			this.GrpDetail.Location = new System.Drawing.Point(390, 299);
			this.GrpDetail.Name = "GrpDetail";
			this.GrpDetail.Size = new System.Drawing.Size(333, 290);
			this.GrpDetail.TabIndex = 4;
			this.GrpDetail.TabStop = false;
			this.GrpDetail.Text = "流设置";
			// 
			// IpStreamVolume
			// 
			this.IpStreamVolume.Location = new System.Drawing.Point(68, 188);
			this.IpStreamVolume.Maximum = 100;
			this.IpStreamVolume.Name = "IpStreamVolume";
			this.IpStreamVolume.Size = new System.Drawing.Size(242, 45);
			this.IpStreamVolume.TabIndex = 16;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label7.Location = new System.Drawing.Point(21, 186);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 16);
			this.label7.TabIndex = 14;
			this.label7.Text = "音量";
			// 
			// OptVideoClipType
			// 
			this.OptVideoClipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.OptVideoClipType.FormattingEnabled = true;
			this.OptVideoClipType.Location = new System.Drawing.Point(67, 159);
			this.OptVideoClipType.Name = "OptVideoClipType";
			this.OptVideoClipType.Size = new System.Drawing.Size(244, 20);
			this.OptVideoClipType.TabIndex = 13;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label6.Location = new System.Drawing.Point(21, 159);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 16);
			this.label6.TabIndex = 12;
			this.label6.Text = "画面";
			// 
			// OptVideoRenderType
			// 
			this.OptVideoRenderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.OptVideoRenderType.FormattingEnabled = true;
			this.OptVideoRenderType.Location = new System.Drawing.Point(67, 132);
			this.OptVideoRenderType.Name = "OptVideoRenderType";
			this.OptVideoRenderType.Size = new System.Drawing.Size(244, 20);
			this.OptVideoRenderType.TabIndex = 11;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label5.Location = new System.Drawing.Point(21, 132);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 16);
			this.label5.TabIndex = 10;
			this.label5.Text = "渲染";
			// 
			// OptPrivilege
			// 
			this.OptPrivilege.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.OptPrivilege.FormattingEnabled = true;
			this.OptPrivilege.Location = new System.Drawing.Point(67, 105);
			this.OptPrivilege.Name = "OptPrivilege";
			this.OptPrivilege.Size = new System.Drawing.Size(244, 20);
			this.OptPrivilege.TabIndex = 9;
			// 
			// OptProtocal
			// 
			this.OptProtocal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.OptProtocal.FormattingEnabled = true;
			this.OptProtocal.Location = new System.Drawing.Point(67, 78);
			this.OptProtocal.Name = "OptProtocal";
			this.OptProtocal.Size = new System.Drawing.Size(244, 20);
			this.OptProtocal.TabIndex = 8;
			this.OptProtocal.SelectedIndexChanged += new System.EventHandler(this.OptProtocal_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label4.Location = new System.Drawing.Point(5, 105);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "优先级";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.Location = new System.Drawing.Point(21, 78);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "协议";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(21, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "来源";
			// 
			// IPStreamSrc
			// 
			this.IPStreamSrc.Location = new System.Drawing.Point(67, 50);
			this.IPStreamSrc.Name = "IPStreamSrc";
			this.IPStreamSrc.Size = new System.Drawing.Size(244, 21);
			this.IPStreamSrc.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(37, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(24, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "ID";
			// 
			// IpStreamID
			// 
			this.IpStreamID.Location = new System.Drawing.Point(67, 22);
			this.IpStreamID.Name = "IpStreamID";
			this.IpStreamID.Size = new System.Drawing.Size(244, 21);
			this.IpStreamID.TabIndex = 0;
			// 
			// CmdLoadSetting
			// 
			this.CmdLoadSetting.Location = new System.Drawing.Point(729, 302);
			this.CmdLoadSetting.Name = "CmdLoadSetting";
			this.CmdLoadSetting.Size = new System.Drawing.Size(107, 37);
			this.CmdLoadSetting.TabIndex = 6;
			this.CmdLoadSetting.Text = "载入流...";
			this.CmdLoadSetting.UseVisualStyleBackColor = true;
			this.CmdLoadSetting.Click += new System.EventHandler(this.CmdLoadSetting_Click);
			// 
			// CmdSaveSetting
			// 
			this.CmdSaveSetting.Location = new System.Drawing.Point(729, 345);
			this.CmdSaveSetting.Name = "CmdSaveSetting";
			this.CmdSaveSetting.Size = new System.Drawing.Size(107, 37);
			this.CmdSaveSetting.TabIndex = 7;
			this.CmdSaveSetting.Text = "另存为...";
			this.CmdSaveSetting.UseVisualStyleBackColor = true;
			this.CmdSaveSetting.Click += new System.EventHandler(this.CmdSaveSetting_Click);
			// 
			// LstLayout
			// 
			this.LstLayout.Location = new System.Drawing.Point(392, 12);
			this.LstLayout.Name = "LstLayout";
			treeNode3.Name = "Root";
			treeNode3.Text = "Root";
			this.LstLayout.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
			this.LstLayout.Size = new System.Drawing.Size(333, 281);
			this.LstLayout.TabIndex = 8;
			this.LstLayout.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.LstLayout_AfterSelect);
			// 
			// CmdLayoutLoad
			// 
			this.CmdLayoutLoad.Location = new System.Drawing.Point(729, 14);
			this.CmdLayoutLoad.Name = "CmdLayoutLoad";
			this.CmdLayoutLoad.Size = new System.Drawing.Size(107, 37);
			this.CmdLayoutLoad.TabIndex = 9;
			this.CmdLayoutLoad.Text = "载入...";
			this.CmdLayoutLoad.UseVisualStyleBackColor = true;
			this.CmdLayoutLoad.Click += new System.EventHandler(this.CmdLayoutLoad_Click);
			// 
			// CmdLayoutSave
			// 
			this.CmdLayoutSave.Location = new System.Drawing.Point(729, 57);
			this.CmdLayoutSave.Name = "CmdLayoutSave";
			this.CmdLayoutSave.Size = new System.Drawing.Size(107, 37);
			this.CmdLayoutSave.TabIndex = 10;
			this.CmdLayoutSave.Text = "保存...";
			this.CmdLayoutSave.UseVisualStyleBackColor = true;
			this.CmdLayoutSave.Click += new System.EventHandler(this.CmdLayoutSave_Click);
			// 
			// CmdRemoveLayout
			// 
			this.CmdRemoveLayout.Location = new System.Drawing.Point(729, 186);
			this.CmdRemoveLayout.Name = "CmdRemoveLayout";
			this.CmdRemoveLayout.Size = new System.Drawing.Size(107, 37);
			this.CmdRemoveLayout.TabIndex = 11;
			this.CmdRemoveLayout.Text = "删除";
			this.CmdRemoveLayout.UseVisualStyleBackColor = true;
			this.CmdRemoveLayout.Click += new System.EventHandler(this.CmdRemoveLayout_Click);
			// 
			// OpPreview
			// 
			this.OpPreview.BackColor = System.Drawing.Color.White;
			this.OpPreview.Location = new System.Drawing.Point(14, 12);
			this.OpPreview.Name = "OpPreview";
			this.OpPreview.Size = new System.Drawing.Size(368, 207);
			this.OpPreview.TabIndex = 12;
			// 
			// CmdAddItem
			// 
			this.CmdAddItem.Location = new System.Drawing.Point(729, 414);
			this.CmdAddItem.Name = "CmdAddItem";
			this.CmdAddItem.Size = new System.Drawing.Size(107, 37);
			this.CmdAddItem.TabIndex = 1;
			this.CmdAddItem.Text = "新增流来源";
			this.CmdAddItem.UseVisualStyleBackColor = true;
			this.CmdAddItem.Click += new System.EventHandler(this.CmdAddItem_Click);
			// 
			// CmdLayoutNew
			// 
			this.CmdLayoutNew.Location = new System.Drawing.Point(729, 100);
			this.CmdLayoutNew.Name = "CmdLayoutNew";
			this.CmdLayoutNew.Size = new System.Drawing.Size(107, 37);
			this.CmdLayoutNew.TabIndex = 13;
			this.CmdLayoutNew.Text = "新增";
			this.CmdLayoutNew.UseVisualStyleBackColor = true;
			this.CmdLayoutNew.Click += new System.EventHandler(this.CmdLayoutNew_Click);
			// 
			// CmdStageAdd
			// 
			this.CmdStageAdd.Location = new System.Drawing.Point(11, 236);
			this.CmdStageAdd.Name = "CmdStageAdd";
			this.CmdStageAdd.Size = new System.Drawing.Size(63, 25);
			this.CmdStageAdd.TabIndex = 15;
			this.CmdStageAdd.Text = "新增机位";
			this.CmdStageAdd.UseVisualStyleBackColor = true;
			this.CmdStageAdd.Click += new System.EventHandler(this.CmdStageAdd_Click);
			// 
			// CmdStageRemove
			// 
			this.CmdStageRemove.Location = new System.Drawing.Point(80, 236);
			this.CmdStageRemove.Name = "CmdStageRemove";
			this.CmdStageRemove.Size = new System.Drawing.Size(63, 25);
			this.CmdStageRemove.TabIndex = 16;
			this.CmdStageRemove.Text = "删除机位";
			this.CmdStageRemove.UseVisualStyleBackColor = true;
			// 
			// OpStageLayoutName
			// 
			this.OpStageLayoutName.AutoSize = true;
			this.OpStageLayoutName.Location = new System.Drawing.Point(12, 222);
			this.OpStageLayoutName.Name = "OpStageLayoutName";
			this.OpStageLayoutName.Size = new System.Drawing.Size(0, 12);
			this.OpStageLayoutName.TabIndex = 17;
			// 
			// CmdSaveNewStageLayout
			// 
			this.CmdSaveNewStageLayout.Location = new System.Drawing.Point(729, 143);
			this.CmdSaveNewStageLayout.Name = "CmdSaveNewStageLayout";
			this.CmdSaveNewStageLayout.Size = new System.Drawing.Size(107, 37);
			this.CmdSaveNewStageLayout.TabIndex = 18;
			this.CmdSaveNewStageLayout.Text = "新增至";
			this.CmdSaveNewStageLayout.UseVisualStyleBackColor = true;
			this.CmdSaveNewStageLayout.Click += new System.EventHandler(this.CmdSaveNewStageLayout_Click);
			// 
			// CmdStageApply
			// 
			this.CmdStageApply.Location = new System.Drawing.Point(149, 236);
			this.CmdStageApply.Name = "CmdStageApply";
			this.CmdStageApply.Size = new System.Drawing.Size(88, 25);
			this.CmdStageApply.TabIndex = 19;
			this.CmdStageApply.Text = "应用到主屏";
			this.CmdStageApply.UseVisualStyleBackColor = true;
			this.CmdStageApply.Click += new System.EventHandler(this.CmdStageApply_Click);
			// 
			// FrmSetting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(844, 603);
			this.Controls.Add(this.CmdStageApply);
			this.Controls.Add(this.CmdSaveNewStageLayout);
			this.Controls.Add(this.OpStageLayoutName);
			this.Controls.Add(this.CmdStageRemove);
			this.Controls.Add(this.CmdStageAdd);
			this.Controls.Add(this.CmdLayoutNew);
			this.Controls.Add(this.OpPreview);
			this.Controls.Add(this.CmdRemoveLayout);
			this.Controls.Add(this.CmdLayoutSave);
			this.Controls.Add(this.CmdLayoutLoad);
			this.Controls.Add(this.LstLayout);
			this.Controls.Add(this.CmdSaveSetting);
			this.Controls.Add(this.CmdLoadSetting);
			this.Controls.Add(this.GrpDetail);
			this.Controls.Add(this.CmdRemoveItem);
			this.Controls.Add(this.CmdSaveItem);
			this.Controls.Add(this.CmdAddItem);
			this.Controls.Add(this.LstVideoStream);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FrmSetting";
			this.Text = "FrmSetting";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSetting_FormClosing);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmSetting_MouseDown);
			this.GrpDetail.ResumeLayout(false);
			this.GrpDetail.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.IpStreamVolume)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView LstVideoStream;
		private System.Windows.Forms.ColumnHeader LstVideoStream_Name;
		private System.Windows.Forms.ColumnHeader LstVideoStream_Src;
		private System.Windows.Forms.ColumnHeader LstVideoStream_Protocol;
		private System.Windows.Forms.ColumnHeader LstVideoStream_Privilege;
		private System.Windows.Forms.Button CmdSaveItem;
		private System.Windows.Forms.Button CmdRemoveItem;
		private System.Windows.Forms.GroupBox GrpDetail;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox IPStreamSrc;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox IpStreamID;
		private System.Windows.Forms.ComboBox OptPrivilege;
		private System.Windows.Forms.ComboBox OptProtocal;
		private System.Windows.Forms.ComboBox OptVideoRenderType;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox OptVideoClipType;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button CmdLoadSetting;
		private System.Windows.Forms.Button CmdSaveSetting;
		private System.Windows.Forms.TreeView LstLayout;
		private System.Windows.Forms.Button CmdLayoutLoad;
		private System.Windows.Forms.Button CmdLayoutSave;
		private System.Windows.Forms.Button CmdRemoveLayout;
		private System.Windows.Forms.Panel OpPreview;
		private System.Windows.Forms.TrackBar IpStreamVolume;
		private System.Windows.Forms.Button CmdAddItem;
		private System.Windows.Forms.Button CmdLayoutNew;
		private System.Windows.Forms.Button CmdStageAdd;
		private System.Windows.Forms.Button CmdStageRemove;
		private System.Windows.Forms.Label OpStageLayoutName;
		private System.Windows.Forms.Button CmdSaveNewStageLayout;
		private System.Windows.Forms.Button CmdStageApply;
	}
}
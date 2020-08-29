using System;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
namespace Enterprise
{
	partial class FrmMain
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
			this.skinningManager1 = new SkinFramework.SkinningManager();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
			this.系统APIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.博客文章ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbGetLinkString = new System.Windows.Forms.ToolStripButton();
			this.tsbGenerateEntities = new System.Windows.Forms.ToolStripButton();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tvDatabase = new System.Windows.Forms.TreeView();
			this.cmsTree = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmGenerateEntity = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.dgvShowDB = new System.Windows.Forms.DataGridView();
			this.gbProcess = new System.Windows.Forms.GroupBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnEexcute = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.bntGenerateEntity = new System.Windows.Forms.Button();
			this.tbSql = new System.Windows.Forms.TextBox();
			this.toolStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.cmsTree.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvShowDB)).BeginInit();
			this.gbProcess.SuspendLayout();
			this.SuspendLayout();
			// 
			// skinningManager1
			// 
			this.skinningManager1.DefaultSkin = SkinFramework.DefaultSkin.Office2007Luna;
			this.skinningManager1.ParentForm = this;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripDropDownButton1,
									this.toolStripDropDownButton3,
									this.toolStripDropDownButton2,
									this.tsbGetLinkString,
									this.tsbGenerateEntities});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(900, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
			this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(82, 22);
			this.toolStripDropDownButton1.Text = "系统设置";
			// 
			// toolStripDropDownButton3
			// 
			this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
			this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
			this.toolStripDropDownButton3.Size = new System.Drawing.Size(106, 22);
			this.toolStripDropDownButton3.Text = "在线技术支持";
			this.toolStripDropDownButton3.Click += new System.EventHandler(this.ToolStripDropDownButton3Click);
			// 
			// toolStripDropDownButton2
			// 
			this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.系统APIToolStripMenuItem,
									this.博客文章ToolStripMenuItem});
			this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
			this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
			this.toolStripDropDownButton2.Size = new System.Drawing.Size(82, 22);
			this.toolStripDropDownButton2.Text = "帮助文档";
			// 
			// 系统APIToolStripMenuItem
			// 
			this.系统APIToolStripMenuItem.Name = "系统APIToolStripMenuItem";
			this.系统APIToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.系统APIToolStripMenuItem.Text = "系统API";
			this.系统APIToolStripMenuItem.Click += new System.EventHandler(this.系统APIToolStripMenuItemClick);
			// 
			// 博客文章ToolStripMenuItem
			// 
			this.博客文章ToolStripMenuItem.Name = "博客文章ToolStripMenuItem";
			this.博客文章ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.博客文章ToolStripMenuItem.Text = "博客文章";
			this.博客文章ToolStripMenuItem.Click += new System.EventHandler(this.博客文章ToolStripMenuItemClick);
			// 
			// tsbGetLinkString
			// 
			this.tsbGetLinkString.Image = ((System.Drawing.Image)(resources.GetObject("tsbGetLinkString.Image")));
			this.tsbGetLinkString.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbGetLinkString.Name = "tsbGetLinkString";
			this.tsbGetLinkString.Size = new System.Drawing.Size(109, 22);
			this.tsbGetLinkString.Text = "获取连接字符串";
			this.tsbGetLinkString.Click += new System.EventHandler(this.ToolStripButton1Click);
			// 
			// tsbGenerateEntities
			// 
			this.tsbGenerateEntities.Image = ((System.Drawing.Image)(resources.GetObject("tsbGenerateEntities.Image")));
			this.tsbGenerateEntities.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbGenerateEntities.Name = "tsbGenerateEntities";
			this.tsbGenerateEntities.Size = new System.Drawing.Size(133, 22);
			this.tsbGenerateEntities.Text = "一键生成数据库实体";
			this.tsbGenerateEntities.Click += new System.EventHandler(this.TsbGenerateEntitiesClick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 464);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(900, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(125, 17);
			this.toolStripStatusLabel1.Text = "秦仕川©版权所有 2012";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 25);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tvDatabase);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(900, 439);
			this.splitContainer1.SplitterDistance = 257;
			this.splitContainer1.TabIndex = 2;
			// 
			// tvDatabase
			// 
			this.tvDatabase.BackColor = System.Drawing.SystemColors.GrayText;
			this.tvDatabase.CheckBoxes = true;
			this.tvDatabase.ContextMenuStrip = this.cmsTree;
			this.tvDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvDatabase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.tvDatabase.ImageIndex = 0;
			this.tvDatabase.ImageList = this.imageList1;
			this.tvDatabase.Location = new System.Drawing.Point(0, 0);
			this.tvDatabase.Name = "tvDatabase";
			this.tvDatabase.SelectedImageIndex = 0;
			this.tvDatabase.Size = new System.Drawing.Size(257, 439);
			this.tvDatabase.TabIndex = 0;
			this.tvDatabase.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TvDatabaseMouseDown);
			// 
			// cmsTree
			// 
			this.cmsTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsmGenerateEntity,
									this.tsmCopy});
			this.cmsTree.Name = "cmsTree";
			this.cmsTree.Size = new System.Drawing.Size(153, 70);
			this.cmsTree.Opening += new System.ComponentModel.CancelEventHandler(this.CmsTreeOpening);
			// 
			// tsmGenerateEntity
			// 
			this.tsmGenerateEntity.Name = "tsmGenerateEntity";
			this.tsmGenerateEntity.Size = new System.Drawing.Size(152, 22);
			this.tsmGenerateEntity.Text = "生成对应实体";
			this.tsmGenerateEntity.Click += new System.EventHandler(this.TsmGenerateEntityClick);
			// 
			// tsmCopy
			// 
			this.tsmCopy.Name = "tsmCopy";
			this.tsmCopy.Size = new System.Drawing.Size(152, 22);
			this.tsmCopy.Text = "复制其名";
			this.tsmCopy.Click += new System.EventHandler(this.TsmCopyClick);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "Database.ico");
			this.imageList1.Images.SetKeyName(1, "BLURAY.ico");
			this.imageList1.Images.SetKeyName(2, "HDDVD.ico");
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.dgvShowDB);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.gbProcess);
			this.splitContainer2.Panel2.Controls.Add(this.tbSql);
			this.splitContainer2.Size = new System.Drawing.Size(639, 439);
			this.splitContainer2.SplitterDistance = 205;
			this.splitContainer2.TabIndex = 5;
			// 
			// dgvShowDB
			// 
			this.dgvShowDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvShowDB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvShowDB.Location = new System.Drawing.Point(0, 0);
			this.dgvShowDB.Name = "dgvShowDB";
			this.dgvShowDB.RowTemplate.Height = 23;
			this.dgvShowDB.Size = new System.Drawing.Size(639, 205);
			this.dgvShowDB.TabIndex = 0;
			// 
			// gbProcess
			// 
			this.gbProcess.Controls.Add(this.btnClose);
			this.gbProcess.Controls.Add(this.btnEexcute);
			this.gbProcess.Controls.Add(this.btnClear);
			this.gbProcess.Controls.Add(this.bntGenerateEntity);
			this.gbProcess.Location = new System.Drawing.Point(252, 160);
			this.gbProcess.Name = "gbProcess";
			this.gbProcess.Size = new System.Drawing.Size(342, 62);
			this.gbProcess.TabIndex = 5;
			this.gbProcess.TabStop = false;
			this.gbProcess.Text = "系统操作";
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(262, 14);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 39);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "退出";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
			// 
			// btnEexcute
			// 
			this.btnEexcute.Location = new System.Drawing.Point(184, 14);
			this.btnEexcute.Name = "btnEexcute";
			this.btnEexcute.Size = new System.Drawing.Size(75, 39);
			this.btnEexcute.TabIndex = 2;
			this.btnEexcute.Text = "执行sql";
			this.btnEexcute.UseVisualStyleBackColor = true;
			this.btnEexcute.Click += new System.EventHandler(this.BtnEexcuteClick);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(103, 14);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 39);
			this.btnClear.TabIndex = 3;
			this.btnClear.Text = "清空";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.BtnClearClick);
			// 
			// bntGenerateEntity
			// 
			this.bntGenerateEntity.Location = new System.Drawing.Point(10, 14);
			this.bntGenerateEntity.Name = "bntGenerateEntity";
			this.bntGenerateEntity.Size = new System.Drawing.Size(87, 39);
			this.bntGenerateEntity.TabIndex = 4;
			this.bntGenerateEntity.Text = "生成对应实体";
			this.bntGenerateEntity.UseVisualStyleBackColor = true;
			this.bntGenerateEntity.Click += new System.EventHandler(this.bntGenerateEntityClick);
			// 
			// tbSql
			// 
			this.tbSql.Dock = System.Windows.Forms.DockStyle.Top;
			this.tbSql.Location = new System.Drawing.Point(0, 0);
			this.tbSql.Multiline = true;
			this.tbSql.Name = "tbSql";
			this.tbSql.Size = new System.Drawing.Size(639, 156);
			this.tbSql.TabIndex = 1;
			this.tbSql.Text = "在此输入sql语句";
			this.tbSql.MouseEnter += new System.EventHandler(this.TbSqlMouseEnter);
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(900, 486);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Moon.Net企业研发平台";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMainFormClosed);
			this.Load += new System.EventHandler(this.FrmMainLoad);
			this.SizeChanged += new System.EventHandler(this.FrmMainSizeChanged);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.cmsTree.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvShowDB)).EndInit();
			this.gbProcess.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem tsmCopy;
		private System.Windows.Forms.ToolStripButton tsbGenerateEntities;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.GroupBox gbProcess;
		private System.Windows.Forms.ToolStripMenuItem 博客文章ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 系统APIToolStripMenuItem;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.ToolStripButton tsbGetLinkString;
		private System.Windows.Forms.Button bntGenerateEntity;
		private System.Windows.Forms.DataGridView dgvShowDB;
		private System.Windows.Forms.TextBox tbSql;
		private System.Windows.Forms.Button btnEexcute;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.ToolStripMenuItem tsmGenerateEntity;
		private System.Windows.Forms.ContextMenuStrip cmsTree;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
		private System.Windows.Forms.TreeView tvDatabase;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private SkinFramework.SkinningManager skinningManager1;
		
		
	}
}

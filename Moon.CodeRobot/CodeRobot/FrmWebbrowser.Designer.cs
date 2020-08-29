/*
 * 由SharpDevelop创建。
 * 用户： qscq
 * 日期: 2014/3/8
 * 时间: 12:52
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace CodeRobot
{
	partial class FrmWebbrowser
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		 
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.qRibbonCaption1 = new Qios.DevSuite.Components.Ribbon.QRibbonCaption();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbtnGoBack = new System.Windows.Forms.ToolStripButton();
			this.tsbtnForward = new System.Windows.Forms.ToolStripButton();
			this.tstbURL = new System.Windows.Forms.ToolStripTextBox();
			this.tsbtnGOC = new System.Windows.Forms.ToolStripButton();
			this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.panel1 = new System.Windows.Forms.Panel();
			this.wbLogin = new System.Windows.Forms.WebBrowser();
			((System.ComponentModel.ISupportInitialize)(this.qRibbonCaption1)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// qRibbonCaption1
			// 
			this.qRibbonCaption1.Location = new System.Drawing.Point(0, 0);
			this.qRibbonCaption1.Name = "qRibbonCaption1";
			this.qRibbonCaption1.Size = new System.Drawing.Size(419, 28);
			this.qRibbonCaption1.TabIndex = 0;
			this.qRibbonCaption1.Text = " ";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsbtnGoBack,
									this.tsbtnForward,
									this.tstbURL,
									this.tsbtnGOC,
									this.tsbtnRefresh});
			this.toolStrip1.Location = new System.Drawing.Point(0, 28);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(419, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsbtnGoBack
			// 
			this.tsbtnGoBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnGoBack.Image = global::CodeRobot.Resources.UI.tsbtnGoBack_Image;
			this.tsbtnGoBack.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnGoBack.Name = "tsbtnGoBack";
			this.tsbtnGoBack.Size = new System.Drawing.Size(23, 22);
			this.tsbtnGoBack.Text = "toolStripButton1";
			this.tsbtnGoBack.Click += new System.EventHandler(this.TsbtnGoBackClick);
			// 
			// tsbtnForward
			// 
			this.tsbtnForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnForward.Image = global::CodeRobot.Resources.UI.tsbtnForward_Image;
			this.tsbtnForward.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnForward.Name = "tsbtnForward";
			this.tsbtnForward.Size = new System.Drawing.Size(23, 22);
			this.tsbtnForward.Text = "toolStripButton2";
			this.tsbtnForward.Click += new System.EventHandler(this.TsbtnForwardClick);
			// 
			// tstbURL
			// 
			this.tstbURL.Name = "tstbURL";
			this.tstbURL.Size = new System.Drawing.Size(300, 25);
			// 
			// tsbtnGOC
			// 
			this.tsbtnGOC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnGOC.Image = global::CodeRobot.Resources.UI.tsbtnGO_Image;
			this.tsbtnGOC.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnGOC.Name = "tsbtnGOC";
			this.tsbtnGOC.Size = new System.Drawing.Size(23, 22);
			this.tsbtnGOC.Text = "toolStripButton3";
			this.tsbtnGOC.Click += new System.EventHandler(this.TsbtnGOCClick);
			// 
			// tsbtnRefresh
			// 
			this.tsbtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnRefresh.Image = global::CodeRobot.Resources.UI.tsbtnRefresh_Image;
			this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnRefresh.Name = "tsbtnRefresh";
			this.tsbtnRefresh.Size = new System.Drawing.Size(23, 22);
			this.tsbtnRefresh.Text = "toolStripButton4";
			this.tsbtnRefresh.Click += new System.EventHandler(this.TsbtnRefreshClick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 455);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(419, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.wbLogin);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 53);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(419, 402);
			this.panel1.TabIndex = 3;
			// 
			// wbLogin
			// 
			this.wbLogin.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wbLogin.Location = new System.Drawing.Point(0, 0);
			this.wbLogin.Name = "wbLogin";
			this.wbLogin.Size = new System.Drawing.Size(419, 402);
			this.wbLogin.TabIndex = 0;
			// 
			// FrmWebbrowser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(419, 477);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.qRibbonCaption1);
			this.Icon = global::CodeRobot.Resources.UI.ie;
			this.Name = "FrmWebbrowser";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = " ";
			this.Load += new System.EventHandler(this.FrmWebbrowserLoad);
			((System.ComponentModel.ISupportInitialize)(this.qRibbonCaption1)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.ToolStripButton tsbtnGOC;
		private System.Windows.Forms.ToolStripTextBox tstbURL;
		private System.Windows.Forms.ToolStripButton tsbtnForward;
		private System.Windows.Forms.ToolStripButton tsbtnGoBack;
		private System.Windows.Forms.WebBrowser wbLogin;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private Qios.DevSuite.Components.Ribbon.QRibbonCaption qRibbonCaption1;
	}
}

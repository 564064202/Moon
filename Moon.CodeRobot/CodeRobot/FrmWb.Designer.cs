/*
 * 由SharpDevelop创建。
 * 用户： qscq
 * 日期: 2015/7/6
 * 时间: 21:01
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace CodeRobot
{
	partial class FrmWb
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
		 
			this.wb1 = new System.Windows.Forms.WebBrowser();
		 
			this.SuspendLayout();
			// 
			// qRibbonCaption1
			// 
			 
			// 
			// wb1
			// 
			this.wb1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wb1.Location = new System.Drawing.Point(0, 28);
			this.wb1.MinimumSize = new System.Drawing.Size(20, 20);
			this.wb1.Name = "wb1";
			this.wb1.Size = new System.Drawing.Size(516, 543);
			this.wb1.TabIndex = 3;
			// 
			// FrmWb
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(516, 571);
			this.Controls.Add(this.wb1);
		//	this.Controls.Add(this.qRibbonCaption1);
			this.Name = "FrmWb";
			this.Text = "txt";
			this.Load += new System.EventHandler(this.FrmWbLoad);
			//((System.ComponentModel.ISupportInitialize)(this.qRibbonCaption1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.WebBrowser wb1;
		 
	}
}

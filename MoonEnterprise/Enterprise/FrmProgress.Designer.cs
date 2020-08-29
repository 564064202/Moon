/*
 * 由SharpDevelop创建。
 * 用户： qinshichuan
 * 日期: 2012-9-8
 * 时间: 9:50
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace Enterprise
{
	partial class FrmProgress
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
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.timerProgerss = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(12, 12);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(248, 23);
			this.progressBar1.TabIndex = 0;
			// 
			// timerProgerss
			// 
			this.timerProgerss.Enabled = true;
			this.timerProgerss.Interval = 20;
			this.timerProgerss.Tick += new System.EventHandler(this.TimerProgerssTick);
			// 
			// FrmProgress
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.ClientSize = new System.Drawing.Size(272, 46);
			this.Controls.Add(this.progressBar1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FrmProgress";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FrmProgress";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Timer timerProgerss;
		private System.Windows.Forms.ProgressBar progressBar1;
	}
}

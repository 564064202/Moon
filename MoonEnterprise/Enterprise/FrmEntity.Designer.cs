/*
 * 由SharpDevelop创建。
 * 用户： qinshichuan
 * 日期: 2012-9-1
 * 时间: 19:56
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace Enterprise
{
	partial class FrmEntity
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
			this.tbCode = new System.Windows.Forms.TextBox();
			this.bntCopy = new System.Windows.Forms.Button();
			this.skinningManager1 = new SkinFramework.SkinningManager();
			this.SuspendLayout();
			// 
			// tbCode
			// 
			this.tbCode.Location = new System.Drawing.Point(13, 33);
			this.tbCode.Multiline = true;
			this.tbCode.Name = "tbCode";
			this.tbCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbCode.Size = new System.Drawing.Size(504, 510);
			this.tbCode.TabIndex = 0;
			// 
			// bntCopy
			// 
			this.bntCopy.Location = new System.Drawing.Point(442, 4);
			this.bntCopy.Name = "bntCopy";
			this.bntCopy.Size = new System.Drawing.Size(75, 23);
			this.bntCopy.TabIndex = 1;
			this.bntCopy.Text = "复制";
			this.bntCopy.UseVisualStyleBackColor = true;
			this.bntCopy.Click += new System.EventHandler(this.BntCopyClick);
			// 
			// skinningManager1
			// 
			this.skinningManager1.DefaultSkin = SkinFramework.DefaultSkin.Office2007Luna;
			this.skinningManager1.ParentForm = this;
			// 
			// FrmEntity
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(526, 555);
			this.Controls.Add(this.bntCopy);
			this.Controls.Add(this.tbCode);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FrmEntity";
			this.Text = "FrmEntity";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private SkinFramework.SkinningManager skinningManager1;
		private System.Windows.Forms.Button bntCopy;
		private System.Windows.Forms.TextBox tbCode;
	}
}

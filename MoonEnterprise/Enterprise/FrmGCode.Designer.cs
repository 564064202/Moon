/*
 * 由SharpDevelop创建。
 * 用户： qinshichuan
 * 日期: 2012-9-1
 * 时间: 21:12
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace Enterprise
{
	partial class FrmGCode
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
			this.skinningManager1 = new SkinFramework.SkinningManager();
			this.tbCode = new System.Windows.Forms.TextBox();
			this.btnCopy = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// skinningManager1
			// 
			this.skinningManager1.DefaultSkin = SkinFramework.DefaultSkin.Office2007Luna;
			this.skinningManager1.ParentForm = this;
			// 
			// tbCode
			// 
			this.tbCode.Location = new System.Drawing.Point(13, 29);
			this.tbCode.Multiline = true;
			this.tbCode.Name = "tbCode";
			this.tbCode.Size = new System.Drawing.Size(446, 514);
			this.tbCode.TabIndex = 0;
			// 
			// btnCopy
			// 
			this.btnCopy.Location = new System.Drawing.Point(384, 3);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(75, 23);
			this.btnCopy.TabIndex = 1;
			this.btnCopy.Text = "复制";
			this.btnCopy.UseVisualStyleBackColor = true;
			this.btnCopy.Click += new System.EventHandler(this.BtnCopyClick);
			// 
			// FrmGCode
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(471, 555);
			this.Controls.Add(this.btnCopy);
			this.Controls.Add(this.tbCode);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FrmGCode";
			this.Text = "FrmGCode";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btnCopy;
		private System.Windows.Forms.TextBox tbCode;
		private SkinFramework.SkinningManager skinningManager1;
	}
}

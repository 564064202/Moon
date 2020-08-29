/*
 * 由SharpDevelop创建。
 * 用户： qinshichuan
 * 日期: 2012-9-1
 * 时间: 15:16
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace Enterprise
{
	partial class FrmAllEntities
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnComplie = new System.Windows.Forms.Button();
			this.btnCopy = new System.Windows.Forms.Button();
			this.tbCode = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// skinningManager1
			// 
			this.skinningManager1.DefaultSkin = SkinFramework.DefaultSkin.Office2007Luna;
			this.skinningManager1.ParentForm = this;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnComplie);
			this.groupBox1.Controls.Add(this.btnCopy);
			this.groupBox1.Controls.Add(this.tbCode);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(531, 503);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "当前对应的实体";
			// 
			// btnComplie
			// 
			this.btnComplie.Location = new System.Drawing.Point(358, 10);
			this.btnComplie.Name = "btnComplie";
			this.btnComplie.Size = new System.Drawing.Size(75, 23);
			this.btnComplie.TabIndex = 2;
			this.btnComplie.Text = "编译";
			this.btnComplie.UseVisualStyleBackColor = true;
			this.btnComplie.Click += new System.EventHandler(this.BtnComplieClick);
			// 
			// btnCopy
			// 
			this.btnCopy.Location = new System.Drawing.Point(439, 10);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(75, 23);
			this.btnCopy.TabIndex = 1;
			this.btnCopy.Text = "复制";
			this.btnCopy.UseVisualStyleBackColor = true;
			this.btnCopy.Click += new System.EventHandler(this.BtnCopyClick);
			// 
			// tbCode
			// 
			this.tbCode.Location = new System.Drawing.Point(18, 36);
			this.tbCode.Multiline = true;
			this.tbCode.Name = "tbCode";
			this.tbCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbCode.Size = new System.Drawing.Size(496, 461);
			this.tbCode.TabIndex = 0;
			// 
			// FrmAllEntities
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(555, 527);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "FrmAllEntities";
			this.Text = "当前数据库";
			this.TopMost = true;
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TextBox tbCode;
		private System.Windows.Forms.Button btnCopy;
		private System.Windows.Forms.Button btnComplie;
		private System.Windows.Forms.GroupBox groupBox1;
		private SkinFramework.SkinningManager skinningManager1;
	}
}

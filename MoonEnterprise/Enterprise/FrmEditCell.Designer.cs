/*
 * 由SharpDevelop创建。
 * 用户： qinshichuan
 * 日期: 2012-9-8
 * 时间: 12:21
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace Enterprise
{
	partial class FrmEditCell
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbCell = new System.Windows.Forms.TextBox();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.skinningManager1 = new SkinFramework.SkinningManager();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbCell);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(268, 62);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "该单元的值";
			// 
			// tbCell
			// 
			this.tbCell.Location = new System.Drawing.Point(23, 24);
			this.tbCell.Name = "tbCell";
			this.tbCell.Size = new System.Drawing.Size(230, 21);
			this.tbCell.TabIndex = 0;
			this.tbCell.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TbCellMouseDoubleClick);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(205, 80);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(75, 23);
			this.btnUpdate.TabIndex = 1;
			this.btnUpdate.Text = "确定修改";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.BtnUpdateClick);
			// 
			// skinningManager1
			// 
			this.skinningManager1.DefaultSkin = SkinFramework.DefaultSkin.Office2007Luna;
			this.skinningManager1.ParentForm = this;
			// 
			// FrmEditCell
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 109);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmEditCell";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "单元格数据修改";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEditCellFormClosing);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
		}
		private SkinFramework.SkinningManager skinningManager1;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.TextBox tbCell;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}

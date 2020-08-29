/*
 * 由SharpDevelop创建。
 * 用户： qinshichuan
 * 日期: 2012-6-16
 * 时间: 16:47
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace Enterprise
{
	partial class FrmHelpSetLinkStringDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHelpSetLinkStringDialog));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnGetDatabaseList = new System.Windows.Forms.Button();
			this.btnIntail = new System.Windows.Forms.Button();
			this.cmbSerserList = new System.Windows.Forms.ComboBox();
			this.rbtnSqlServer = new System.Windows.Forms.RadioButton();
			this.rbtnWindows = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbDatabaseList = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.tbUserName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnTest = new System.Windows.Forms.Button();
			this.skinningManager1 = new SkinFramework.SkinningManager();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
			this.groupBox1.Controls.Add(this.btnGetDatabaseList);
			this.groupBox1.Controls.Add(this.btnIntail);
			this.groupBox1.Controls.Add(this.cmbSerserList);
			this.groupBox1.Controls.Add(this.rbtnSqlServer);
			this.groupBox1.Controls.Add(this.rbtnWindows);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.cmbDatabaseList);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(13, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(267, 104);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "登陆信息";
			// 
			// btnGetDatabaseList
			// 
			this.btnGetDatabaseList.Location = new System.Drawing.Point(231, 67);
			this.btnGetDatabaseList.Name = "btnGetDatabaseList";
			this.btnGetDatabaseList.Size = new System.Drawing.Size(32, 23);
			this.btnGetDatabaseList.TabIndex = 13;
			this.btnGetDatabaseList.Text = "←";
			this.btnGetDatabaseList.UseVisualStyleBackColor = true;
			// 
			// btnIntail
			// 
			this.btnIntail.Location = new System.Drawing.Point(231, 17);
			this.btnIntail.Name = "btnIntail";
			this.btnIntail.Size = new System.Drawing.Size(32, 23);
			this.btnIntail.TabIndex = 12;
			this.btnIntail.Text = "←";
			this.btnIntail.UseVisualStyleBackColor = true;
			this.btnIntail.Click += new System.EventHandler(this.BtnIntailClick);
			// 
			// cmbSerserList
			// 
			this.cmbSerserList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSerserList.FormattingEnabled = true;
			this.cmbSerserList.Location = new System.Drawing.Point(97, 18);
			this.cmbSerserList.Name = "cmbSerserList";
			this.cmbSerserList.Size = new System.Drawing.Size(132, 20);
			this.cmbSerserList.TabIndex = 11;
			// 
			// rbtnSqlServer
			// 
			this.rbtnSqlServer.Checked = true;
			this.rbtnSqlServer.Location = new System.Drawing.Point(97, 45);
			this.rbtnSqlServer.Name = "rbtnSqlServer";
			this.rbtnSqlServer.Size = new System.Drawing.Size(77, 18);
			this.rbtnSqlServer.TabIndex = 10;
			this.rbtnSqlServer.TabStop = true;
			this.rbtnSqlServer.Text = "sqlserver";
			this.rbtnSqlServer.UseVisualStyleBackColor = true;
			// 
			// rbtnWindows
			// 
			this.rbtnWindows.Location = new System.Drawing.Point(180, 45);
			this.rbtnWindows.Name = "rbtnWindows";
			this.rbtnWindows.Size = new System.Drawing.Size(71, 20);
			this.rbtnWindows.TabIndex = 9;
			this.rbtnWindows.Text = "windows";
			this.rbtnWindows.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 44);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 23);
			this.label3.TabIndex = 8;
			this.label3.Text = "登陆方式:";
			// 
			// cmbDatabaseList
			// 
			this.cmbDatabaseList.FormattingEnabled = true;
			this.cmbDatabaseList.Location = new System.Drawing.Point(97, 68);
			this.cmbDatabaseList.Name = "cmbDatabaseList";
			this.cmbDatabaseList.Size = new System.Drawing.Size(132, 20);
			this.cmbDatabaseList.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "数据库:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "服务器:";
			// 
			// groupBox2
			// 
			this.groupBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox2.BackgroundImage")));
			this.groupBox2.Controls.Add(this.tbPassword);
			this.groupBox2.Controls.Add(this.tbUserName);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new System.Drawing.Point(13, 124);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(267, 90);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "登陆账号";
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(97, 51);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.Size = new System.Drawing.Size(144, 21);
			this.tbPassword.TabIndex = 4;
			// 
			// tbUserName
			// 
			this.tbUserName.Location = new System.Drawing.Point(97, 20);
			this.tbUserName.Name = "tbUserName";
			this.tbUserName.Size = new System.Drawing.Size(144, 21);
			this.tbUserName.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(24, 55);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(57, 23);
			this.label5.TabIndex = 2;
			this.label5.Text = "密码:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(24, 23);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(57, 23);
			this.label4.TabIndex = 1;
			this.label4.Text = "用户名:";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(205, 231);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "保存";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(124, 231);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "取消";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// btnTest
			// 
			this.btnTest.Location = new System.Drawing.Point(29, 231);
			this.btnTest.Name = "btnTest";
			this.btnTest.Size = new System.Drawing.Size(75, 23);
			this.btnTest.TabIndex = 4;
			this.btnTest.Text = "测试";
			this.btnTest.UseVisualStyleBackColor = true;
			this.btnTest.Click += new System.EventHandler(this.BtnTestClick);
			// 
			// skinningManager1
			// 
			this.skinningManager1.DefaultSkin = SkinFramework.DefaultSkin.Office2007Luna;
			this.skinningManager1.ParentForm = this;
			// 
			// FrmHelpSetLinkStringDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.btnTest);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "FrmHelpSetLinkStringDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "连接到SqlServer";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btnGetDatabaseList;
		private System.Windows.Forms.Button btnIntail;
		private System.Windows.Forms.ComboBox cmbSerserList;
		private SkinFramework.SkinningManager skinningManager1;
		private System.Windows.Forms.Button btnTest;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbUserName;
		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RadioButton rbtnWindows;
		private System.Windows.Forms.RadioButton rbtnSqlServer;
		private System.Windows.Forms.ComboBox cmbDatabaseList;
		private System.Windows.Forms.GroupBox groupBox1;
		
		 
	}
}

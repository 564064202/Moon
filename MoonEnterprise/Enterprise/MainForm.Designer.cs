using System.Windows.Forms;
/*
 * 由SharpDevelop创建。
 * 用户： qinshichuan
 * 日期: 2012-6-10
 * 时间: 16:53
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace Enterprise
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.gbAll = new System.Windows.Forms.GroupBox();
			this.gbFastLink = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnFastLogin = new System.Windows.Forms.Button();
			this.cmbHistoriesLinks = new System.Windows.Forms.ComboBox();
			this.gbNewLink = new System.Windows.Forms.GroupBox();
			this.tbGenerateFilesDirectoryPath = new System.Windows.Forms.TextBox();
			this.btnShowGenerateFolder = new System.Windows.Forms.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.tbProjectName = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.chkMarkPrimaryField = new System.Windows.Forms.CheckBox();
			this.label8 = new System.Windows.Forms.Label();
			this.btnHelpWriting = new System.Windows.Forms.Button();
			this.tbLinkString = new System.Windows.Forms.TextBox();
			this.cmbDBType = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnLogin = new System.Windows.Forms.Button();
			this.btnQuit = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.btmSaveUsersEmail = new System.Windows.Forms.Button();
			this.tbUsersEmail = new System.Windows.Forms.TextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.btnSendEmail = new System.Windows.Forms.Button();
			this.tbEmail = new System.Windows.Forms.TextBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.linklbFAQ = new System.Windows.Forms.LinkLabel();
			this.linklbCnBlogs = new System.Windows.Forms.LinkLabel();
			this.label7 = new System.Windows.Forms.Label();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.lblNewest = new System.Windows.Forms.LinkLabel();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.lblAssemblyName = new System.Windows.Forms.Label();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.lblSystemAssemblyName = new System.Windows.Forms.Label();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.button7 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.dgvHistory = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fbDSetGenerateFolder = new System.Windows.Forms.FolderBrowserDialog();
			this.skinningManager1 = new SkinFramework.SkinningManager();
			this.label4 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.gbAll.SuspendLayout();
			this.gbFastLink.SuspendLayout();
			this.gbNewLink.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.tabPage6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Controls.Add(this.tabPage6);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(396, 268);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.gbAll);
			this.tabPage1.Location = new System.Drawing.Point(4, 21);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(388, 243);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "快速登录";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// gbAll
			// 
			this.gbAll.Controls.Add(this.gbFastLink);
			this.gbAll.Controls.Add(this.gbNewLink);
			this.gbAll.Controls.Add(this.btnLogin);
			this.gbAll.Controls.Add(this.btnQuit);
			this.gbAll.Location = new System.Drawing.Point(8, 6);
			this.gbAll.Name = "gbAll";
			this.gbAll.Size = new System.Drawing.Size(368, 229);
			this.gbAll.TabIndex = 0;
			this.gbAll.TabStop = false;
			// 
			// gbFastLink
			// 
			this.gbFastLink.Controls.Add(this.label3);
			this.gbFastLink.Controls.Add(this.btnFastLogin);
			this.gbFastLink.Controls.Add(this.cmbHistoriesLinks);
			this.gbFastLink.Location = new System.Drawing.Point(16, 11);
			this.gbFastLink.Name = "gbFastLink";
			this.gbFastLink.Size = new System.Drawing.Size(341, 47);
			this.gbFastLink.TabIndex = 9;
			this.gbFastLink.TabStop = false;
			this.gbFastLink.Text = "历史项目";
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(5, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(85, 18);
			this.label3.TabIndex = 11;
			this.label3.Text = "历史记录:";
			// 
			// btnFastLogin
			// 
			this.btnFastLogin.ForeColor = System.Drawing.Color.Red;
			this.btnFastLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnFastLogin.Image")));
			this.btnFastLogin.Location = new System.Drawing.Point(254, 17);
			this.btnFastLogin.Name = "btnFastLogin";
			this.btnFastLogin.Size = new System.Drawing.Size(69, 23);
			this.btnFastLogin.TabIndex = 11;
			this.btnFastLogin.Text = "登录";
			this.btnFastLogin.UseVisualStyleBackColor = true;
			this.btnFastLogin.Click += new System.EventHandler(this.BtnFastLoginClick);
			// 
			// cmbHistoriesLinks
			// 
			this.cmbHistoriesLinks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbHistoriesLinks.FormattingEnabled = true;
			this.cmbHistoriesLinks.Location = new System.Drawing.Point(96, 18);
			this.cmbHistoriesLinks.Name = "cmbHistoriesLinks";
			this.cmbHistoriesLinks.Size = new System.Drawing.Size(139, 20);
			this.cmbHistoriesLinks.TabIndex = 0;
			// 
			// gbNewLink
			// 
			this.gbNewLink.Controls.Add(this.tbGenerateFilesDirectoryPath);
			this.gbNewLink.Controls.Add(this.btnShowGenerateFolder);
			this.gbNewLink.Controls.Add(this.label12);
			this.gbNewLink.Controls.Add(this.tbProjectName);
			this.gbNewLink.Controls.Add(this.label10);
			this.gbNewLink.Controls.Add(this.chkMarkPrimaryField);
			this.gbNewLink.Controls.Add(this.label8);
			this.gbNewLink.Controls.Add(this.btnHelpWriting);
			this.gbNewLink.Controls.Add(this.tbLinkString);
			this.gbNewLink.Controls.Add(this.cmbDBType);
			this.gbNewLink.Controls.Add(this.label2);
			this.gbNewLink.Controls.Add(this.label1);
			this.gbNewLink.Location = new System.Drawing.Point(15, 61);
			this.gbNewLink.Name = "gbNewLink";
			this.gbNewLink.Size = new System.Drawing.Size(341, 141);
			this.gbNewLink.TabIndex = 8;
			this.gbNewLink.TabStop = false;
			this.gbNewLink.Text = "新建项目";
			// 
			// tbGenerateFilesDirectoryPath
			// 
			this.tbGenerateFilesDirectoryPath.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.tbGenerateFilesDirectoryPath.Location = new System.Drawing.Point(178, 113);
			this.tbGenerateFilesDirectoryPath.Name = "tbGenerateFilesDirectoryPath";
			this.tbGenerateFilesDirectoryPath.Size = new System.Drawing.Size(146, 21);
			this.tbGenerateFilesDirectoryPath.TabIndex = 21;
			this.tbGenerateFilesDirectoryPath.DoubleClick += new System.EventHandler(this.TbGenerateFilesDirectoryPathDoubleClick);
			// 
			// btnShowGenerateFolder
			// 
			this.btnShowGenerateFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnShowGenerateFolder.Image")));
			this.btnShowGenerateFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnShowGenerateFolder.Location = new System.Drawing.Point(96, 112);
			this.btnShowGenerateFolder.Name = "btnShowGenerateFolder";
			this.btnShowGenerateFolder.Size = new System.Drawing.Size(75, 23);
			this.btnShowGenerateFolder.TabIndex = 20;
			this.btnShowGenerateFolder.Text = "浏览->";
			this.btnShowGenerateFolder.UseVisualStyleBackColor = true;
			this.btnShowGenerateFolder.Click += new System.EventHandler(this.BtnShowGenerateFolderClick);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(5, 118);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(85, 18);
			this.label12.TabIndex = 18;
			this.label12.Text = "生成文件路径:";
			// 
			// tbProjectName
			// 
			this.tbProjectName.Location = new System.Drawing.Point(97, 88);
			this.tbProjectName.Name = "tbProjectName";
			this.tbProjectName.Size = new System.Drawing.Size(139, 21);
			this.tbProjectName.TabIndex = 5;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(5, 91);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(85, 23);
			this.label10.TabIndex = 15;
			this.label10.Text = "项目名:";
			// 
			// chkMarkPrimaryField
			// 
			this.chkMarkPrimaryField.Location = new System.Drawing.Point(97, 65);
			this.chkMarkPrimaryField.Name = "chkMarkPrimaryField";
			this.chkMarkPrimaryField.Size = new System.Drawing.Size(124, 24);
			this.chkMarkPrimaryField.TabIndex = 4;
			this.chkMarkPrimaryField.Text = "(标记外键字段)";
			this.chkMarkPrimaryField.UseVisualStyleBackColor = true;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(5, 70);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(86, 23);
			this.label8.TabIndex = 13;
			this.label8.Text = "外键辅显功能:";
			// 
			// btnHelpWriting
			// 
			this.btnHelpWriting.ForeColor = System.Drawing.Color.Red;
			this.btnHelpWriting.Location = new System.Drawing.Point(255, 41);
			this.btnHelpWriting.Name = "btnHelpWriting";
			this.btnHelpWriting.Size = new System.Drawing.Size(69, 23);
			this.btnHelpWriting.TabIndex = 12;
			this.btnHelpWriting.Text = "辅助填写";
			this.btnHelpWriting.UseVisualStyleBackColor = true;
			this.btnHelpWriting.Click += new System.EventHandler(this.BtnHelpWritingClick);
			// 
			// tbLinkString
			// 
			this.tbLinkString.Location = new System.Drawing.Point(97, 42);
			this.tbLinkString.Name = "tbLinkString";
			this.tbLinkString.Size = new System.Drawing.Size(139, 21);
			this.tbLinkString.TabIndex = 3;
			// 
			// cmbDBType
			// 
			this.cmbDBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDBType.ForeColor = System.Drawing.SystemColors.Desktop;
			this.cmbDBType.FormattingEnabled = true;
			this.cmbDBType.ItemHeight = 12;
			this.cmbDBType.Location = new System.Drawing.Point(97, 13);
			this.cmbDBType.Name = "cmbDBType";
			this.cmbDBType.Size = new System.Drawing.Size(139, 20);
			this.cmbDBType.TabIndex = 0;
			this.cmbDBType.SelectedIndexChanged += new System.EventHandler(this.CmbDBTypeSelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(5, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 7;
			this.label2.Text = "连接字符串:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 6;
			this.label1.Text = "请选数据库类型:";
			// 
			// btnLogin
			// 
			this.btnLogin.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnLogin.Location = new System.Drawing.Point(270, 203);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(69, 23);
			this.btnLogin.TabIndex = 6;
			this.btnLogin.Text = "登录";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.BtnLoginClick);
			// 
			// btnQuit
			// 
			this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnQuit.Location = new System.Drawing.Point(176, 203);
			this.btnQuit.Name = "btnQuit";
			this.btnQuit.Size = new System.Drawing.Size(75, 23);
			this.btnQuit.TabIndex = 1;
			this.btnQuit.Text = "退出";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.BtnQuitClick);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.groupBox5);
			this.tabPage2.Location = new System.Drawing.Point(4, 21);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(388, 243);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "系统配置";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.label9);
			this.groupBox5.Controls.Add(this.label5);
			this.groupBox5.Controls.Add(this.btmSaveUsersEmail);
			this.groupBox5.Controls.Add(this.tbUsersEmail);
			this.groupBox5.Location = new System.Drawing.Point(8, 6);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(372, 128);
			this.groupBox5.TabIndex = 2;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "技术支持邮箱";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(11, 34);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(308, 23);
			this.label9.TabIndex = 2;
			this.label9.Text = "请输入在下方输入您的邮箱,以便随时联系您.";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(11, 77);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 14);
			this.label5.TabIndex = 1;
			this.label5.Text = "您的邮箱:";
			// 
			// btmSaveUsersEmail
			// 
			this.btmSaveUsersEmail.Image = ((System.Drawing.Image)(resources.GetObject("btmSaveUsersEmail.Image")));
			this.btmSaveUsersEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btmSaveUsersEmail.Location = new System.Drawing.Point(291, 72);
			this.btmSaveUsersEmail.Name = "btmSaveUsersEmail";
			this.btmSaveUsersEmail.Size = new System.Drawing.Size(75, 23);
			this.btmSaveUsersEmail.TabIndex = 1;
			this.btmSaveUsersEmail.Text = "保存";
			this.btmSaveUsersEmail.UseVisualStyleBackColor = true;
			this.btmSaveUsersEmail.Click += new System.EventHandler(this.BtmSaveUsersEmailClick);
			// 
			// tbUsersEmail
			// 
			this.tbUsersEmail.Location = new System.Drawing.Point(81, 73);
			this.tbUsersEmail.Name = "tbUsersEmail";
			this.tbUsersEmail.Size = new System.Drawing.Size(204, 21);
			this.tbUsersEmail.TabIndex = 0;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.groupBox8);
			this.tabPage3.Controls.Add(this.groupBox7);
			this.tabPage3.Location = new System.Drawing.Point(4, 21);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(388, 243);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "技术支持";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.label4);
			this.groupBox8.Controls.Add(this.btnSendEmail);
			this.groupBox8.Controls.Add(this.tbEmail);
			this.groupBox8.Location = new System.Drawing.Point(8, 88);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(372, 125);
			this.groupBox8.TabIndex = 1;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "在线邮件支持(下方输入内容直接发送)";
			// 
			// btnSendEmail
			// 
			this.btnSendEmail.Location = new System.Drawing.Point(291, 98);
			this.btnSendEmail.Name = "btnSendEmail";
			this.btnSendEmail.Size = new System.Drawing.Size(75, 23);
			this.btnSendEmail.TabIndex = 1;
			this.btnSendEmail.Text = "立即发送";
			this.btnSendEmail.UseVisualStyleBackColor = true;
			this.btnSendEmail.Click += new System.EventHandler(this.BtnSendEmailClick);
			// 
			// tbEmail
			// 
			this.tbEmail.Location = new System.Drawing.Point(7, 20);
			this.tbEmail.Multiline = true;
			this.tbEmail.Name = "tbEmail";
			this.tbEmail.Size = new System.Drawing.Size(359, 74);
			this.tbEmail.TabIndex = 0;
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.linklbFAQ);
			this.groupBox7.Controls.Add(this.linklbCnBlogs);
			this.groupBox7.Controls.Add(this.label7);
			this.groupBox7.Location = new System.Drawing.Point(8, 6);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(372, 76);
			this.groupBox7.TabIndex = 0;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "关于Moon.ORM";
			// 
			// linklbFAQ
			// 
			this.linklbFAQ.Location = new System.Drawing.Point(6, 58);
			this.linklbFAQ.Name = "linklbFAQ";
			this.linklbFAQ.Size = new System.Drawing.Size(150, 12);
			this.linklbFAQ.TabIndex = 2;
			this.linklbFAQ.TabStop = true;
			this.linklbFAQ.Text = "4.MooN.ORM FAQ";
			this.linklbFAQ.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinklbFAQLinkClicked);
			// 
			// linklbCnBlogs
			// 
			this.linklbCnBlogs.Location = new System.Drawing.Point(6, 42);
			this.linklbCnBlogs.Name = "linklbCnBlogs";
			this.linklbCnBlogs.Size = new System.Drawing.Size(150, 12);
			this.linklbCnBlogs.TabIndex = 1;
			this.linklbCnBlogs.TabStop = true;
			this.linklbCnBlogs.Text = "3.MooN.ORM技术博客;";
			this.linklbCnBlogs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinklbCnBlogsLinkClicked);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(6, 17);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(360, 25);
			this.label7.TabIndex = 0;
			this.label7.Text = "1.Moon.ORM提供在线的QQ群支持,QQ群号:21696534\r\n2.您可以在下方发送即时邮件,编辑内容直接发送既可以;\r\n";
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.groupBox11);
			this.tabPage4.Controls.Add(this.groupBox10);
			this.tabPage4.Controls.Add(this.groupBox9);
			this.tabPage4.Location = new System.Drawing.Point(4, 21);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(388, 243);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "系统更新";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// groupBox11
			// 
			this.groupBox11.Controls.Add(this.lblNewest);
			this.groupBox11.Location = new System.Drawing.Point(8, 144);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(372, 63);
			this.groupBox11.TabIndex = 2;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "系统更新";
			// 
			// lblNewest
			// 
			this.lblNewest.Location = new System.Drawing.Point(56, 21);
			this.lblNewest.Name = "lblNewest";
			this.lblNewest.Size = new System.Drawing.Size(229, 23);
			this.lblNewest.TabIndex = 1;
			this.lblNewest.TabStop = true;
			this.lblNewest.Text = "去下载";
			this.lblNewest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblNewestLinkClicked);
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.lblAssemblyName);
			this.groupBox10.Location = new System.Drawing.Point(8, 75);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(372, 63);
			this.groupBox10.TabIndex = 1;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "当前Moon.NET版本";
			// 
			// lblAssemblyName
			// 
			this.lblAssemblyName.Location = new System.Drawing.Point(56, 27);
			this.lblAssemblyName.Name = "lblAssemblyName";
			this.lblAssemblyName.Size = new System.Drawing.Size(246, 23);
			this.lblAssemblyName.TabIndex = 0;
			this.lblAssemblyName.Text = "label4";
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.lblSystemAssemblyName);
			this.groupBox9.Location = new System.Drawing.Point(8, 6);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(372, 63);
			this.groupBox9.TabIndex = 0;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "当前系统版本";
			// 
			// lblSystemAssemblyName
			// 
			this.lblSystemAssemblyName.Location = new System.Drawing.Point(56, 17);
			this.lblSystemAssemblyName.Name = "lblSystemAssemblyName";
			this.lblSystemAssemblyName.Size = new System.Drawing.Size(246, 23);
			this.lblSystemAssemblyName.TabIndex = 1;
			this.lblSystemAssemblyName.Text = "label4";
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.groupBox6);
			this.tabPage5.Location = new System.Drawing.Point(4, 21);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(388, 243);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "系统注册";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.button7);
			this.groupBox6.Controls.Add(this.label6);
			this.groupBox6.Controls.Add(this.textBox4);
			this.groupBox6.Location = new System.Drawing.Point(8, 6);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(374, 58);
			this.groupBox6.TabIndex = 4;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "系统注册";
			// 
			// button7
			// 
			this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
			this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button7.Location = new System.Drawing.Point(296, 20);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(76, 23);
			this.button7.TabIndex = 2;
			this.button7.Text = "注册";
			this.button7.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 23);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 14);
			this.label6.TabIndex = 1;
			this.label6.Text = "注册key:";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(84, 20);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(206, 21);
			this.textBox4.TabIndex = 0;
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.dgvHistory);
			this.tabPage6.Location = new System.Drawing.Point(4, 21);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage6.Size = new System.Drawing.Size(388, 243);
			this.tabPage6.TabIndex = 5;
			this.tabPage6.Text = "项目管理";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// dgvHistory
			// 
			this.dgvHistory.AllowUserToAddRows = false;
			this.dgvHistory.AllowUserToDeleteRows = false;
			this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.Column1,
									this.Column2,
									this.Column7,
									this.Column3,
									this.Column4,
									this.Column5,
									this.Column6,
									this.Column8});
			this.dgvHistory.Location = new System.Drawing.Point(8, 6);
			this.dgvHistory.Name = "dgvHistory";
			this.dgvHistory.RowTemplate.Height = 23;
			this.dgvHistory.Size = new System.Drawing.Size(372, 229);
			this.dgvHistory.TabIndex = 0;
			this.dgvHistory.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvHistoryCellMouseDown);
			// 
			// Column1
			// 
			this.Column1.DataPropertyName = "ID";
			this.Column1.HeaderText = "ID号";
			this.Column1.Name = "Column1";
			this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// Column2
			// 
			this.Column2.DataPropertyName = "ProjectName";
			this.Column2.HeaderText = "项目名称";
			this.Column2.Name = "Column2";
			// 
			// Column7
			// 
			this.Column7.DataPropertyName = "DatabaseName";
			this.Column7.HeaderText = "数据库名";
			this.Column7.Name = "Column7";
			// 
			// Column3
			// 
			this.Column3.DataPropertyName = "DbType";
			this.Column3.HeaderText = "数据库类型";
			this.Column3.Name = "Column3";
			// 
			// Column4
			// 
			this.Column4.DataPropertyName = "LinkString";
			this.Column4.HeaderText = "连接字符串";
			this.Column4.Name = "Column4";
			// 
			// Column5
			// 
			this.Column5.DataPropertyName = "AddTime";
			this.Column5.HeaderText = "添加时间";
			this.Column5.Name = "Column5";
			// 
			// Column6
			// 
			this.Column6.DataPropertyName = "MarkPrimaryField";
			this.Column6.HeaderText = "标记外键";
			this.Column6.Name = "Column6";
			// 
			// Column8
			// 
			this.Column8.DataPropertyName = "FilesGeneratingPath";
			this.Column8.HeaderText = "dll的生成路径";
			this.Column8.Name = "Column8";
			// 
			// skinningManager1
			// 
			this.skinningManager1.DefaultSkin = SkinFramework.DefaultSkin.Office2007Luna;
			this.skinningManager1.ParentForm = this;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(7, 101);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(173, 23);
			this.label4.TabIndex = 2;
			this.label4.Text = "请留下您的邮箱地址";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnQuit;
			this.ClientSize = new System.Drawing.Size(396, 268);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Moon企业研发平台";
			this.Activated += new System.EventHandler(this.MainFormActivated);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.LocationChanged += new System.EventHandler(this.MainFormLocationChanged);
			this.RegionChanged += new System.EventHandler(this.MainFormRegionChanged);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.gbAll.ResumeLayout(false);
			this.gbFastLink.ResumeLayout(false);
			this.gbNewLink.ResumeLayout(false);
			this.gbNewLink.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.tabPage6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridView dgvHistory;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.Label lblSystemAssemblyName;
		private System.Windows.Forms.Label lblAssemblyName;
		private SkinFramework.SkinningManager skinningManager1;
		private System.Windows.Forms.FolderBrowserDialog fbDSetGenerateFolder;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button btnShowGenerateFolder;
		private System.Windows.Forms.TextBox tbGenerateFilesDirectoryPath;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tbProjectName;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.CheckBox chkMarkPrimaryField;
		private System.Windows.Forms.Button btnHelpWriting;
		private System.Windows.Forms.LinkLabel lblNewest;
		private System.Windows.Forms.GroupBox groupBox11;
		private System.Windows.Forms.LinkLabel linklbFAQ;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.LinkLabel linklbCnBlogs;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.TextBox tbEmail;
		private System.Windows.Forms.Button btnSendEmail;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.TextBox tbUsersEmail;
		private System.Windows.Forms.Button btmSaveUsersEmail;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button btnQuit;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbDBType;
		private System.Windows.Forms.TextBox tbLinkString;
		private System.Windows.Forms.GroupBox gbNewLink;
		private System.Windows.Forms.ComboBox cmbHistoriesLinks;
		private System.Windows.Forms.Button btnFastLogin;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox gbFastLink;
		private System.Windows.Forms.GroupBox gbAll;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		
		
	}
}

namespace CodeRobot
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
        	this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.btnDelete = new System.Windows.Forms.Button();
        	this.cbHistoryProject = new System.Windows.Forms.ComboBox();
        	this.label5 = new System.Windows.Forms.Label();
        	this.groupBox2 = new System.Windows.Forms.GroupBox();
        	this.linkLabel1 = new System.Windows.Forms.LinkLabel();
        	this.chkNoUnderline = new System.Windows.Forms.CheckBox();
        	this.label6 = new System.Windows.Forms.Label();
        	this.rbMoreFile = new System.Windows.Forms.RadioButton();
        	this.rbOneFile = new System.Windows.Forms.RadioButton();
        	this.txtProjectName = new System.Windows.Forms.TextBox();
        	this.label3 = new System.Windows.Forms.Label();
        	this.btnBrowse = new System.Windows.Forms.Button();
        	this.txtFilePath = new System.Windows.Forms.TextBox();
        	this.label4 = new System.Windows.Forms.Label();
        	this.txtConStr = new System.Windows.Forms.TextBox();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label1 = new System.Windows.Forms.Label();
        	this.cbDbType = new System.Windows.Forms.ComboBox();
        	this.btnLogin = new System.Windows.Forms.Button();
        	this.btnClose = new System.Windows.Forms.Button();
        	this.btnTest = new System.Windows.Forms.Button();
        	this.qRibbonCaption1 = new Qios.DevSuite.Components.Ribbon.QRibbonCaption();
        	this.statusStrip1 = new System.Windows.Forms.StatusStrip();
        	this.tsslblLinkBlog = new System.Windows.Forms.ToolStripStatusLabel();
        	this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
        	this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
        	this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
        	this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
        	this.tslblQA = new System.Windows.Forms.ToolStripStatusLabel();
        	this.lblVersion = new System.Windows.Forms.Label();
        	this.chkItem = new System.Windows.Forms.CheckBox();
        	this.groupBox1.SuspendLayout();
        	this.groupBox2.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.qRibbonCaption1)).BeginInit();
        	this.statusStrip1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.Controls.Add(this.btnDelete);
        	this.groupBox1.Controls.Add(this.cbHistoryProject);
        	this.groupBox1.Controls.Add(this.label5);
        	this.groupBox1.Location = new System.Drawing.Point(12, 44);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Size = new System.Drawing.Size(422, 68);
        	this.groupBox1.TabIndex = 10;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "历史项目";
        	// 
        	// btnDelete
        	// 
        	this.btnDelete.Location = new System.Drawing.Point(293, 28);
        	this.btnDelete.Name = "btnDelete";
        	this.btnDelete.Size = new System.Drawing.Size(116, 23);
        	this.btnDelete.TabIndex = 12;
        	this.btnDelete.Text = "删除";
        	this.btnDelete.UseVisualStyleBackColor = true;
        	this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
        	// 
        	// cbHistoryProject
        	// 
        	this.cbHistoryProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.cbHistoryProject.FormattingEnabled = true;
        	this.cbHistoryProject.Location = new System.Drawing.Point(113, 30);
        	this.cbHistoryProject.Name = "cbHistoryProject";
        	this.cbHistoryProject.Size = new System.Drawing.Size(155, 20);
        	this.cbHistoryProject.TabIndex = 11;
        	this.cbHistoryProject.SelectedIndexChanged += new System.EventHandler(this.cbHistoryProject_SelectedIndexChanged);
        	// 
        	// label5
        	// 
        	this.label5.AutoSize = true;
        	this.label5.Location = new System.Drawing.Point(30, 34);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(59, 12);
        	this.label5.TabIndex = 0;
        	this.label5.Text = "项目名称:";
        	// 
        	// groupBox2
        	// 
        	this.groupBox2.Controls.Add(this.linkLabel1);
        	this.groupBox2.Controls.Add(this.chkNoUnderline);
        	this.groupBox2.Controls.Add(this.label6);
        	this.groupBox2.Controls.Add(this.rbMoreFile);
        	this.groupBox2.Controls.Add(this.rbOneFile);
        	this.groupBox2.Controls.Add(this.txtProjectName);
        	this.groupBox2.Controls.Add(this.label3);
        	this.groupBox2.Controls.Add(this.btnBrowse);
        	this.groupBox2.Controls.Add(this.txtFilePath);
        	this.groupBox2.Controls.Add(this.label4);
        	this.groupBox2.Controls.Add(this.txtConStr);
        	this.groupBox2.Controls.Add(this.label2);
        	this.groupBox2.Controls.Add(this.label1);
        	this.groupBox2.Controls.Add(this.cbDbType);
        	this.groupBox2.Location = new System.Drawing.Point(12, 133);
        	this.groupBox2.Name = "groupBox2";
        	this.groupBox2.Size = new System.Drawing.Size(422, 228);
        	this.groupBox2.TabIndex = 5;
        	this.groupBox2.TabStop = false;
        	this.groupBox2.Text = "新建项目";
        	// 
        	// linkLabel1
        	// 
        	this.linkLabel1.Location = new System.Drawing.Point(293, 33);
        	this.linkLabel1.Name = "linkLabel1";
        	this.linkLabel1.Size = new System.Drawing.Size(116, 21);
        	this.linkLabel1.TabIndex = 26;
        	this.linkLabel1.TabStop = true;
        	this.linkLabel1.Text = "使用条款(用前必读)";
        	this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1LinkClicked);
        	// 
        	// chkNoUnderline
        	// 
        	this.chkNoUnderline.Location = new System.Drawing.Point(113, 196);
        	this.chkNoUnderline.Name = "chkNoUnderline";
        	this.chkNoUnderline.Size = new System.Drawing.Size(104, 26);
        	this.chkNoUnderline.TabIndex = 25;
        	this.chkNoUnderline.Text = "去掉下划线";
        	this.chkNoUnderline.UseVisualStyleBackColor = true;
        	this.chkNoUnderline.CheckedChanged += new System.EventHandler(this.ChkNoUnderlineCheckedChanged);
        	// 
        	// label6
        	// 
        	this.label6.AutoSize = true;
        	this.label6.Location = new System.Drawing.Point(28, 176);
        	this.label6.Name = "label6";
        	this.label6.Size = new System.Drawing.Size(59, 12);
        	this.label6.TabIndex = 23;
        	this.label6.Text = "文件选项:";
        	this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// rbMoreFile
        	// 
        	this.rbMoreFile.AutoSize = true;
        	this.rbMoreFile.Location = new System.Drawing.Point(243, 176);
        	this.rbMoreFile.Name = "rbMoreFile";
        	this.rbMoreFile.Size = new System.Drawing.Size(143, 16);
        	this.rbMoreFile.TabIndex = 22;
        	this.rbMoreFile.TabStop = true;
        	this.rbMoreFile.Text = "一个实体生成一个文件";
        	this.rbMoreFile.UseVisualStyleBackColor = true;
        	// 
        	// rbOneFile
        	// 
        	this.rbOneFile.AutoSize = true;
        	this.rbOneFile.Checked = true;
        	this.rbOneFile.Location = new System.Drawing.Point(113, 176);
        	this.rbOneFile.Name = "rbOneFile";
        	this.rbOneFile.Size = new System.Drawing.Size(107, 16);
        	this.rbOneFile.TabIndex = 21;
        	this.rbOneFile.TabStop = true;
        	this.rbOneFile.Text = "生成在一个文件";
        	this.rbOneFile.UseVisualStyleBackColor = true;
        	// 
        	// txtProjectName
        	// 
        	this.txtProjectName.Location = new System.Drawing.Point(113, 20);
        	this.txtProjectName.Name = "txtProjectName";
        	this.txtProjectName.Size = new System.Drawing.Size(155, 21);
        	this.txtProjectName.TabIndex = 20;
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(29, 24);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(59, 12);
        	this.label3.TabIndex = 19;
        	this.label3.Text = "项目名称:";
        	this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// btnBrowse
        	// 
        	this.btnBrowse.Location = new System.Drawing.Point(364, 129);
        	this.btnBrowse.Name = "btnBrowse";
        	this.btnBrowse.Size = new System.Drawing.Size(48, 23);
        	this.btnBrowse.TabIndex = 18;
        	this.btnBrowse.Text = "浏览";
        	this.btnBrowse.UseVisualStyleBackColor = true;
        	this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
        	// 
        	// txtFilePath
        	// 
        	this.txtFilePath.Location = new System.Drawing.Point(113, 129);
        	this.txtFilePath.Name = "txtFilePath";
        	this.txtFilePath.Size = new System.Drawing.Size(244, 21);
        	this.txtFilePath.TabIndex = 17;
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Location = new System.Drawing.Point(28, 134);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(83, 12);
        	this.label4.TabIndex = 16;
        	this.label4.Text = "生成文件路径:";
        	this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// txtConStr
        	// 
        	this.txtConStr.Location = new System.Drawing.Point(113, 90);
        	this.txtConStr.Name = "txtConStr";
        	this.txtConStr.Size = new System.Drawing.Size(297, 21);
        	this.txtConStr.TabIndex = 13;
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(28, 94);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(71, 12);
        	this.label2.TabIndex = 12;
        	this.label2.Text = "连接字符串:";
        	this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(28, 59);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(71, 12);
        	this.label1.TabIndex = 11;
        	this.label1.Text = "数据库类型:";
        	this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// cbDbType
        	// 
        	this.cbDbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.cbDbType.FormattingEnabled = true;
        	this.cbDbType.Location = new System.Drawing.Point(113, 56);
        	this.cbDbType.Name = "cbDbType";
        	this.cbDbType.Size = new System.Drawing.Size(155, 20);
        	this.cbDbType.TabIndex = 10;
        	// 
        	// btnLogin
        	// 
        	this.btnLogin.Location = new System.Drawing.Point(336, 368);
        	this.btnLogin.Name = "btnLogin";
        	this.btnLogin.Size = new System.Drawing.Size(98, 23);
        	this.btnLogin.TabIndex = 20;
        	this.btnLogin.Text = "登录";
        	this.btnLogin.UseVisualStyleBackColor = true;
        	this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
        	// 
        	// btnClose
        	// 
        	this.btnClose.Location = new System.Drawing.Point(36, 367);
        	this.btnClose.Name = "btnClose";
        	this.btnClose.Size = new System.Drawing.Size(75, 23);
        	this.btnClose.TabIndex = 21;
        	this.btnClose.Text = "退出";
        	this.btnClose.UseVisualStyleBackColor = true;
        	this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
        	// 
        	// btnTest
        	// 
        	this.btnTest.Location = new System.Drawing.Point(125, 367);
        	this.btnTest.Name = "btnTest";
        	this.btnTest.Size = new System.Drawing.Size(75, 23);
        	this.btnTest.TabIndex = 22;
        	this.btnTest.Text = "测试连接";
        	this.btnTest.UseVisualStyleBackColor = true;
        	this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
        	// 
        	// qRibbonCaption1
        	// 
        	this.qRibbonCaption1.Location = new System.Drawing.Point(0, 0);
        	this.qRibbonCaption1.Name = "qRibbonCaption1";
        	this.qRibbonCaption1.Size = new System.Drawing.Size(450, 28);
        	this.qRibbonCaption1.TabIndex = 23;
        	this.qRibbonCaption1.Text = "Moon.Orm开发平台";
        	// 
        	// statusStrip1
        	// 
        	this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.tsslblLinkBlog,
        	        	        	this.toolStripStatusLabel1,
        	        	        	this.toolStripStatusLabel2,
        	        	        	this.toolStripStatusLabel3,
        	        	        	this.toolStripStatusLabel5,
        	        	        	this.tslblQA});
        	this.statusStrip1.Location = new System.Drawing.Point(0, 403);
        	this.statusStrip1.Name = "statusStrip1";
        	this.statusStrip1.Size = new System.Drawing.Size(450, 22);
        	this.statusStrip1.TabIndex = 24;
        	this.statusStrip1.Text = "statusStrip1";
        	// 
        	// tsslblLinkBlog
        	// 
        	this.tsslblLinkBlog.IsLink = true;
        	this.tsslblLinkBlog.Name = "tsslblLinkBlog";
        	this.tsslblLinkBlog.Size = new System.Drawing.Size(68, 17);
        	this.tsslblLinkBlog.Text = "入门总指南";
        	this.tsslblLinkBlog.Click += new System.EventHandler(this.TsslblLinkBlogClick);
        	// 
        	// toolStripStatusLabel1
        	// 
        	this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
        	this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 17);
        	this.toolStripStatusLabel1.Text = "  ";
        	// 
        	// toolStripStatusLabel2
        	// 
        	this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
        	this.toolStripStatusLabel2.Size = new System.Drawing.Size(110, 17);
        	this.toolStripStatusLabel2.Text = "QQ群:225656797 ";
        	// 
        	// toolStripStatusLabel3
        	// 
        	this.toolStripStatusLabel3.IsLink = true;
        	this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
        	this.toolStripStatusLabel3.Size = new System.Drawing.Size(68, 17);
        	this.toolStripStatusLabel3.Text = "获取源代码";
        	this.toolStripStatusLabel3.Click += new System.EventHandler(this.ToolStripStatusLabel3Click);
        	// 
        	// toolStripStatusLabel5
        	// 
        	this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
        	this.toolStripStatusLabel5.Size = new System.Drawing.Size(24, 17);
        	this.toolStripStatusLabel5.Text = "    ";
        	// 
        	// tslblQA
        	// 
        	this.tslblQA.IsLink = true;
        	this.tslblQA.Name = "tslblQA";
        	this.tslblQA.Size = new System.Drawing.Size(56, 17);
        	this.tslblQA.Text = "技术咨询";
        	this.tslblQA.Click += new System.EventHandler(this.TslblQAClick);
        	// 
        	// lblVersion
        	// 
        	this.lblVersion.Location = new System.Drawing.Point(143, 113);
        	this.lblVersion.Name = "lblVersion";
        	this.lblVersion.Size = new System.Drawing.Size(100, 25);
        	this.lblVersion.TabIndex = 25;
        	this.lblVersion.Text = "ver";
        	this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// chkItem
        	// 
        	this.chkItem.Location = new System.Drawing.Point(226, 368);
        	this.chkItem.Name = "chkItem";
        	this.chkItem.Size = new System.Drawing.Size(104, 24);
        	this.chkItem.TabIndex = 26;
        	this.chkItem.Text = "同意使用条款";
        	this.chkItem.UseVisualStyleBackColor = true;
        	this.chkItem.CheckedChanged += new System.EventHandler(this.ChkItemCheckedChanged);
        	// 
        	// frmMain
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(450, 425);
        	this.Controls.Add(this.chkItem);
        	this.Controls.Add(this.lblVersion);
        	this.Controls.Add(this.statusStrip1);
        	this.Controls.Add(this.qRibbonCaption1);
        	this.Controls.Add(this.btnTest);
        	this.Controls.Add(this.btnClose);
        	this.Controls.Add(this.btnLogin);
        	this.Controls.Add(this.groupBox2);
        	this.Controls.Add(this.groupBox1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.MaximizeBox = false;
        	this.Name = "frmMain";
        	this.Text = "Moon.Orm开发平台";
        	this.Load += new System.EventHandler(this.frmMain_Load);
        	this.groupBox1.ResumeLayout(false);
        	this.groupBox1.PerformLayout();
        	this.groupBox2.ResumeLayout(false);
        	this.groupBox2.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.qRibbonCaption1)).EndInit();
        	this.statusStrip1.ResumeLayout(false);
        	this.statusStrip1.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.ToolStripStatusLabel tslblQA;
        private System.Windows.Forms.CheckBox chkItem;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.CheckBox chkNoUnderline;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsslblLinkBlog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private Qios.DevSuite.Components.Ribbon.QRibbonCaption qRibbonCaption1;

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbHistoryProject;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConStr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDbType;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbMoreFile;
        private System.Windows.Forms.RadioButton rbOneFile;
        private System.Windows.Forms.Button btnTest;
    }
}


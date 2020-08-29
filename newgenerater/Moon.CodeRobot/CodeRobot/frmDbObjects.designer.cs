namespace CodeRobot
{
    partial class frmDbObjects
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCompile = new System.Windows.Forms.Button();
            this.btnAllCancel = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lstTables = new System.Windows.Forms.CheckedListBox();
            this.btnBuild = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEntityName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSQL = new System.Windows.Forms.RichTextBox();
            this.btnBuilderCode = new System.Windows.Forms.Button();
            this.chbInheritBase = new System.Windows.Forms.CheckBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(461, 333);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.btnOpen);
            this.tabPage1.Controls.Add(this.btnRefresh);
            this.tabPage1.Controls.Add(this.btnCompile);
            this.tabPage1.Controls.Add(this.btnAllCancel);
            this.tabPage1.Controls.Add(this.btnSelectAll);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lstTables);
            this.tabPage1.Controls.Add(this.btnBuild);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(453, 308);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据库对象生成实体";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnOpenFile);
            this.tabPage2.Controls.Add(this.chbInheritBase);
            this.tabPage2.Controls.Add(this.btnBuilderCode);
            this.tabPage2.Controls.Add(this.txtSQL);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtEntityName);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(453, 308);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "SQL语句生成实体";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(331, 266);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(89, 23);
            this.btnOpen.TabIndex = 18;
            this.btnOpen.Text = "打开文件目录";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(331, 31);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(89, 23);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCompile
            // 
            this.btnCompile.Location = new System.Drawing.Point(331, 219);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(89, 23);
            this.btnCompile.TabIndex = 16;
            this.btnCompile.Text = "编译";
            this.btnCompile.UseVisualStyleBackColor = true;
            this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
            // 
            // btnAllCancel
            // 
            this.btnAllCancel.Location = new System.Drawing.Point(331, 125);
            this.btnAllCancel.Name = "btnAllCancel";
            this.btnAllCancel.Size = new System.Drawing.Size(89, 23);
            this.btnAllCancel.TabIndex = 15;
            this.btnAllCancel.Text = "全部取消";
            this.btnAllCancel.UseVisualStyleBackColor = true;
            this.btnAllCancel.Click += new System.EventHandler(this.btnAllCancel_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(331, 78);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(89, 23);
            this.btnSelectAll.TabIndex = 14;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "选择要生成的对象(框架只支持单一主键)";
            // 
            // lstTables
            // 
            this.lstTables.CheckOnClick = true;
            this.lstTables.FormattingEnabled = true;
            this.lstTables.Location = new System.Drawing.Point(11, 31);
            this.lstTables.Name = "lstTables";
            this.lstTables.Size = new System.Drawing.Size(281, 244);
            this.lstTables.TabIndex = 12;
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(331, 172);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(89, 23);
            this.btnBuild.TabIndex = 11;
            this.btnBuild.Text = "生成";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "实体名";
            // 
            // txtEntityName
            // 
            this.txtEntityName.Location = new System.Drawing.Point(60, 7);
            this.txtEntityName.Name = "txtEntityName";
            this.txtEntityName.Size = new System.Drawing.Size(220, 21);
            this.txtEntityName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "SQL语句";
            // 
            // txtSQL
            // 
            this.txtSQL.Location = new System.Drawing.Point(60, 48);
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Size = new System.Drawing.Size(374, 210);
            this.txtSQL.TabIndex = 3;
            this.txtSQL.Text = "";
            // 
            // btnBuilderCode
            // 
            this.btnBuilderCode.Location = new System.Drawing.Point(359, 275);
            this.btnBuilderCode.Name = "btnBuilderCode";
            this.btnBuilderCode.Size = new System.Drawing.Size(75, 23);
            this.btnBuilderCode.TabIndex = 4;
            this.btnBuilderCode.Text = "生成";
            this.btnBuilderCode.UseVisualStyleBackColor = true;
            this.btnBuilderCode.Click += new System.EventHandler(this.btnBuilderCode_Click);
            // 
            // chbInheritBase
            // 
            this.chbInheritBase.AutoSize = true;
            this.chbInheritBase.Checked = true;
            this.chbInheritBase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbInheritBase.Location = new System.Drawing.Point(302, 12);
            this.chbInheritBase.Name = "chbInheritBase";
            this.chbInheritBase.Size = new System.Drawing.Size(132, 16);
            this.chbInheritBase.TabIndex = 5;
            this.chbInheritBase.Text = "是否继承EntityBase";
            this.chbInheritBase.UseVisualStyleBackColor = true;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(252, 275);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(89, 23);
            this.btnOpenFile.TabIndex = 19;
            this.btnOpenFile.Text = "打开文件目录";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(11, 287);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(281, 12);
            this.progressBar1.TabIndex = 19;
            // 
            // frmDbObjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 339);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmDbObjects";
            this.Text = "frmDbObjects";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDbObjects_FormClosed);
            this.Load += new System.EventHandler(this.frmDbObjects_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCompile;
        private System.Windows.Forms.Button btnAllCancel;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox lstTables;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnBuilderCode;
        private System.Windows.Forms.RichTextBox txtSQL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEntityName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbInheritBase;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.ProgressBar progressBar1;

    }
}
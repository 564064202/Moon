using System.Windows.Forms;

namespace CodeRobot
{
    partial class frmDbObjects: Form
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
        	this.components = new System.ComponentModel.Container();
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDbObjects));
        	this.cmsSql = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.tsmiPaste = new System.Windows.Forms.ToolStripMenuItem();
         
        	this.tabPage2 = new System.Windows.Forms.TabPage();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label3 = new System.Windows.Forms.Label();
        	this.txtEntityName = new System.Windows.Forms.TextBox();
        	this.txtSQL = new System.Windows.Forms.RichTextBox();
        	this.btnBuilderCode = new System.Windows.Forms.Button();
        	this.chbInheritBase = new System.Windows.Forms.CheckBox();
        	this.tabPage1 = new System.Windows.Forms.TabPage();
        	this.btnBuild = new System.Windows.Forms.Button();
        	this.lstTables = new System.Windows.Forms.CheckedListBox();
        	this.btnSelectAll = new System.Windows.Forms.Button();
        	this.btnAllCancel = new System.Windows.Forms.Button();
        	this.btnCompile = new System.Windows.Forms.Button();
        	this.btnRefresh = new System.Windows.Forms.Button();
        	this.btnOpen = new System.Windows.Forms.Button();
        	this.progressBar1 = new System.Windows.Forms.ProgressBar();
        	this.btnCopy = new System.Windows.Forms.Button();
        	this.tabControl1 = new System.Windows.Forms.TabControl();
        	this.cmsSql.SuspendLayout();
        	//((System.ComponentModel.ISupportInitialize)(this.qRibbonCaption1)).BeginInit();
        	this.tabPage2.SuspendLayout();
        	this.tabPage1.SuspendLayout();
        	this.tabControl1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// cmsSql
        	// 
        	this.cmsSql.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.tsmiPaste});
        	this.cmsSql.Name = "cmsSql";
        	this.cmsSql.Size = new System.Drawing.Size(146, 26);
        	this.cmsSql.Opening += new System.ComponentModel.CancelEventHandler(this.CmsSqlOpening);
        	// 
        	// tsmiPaste
        	// 
        	this.tsmiPaste.Name = "tsmiPaste";
        	this.tsmiPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
        	this.tsmiPaste.Size = new System.Drawing.Size(145, 22);
        	this.tsmiPaste.Text = "粘贴";
        	this.tsmiPaste.Click += new System.EventHandler(this.TsmiPasteClick);
        	// 
        	// qRibbonCaption1
        	// 
         
        	// 
        	// tabPage2
        	// 
        	this.tabPage2.Controls.Add(this.chbInheritBase);
        	this.tabPage2.Controls.Add(this.btnBuilderCode);
        	this.tabPage2.Controls.Add(this.txtSQL);
        	this.tabPage2.Controls.Add(this.txtEntityName);
        	this.tabPage2.Controls.Add(this.label3);
        	this.tabPage2.Controls.Add(this.label2);
        	this.tabPage2.Location = new System.Drawing.Point(4, 22);
        	this.tabPage2.Name = "tabPage2";
        	this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage2.Size = new System.Drawing.Size(483, 409);
        	this.tabPage2.TabIndex = 1;
        	this.tabPage2.Text = "通过SQL生成实体";
        	this.tabPage2.UseVisualStyleBackColor = true;
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(11, 24);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(41, 12);
        	this.label2.TabIndex = 0;
        	this.label2.Text = "实体名";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(10, 63);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(47, 12);
        	this.label3.TabIndex = 2;
        	this.label3.Text = "SQL语句";
        	// 
        	// txtEntityName
        	// 
        	this.txtEntityName.Location = new System.Drawing.Point(61, 21);
        	this.txtEntityName.Name = "txtEntityName";
        	this.txtEntityName.Size = new System.Drawing.Size(220, 21);
        	this.txtEntityName.TabIndex = 1;
        	// 
        	// txtSQL
        	// 
        	this.txtSQL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        	this.txtSQL.BorderStyle = System.Windows.Forms.BorderStyle.None;
        	this.txtSQL.ContextMenuStrip = this.cmsSql;
        	this.txtSQL.Location = new System.Drawing.Point(60, 63);
        	this.txtSQL.Name = "txtSQL";
        	this.txtSQL.Size = new System.Drawing.Size(417, 300);
        	this.txtSQL.TabIndex = 3;
        	this.txtSQL.Text = "";
        	this.txtSQL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSQLKeyDown);
        	// 
        	// btnBuilderCode
        	// 
        	this.btnBuilderCode.Location = new System.Drawing.Point(402, 378);
        	this.btnBuilderCode.Name = "btnBuilderCode";
        	this.btnBuilderCode.Size = new System.Drawing.Size(75, 23);
        	this.btnBuilderCode.TabIndex = 4;
        	this.btnBuilderCode.Text = "生成(&F5)";
        	this.btnBuilderCode.UseVisualStyleBackColor = true;
        	this.btnBuilderCode.Click += new System.EventHandler(this.btnBuilderCode_Click);
        	// 
        	// chbInheritBase
        	// 
        	this.chbInheritBase.AutoSize = true;
        	this.chbInheritBase.Location = new System.Drawing.Point(287, 23);
        	this.chbInheritBase.Name = "chbInheritBase";
        	this.chbInheritBase.Size = new System.Drawing.Size(132, 16);
        	this.chbInheritBase.TabIndex = 5;
        	this.chbInheritBase.Text = "是否继承EntityBase";
        	this.chbInheritBase.UseVisualStyleBackColor = true;
        	// 
        	// tabPage1
        	// 
        	this.tabPage1.Controls.Add(this.btnCopy);
        	this.tabPage1.Controls.Add(this.progressBar1);
        	this.tabPage1.Controls.Add(this.btnOpen);
        	this.tabPage1.Controls.Add(this.btnRefresh);
        	this.tabPage1.Controls.Add(this.btnCompile);
        	this.tabPage1.Controls.Add(this.btnAllCancel);
        	this.tabPage1.Controls.Add(this.btnSelectAll);
        	this.tabPage1.Controls.Add(this.lstTables);
        	this.tabPage1.Controls.Add(this.btnBuild);
        	this.tabPage1.Location = new System.Drawing.Point(4, 22);
        	this.tabPage1.Name = "tabPage1";
        	this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage1.Size = new System.Drawing.Size(483, 409);
        	this.tabPage1.TabIndex = 0;
        	this.tabPage1.Text = "实体生成";
        	this.tabPage1.UseVisualStyleBackColor = true;
        	// 
        	// btnBuild
        	// 
        	this.btnBuild.Location = new System.Drawing.Point(371, 152);
        	this.btnBuild.Name = "btnBuild";
        	this.btnBuild.Size = new System.Drawing.Size(89, 23);
        	this.btnBuild.TabIndex = 11;
        	this.btnBuild.Text = "生成";
        	this.btnBuild.UseVisualStyleBackColor = true;
        	this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
        	// 
        	// lstTables
        	// 
        	this.lstTables.CheckOnClick = true;
        	this.lstTables.FormattingEnabled = true;
        	this.lstTables.Location = new System.Drawing.Point(11, 31);
        	this.lstTables.Name = "lstTables";
        	this.lstTables.Size = new System.Drawing.Size(331, 324);
        	this.lstTables.TabIndex = 12;
        	// 
        	// btnSelectAll
        	// 
        	this.btnSelectAll.Location = new System.Drawing.Point(371, 72);
        	this.btnSelectAll.Name = "btnSelectAll";
        	this.btnSelectAll.Size = new System.Drawing.Size(89, 23);
        	this.btnSelectAll.TabIndex = 14;
        	this.btnSelectAll.Text = "全选";
        	this.btnSelectAll.UseVisualStyleBackColor = true;
        	this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
        	// 
        	// btnAllCancel
        	// 
        	this.btnAllCancel.Location = new System.Drawing.Point(371, 112);
        	this.btnAllCancel.Name = "btnAllCancel";
        	this.btnAllCancel.Size = new System.Drawing.Size(89, 23);
        	this.btnAllCancel.TabIndex = 15;
        	this.btnAllCancel.Text = "全部取消";
        	this.btnAllCancel.UseVisualStyleBackColor = true;
        	this.btnAllCancel.Click += new System.EventHandler(this.btnAllCancel_Click);
        	// 
        	// btnCompile
        	// 
        	this.btnCompile.Location = new System.Drawing.Point(371, 192);
        	this.btnCompile.Name = "btnCompile";
        	this.btnCompile.Size = new System.Drawing.Size(89, 23);
        	this.btnCompile.TabIndex = 16;
        	this.btnCompile.Text = "编译";
        	this.btnCompile.UseVisualStyleBackColor = true;
        	this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
        	// 
        	// btnRefresh
        	// 
        	this.btnRefresh.Location = new System.Drawing.Point(371, 32);
        	this.btnRefresh.Name = "btnRefresh";
        	this.btnRefresh.Size = new System.Drawing.Size(89, 23);
        	this.btnRefresh.TabIndex = 17;
        	this.btnRefresh.Text = "刷新";
        	this.btnRefresh.UseVisualStyleBackColor = true;
        	this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
        	// 
        	// btnOpen
        	// 
        	this.btnOpen.Location = new System.Drawing.Point(371, 232);
        	this.btnOpen.Name = "btnOpen";
        	this.btnOpen.Size = new System.Drawing.Size(89, 23);
        	this.btnOpen.TabIndex = 18;
        	this.btnOpen.Text = "打开文件目录";
        	this.btnOpen.UseVisualStyleBackColor = true;
        	this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
        	// 
        	// progressBar1
        	// 
        	this.progressBar1.Location = new System.Drawing.Point(11, 361);
        	this.progressBar1.Name = "progressBar1";
        	this.progressBar1.Size = new System.Drawing.Size(331, 19);
        	this.progressBar1.TabIndex = 19;
        	// 
        	// btnCopy
        	// 
        	this.btnCopy.Location = new System.Drawing.Point(371, 272);
        	this.btnCopy.Name = "btnCopy";
        	this.btnCopy.Size = new System.Drawing.Size(89, 23);
        	this.btnCopy.TabIndex = 20;
        	this.btnCopy.Text = "复制配置";
        	this.btnCopy.UseVisualStyleBackColor = true;
        	this.btnCopy.Click += new System.EventHandler(this.BtnCopyClick);
        	// 
        	// tabControl1
        	// 
        	this.tabControl1.Controls.Add(this.tabPage1);
        	this.tabControl1.Controls.Add(this.tabPage2);
        	this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.tabControl1.Location = new System.Drawing.Point(0, 34);
        	this.tabControl1.Name = "tabControl1";
        	this.tabControl1.SelectedIndex = 0;
        	this.tabControl1.Size = new System.Drawing.Size(491, 435);
        	this.tabControl1.TabIndex = 0;
        	this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1SelectedIndexChanged);
        	// 
        	// frmDbObjects
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(491, 469);
        //	this.Controls.Add(this.qRibbonCaption1);
        	this.Controls.Add(this.tabControl1);
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Name = "frmDbObjects";
        	this.Text = "qRibbonCaption1";
        	this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDbObjects_FormClosed);
        	this.Load += new System.EventHandler(this.frmDbObjects_Load);
        	this.cmsSql.ResumeLayout(false);
        	 
        	this.tabPage2.ResumeLayout(false);
        	this.tabPage2.PerformLayout();
        	this.tabPage1.ResumeLayout(false);
        	this.tabControl1.ResumeLayout(false);
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.ToolStripMenuItem tsmiPaste;
        private System.Windows.Forms.ContextMenuStrip cmsSql;
        private System.Windows.Forms.Button btnCopy;
 
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEntityName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtSQL;
        private System.Windows.Forms.Button btnBuilderCode;
        private System.Windows.Forms.CheckBox chbInheritBase;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.CheckedListBox lstTables;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnAllCancel;
        private System.Windows.Forms.Button btnCompile;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;

        #endregion


    }
}
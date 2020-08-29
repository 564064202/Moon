/*
 * 由SharpDevelop创建。
 * 用户： qinshichuan
 * 日期: 2012-6-10
 * 时间: 16:53
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

using Moon.Orm;
using MoonDB;
using System.Threading;
namespace Enterprise
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			CheckForIllegalCrossThreadCalls=false;
			this.StartPosition= FormStartPosition.CenterScreen;
			InitializeComponent();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
		}
		
		void BtnQuitClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
		
		void CmbDBTypeSelectedIndexChanged(object sender, EventArgs e)
		{
			string type=cmbDBType.SelectedItem.ToString();
			if (type=="MSSQL"||type=="SQLITE") {
				btnHelpWriting.Enabled=true;
			}else{
				btnHelpWriting.Enabled=false;
			}
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			
			this.Text+="(评估版)";
			SetData(null);
			
		}
		void SetData(object obj){
			
//				string[] arra=Moon.Orm.DatabasesType.GetNames(typeof(Moon.Orm.DatabasesType));
//				foreach (string name in arra) {
//					cmbDBType.Items.Add(name);
//				}
			cmbDBType.Items.Add("MSSQL");
			cmbDBType.Items.Add("SQLITE");
			cmbDBType.Items.Add("MYSQL");
			cmbDBType.Items.Add("PostgreSql");
			cmbDBType.SelectedIndex=0;
			
			
			var usersSystemInfo=Lib.GetUsersSystemInfo();
			tbUsersEmail.Text=usersSystemInfo.Email;
			lblAssemblyName.Text=GetAssemblyName();
			lblSystemAssemblyName.Text=GetSystemAssemblyName();
			
			List<LinkHistory> list=DBFactory.GetEntities<LinkHistory>(
				LinkHistoryTable.ID.BiggerThan(0).OrderBy(LinkHistoryTable.ID,true));
			foreach (LinkHistory history in list) {
				cmbHistoriesLinks.Items.Add(history.ProjectName);
			}
			if (list.Count>0) {
				cmbHistoriesLinks.SelectedIndex=0;
			}
			
			//LinkHistoryTable.
			if (cmbHistoriesLinks.Items.Count==0) {
				btnFastLogin.Enabled=false;
			}
			
			dgvHistory.DataSource=list;
			
			
			
		}
		void BtnLoginClick(object sender, EventArgs e)
		{
			string linkString=tbLinkString.Text;
			if (string.IsNullOrEmpty(linkString)) {
				MessageBox.Show("请输入连接字符串","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				tbLinkString.Focus();
				return;
			}
			string ProjectName=tbProjectName.Text;
			if (string.IsNullOrEmpty(ProjectName)) {
				MessageBox.Show("请输入项目名称","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				tbProjectName.Focus();
				return;
			}
			if (string.IsNullOrEmpty(tbGenerateFilesDirectoryPath.Text)) {
				MessageBox.Show("请选择项目文件生成到哪里","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				btnShowGenerateFolder.PerformClick();
				return;
			}
			string dbType=cmbDBType.SelectedItem.ToString();
			bool markPrimaryField=chkMarkPrimaryField.Checked;
			bool existSameName=DBFactory.Exists(LinkHistoryTable.ProjectName.Equal(ProjectName));
			if (existSameName) {
				MessageBox.Show("此项目名称已存在,请重新设置","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				tbProjectName.Focus();
				tbProjectName.SelectAll();
				return;
			}
			
			LinkHistory history=new LinkHistory();
			history.AddTime=DateTime.Now;
			history.LinkString=linkString;
			history.MarkPrimaryField=markPrimaryField;
			history.ProjectName=ProjectName;
			history.DbType=cmbDBType.SelectedItem.ToString();
			history.FilesGeneratingPath=tbGenerateFilesDirectoryPath.Text;
			history.DatabaseName=_databaseName;
			
			object id=DBFactory.Add(history);
			GlobalSet.CURRENT_LINK_HISTORY=DBFactory.GetEntity<LinkHistory>(
				LinkHistoryTable.ID.Equal(id));
			this.Hide();
			try {
				FrmMain main=new FrmMain(GlobalSet.CURRENT_LINK_HISTORY.ID);
				main.Show();
			} catch (Exception ex) {
				MessageBox.Show("连接失败.\r\n"+ex.Message);
			}
			
			
		}
		
		void MainFormActivated(object sender, EventArgs e)
		{
			//cmbHistoriesLinks.Focus();
			
		}
		
		void BtnShowGenerateFolderClick(object sender, EventArgs e)
		{
			if (fbDSetGenerateFolder.ShowDialog()!= DialogResult.Cancel) {
				string directoryPath=fbDSetGenerateFolder.SelectedPath;
				tbGenerateFilesDirectoryPath.Text=directoryPath;
			}
		}
		FrmHelpSetLinkStringDialog dia;
		void BtnHelpWritingClick(object sender, EventArgs e)
		{
			string type=cmbDBType.SelectedItem.ToString();
			if (type=="MSSQL") {
				if (dia==null || dia.IsDisposed) {
					dia= new FrmHelpSetLinkStringDialog (this);
				}
				int y=this.Location.Y;
				int x=this.Location.X+this.Width;
				dia.Location=new Point(x,y);
				dia.Show();
			}else if(type=="SQLITE"){
				
			}
			
		}
		private string _databaseName;
		public void SetLinkString(string link,string databaseName){
			tbLinkString.Text=link;
			_databaseName=databaseName;
		}
		
		
		void TbGenerateFilesDirectoryPathDoubleClick(object sender, EventArgs e)
		{
			if (tbGenerateFilesDirectoryPath.Text!="") {
				tbGenerateFilesDirectoryPath.SelectAll();
			}
		}
		
		
		private string GetAssemblyName(){
			string path=Application.StartupPath;
			var  assembly= Assembly.LoadFile(path+"\\Moon.Orm.dll");
			return assembly.FullName;
		}
		private string GetSystemAssemblyName(){
			
			var  assembly= Assembly.GetEntryAssembly();
			return assembly.FullName;
		}
		
		void LinklbCnBlogsLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://www.cnblogs.com/humble");
		}
		
		void LinklbFAQLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://www.cnblogs.com/humble/category/372052.html");
		}
		
		void BtnSendEmailClick(object sender, EventArgs e)
		{
			string content=tbEmail.Text;
			string ownEmail=tbUsersEmail.Text;
			
			Tool.SendEmail("邮件技术支持->",
			               content,"qsmy_qin@163.com",ownEmail);
			MessageBox.Show("邮件发送成功!");
		}
		
		void MainFormRegionChanged(object sender, EventArgs e)
		{
			
			
		}
		
		void MainFormLocationChanged(object sender, EventArgs e)
		{
			if (dia!=null) {
				int y=this.Location.Y;
				int x=this.Location.X+this.Width;
				dia.Location=new Point(x,y);
			}
			
		}
		
		void BtnFastLoginClick(object sender, EventArgs e)
		{
			
			var hh =DBFactory.GetEntity<LinkHistory>(
				LinkHistoryTable.ProjectName.Equal(cmbHistoriesLinks.SelectedItem.ToString()));

			var ret=DbHelper.DataBase.IsLinkStringOK(hh.LinkString,hh.DbType);
			if ("true"==ret) {
				GlobalSet.CURRENT_LINK_HISTORY=hh;
				this.Hide();
				try {
					FrmMain main=new FrmMain(hh.ID);
					main.Show();
				} catch (Exception ex) {
					
					MessageBox.Show(ex.Message);
				}
				
			}else{
				MessageBox.Show(ret,"提示(连接数据库失败)",MessageBoxButtons.OK,MessageBoxIcon.Information);
				
			}
			
			
		}
		
		void BtmSaveUsersEmailClick(object sender, EventArgs e)
		{
			var email=tbUsersEmail.Text;
			if (email!="") {
				UsersSystemInfo info=new UsersSystemInfo();
				info.Email=email;
				info.SetOnlyMark(UsersSystemInfoTable.ID.Equal(1));
				DBFactory.Update(info);
				MessageBox.Show("保存成功","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				
			}
		}
		
		
		
		void LblNewestLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string url="http://www.cnblogs.com/humble/archive/2012/09/02/2667843.html";
			Process.Start(url);
		}
		
		
		
		void DgvHistoryCellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				if (e.Button == System.Windows.Forms.MouseButtons.Right&&e.ColumnIndex>-1&&e.RowIndex>-1)
				{
					
					dgvHistory.ClearSelection();
					dgvHistory.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
					var ID=dgvHistory.Rows[e.RowIndex].Cells[7].Value;
					var cellValue=dgvHistory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
					var fieldName=dgvHistory.Columns[e.ColumnIndex].DataPropertyName;
					if (fieldName=="DbType"||fieldName=="ID") {
						FrmEditCell.GetSingleton().Hide();
						return;
					}
					cellValue=cellValue==null?"":cellValue;
					FrmEditCell.GetSingleton().Location=MousePosition;
					FrmEditCell.GetSingleton().SetValue(Convert.ToInt64(ID),fieldName,cellValue.ToString(),dgvHistory);
					FrmEditCell.GetSingleton().Show();
				}else{
					FrmEditCell.GetSingleton().Hide();
				}
			}
		}
	}
}

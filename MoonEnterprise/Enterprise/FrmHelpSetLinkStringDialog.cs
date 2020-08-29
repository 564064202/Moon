/*
 * 由SharpDevelop创建。
 * 用户： qinshichuan
 * 日期: 2012-6-16
 * 时间: 16:47
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Moon.Orm;
using MoonDB;
using Moletrator.SQLDocumentor;

namespace Enterprise
{
	/// <summary>
	/// Description of FrmHelpSetLinkStringDialog.
	/// </summary>
	public partial class FrmHelpSetLinkStringDialog : Form
	{
		public FrmHelpSetLinkStringDialog( MainForm main)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			_main=main;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		private MainForm _main;
		
		void FrmHelpSetLinkStringDialogLoad(object sender, EventArgs e)
		{
			
		}
		
		
		bool _intailServerList=false;
		
		
		 
		
		 
		
		void BtnIntailClick(object sender, EventArgs e)
		{
			if (_intailServerList==false) {
				SQLInfoEnumerator sie = new SQLInfoEnumerator();
				var all=sie.EnumerateSQLServers();
				var onlyExpress=DbHelper.DataBase.IsOnlyLocalExpressServer();
				foreach (var a in all) {
					if (a=="(local)"&&onlyExpress) {
						cmbSerserList.Items.Add("localhost\\sqlexpress");
					}else{
						cmbSerserList.Items.Add(a);
					}
				}
				cmbSerserList.SelectedIndex=0;
				_intailServerList=true;
				btnIntail.Enabled=false;
				if (cmbSerserList.SelectedItem.ToString().Contains("local")) {
					rbtnWindows.Checked=true;
					var list=(DbHelper.DataBase.GetDatabaseListByListString());
					if(list.Count>0){
						foreach (var a in list) {
							cmbDatabaseList.Items.Add(a);
						}
						cmbDatabaseList.SelectedIndex=0;
						tbUserName.Enabled=false;
						tbPassword.Enabled=false;
					}else{
						cmbDatabaseList.Enabled=false;
						MessageBox.Show("数据表获取失败,系统不允许获取,登陆可能失败.","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
					}
				}
			}
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void BtnTestClick(object sender, EventArgs e)
		{
			
			string link="Data Source="+cmbSerserList.Text+";Integrated Security=SSPI;Initial Catalog="+cmbDatabaseList.Text+";";
			System.Data.SqlClient.SqlConnection conn=null;
			try {
				conn=new System.Data.SqlClient.SqlConnection(link);
				conn.Open();
				MessageBox.Show("连接成功.","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				
			} catch (Exception ex) {
				
				MessageBox.Show("连接失败\r\n"+ex.Message,"提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				
			}
			finally{
				conn.Close();
			}
			
		}
		
		void BtnSaveClick(object sender, EventArgs e)
		{
			string link="Data Source="+cmbSerserList.Text+";Integrated Security=SSPI;Initial Catalog="+cmbDatabaseList.Text+";";
			var conn=new System.Data.SqlClient.SqlConnection(link);
			try {
				conn.Open();
				_main.SetLinkString(link,cmbDatabaseList.SelectedItem.ToString());
				this.DialogResult= DialogResult.OK;
				this.Close();
			} catch (Exception ex) {
				
				var ret=MessageBox.Show("数据库无法连接,是否继续保存?\r\n"+ex.Message,"提示",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
				
				if (ret== DialogResult.OK) {
					
					MessageBox.Show("保存成功\r\n"+ex.Message,"提示",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
				
				}
				 
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using CodeRobot;
using Moon.CodeBuider;
using Moon.LanguageExpert;
using Moon.Orm;
using Qios.DevSuite.Components;
using Qios.DevSuite.Components.Ribbon;

namespace CodeRobot
{
	public partial class frmMain : QRibbonForm
	{
		string defaultFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		public frmMain()
		{
			InitializeComponent();
			StartPosition= FormStartPosition.CenterScreen;
			this.MaximizeBox=false;
			lblVersion.Text= "版本号:"+System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			InitControl();
			string path=Moon.Orm.GlobalData.DLL_EXE_DIRECTORY_PATH+"checked.pdb";
			  SystemHelper.RegistersetValue();
				if(File.Exists(path)){
					chkItem.Checked=true;
				}
			 
		}

		private void InitControl()
		{
			this.txtFilePath.Text = defaultFilePath;
			FillDDL();
			LoadHistory();
		}

		protected void FillDDL()
		{
			this.cbDbType.Items.Clear();

			this.cbDbType.Items.Add(DbType.SqlServer.ToString());
			this.cbDbType.Items.Add(DbType.MySql.ToString());
			//this.cbDbType.Items.Add(DbType.Oracle.ToString());
			this.cbDbType.Items.Add(DbType.Sqlite.ToString());

			this.cbDbType.SelectedIndex = 0;
		}

		protected void LoadHistory()
		{
			cbHistoryProject.Items.Clear();
			cbHistoryProject.Items.Add(new CustomerDbConfig { ProjectName = "", ConnectionString = null });

			List<CustomerDbConfig> list = GetHistoryProject();

			foreach (CustomerDbConfig config in list)
			{
				cbHistoryProject.Items.Add(config);
			}
			cbHistoryProject.DisplayMember = "ProjectName";
			cbHistoryProject.SelectedIndex = 0;
		}

		private void cbHistoryProject_SelectedIndexChanged(object sender, EventArgs e)
		{
			CustomerDbConfig dbConfig = (CustomerDbConfig)cbHistoryProject.SelectedItem;
			if (dbConfig.ProjectName == "")
			{
				cbDbType.SelectedIndex = 0;
				txtConStr.Text = "";
				txtProjectName.Text = "";
				groupBox2.Text="新建项目";
			}
			else
			{
				groupBox2.Text="项目信息";
				cbDbType.SelectedItem = GetDbType(dbConfig.ProviderName);
				txtConStr.Text = dbConfig.ConnectionString;
				txtProjectName.Text = dbConfig.ProjectName;
			}
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			if (Moon.Orm.Util.StringUtil.IsNullOrWhiteSpace(txtFilePath.Text)==false) {
				if(Directory.Exists(txtFilePath.Text))
					this.folderBrowserDialog1.SelectedPath=txtFilePath.Text;
			}
			this.folderBrowserDialog1.ShowDialog();
			txtFilePath.Text = this.folderBrowserDialog1.SelectedPath;
		}
		Random _rand=new Random(100);
		public void ShowMyBlog(){
			
			string url="http://files.cnblogs.com/files/humble/d.pdf?r="+_rand.Next();
			Process.Start(url);
		}
		private void btnLogin_Click(object sender, EventArgs e)
		{
			if(chkItem.Checked==false){
				MessageBox.Show("请同意使用条款","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
			try
			{
				if (TestConnection())
				{
					SaveDbConfiger();
					frmDbObjects frm = new frmDbObjects();
					frm.StartPosition=FormStartPosition.CenterScreen;
					frm.ConnectionStr = txtConStr.Text;
					frm.NameSpace = txtProjectName.Text;
					frm.FilePath = txtFilePath.Text;
					frm.DataBaseType = this.cbDbType.SelectedItem.ToString();
					frm.BuildFileType = rbOneFile.Checked ? BuildClassFileType.AllInOneFile : BuildClassFileType.OneClassOneFile;
					frm.Show();
					frm.Text=txtProjectName.Text;
					//this.Hide();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("连接失败！错误信息：" + ex.Message);
			}
		}

		private string GetDbProvider(string dbType)
		{
			string provider = "Moon.Orm,SqlServer";
			switch (dbType)
			{
				case "SqlServer":
					provider = "Moon.Orm,SqlServer";
					break;
				case "MySql":
					provider = "Moon.Orm,Moon.Orm.MySql";
					break;
				case "Oracle":
					provider = "Moon.Orm,Moon.Orm.Oracle";
					break;
				case "Sqlite":
					provider = "Moon.Orm,Moon.Orm.Sqlite";
					break;
			}
			return provider;
		}

		private string GetDbType(string dbProvider)
		{
			string dbType = "SqlServer";
			switch (dbProvider)
			{
				case "Moon.Orm,SqlServer":
					dbType = "SqlServer";
					break;
				case "Moon.Orm,Moon.Orm.MySql":
					dbType = "MySql";
					break;
				case "Moon.Orm,Moon.Orm.Oracle":
					dbType = "Oracle";
					break;
				case "Moon.Orm,Moon.Orm.Sqlite":
					dbType = "Sqlite";
					break;
			}
			return dbType;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			System.Environment.Exit(0);
		}

		private void SaveDbConfiger()
		{
			UpdateOrCreateConnectionString(txtProjectName.Text, txtConStr.Text, GetDbProvider(cbDbType.SelectedItem.ToString()));
		}

		// <summary>
		/// 更新或新增[connectionStrings]节点的子节点值，存在则更新子节点,不存在则新增子节点，返回成功与否布尔值
		/// </summary>
		/// <param name="configurationFile">要操作的配置文件名称,枚举常量</param>
		/// <param name="name">子节点name值</param>
		/// <param name="connectionString">子节点connectionString值</param>
		/// <param name="providerName">子节点providerName值</param>
		/// <returns>返回成功与否布尔值</returns>
		public bool UpdateOrCreateConnectionString(string name, string connectionString, string providerName)
		{
			bool isSuccess = false;
			string filename =  System.Windows.Forms.Application.ExecutablePath + ".config";

			XmlDocument doc = new XmlDocument();
			doc.Load(filename);

			XmlNode node = doc.SelectSingleNode("//connectionStrings");

			try
			{
				XmlElement element = (XmlElement)node.SelectSingleNode("//add[@name='" + name + "']");

				if (element != null)
				{
					//存在则更新子节点
					element.SetAttribute("connectionString", connectionString);
					element.SetAttribute("providerName", providerName);
				}
				else
				{
					//不存在则新增子节点
					XmlElement subElement = doc.CreateElement("add");
					subElement.SetAttribute("name", name);
					subElement.SetAttribute("connectionString", connectionString);
					subElement.SetAttribute("providerName", providerName);
					node.AppendChild(subElement);
				}
				doc.Save(filename);

				isSuccess = true;
			}
			catch
			{
				isSuccess = false;
			}

			return isSuccess;
		}

		private bool DeleteConfig(string configName)
		{
			bool isSuccess = false;
			string filename =  System.Windows.Forms.Application.ExecutablePath + ".config";

			XmlDocument doc = new XmlDocument();
			doc.Load(filename);

			XmlNode node = doc.SelectSingleNode("//connectionStrings");

			try
			{
				XmlElement element = (XmlElement)node.SelectSingleNode("//add[@name='" + configName + "']");
				if (element != null)
				{
					node.RemoveChild(element);
					doc.Save(filename);
					isSuccess = true;
				}
			}
			catch
			{
				isSuccess = false;
			}
			return isSuccess;
		}

		private List<CustomerDbConfig> GetHistoryProject()
		{
			List<CustomerDbConfig> list = new List<CustomerDbConfig>();
			string filename =  System.Windows.Forms.Application.ExecutablePath + ".config";

			XmlDocument doc = new XmlDocument();
			doc.Load(filename); //加载配置文件

			XmlNode node = doc.SelectSingleNode("//connectionStrings");   //得到[connectionStrings]节点

			foreach (XmlNode node1 in node.ChildNodes)
			{
				CustomerDbConfig config = new CustomerDbConfig();
				config.ProjectName = node1.Attributes["name"].Value;
				config.ConnectionString = node1.Attributes["connectionString"].Value;
				config.ProviderName = node1.Attributes["providerName"].Value;
				list.Add(config);
			}

			return list;
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			var project = (CustomerDbConfig)cbHistoryProject.SelectedItem;
			bool flag = DeleteConfig(project.ProjectName);
			if (flag)
			{
				cbHistoryProject.Items.Remove(project);
				cbDbType.SelectedIndex = 0;
				txtConStr.Text = "";
				txtProjectName.Text = "";
			}

		}

		private void btnTest_Click(object sender, EventArgs e)
		{
			try
			{
				if (TestConnection())
				{
					MessageBox.Show("连接成功！");
				}
				else
				{
					MessageBox.Show("连接失败！");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("连接失败！错误信息："+ex.Message);
			}
		}

		private bool TestConnection()
		{
			bool flag = true;
			try
			{
				Db db = null;
				string strConnection = txtConStr.Text;
				switch (this.cbDbType.SelectedItem.ToString().ToLower())
				{
					case "sqlserver":
						db = new SqlServer(strConnection);
						break;
					case "mysql":
						db = new MySql(strConnection);
						break;
					case "oracle":

						break;
					case "sqlite":
						db = new Sqlite(strConnection);
						break;

				}
				if (db == null)
				{
					flag = false;
				}
			}
			catch(Exception ex)
			{
				flag = false;
				throw ex;
			}
			
			return flag;
		}
		
		void TsslblLinkBlogClick(object sender, EventArgs e)
		{
			ShowMyBlog();
		}
		
		
		void ChkNoUnderlineCheckedChanged(object sender, EventArgs e)
		{
			GenUtil.ChkNoUnderline=chkNoUnderline.Checked;
		}
		
		void ToolStripStatusLabel4Click(object sender, EventArgs e)
		{
			string url="http://lko2o.com/moon/article/199";
			Process.Start(url);
		}
		
		void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			
			string url="http://lko2o.com/moon/article/208";
			Process.Start(url);
		}
		
		void ChkItemCheckedChanged(object sender, EventArgs e)
		{
			string path=Moon.Orm.GlobalData.DLL_EXE_DIRECTORY_PATH+"checked.pdb";
			if (chkItem.Checked) {
				if(File.Exists(path)==false){
					File.Create(path).Close();
				}
			}else{
				if(File.Exists(path)){
					File.Delete(path);
				}
			}
		}
        
        void TslblQAClick(object sender, EventArgs e)
        {
        	FrmWb frm=new FrmWb("技术咨询","http://lko2o.com/moon/article/199");
        	frm.Show();
        }
        
        
        
        void ToolStripStatusLabel3Click(object sender, EventArgs e)
        {
        	string url="http://www.cnblogs.com/humble/p/3323161.html";
        	FrmWb frm=new FrmWb("获取源码",url);
        	frm.Show();
        }
	}

	public class CustomerDbConfig
	{
		public string ProjectName { get; set; }

		public string ConnectionString { get; set; }

		public string ProviderName { get; set; }
	}

}

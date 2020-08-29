using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Moon.Orm;
using Moon.CodeBuider;
using System.Configuration;
using System.Xml;

namespace CodeRobot
{
	public partial class frmMain : Form
	{
		string defaultFilePath = "D:\\Moon.Model\\";
		public frmMain()
		{
			InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			InitControl();
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
			}
			else
			{
				cbDbType.SelectedItem = GetDbType(dbConfig.ProviderName);
				txtConStr.Text = dbConfig.ConnectionString;
				txtProjectName.Text = dbConfig.ProjectName;
			}
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			this.folderBrowserDialog1.ShowDialog();
			txtFilePath.Text = this.folderBrowserDialog1.SelectedPath;
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			try
			{
				if (TestConnection())
				{
					SaveDbConfiger();
					frmDbObjects frm = new frmDbObjects();

					frm.ConnectionStr = txtConStr.Text;
					frm.NameSpace = txtProjectName.Text;
					frm.FilePath = txtFilePath.Text;
					frm.DataBaseType = this.cbDbType.SelectedItem.ToString();
					frm.BuildFileType = rbOneFile.Checked ? BuildClassFileType.AllInOneFile : BuildClassFileType.OneClassOneFile;
					frm.Show();

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
	}

	public class CustomerDbConfig
	{
		public string ProjectName { get; set; }

		public string ConnectionString { get; set; }

		public string ProviderName { get; set; }
	}

}

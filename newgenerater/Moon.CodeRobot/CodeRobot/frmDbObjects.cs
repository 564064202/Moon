using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Moon.Orm;
using Moon.CodeBuider;
using System.CodeDom.Compiler;

namespace CodeRobot
{
	public partial class frmDbObjects : Form
	{
		public frmDbObjects()
		{
			InitializeComponent();
		}
		private DbObjectBase dbBase = null;
		public string DataBaseType { get; set; }
		public string ConnectionStr { get; set; }
		public string NameSpace { get; set; }
		public string FilePath { get; set; }

		public BuildClassFileType BuildFileType { get; set; }

		private CodeBuiderMain codeBuilder = null;

		private void frmDbObjects_Load(object sender, EventArgs e)
		{
			try
			{
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
		}

		private void btnBuild_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("点击生成会先清空生成目录下的文件，请注意备份文件!\r\n你确定要生成吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dr == DialogResult.Yes)
			{
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
						string msg = string.Empty;
						
						codeBuilder.BuildeEntityCode(listTables, BuildFileType,progressBar1, ref msg);

						if (string.IsNullOrEmpty(msg))
						{
							msg = "生成成功！";
						}
						else
						{
							msg = "生成成功！但表【" + msg+"】有多个主键，没有生成实体。";
						}

						MessageBox.Show(msg);
					}
					else
					{
						MessageBox.Show("请选择要生成的表！");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error,
					                MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, false);
				}
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
			System.Diagnostics.Process.Start("file:\\" + FilePath);
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
				MessageBox.Show("请输入要生成的实体名称！");
			}
			else
			{
				if (codeBuilder == null)
				{
					codeBuilder = new CodeBuiderMain(dbBase, NameSpace, FilePath);
				}
				try
				{
					codeBuilder.BuildClassBySQL(NameSpace, txtEntityName.Text.Trim(), chbInheritBase.Checked, txtSQL.Text.Trim());
					MessageBox.Show("生成成功！");
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
			System.Diagnostics.Process.Start("file:\\" + FilePath);
		}

		

	}
}

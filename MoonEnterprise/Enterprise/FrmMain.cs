/*
 * 由SharpDevelop创建。
 * 用户： qinshichuan
 * 日期: 2012-6-30
 * 时间: 16:35
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Moon.Orm;
using MoonDB;

namespace Enterprise
{
	/// <summary>
	/// Description of FrmMain.
	/// </summary>
	public partial class FrmMain : Form
	{
		
		public FrmMain(long historyID):base()
		{
			
			InitializeComponent();
			this.Text="Moon.Net研发平台";
			_currentCogifg=DBFactory.GetEntity<LinkHistory>(
				LinkHistoryTable.ID.Equal(historyID));
			CheckForIllegalCrossThreadCalls=false;
			DateTime dt=new DateTime(2013,12,25);
			if (DateTime.Now>dt) {
				this.Close();
			}
			
		}
		private LinkHistory _currentCogifg;
		void FrmMainFormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
			
		}
		void FrmMainSizeChanged(object sender, EventArgs e)
		{
//			int x=this.Width-gbProcess.Width;
//			int y=tbSql.Location.Y+tbSql.Height;
//			Point p=new Point(x,gbProcess.Height);
//			gbProcess.Location=p;
		}
		void FrmMainLoad(object sender, EventArgs e)
		{
			var father = new TreeNode(_currentCogifg.ProjectName+"(双击展开所有表)");
			father.Name = "moonparent";
			father.ImageIndex=0;
			tvDatabase.Nodes.Add(father);
			father.SelectedImageIndex=2;
			
			
			//
			string path=Application.StartupPath;
			var  _assembly= Assembly.LoadFile(path+"\\Moon.Orm.dll");
			string type = "Moon.Orm.EntityBuilder." + _currentCogifg.DbType;
			Type tp = _assembly.GetType(type);
			object[] constructParms = new object[]
			{
				
			};
			var db= Activator.CreateInstance(tp, constructParms) as Moon.Orm.EntityBuilder.DbBase;
			
			if (GlobalSet.CURRENT_LINK_HISTORY.DbType=="MYSQL"&&string.IsNullOrEmpty(GlobalSet.CURRENT_LINK_HISTORY.DatabaseName))
			{
				string link=_currentCogifg.LinkString.ToLower();
				int index1=link.IndexOf("database")+8;
				link=link.Substring(index1);
				int a=link.IndexOf("=");
				int b=link.IndexOf(";");
				string name=link.Substring(a+1,b-a-1);
				_currentCogifg.DatabaseName=name;
			}
			var list=db.GetDBsAllTableList(_currentCogifg.LinkString,_currentCogifg.DatabaseName);
			//
			foreach (var a in list) {
				var newNode = new TreeNode(a);
				newNode.Name = a;
				newNode.ImageIndex=1;
				newNode.SelectedImageIndex=2;
				father.Nodes.Add(newNode);
				
			}
		}
		
		void TvDatabaseMouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				tvDatabase.SelectedNode = tvDatabase.GetNodeAt(e.X, e.Y);
			}
			else{
				tvDatabase.SelectedNode = tvDatabase.GetNodeAt(e.X, e.Y);
				TsmSeeStructClick();
			}
		}
		
		
		
		void CmsTreeOpening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			tsmGenerateEntity.Text="生成对应实体";
			var node=tvDatabase.SelectedNode;
			if (node==null) {
				e.Cancel=true;
				return;
			}
			if (node.Name=="moonparent") {
				tsmGenerateEntity.Text="生成该库所有实体";
			}
			
		}
		public class FS{
			public Form FP;
			public FrmAllEntities FM;
		}
		
		void ShowAll(object obj){
			var fs=obj as FS;
			var fp=fs.FP;
			var fm=fs.FM;
			string path=Application.StartupPath;
			var  _assembly= Assembly.LoadFile(path+"\\Moon.Orm.dll");
			string type = "Moon.Orm.EntityBuilder." + _currentCogifg.DbType;
			string engineTypeString="Moon.Orm." + _currentCogifg.DbType;
			Type tp = _assembly.GetType(type);
			Type engineType=_assembly.GetType(engineTypeString);
			DB engine=null;
			
			object[] engineconstructParms = new object[]
			{
				_currentCogifg.LinkString
					
			};
			engine=Activator.CreateInstance(engineType, engineconstructParms) as Moon.Orm.DB;
			object[] constructParms = new object[]
			{
				_currentCogifg.ProjectName,
				"Table",engine
			};
			
			var db= Activator.CreateInstance(tp, constructParms) as Moon.Orm.EntityBuilder.DbBase;
			db.SetDbName(_currentCogifg.DatabaseName);
			string code=db.GetYourModel();
			fp.Hide();
			fp.Dispose();
			fm.SetCode(code);
			fm.Show();
			Thread.CurrentThread.Abort();
			
		}
		private Thread _threadProgress;
		private void ShowAllEntitiesWithProgress(){
			FrmProgress fp=new FrmProgress();
			fp.Show();
			var frm=new FrmAllEntities("",_currentCogifg,this);
			frm.Text+=_currentCogifg.DatabaseName;
			
			_threadProgress=new Thread(
				new ParameterizedThreadStart(ShowAll));
			var fs=new FS();
			fs.FP=fp;
			fs.FM=frm;
			_threadProgress.Start(fs);
		}
		void TsmGenerateEntityClick(object sender, EventArgs e)
		{
			var node=tvDatabase.SelectedNode;
			if (node==null) {
				
				return;
			}
			if (node.Name=="moonparent") {
				ShowAllEntitiesWithProgress();
				
			}else{
				string path=Application.StartupPath;
				var  _assembly= Assembly.LoadFile(path+"\\Moon.Orm.dll");
				string type = "Moon.Orm.EntityBuilder." + _currentCogifg.DbType;
				string engineTypeString="Moon.Orm." + _currentCogifg.DbType;
				Type tp = _assembly.GetType(type);
				Type engineType=_assembly.GetType(engineTypeString);
				DB engine=null;
				object[] engineconstructParms = new object[]
				{
					_currentCogifg.LinkString
						
				};
				engine=Activator.CreateInstance(engineType, engineconstructParms) as Moon.Orm.DB;
				object[] constructParms = new object[]
				{
					_currentCogifg.DatabaseName,
					"Table",engine
				};
				
				var db= Activator.CreateInstance(tp, constructParms) as Moon.Orm.EntityBuilder.DbBase;
				db.SetDbName(_currentCogifg.DatabaseName);
				string code=db.GenerateOneEntity(node.Text)+"\r\n"+db.GenerateOneEntitySet(node.Text);
				var frm=new FrmEntity(code,_currentCogifg,this);
				frm.Text+=_currentCogifg.DatabaseName;
				frm.Show();
			}
		}
		
		void TsmSeeStructClick()
		{
			var node=tvDatabase.SelectedNode;
			if (node==null) {
				return;
			}
			if (node.Name!="moonparent")
			{
				
				string path=Application.StartupPath;
				var  _assembly= Assembly.LoadFile(path+"\\Moon.Orm.dll");
				string type = "Moon.Orm.EntityBuilder." + _currentCogifg.DbType;
				string engineTypeString="Moon.Orm." + _currentCogifg.DbType;
				Type tp = _assembly.GetType(type);
				Type engineType=_assembly.GetType(engineTypeString);
				DB engine=null;
				object[] engineconstructParms = new object[]
				{
					_currentCogifg.LinkString
						
				};
				engine=Activator.CreateInstance(engineType, engineconstructParms) as Moon.Orm.DB;
				object[] constructParms = new object[]
				{
					_currentCogifg.DatabaseName,
					"Table",engine
				};
				
				var db= Activator.CreateInstance(tp, constructParms) as Moon.Orm.EntityBuilder.DbBase;
				var tb=db.GetTablesDataTableStruct(node.Text);
				dgvShowDB.DataSource=tb;
				
				
			}
		}
		
		
		
		void BtnEexcuteClick(object sender, EventArgs e)
		{
			
			if (tbSql.Text!="") {
				try {
					string path=Application.StartupPath;
					var  _assembly= Assembly.LoadFile(path+"\\Moon.Orm.dll");
					string type = "Moon.Orm.EntityBuilder." + _currentCogifg.DbType;
					string engineTypeString="Moon.Orm." + _currentCogifg.DbType;
					Type tp = _assembly.GetType(type);
					Type engineType=_assembly.GetType(engineTypeString);
					DB engine=null;
					object[] engineconstructParms = new object[]
					{
						_currentCogifg.LinkString
							
					};
					engine=Activator.CreateInstance(engineType, engineconstructParms) as Moon.Orm.DB;
					var tb=engine.GetDataTable(tbSql.Text);
					dgvShowDB.DataSource=tb;
				} catch (Exception ex) {
					
					MessageBox.Show(ex.Message);
				}
			}else{
				MessageBox.Show("请输入sql语句");
				tbSql.Focus();
			}
		}
		
		void BtnClearClick(object sender, EventArgs e)
		{
			tbSql.Clear();
		}
		
		void bntGenerateEntityClick(object sender, EventArgs e)
		{
			try {
				string path=Application.StartupPath;
				var  _assembly= Assembly.LoadFile(path+"\\Moon.Orm.dll");
				string typed = "Moon.Orm.EntityBuilder." + _currentCogifg.DbType;
				string engineTypeString="Moon.Orm." + _currentCogifg.DbType;
				Type tp = _assembly.GetType(typed);
				Type engineType=_assembly.GetType(engineTypeString);
				DB engine=null;
				object[] engineconstructParms = new object[]
				{
					_currentCogifg.LinkString
						
				};
				engine=Activator.CreateInstance(engineType, engineconstructParms) as Moon.Orm.DB;
				
				
				string sql=tbSql.Text;
				var table=engine.GetDataTable(sql);
				DataColumnCollection datacolumns=table.Columns;
				StringBuilder sb=new StringBuilder();
				sb.AppendLine("public class 生成类{\r\n");
				foreach (DataColumn dc in datacolumns) {
					string name=dc.ColumnName;
					string type= dc.DataType.ToString();
					int index=type.LastIndexOf(".");
					type=type.Substring(index+1);
					sb.AppendLine("		private "+type+" _"+name+";");
					sb.AppendLine("		public  "+type+"  "+name+" {");
					sb.AppendLine("		get{");
					sb.AppendLine("			return _"+name+";");
					sb.AppendLine("		}");
					sb.AppendLine("		set{");
					sb.AppendLine(" 			_"+name+"=value;");
					sb.AppendLine("		}");
					sb.AppendLine("		}");
				}
				sb.AppendLine("}");
				FrmGCode frm=new FrmGCode(sb.ToString());
				frm.ShowDialog();
			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}
		
		
		
		
		
		void ToolStripButton1Click(object sender, EventArgs e)
		{

			StringBuilder sb=new StringBuilder();
			
			sb.AppendLine("<add key=\"dbType\" value=\""+_currentCogifg.DbType+"\" />");
			sb.AppendLine("<add key=\"linkString\" value=\""+_currentCogifg.LinkString+"\" />");
			string ret=sb.ToString();
			Clipboard.SetText(ret);
			MessageBox.Show("复制成功\r\n"+ret,"提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}
		
		void TsbGenerateEntitiesClick(object sender, EventArgs e)
		{
			ShowAllEntitiesWithProgress();
		}
		
		void TsmCopyClick(object sender, EventArgs e)
		{
			
			var node=tvDatabase.SelectedNode;
			if (node==null) {
				return;
			}else{
				if (node.Name!="moonparent")
				{
					Clipboard.SetText(node.Text);
					MessageBox.Show("复制成功\r\n"+node.Text,"提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
					
				}else{
					Clipboard.SetText(_currentCogifg.DatabaseName);
					MessageBox.Show("复制成功\r\n"+_currentCogifg.DatabaseName,"提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
					
				}
				
			}
		}
		
		void BtnCloseClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void TbSqlMouseEnter(object sender, EventArgs e)
		{
			if (tbSql.Text=="在此输入sql语句") {
				tbSql.Clear();
			}
		}
		
		void 系统APIToolStripMenuItemClick(object sender, EventArgs e)
		{
			Process.Start("Moon.ORM帮助文档.chm");
		}
		
		void 博客文章ToolStripMenuItemClick(object sender, EventArgs e)
		{
			Process.Start("http://www.cnblogs.com/humble/category/372052.html");
		}
		
		void ToolStripDropDownButton3Click(object sender, EventArgs e)
		{
			Process.Start("http://www.cnblogs.com/humble");
		}
	}
}

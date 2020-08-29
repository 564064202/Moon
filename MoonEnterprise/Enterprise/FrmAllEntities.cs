/*
 * 由SharpDevelop创建。
 * 用户： qinshichuan
 * 日期: 2012-9-1
 * 时间: 15:16
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using  MoonDB;
namespace Enterprise
{
	/// <summary>
	/// Description of FrmAllEntities.
	/// </summary>
	public partial class FrmAllEntities : Form
	{
		public FrmAllEntities(string code,LinkHistory his,Form p)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			
			this.MaximizeBox=false;
			InitializeComponent();
			this.tbCode.Text=code;
			_his=his;
			this.Location=new Point(p.Location.X+300,p.Location.Y);
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		private LinkHistory _his;
		public void SetCode(string code){
			tbCode.Text=code;
		}
		void BtnComplieClick(object sender, EventArgs e)
		{
			string fileString=tbCode.Text;
			try {
				if (string.IsNullOrEmpty(fileString)) {
					MessageBox.Show("请先生成系统实体");
					return;
				}
			 
				string _generateString=_his.FilesGeneratingPath;
				int s1=fileString.IndexOf("namespace");
				int  s2=fileString.IndexOf("{");
				string name=fileString.Substring(s1+9,s2-s1-9);
				name=name.Replace(" ","");
				System .IO.StreamWriter sw=new System.IO.StreamWriter(_generateString+name+".cs");
				sw.WriteLine(fileString);
				sw.Close();
				name= _generateString+name+".dll";
				var ret=Tool.Complie(fileString,name);
				MessageBox.Show(ret);
				System.Diagnostics.Process.Start("explorer","/select,"+name);
				string host= System.Net.Dns.GetHostName() ;
				Tool.SendEmail("("+host+")使用Moon.ORM",host,"qsmy_qin@163.com","564064202@qq.com");
				
			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
				
			}
		}
		
		void BtnCopyClick(object sender, EventArgs e)
		{
			try{
				Clipboard.SetText(tbCode.Text);
				MessageBox.Show("复制成功");}
			catch{
				MessageBox.Show("复制失败");
			}
		}
	}
}

/*
 * 由SharpDevelop创建。
 * 用户： qinshichuan
 * 日期: 2012-9-1
 * 时间: 19:56
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using MoonDB;
using Moon.Orm;
namespace Enterprise
{
	/// <summary>
	/// Description of FrmEntity.
	/// </summary>
	public partial class FrmEntity : Form
	{
		public FrmEntity(string code,LinkHistory his,Form p)
		{
			this.MaximizeBox=false;
			this.StartPosition=FormStartPosition.CenterScreen;
			InitializeComponent();
			this.tbCode.Text=code;
			_his=his;
			this.Location=new Point(p.Location.X+300,p.Location.Y);
		}
		private LinkHistory _his;
		
		
		void BntCopyClick(object sender, EventArgs e)
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

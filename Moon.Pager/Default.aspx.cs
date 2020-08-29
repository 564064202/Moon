/*
 * 由SharpDevelop创建。
 * 用户： 秦仕川
 * 日期: 2013-12-7
 * 时间: 16:40
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Moon.Orm;
using sqlite;
using Moon.Orm.Util;

namespace Moon.Pager
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public class Default : Page
	{
		
		protected void PageInit(object sender, EventArgs e)
		{
			
		}
		
		public string Pager{
			get;
			set;
		}
		
		private void Page_Load(object sender, EventArgs e)
		{
						
						
		}
		
		protected override void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}
		//----------------------------------------------------------------------
		private void InitializeComponent()
		{
			this.Load	+= new System.EventHandler(Page_Load);
			this.Init   += new System.EventHandler(PageInit);
			
			
			
		}
		
	}
}
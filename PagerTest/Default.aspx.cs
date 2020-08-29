/*
 * 由SharpDevelop创建。
 * 用户： qsmy_
 * 日期: 2015/10/15
 * 时间: 21:13
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

namespace PagerTest
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public class Default : Page
	{	
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#region Data

		protected	HtmlInputButton		_Button_Ok;
		protected	HtmlInputText 		_Input_Name;

		#endregion
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#region Page Init & Exit (Open/Close DB connections here...)

		protected void PageInit(object sender, EventArgs e)
		{
		}
		//----------------------------------------------------------------------
		protected void PageExit(object sender, EventArgs e)
		{
		}

		#endregion
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#region Page Load
		private void Page_Load(object sender, EventArgs e)
		{
			Response.Write(@"Hello #Develop<br>");
			//------------------------------------------------------------------
			if(IsPostBack)
			{
			}
			//------------------------------------------------------------------
		}
		#endregion
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#region Click_Button_OK

		//----------------------------------------------------------------------
		protected void Click_Button_Ok(object sender, EventArgs e)
		{
			Response.Write( _Button_Ok.Value + " was cklicked!<br>");
		}

		#endregion
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#region Changed_Input_Name

		//----------------------------------------------------------------------
		protected void Changed_Input_Name(object sender, EventArgs e)
		{
			Response.Write( _Input_Name.Value + " has changed!<br>");
		}

		#endregion
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#region More...
		#endregion
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#region Initialize Component

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
			this.Unload += new System.EventHandler(PageExit);
			
			_Button_Ok.ServerClick	 += new EventHandler(Click_Button_Ok);
			_Input_Name.ServerChange += new EventHandler(Changed_Input_Name);
		}
		#endregion
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
	}
}
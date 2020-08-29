/*
 * 由SharpDevelop创建。
 * 用户： 秦仕川
 * 日期: 2013-12-7
 * 时间: 16:47
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
using sqlite;
using Moon.Orm;

namespace Moon.Pager
{
	/// <summary>
	/// Description of SmallPage
	/// </summary>
	public class SmallPage : Page
	{
		
		protected void PageInit(object sender, System.EventArgs e)
		{
		}
		//----------------------------------------------------------------------
		
		protected void PageExit(object sender, System.EventArgs e)
		{
			

		}
		public  DictionaryList List;
		private void Page_Load(object sender, System.EventArgs e)
		{
			using (var db=Db.CreateDefaultDb()) {
				var mqlJoin=ScoreSet.SelectAll()
					.InnerJoin(StudentSet.Select(StudentSet.Name))
					.InnerJoin(ClassSet.Select(ClassSet.ID.AS("ClassID"),ClassSet.ClassName))
					.ON(ScoreSet.Student_ID.Equal(StudentSet.ID)
					    .And(StudentSet.Class_ID.Equal(ClassSet.ID) )
					   );
				if (Request["onlyGetSumDataCount"]=="1") {
					var sumCount=db.GetCount(mqlJoin);
					Response.Write(sumCount);
					Response.End();
					return;
				}else{
					int sumPageCount;
					int sumDataCount;
					var pageIndex=Request["pageIndex"];
					var pageSize=Request["pageSize"];
					this.List=db.GetPagerToDictionaryList(mqlJoin,out sumPageCount,out sumDataCount,int.Parse(pageIndex),
					                                      int.Parse(pageSize),null);
				}
			
			}
		}
		

		protected override void OnInit(EventArgs e)
		{	InitializeComponent();
			base.OnInit(e);
		}
		
		private void InitializeComponent()
		{
			this.Load	+= new System.EventHandler(Page_Load);
			this.Init   += new System.EventHandler(PageInit);
			this.Unload += new System.EventHandler(PageExit);
			
		}
		
	}
}

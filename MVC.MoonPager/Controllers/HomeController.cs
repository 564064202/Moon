/*
 * 由SharpDevelop创建。
 * 用户： 秦仕川
 * 日期: 2013-12-7
 * 时间: 20:55
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Web.Mvc;
 
using Moon.Orm;
using sqlite;

namespace MVC.MoonPager.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			using (var db=GetDb()) {
				var mqlJoin=ScoreSet.SelectAll()
					.InnerJoin(StudentSet.Select(StudentSet.Name))
					.InnerJoin(ClassSet.Select(ClassSet.ID.AS("ClassID"),ClassSet.ClassName))
					.ON(ScoreSet.StudentID.Equal(StudentSet.ID)
					    .And(StudentSet.ClassID.Equal(ClassSet.ID) )
					   );
				var pager=Moon.Orm.Util.PagerUtil.GetWebPager(db,"SmallPage","content",mqlJoin,3,null);
				return View(pager);
			}
			
		}
		Db GetDb(){
			var db=new Sqlite(@"Data Source=C:\Moon\Moon.Pager\bin\Moon_Sqlite.db;");
			return db;
		}
		public ActionResult SmallPage()
		{
			using (var db=GetDb()) {
				var mqlJoin=ScoreSet.SelectAll()
					.InnerJoin(StudentSet.Select(StudentSet.Name))
					.InnerJoin(ClassSet.Select(ClassSet.ID.AS("ClassID"),ClassSet.ClassName))
					.ON(ScoreSet.StudentID.Equal(StudentSet.ID)
					    .And(StudentSet.ClassID.Equal(ClassSet.ID) )
					   );
				var list=Moon.Orm.Util.PagerUtil.GetOneWebPagesData(db,mqlJoin,null);
				return View(list);
			}
			
		}
		
		public ActionResult Contact()
		{
			return View();
		}
	}
}

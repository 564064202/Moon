/*
 * 由SharpDevelop创建。
 * 用户： 秦仕川
 * 日期: 2013-12-7
 * 时间: 20:55
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Moon.Orm.Util;

namespace MVC.MoonPager
{
	public class MvcApplication : HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.Ignore("{resource}.axd/{*pathInfo}");
			
			routes.MapRoute(
				"Default",
				"{controller}/{action}/{id}",
				new {
					controller = "Home",
					action = "Index",
					id = UrlParameter.Optional
				});
		}
		
		protected void Application_Start()
		{
			LogUtil.Warning("Application_Start");
			RegisterRoutes(RouteTable.Routes);
			LogUtil.Debug(RouteTable.Routes.ToString());
		}
	}
}

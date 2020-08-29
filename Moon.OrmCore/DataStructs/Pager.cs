/*
 * 由SharpDevelop创建。
 * 用户： 秦仕川
 * 日期: 2013-12-7
 * 时间: 15:50
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Text;
using System.Web;

namespace Moon.Orm
{
	/// <summary>
	/// 分页类:分页数据及控件
	/// </summary>
	public class Pager
	{
		/// <summary>
		/// 分页的数据
		/// </summary>
		public DictionaryList Data
		{
			get;
			set;
		}
		/// <summary>
		/// Url分页控件:html
		/// </summary>
		public string UrlPagerControl{
			get;
			set;
		}
	}
}

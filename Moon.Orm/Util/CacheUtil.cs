/*
 * 由SharpDevelop创建。
 * 用户： qsmy_
 * 日期: 2015/10/15
 * 时间: 18:48
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Web;
using System.Web.Caching;

namespace Moon.Orm.Util
{
	/// <summary>
	/// 缓存辅助类,采用HttpRuntime.Cache.
	/// </summary>
	public static class CacheUtil
	{
		/// <summary>
		/// HttpRuntime.Cache
		/// </summary>
		public static readonly Cache HttpRuntimeCache=HttpRuntime.Cache;
		/// <summary>
		/// 缓存数据
		/// </summary>
		/// <param name="key">键</param>
		/// <param name="value">值</param>
		/// <param name="s">缓存时间秒</param>
		public static void Insert(string key,object value,int s){
			DateTime expire = DateTime.Now.AddSeconds(s);
			HttpRuntime.Cache.Insert(key, value,null, expire, TimeSpan.Zero);
		}
		/// <summary>
		/// 获取缓存内容(如果没有缓存就为null)
		/// </summary>
		/// <param name="key">健</param>
		/// <returns>缓存的内容</returns>
		public static object Get(string key){
			object result = HttpRuntime.Cache.Get(key);
			return result;
		}
	}
}

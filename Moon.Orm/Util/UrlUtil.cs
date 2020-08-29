/*
 * 由SharpDevelop创建。
 * 用户： qsmy_
 * 日期: 2015/11/6
 * 时间: 21:11
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Reflection;
using System.Text;

namespace Moon.Orm.Util
{
	/// <summary>
	/// Url辅助类
	/// </summary>
	public static class UrlUtil
	{
		/// <summary>
		/// 获取指定对象的属性值
		/// </summary>
		/// <param name="instance"></param>
		/// <param name="propertyname"></param>
		/// <returns></returns>
		public static object GetObjectPropertyValue<T>(T instance, string propertyname)
		{
			Type type = typeof(T);
			PropertyInfo property = type.GetProperty(propertyname);
			if (property == null)
				return string.Empty;
			object o = property.GetValue(instance, null);
			if (o == null) return string.Empty;
			return o.ToString();
		}
		/// <summary>
		/// 获取指定对象的url参数表达式
		/// </summary>
		/// <param name="instance"></param>
		/// <returns></returns>
		public static string GetObjectParameters<T>(T instance){
			StringBuilder sb=new StringBuilder();
			Type t = typeof(T);
			System.Reflection.PropertyInfo[] properties = t.GetProperties();
			foreach (System.Reflection.PropertyInfo p in properties)
			{
				sb.Append(p.Name+"="+GetObjectPropertyValue<T>(instance,p.Name)+"&");
			}
			var ret=sb.ToString();
			if (ret.EndsWith("&")) {
				ret=ret.Substring(0,ret.Length-1);
			}
			return ret;
		}
	}
}

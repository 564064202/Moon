/*
 * 由SharpDevelop创建。
 * 用户： qsmy_
 * 日期: 2015/10/15
 * 时间: 16:52
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Resources;

namespace Moon.Orm.Util
{
	/// <summary>
	///   OrmResourceUtil.
	/// </summary>
	public static class OrmResourceUtil
	{
		/// <summary>
		/// Orm资源文件DIC
		/// </summary>
		public static readonly Dictionary<string,string> OrmResourceDIC=new Dictionary<string, string>();
		static OrmResourceUtil(){
			Stream stream =Assembly.GetExecutingAssembly().GetManifestResourceStream("Moon.Orm.OrmResource.resources");
			ResourceReader rr = new ResourceReader(stream);
			IDictionaryEnumerator enumerator = rr.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DictionaryEntry de = (DictionaryEntry)enumerator.Current;
				OrmResourceDIC.Add(de.Key.ToString(),de.Value.ToString());
			}
			stream.Close();
		}
		/// <summary>
		/// 获取指定的键值
		/// </summary>
		/// <param name="key">key</param>
		/// <returns>value</returns>
		public static string GetValue(string key)
		{
			return OrmResourceDIC[key];
		}
	}
}

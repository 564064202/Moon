/*
 * 由SharpDevelop创建。
 * 用户： 秦仕川
 * 日期: 2013-11-9
 * 时间: 11:38
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Text;

using Moon.Orm;

namespace Moon.Orm.Util
{
	/// <summary>
	/// DictionaryList的辅助类
	/// 包括显示等功能
	/// </summary>
	public class DictionaryListHelper
	{
		/// <summary>
		/// 在控制台中显示dictionaryList数据
		/// </summary>
		/// <param name="dictionaryList">目标数据</param>
		public static void ShowDictionaryListInConsole(List<Dictionary<string,MObject>> dictionaryList){
			Console.WriteLine(ConvertDictionaryListToString(dictionaryList));
		}
		/// <summary>
		/// 将dictionaryList数据变成直观的String格式
		/// </summary>
		/// <param name="dictionaryList">目标数据</param>
		/// <returns>string格式的数据</returns>
		public static string ConvertDictionaryListToString(List<Dictionary<string,MObject>> dictionaryList){
			StringBuilder sb=new StringBuilder();
			foreach (var obj in dictionaryList) {
				foreach (var kvp in obj) {
					sb.Append(kvp.Key+"="+kvp.Value+" ");
				}
				sb.AppendLine();
			}
			return sb.ToString();
		}
	}
}

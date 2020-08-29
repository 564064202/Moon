/*
 * 由SharpDevelop创建。
 * 用户： 秦仕川
 * 日期: 2013-11-16
 * 时间: 8:29
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Text;

using Moon.Orm.Util;
using Newtonsoft.Json.Linq;

namespace Moon.Orm
{
	/// <summary>
	/// <code>Dictionary&lt;string,JObject>&gt;</code>
	/// </summary>
	public class JObjectDictionary:Dictionary<string,JObject>
	{
		/// <summary>
		/// 将JObjectDictionary转换为string类型,该方法基本上用来查看数据用的
		/// </summary>
		/// <returns>sting表现形式</returns>
		public override string ToString(){
			StringBuilder sb=new StringBuilder();
			foreach (var kvp in this) {
				var tablePre=kvp.Key;
				sb.AppendLine(tablePre+":");
				var entity=kvp.Value;
				foreach (var v in entity) {
					sb.AppendLine(v.Key+"="+v.Value);
				}
				sb.AppendLine();
			}
			return sb.ToString();
		}
		/// <summary>
		/// 将数据展现在控制台上
		/// </summary>
		public void ShowInConsole(){
			Console.Write(this.ToString());
		}
	}
}

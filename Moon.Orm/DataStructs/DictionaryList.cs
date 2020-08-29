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

namespace Moon.Orm
{
	/// <summary>
	/// 原型:<code>List&lt;Dictionary&lt;string,MObject&gt;&gt;</code>,
	/// MObject本质就是object的分装
	/// 加了类型转换和空判定
	/// </summary>
	public class DictionaryList:List<Dictionary<string,MObject>>
	{
		/// <summary>
		/// DictionaryList转化为json格式
		/// </summary>
		/// <returns>json</returns>
		public virtual string ToJson(){
			StringBuilder sb=new StringBuilder();
			sb.Append("[");
			int count=0;
			foreach (var dic in this) {
				count++;
				string json=JsonUtil.DicToJson(dic);
				if (count==this.Count) {
					sb.Append(json);
				}else{
					sb.Append(json+",");
				}
			}
			sb.Append("]");
			return sb.ToString();
		}
		/// <summary>
		/// 将DictionaryList转换为string,该方法基本在查看数据时才会使用
		/// </summary>
		/// <returns>转化为string格式</returns>
		public override string ToString()
		{
			StringBuilder sb=new StringBuilder();
			foreach (var obj in this) {
				foreach (var kvp in obj) {
					sb.Append(kvp.Key+"="+kvp.Value+" ");
				}
				sb.AppendLine();
			}
			return sb.ToString();
		}
		/// <summary>
		/// 在控制台中显示数据
		/// </summary>
		public void ShowInConsole(){
			Console.Write(this.ToString());
		}
		
	}

}

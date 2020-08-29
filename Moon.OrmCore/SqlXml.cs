/*
 * 由SharpDevelop创建。
 * 用户： 秦仕川
 * 日期: 2013-10-19
 * 时间: 13:40
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;

namespace Moon.Orm
{
	/// <summary>
	/// sql的xml描述
	/// </summary>
	public class SqlXml
	{
		/// <summary>
		/// sql语句
		/// </summary>
		public string SQL{
			get;
			set;
		}
		/// <summary>
		/// 相关的描述信息
		/// </summary>
		public string Description{
			get;
			set;
		}
		/// <summary>
		/// 该sql的唯一id
		/// </summary>
		public string ID{
			get;
			set;
		}
	}
}

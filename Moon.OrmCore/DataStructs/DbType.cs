/*
 * 由SharpDevelop创建。
 * 用户： 秦仕川
 * 日期: 2013-8-3
 * 时间: 10:25
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;

namespace Moon.Orm
{
	/// <summary>
	/// 数据库类型
	/// </summary>
	public enum DbType 
	{
		/// <summary>
		/// SqlServer
		/// </summary>
		SqlServer,
		/// <summary>
		/// Oracle
		/// </summary>
		Oracle,
		/// <summary>
		/// MySql
		/// </summary>
		MySql,
		/// <summary>
		/// PostGresql
		/// </summary>
		PostGresql,
		/// <summary>
		/// Sqlite
		/// </summary>
		Sqlite,
	}
}
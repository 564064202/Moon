/*
 * 由SharpDevelop创建。
 * 用户： 秦仕川
 * 日期: 2013-9-19
 * 时间: 9:56
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Data;
using System.Data.Common;

namespace Moon.Orm
{
	/// <summary>
	/// DynamicList数据获取所用的代理
	/// </summary>
	public delegate object DynamicListHandler(string sql,Db db);
}

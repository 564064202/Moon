/*
 * 由SharpDevelop创建。
 * 用户： 秦仕川
 * 日期: 2013-9-3
 * 时间: 10:24
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Data.Common;
using Oracle.ManagedDataAccess;

using Moon.Orm.Util;
using Oracle.ManagedDataAccess.Client;

namespace Moon.Orm
{
	/// <summary>
	/// Oracle的Ado.net相关的方法.
	/// </summary>
	internal class AdoOracle:DbAdoMethod
	{
		/// <summary>
		/// 构造
		/// </summary>
		/// <param name="linkString">连接字符串</param>
		public AdoOracle(string linkString)
			:base(linkString)
		{
		}
		//static AdoOracle(){
		//	if (SecurityUtil.IsIrcLegal()==false) {
		//		string tip="提示:moon.orm可免费使用,但需要授权(所以你暂时不能使用Oracle).请联系qsmy_qin@163.com免费授权";
		//		LogUtil.Error(tip);
		//		throw new Exception(tip);
		//	}
		//}
		/// <summary>
		/// 创建一个参数
		/// </summary>
		/// <returns>该数据库类型的DbParameter</returns>
		public override DbParameter CreateParameter()
		{
			return new OracleParameter();
		}
		/// <summary>
		/// 创建一个dbcommand
		/// </summary>
		/// <returns>该数据库类型的DbCommand</returns>
		public override DbCommand CreateDbCommand()
		{
			return new OracleCommand();
		}
		/// <summary>
		/// 创建一个DbCommandBuilder
		/// </summary>
		/// <returns>该数据库类型的DbCommandBuilder</returns>
		public override DbCommandBuilder CreateCommandBuilder()
		{
			return new OracleCommandBuilder();
		}
		/// <summary>
		/// 创建一个连接
		/// </summary>
		/// <returns>该数据库类型的DbConnection</returns>
		public override DbConnection CreateConnection()
		{
			return new OracleConnection(LinkString);
		}
		/// <summary>
		/// 创建一个数据适配器
		/// </summary>
		/// <returns>该数据库类型的DbDataAdapter</returns>
		public override DbDataAdapter CreateDataAdapter()
		{
			return new OracleDataAdapter();
		}
	}
}

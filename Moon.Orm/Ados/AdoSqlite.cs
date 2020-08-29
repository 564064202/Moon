/*
 * 由SharpDevelop创建。
 * 用户： 秦仕川
 * 日期: 2013-11-3
 * 时间: 16:00
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;

using Moon.Orm.Util;

namespace Moon.Orm
{
	/// <summary>
	/// SqlServer.
	/// </summary>
	internal class AdoSqlite:DbAdoMethod
	{
		public AdoSqlite(string linkString)
			:base(linkString)
		{
		}
		//static AdoSqlite(){
		//	if (SecurityUtil.IsIrcLegal()==false) {
		//		string tip="提示:moon.orm可免费使用,但需要授权(所以你暂时不能使用sqlite).请联系qsmy_qin@163.com免费授权";
		//		LogUtil.Error(tip);
		//		throw new Exception(tip);
		//	}
		//}
		public override DbParameter CreateParameter()
		{
			return new SQLiteParameter();
		}
		
		public override DbCommand CreateDbCommand()
		{
			return new SQLiteCommand();
		}
		public override DbCommandBuilder CreateCommandBuilder()
		{
			return new SQLiteCommandBuilder();
		}
		public override DbConnection CreateConnection()
		{
			return new SQLiteConnection(LinkString);
		}
		
		public override DbDataAdapter CreateDataAdapter()
		{
			return new SQLiteDataAdapter();
		}
	}
}

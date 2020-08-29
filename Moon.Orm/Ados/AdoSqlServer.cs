/*
 * 由SharpDevelop创建。
 * 用户： 秦仕川
 * 日期: 2013-8-23
 * 时间: 12:10
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Data;
using System.Data.Common;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Moon.Orm
{
	/// <summary>
	/// SqlServer.
	/// </summary>
	internal class AdoSqlServer:DbAdoMethod
	{
		public AdoSqlServer(string linkString)
			:base(linkString)
		{
		}
		
		public override DbParameter CreateParameter()
		{
			return new SqlParameter();
		}
		
		public override DbCommand CreateDbCommand()
		{
			return new SqlCommand();
		}
		public override DbCommandBuilder CreateCommandBuilder()
		{
			return new SqlCommandBuilder();
		}
		public override DbConnection CreateConnection()
		{
			return new SqlConnection(LinkString);
		}
		
		public override DbDataSourceEnumerator CreateDataSourceEnumerator()
		{
			return SqlDataSourceEnumerator.Instance;
		}
		
		public override DbDataAdapter CreateDataAdapter()
		{
			return new SqlDataAdapter();
		}
	}
}

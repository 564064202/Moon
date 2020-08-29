using System;
using System.Data;
using System.Data.Common;

namespace Moon.Orm
{
	/// <summary>
	/// ado的方法基类
	/// </summary>
	public  class DbAdoMethod
	{
		/// <summary>
		/// 构造
		/// </summary>
		/// <param name="linkString">连接字符串</param>
		public DbAdoMethod(string linkString){
			this.LinkString=linkString;
		}
		/// <summary>
		/// 创建一个DbConnection
		/// </summary>
		/// <returns>DbConnection</returns>
		public virtual DbConnection CreateConnection(){
			return null;
		}
		/// <summary>
		/// 创建一个DbCommand
		/// </summary>
		/// <returns>DbCommand</returns>
		public virtual DbCommand CreateDbCommand(){
			return null;
		}
		/// <summary>
		/// 创建一个DbDataAdapter
		/// </summary>
		/// <returns>DbDataAdapter</returns>
		public virtual DbDataAdapter CreateDataAdapter(){
			return null;
		}
		/// <summary>
		/// 创建一个DbDataSourceEnumerator
		/// </summary>
		/// <returns>DbDataSourceEnumerator</returns>
		public virtual DbDataSourceEnumerator CreateDataSourceEnumerator (){
			return null;
		}
		/// <summary>
		/// 创建一个DbParameter
		/// </summary>
		/// <returns>DbParameter</returns>
		public virtual DbParameter CreateParameter (){
			return null;
		}
		/// <summary>
		/// 创建一个DbCommandBuilder
		/// </summary>
		/// <returns>DbCommandBuilder</returns>
		public virtual DbCommandBuilder CreateCommandBuilder()
		{
			return null;
		}
		/// <summary>
		/// 连接字符串
		/// </summary>
		public string LinkString{
			get;
			set;
		}
	}
}


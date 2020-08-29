/*
 * 由SharpDevelop创建。
 * 用户： 秦仕川
 * 日期: 2013-4-20
 * 时间: 17:49
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace Moon.Orm
{
	/// <summary>
	/// 表的特性标记
	/// </summary>
	public class TableAttribute:Attribute
	{
		/// <summary>
		/// 构造
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="dbType"></param>
		public TableAttribute(string tableName,DbType dbType){
			this.TableName=tableName;
			this.DbType=dbType;
		}
		/// <summary>
		/// 表名
		/// </summary>
		public string TableName
		{
			get;
			set;
		}
		/// <summary>
		/// 数据库类型
		/// </summary>
		public DbType DbType{
			get;
			set;
		}
	}
}

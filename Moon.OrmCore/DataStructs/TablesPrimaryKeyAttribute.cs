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
	/// 表中主键的注释
	/// </summary>
	public class TablesPrimaryKeyAttribute:Attribute
	{
		/// <summary>
		/// 标记一个表的主键信息
		/// </summary>
		/// <param name="primaryKeyType">主键的类型</param>
		/// <param name="primaryKeyDataType">主键的.net数据类型</param>
		/// <param name="fieldName">主键的字段名,不包括修饰符如[] 、``</param>
		public TablesPrimaryKeyAttribute(PrimaryKeyType primaryKeyType,Type primaryKeyDataType,string fieldName)
		{
			this.PrimaryKeyDataType=primaryKeyDataType;
			this.PrimaryKeyType=primaryKeyType;
			this.PrimaryFieldName=fieldName;
		}
		/// <summary>
		/// 主键类型
		/// </summary>
		public PrimaryKeyType PrimaryKeyType{
			get;
			set;
		}
		/// <summary>
		/// 主键字段名,不包括修饰符如[] 、``
		/// </summary>
		public string PrimaryFieldName{
			get;
			set;
		}
		/// <summary>
		/// 主键数据类型
		/// </summary>
		public Type PrimaryKeyDataType{
			get;
			set;
		}
	}
}

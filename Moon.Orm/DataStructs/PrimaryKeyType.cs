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
	/// 主键类型
	/// </summary>
	public enum PrimaryKeyType{
		/// <summary>
		/// 自增类型的主键
		/// </summary>
		AutoIncrease,
		/// <summary>
		/// 数据库自动设置的GUID
		/// </summary>
		AutoGUID,
		/// <summary>
		/// 开发人员自己生成的GUID
		/// </summary>
		CustomerGUID,
		/// <summary>
		/// 复合类型的主键
		/// </summary>
		MultiplePK,
		/// <summary>
		/// 没有设置主键
		/// </summary>
		NoPK,
	}
}

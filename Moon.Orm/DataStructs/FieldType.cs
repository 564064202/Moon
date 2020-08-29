using System;

namespace Moon.Orm
{
	/// <summary>
	/// 字段类型
	/// </summary>
	public enum FieldType
	{
		/// <summary>
		/// 一般类型的字段
		/// </summary>
		Common,
		/// <summary>
		/// 唯一主键
		/// </summary>
		OnlyPrimaryKey,
		/// <summary>
		/// 其中的一个主键
		/// </summary>
		OnePrimaryKey,
		/// <summary>
		/// 唯一外键
		/// </summary>
		OnlyForeignKey,
		/// <summary>
		/// 外键
		/// </summary>
		ForeignKey,
		/// <summary>
		/// 函数型字段,函数表达式创建而来
		/// </summary>
		FunctionField,
		/// <summary>
		/// *
		/// </summary>
		AllStar,
	}
}


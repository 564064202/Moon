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
	/// 字段特性.
	/// </summary>
	public class FieldAttribute:Attribute
	{

		/// <summary>
		/// 构造
		/// </summary>
		/// <param name="fieldType">字段类型</param>
		/// <param name="fieldName">字段名</param>
		public FieldAttribute(FieldType fieldType,string fieldName)
		{
			this.FieldName=fieldName;
			this.FieldType=fieldType;
		}
		
		private FieldType _fieldType;
		/// <summary>
		/// 字段类型
		/// </summary>
		public FieldType FieldType {
			get { return _fieldType; }
			set { _fieldType = value; }
		}
		
		private string _fieldName;
		/// <summary>
		/// 字段名
		/// </summary>
		public string FieldName {
			get { return _fieldName; }
			set { _fieldName = value; }
		}
	}


}

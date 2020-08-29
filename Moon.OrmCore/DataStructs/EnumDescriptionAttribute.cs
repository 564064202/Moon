/*
 * 由SharpDevelop创建。
 * 用户： qscq
 * 日期: 2014/9/19
 * 时间: 19:51
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Moon.Orm
{
	/// <summary>
	/// 枚举描述信息的标记
	/// </summary>
	public class EnumDescriptionAttribute:Attribute
	{
		/// <summary>
		/// 构造
		/// </summary>
		/// <param name="description">描述信息</param>
		public EnumDescriptionAttribute(string description)
		{
			Description=description;
		}
		/// <summary>
		/// 构造
		/// </summary>
		/// <param name="description">描述信息</param>
		/// <param name="value">附加值</param>
		public EnumDescriptionAttribute(string description,object value)
		{
			Description=description;
			this.AttachValue=value;
		}
		/// <summary>
		/// 描述信息
		/// </summary>
		public string Description{
			get;
			set;
		}
		/// <summary>
		/// 改描述对应的附加值
		/// </summary>
		public object AttachValue{
			get;
			set;
		}
		/// <summary>
		/// 获取指定枚举项对应的描述信息
		/// </summary>
		/// <param name="enumSubitem">枚举项</param>
		/// <returns>描述信息</returns>
		public static string GetEnumDescription(Enum enumSubitem)
		{
			string strValue = enumSubitem.ToString();
			FieldInfo fieldinfo = enumSubitem.GetType().GetField(strValue);
			Object[] objs = fieldinfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);
			if (objs == null || objs.Length == 0)
			{
				return strValue;
			}
			else
			{
				EnumDescriptionAttribute da = (EnumDescriptionAttribute)objs[0];
				return da.Description;
			}
		}
		/// <summary>
		/// 获取指定枚举类型所有 值-描述信息的字典
		/// </summary>
		/// <param name="enumType">枚举类型</param>
		/// <returns>值-描述信息的字典</returns>
		public static Dictionary<int,string> GetEnumAllDescriptions(Type enumType)
		{
			Dictionary<int,string> dic=new Dictionary<int,string>();
			var values=Enum.GetValues(enumType);
			foreach (var v in values) {
				var des=GetEnumDescription((Enum)v);
				dic[Convert.ToInt32(v)]=des;
			}
			return dic;
		}
	}
}

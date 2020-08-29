/*
 * 由SharpDevelop创建。
 * 用户： qscq
 * 日期: 2014/8/4
 * 时间: 10:35 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
 
using System;
using System.Reflection;

namespace Moon.Orm.Util
{
	/// <summary>
	/// Enum辅助类
	/// </summary>
	public static class EnumUtil
	{
		/// <summary>
		/// 通过枚举的值获取对应的字符串形式,如果没有对应就为空
		/// </summary>
		/// <param name="value">枚举的值</param>
		/// <returns>对应的字符串</returns>
		public static string GetEnumNameByValue<T>(int value){
			string name=Enum.GetName(typeof(T),value);
			return name;
		}
		/// <summary>
		/// 根据枚举获取对应的int值
		/// </summary>
		/// <param name="enumObj">枚举</param>
		/// <returns>对应的枚举值</returns>
		public static int GetValue(object enumObj){
			return (int)enumObj;
		}
		/// <summary>
		/// 获取指定枚举的描述信息
		/// </summary>
		/// <param name="enumSubitem">枚举值</param>
		/// <returns>枚举描述信息</returns>
		public static EnumDescriptionAttribute GetEnumDescription(Enum enumSubitem)
		{
			string strValue = enumSubitem.ToString();
			FieldInfo fieldinfo = enumSubitem.GetType().GetField(strValue);
			Object[] objs = fieldinfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);
			if (objs == null || objs.Length == 0)
			{
				return null;
			}
			else
			{
				EnumDescriptionAttribute da = (EnumDescriptionAttribute)objs[0];
				return da;
			}
		}
	}
}

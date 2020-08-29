/*
 * 由SharpDevelop创建。
 * 用户： qscq
 * 日期: 2014/8/29
 * 时间: 11:26
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace Moon.Orm
{
	/// <summary>
	/// Description of TypeUtil.
	/// </summary>
	public class TypeUtil
	{
		/// <summary>
		/// 将数据转换为指定的类型
		/// </summary>
		/// <param name="value">纯数据(int,string,datetime....)</param>
		/// <param name="desType">目标类型</param>
		/// <returns></returns>
		public static object ConvertTo(object value,Type desType)
		{
			if (value.GetType()==desType) {
				return value;
			}else{
				if (desType==typeof(Byte)) {
					return Convert.ToByte(value);
				}
				if (desType==typeof(Int16)) {
					return Convert.ToInt16(value);
				}
				else if (desType==typeof(Int32)) {
					return Convert.ToInt32(value);
				}else if (desType==typeof(long)) {
					return Convert.ToInt64(value);
				}else if (desType==typeof(DateTime)) {
					return Convert.ToDateTime(value);
				}else if (desType==typeof(ulong)) {
					return Convert.ToUInt64(value);
				}else if (desType==typeof(uint)) {
					return Convert.ToUInt32(value);
				}else if (desType==typeof(decimal)) {
					return Convert.ToDecimal(value);
				}else if (desType==typeof(double)) {
					return Convert.ToDouble(value);
				}
				else if (desType==typeof(string)) {
					return value.ToString();
				}
				else if (desType==typeof(bool)) {
					var strValue=value.ToString();
					if (strValue=="0") {
						return false;
					}else if (strValue=="1"||strValue=="on") {
						return true;
					} 
					return Convert.ToBoolean(value);
				}
                else if (desType == typeof(decimal?))
                {
                    return Convert.ToDecimal(value);
                }
                else if (desType == typeof(Byte?))
                {
                    return Convert.ToByte(value);
                }
                else if (desType==typeof(Int32?)) {
					return Convert.ToInt32( value);
				}else if (desType==typeof(long?)) {
					return Convert.ToInt64(value);
				}else if (desType==typeof(DateTime?)) {
					return Convert.ToDateTime(value);
				}else if (desType==typeof(ulong?)) {
					return Convert.ToUInt64(value);
				}else if (desType==typeof(uint?)) {
					return Convert.ToUInt32(value);
				}
				else if (desType==typeof(string)) {
					return value.ToString();
				}
				else if (desType==typeof(bool)) {
					return Convert.ToBoolean(value);
				}else if (desType==typeof(Int16?)) {
					return Convert.ToInt16(value);
				}
				else{
					Moon.Orm.Util.LogUtil.Warning("TypeUtil尚未实现的类型转换:"+desType);
					return value;
				}
			}
		}
	}
}



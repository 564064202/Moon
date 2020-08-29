/*
 * 由SharpDevelop创建。
 * 用户： qscq
 * 日期: 2014/5/3
 * 时间: 11:38
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Globalization;
using System.Text;

namespace Moon.Orm.Util
{
	/// <summary>
	/// 字符串辅助类
	/// </summary>
	public class StringUtil
	{
		/// <summary>
		/// 是否是空白字符串
		/// </summary>
		/// <param name="value">字符串</param>
		/// <returns>是否是空白字符串</returns>
		public static bool IsNullOrWhiteSpace(string value)
		{
			if (value == null)
			{
				return true;
			}
			for (int i = 0; i < value.Length; i++)
			{
				if (!char.IsWhiteSpace(value[i]))
				{
					return false;
				}
			}
			return true;
		}
		/// <summary>
		/// 将一个字符串转换为c#字符串变量中的形式.
		/// </summary>
		/// <param name="str">字符串</param>
		/// <returns>c#字符串变量中的形式</returns>
		public static string ConvertStringToCSharpString(string str){
			if (string.IsNullOrEmpty(str)) {
				return str; 
				 
			}else{
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < str.Length; i++)
				{
					char c = str.ToCharArray()[i];
					switch (c)
					{
						case '\"':
							sb.Append("\\\""); break;
						case '\\':
							sb.Append("\\\\"); break;
						case '\b':
							sb.Append("\\b"); break;
						case '\f':
							sb.Append("\\f"); break;
						case '\n':
							sb.Append("\\n"); break;
						case '\r':
							sb.Append("\\r"); break;
						case '\t':
							sb.Append("\\t"); break;
						case '\v':
							sb.Append("\\v"); break;
						case '\0':
							sb.Append("\\0"); break;
						default:
							sb.Append(c); break;
					}
				}
				return sb.ToString();
			}
		}
		/// <summary>
		/// c#字符串变量中的形式转换为普通字符串的形式
		/// </summary>
		/// <param name="str">C#字符串变量中的形式</param>
		/// <returns>字符串</returns>
		public static string ConvertCSharpStringToString(string str){
			if (string.IsNullOrEmpty(str)) {
				return str;
			}else{
				StringBuilder sb=new StringBuilder(str);
				sb=sb.Replace("\\\"","\"");
				sb=sb.Replace("\\\\","\\");
				sb=sb.Replace("\\b","\b");
				sb=sb.Replace("\\f","\f");
				sb=sb.Replace("\\n","\n");
				sb=sb.Replace("\\r","\r");
				sb=sb.Replace("\\t","\r");
				sb=sb.Replace("\\v","\v");
				sb=sb.Replace("\\0","\0");
				return sb.ToString();
			}
		}
		/// <summary>
		/// 是否是空白字符
		/// </summary>
		/// <param name="c">字符</param>
		/// <returns>是否是空白字符</returns>
		public static bool IsWhiteSpace(char c)
		{
			if (IsLatin1(c))
			{
				return IsWhiteSpaceLatin1(c);
			}
			return CharUnicodeInfoIsWhiteSpace(c);
		}
		private static bool IsLatin1(char ch)
		{
			return ch <= 'ÿ';
		}
		internal static bool CharUnicodeInfoIsWhiteSpace(char c)
		{
			switch (CharUnicodeInfo.GetUnicodeCategory(c))
			{
				case UnicodeCategory.SpaceSeparator:
				case UnicodeCategory.LineSeparator:
				case UnicodeCategory.ParagraphSeparator:
					return true;
				default:
					return false;
			}
		}
		private static bool IsWhiteSpaceLatin1(char c)
		{
			return c == ' ' || (c >= '\t' && c <= '\r') || c == '\u00a0' || c == '\u0085';
		}
	}
}


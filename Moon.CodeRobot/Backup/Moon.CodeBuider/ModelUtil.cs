/*
 * 由SharpDevelop创建。
 * 用户： qscq
 * 日期: 2015/5/9
 * 时间: 20:26
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using Moon.Orm;
using System.Text;
using System.Text.RegularExpressions;

namespace Moon.CodeBuider
{
	/// <summary>
	/// Description of ModelUtil.
	/// </summary>
	public static class ModelUtil
	{
		public static string  ConvertModelString
			(string modelContent,
			 DbType fromType,
			 DbType toType)
		{
			var fromse=GenUtil.GetSE(fromType);
			var tose=GenUtil.GetSE(toType);
			
			string regFrom="^\""+fromse.Start+@"\w+"+fromse.End+"\"$";
			string regTo="^\""+tose.Start+@"\w+"+tose.End+"\"$";

			return null;
		}
		
	}
}

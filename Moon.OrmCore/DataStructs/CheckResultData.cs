/*
 * 由SharpDevelop创建。
 * 用户： qsmy_
 * 日期: 2015/11/8
 * 时间: 13:21
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace Moon.Orm.DataStructs
{
	/// <summary>
	/// 验证结果
	/// </summary>
	public class CheckResult
	{
		/// <summary>
		/// 验证是否成功
		/// </summary>
		public bool Success
		{
			get;
			set;
		}
		/// <summary>
		/// 反馈信息
		/// </summary>
		public string Info
		{
			get;
			set;
		}
		/// <summary>
		/// 反馈的对象
		/// </summary>
		public string Target
		{
			get;
			set;
		}
        /// <summary>
        /// 数据
        /// </summary>
		public object Value{
			get;
			set;
		}
	}
}

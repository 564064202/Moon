/*
 * 由SharpDevelop创建。
 * 用户： qscq
 * 日期: 2014/8/3
 * 时间: 14:20
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.IO;

namespace Moon.Orm.Util
{
	/// <summary>
	/// 处理一些日常IO操作
	/// </summary>
	public static class IOUtil
	{
		/// <summary>
		/// 如果文件夹不存在的话,创建文件夹
		/// </summary>
		/// <param name="path"></param>
		public static void CreateDirectoryWhenNotExist(string path)
		{
			if (Directory.Exists(path)==false) {
				Directory.CreateDirectory(path);
			}
		}
	}
}

/*
 * 由SharpDevelop创建。
 * 用户： qinshichuan
 * 日期: 2012-7-7
 * 时间: 12:24
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using MoonDB;
using Moon.Orm;
namespace Enterprise
{
	/// <summary>
	/// Description of Lib.
	/// </summary>
	public class Lib
	{
		public static UsersSystemInfo GetUsersSystemInfo(){
			bool exist=DBFactory.Exists(UsersSystemInfoTable.ID.BiggerThan(0));
			if (exist) {
				return DBFactory.GetEntity<UsersSystemInfo>(UsersSystemInfoTable.ID.Equal(1));
			}else{
				UsersSystemInfo info=new UsersSystemInfo();
				info.Email="";
				info.SystemKey="";
				DBFactory.Add(info);
				return info;
			}
		}
	}
}

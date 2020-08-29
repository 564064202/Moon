/*
 * 由SharpDevelop创建。
 * 用户： qinshichuan
 * 日期: 2012-6-21
 * 时间: 21:18
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using Moon.Orm;

namespace Enterprise.DbHelper
{
	/// <summary>
	/// Description of DataBase.
	/// </summary>
	public class DataBase
	{
		public static List<string> GetDatabaseListByListString(){
			List<string> list=new List<string>();
			try{
			
			string sql="Select Name FROM Master..SysDatabases order by Name ";
			string link="Data Source=localhost\\sqlexpress;Integrated Security=SSPI;Initial Catalog=master;";
			var conn=new System.Data.SqlClient.SqlConnection(link);
			conn.Open();
			var reader=new MSSQL(link).GetDbDataReader(sql,conn);
			while (reader.Read()) {
				list.Add(reader.GetString(0));
			}
			reader.Close();
			conn.Close();
			return list;
			}catch{
				return list;
			}
		}
		public static List<string> GetAllMsSQLServer(){
			string path=@"C:\Program Files\Microsoft SQL Server";
			List<string> list=new List<string>();
			var exist=Directory.Exists(path);
			if (exist) {
				var all=Directory.GetDirectories(path);
				foreach (var name in all) {
					list.Add(name);
				}
			}return list;
			
		}
		public static bool IsOnlyLocalExpressServer(){
			var list=GetAllMsSQLServer();
			var count=0;
			bool hasExpress=false;
			foreach (var a in list) {
				if (a.Contains("MSSQL")) {
					count++;
				}
				if (a.Contains("SQLEXPRESS")) {
					hasExpress=true;
				}
			}
			return count==1&&hasExpress;
		}
		public static string IsLinkStringOK(string linkString,string dbType){
			
			DbConnection conn;
			string path=Application.StartupPath;
			var  _assembly= Assembly.LoadFile(path+"\\Moon.Orm.dll");
			string type = "Moon.Orm." + dbType;
			 Type tp = _assembly.GetType(type);
			object[] constructParms = new object[]
			{
				linkString
			};
			var db= Activator.CreateInstance(tp, constructParms) as DB;
			object currentDatabaseType = Enum.Parse(typeof(DatabasesType), dbType);
			conn=db.GetDbConnection();
			try {
				conn.Open();
				return "true";
				
			} catch (Exception ex) {
				
				 return ex.Message;
				
			}
			finally{
			conn.Close();
			}
		}
		public static string GetDatabaseNameByLinkString(string linkString){
			return null;
		}
	}
}

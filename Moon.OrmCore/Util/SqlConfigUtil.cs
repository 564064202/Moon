/*
 * 由SharpDevelop创建。
 * 用户： qscq
 * 日期: 2015/4/26
 * 时间: 19:37
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Xml;
using Moon.Orm.Util;

namespace Moon.Orm
{
	/// <summary>
	/// SqlConfig的辅助类
	/// </summary>
	public static class SqlConfigUtil
	{
		static SqlConfigUtil(){
			SQL_CONFIG_MAP=new Dictionary<string,SqlConfig>();
			var files=GetAllSqlConfigFiles();
			 
			foreach (var filePath in files) {
				Load(filePath);
			}
			
		}
		/// <summary>
		/// 系统sql的config配置字典
		/// </summary>
		static readonly Dictionary<string,SqlConfig> SQL_CONFIG_MAP;
		/// <summary>
		/// 加载所有的sql*.config文件
		/// </summary>
		/// <returns></returns>
		static string[] GetAllSqlConfigFiles()
		{
			string sqlsDir=GlobalData.MOON_WORK_DIRECTORY_PATH+"sqls"+GlobalData.OS_SPLIT_STRING;
			IOUtil.CreateDirectoryWhenNotExist(sqlsDir);
			var files=System.IO.Directory.GetFiles(sqlsDir,"sql*.config");
			return files;
		}
		/// <summary>
		/// 加载指定了路径
		/// </summary>
		/// <param name="fileFullPath"></param>
		static void Load(string fileFullPath){
			XmlDocument doc=new XmlDocument();
			doc.Load(fileFullPath);
			var list=doc.DocumentElement.ChildNodes;
			foreach (XmlNode element in list) {
				SqlConfig sqlConfig=new SqlConfig();
				string id=element.Attributes["id"].Value;
				sqlConfig.ID=id;
				var allChildren=element.ChildNodes;
				foreach (XmlNode ch in allChildren) {
					if (ch.Name=="defaultsql") {
						sqlConfig.DefaultSql=ch.InnerText;
					}else if(ch.Name=="description"){
						sqlConfig.Description=ch.InnerText;
					}else{
						sqlConfig[ch.Name]=ch.InnerText;
					}
				}
				SQL_CONFIG_MAP.Add(sqlConfig.ID,sqlConfig);
				
			}
		}
		/// <summary>
		/// 根据ID查询对应的sql语句
		/// </summary>
		/// <param name="db">所用的db引擎</param>
		/// <param name="id">对应sql_*.config文件中的id</param>
		/// <returns>对应的sql语句</returns>
		public static string GetSqlByID(Db db,string id)
		{
			if (SQL_CONFIG_MAP!=null&&SQL_CONFIG_MAP.ContainsKey(id)) {
				var name=db.GetType().Name.ToLower();
				var config=SQL_CONFIG_MAP[id];
				var value= config[name].Trim();
				if(string.IsNullOrEmpty(value)){
					return config.DefaultSql;
				}else{
					return value;
				}
			}else{
				string ex=(GlobalData.MOON_WORK_DIRECTORY_PATH+"sqls文件夹中,没有任何文件中存有名为 "+id+" 的节点");
				Moon.Orm.Util.LogUtil.Error(ex);
				throw new Exception(ex);
			}
		}
	}
}

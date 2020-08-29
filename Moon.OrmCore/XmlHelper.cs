/*
 * 由SharpDevelop创建。
 * 用户： 秦仕川
 * 日期: 2013-10-19
 * 时间: 13:40
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Xml;

namespace Moon.Orm
{
	/// <summary>
	/// 用于操作在工作目录下的
	/// sql*.xml文件的辅助类
	/// </summary>
	public static class XmlHelper
	{
		/// <summary>
		/// 获取工作目录下的所有sql_*.xml文件(如:sql_abc.xml,sql_test.xml),注意:sql.xml排除在外
		/// </summary>
		/// <returns>工作目录下的所有sql_*.xml文件</returns>
		static string[] GetAllXmlFiles()
		{
			string dir=GlobalData.MOON_WORK_DIRECTORY_PATH;
			var files=System.IO.Directory.GetFiles(dir,"sql*.xml");
			return files;
		}
		/// <summary>
		/// 系统sql的xml配置字典
		/// </summary>
		static readonly Dictionary<string,SqlXml> SQL_XML_MAP;
		/// <summary>
		/// 静态构造,将所有工作目录的根目录下中的所有sql*.xml加载
		/// 到内存中
		/// </summary>
		static XmlHelper(){
				SQL_XML_MAP=new Dictionary<string, SqlXml>();
				var files=GetAllXmlFiles();
				foreach (var filePath in files) {
					Load(filePath);
				}
			 
		}
		
		/// <summary>
		/// 加载指定文件的路径的xml到SQL_XML_MAP中
		/// </summary>
		/// <param name="fileFullPath"></param>
		static void Load(string fileFullPath){
			XmlDocument doc=new XmlDocument();
			doc.Load(fileFullPath);
			var list=doc.DocumentElement.ChildNodes;
			foreach (XmlNode element in list) {
				SqlXml data=new SqlXml();
				string id=element.Attributes["id"].Value;
				string sql=null;
				string description=null;
				var allChildren=element.ChildNodes;
				foreach (XmlNode ch in allChildren) {
					if (ch.Name=="sql") {
						sql=ch.InnerText;
					}else if(ch.Name=="description"){
						description=ch.InnerText;
					}
				}
				data.ID=id;
				data.Description=description;
				data.SQL=sql;
				SQL_XML_MAP.Add(id,data);
			}
		}
		
		/// <summary>
		/// 根据自己指定的ID,获取对应的SqlXml对象
		/// </summary>
		/// <param name="id">sql对应的id</param>
		/// <returns>对应的SqlXml,如果为null,表示不存在该id</returns>
		public static SqlXml GetSqlXmlByID(string id){
			if (SQL_XML_MAP!=null&&SQL_XML_MAP.ContainsKey(id)) {
				return SQL_XML_MAP[id];
			}
			return null;
		}
		/// <summary>
		/// 根据自己指定的ID,获取对应的SqlXml对象中的sql
		/// </summary>
		/// <param name="id">sql对应的id</param>
		/// <returns>对应的SqlXml的sql,如果为null,表示不存在该id</returns>
		public static string GetSqlByID(string id){
			if (SQL_XML_MAP!=null&&SQL_XML_MAP.ContainsKey(id)) {
				return SQL_XML_MAP[id].SQL;
			}else{
				string ex=(GlobalData.MOON_WORK_DIRECTORY_PATH+"sql.xml中没有名为 "+id+" 的节点");
				Moon.Orm.Util.LogUtil.Error(ex);
				throw new Exception(ex);
			}
			 
		}
	}

}

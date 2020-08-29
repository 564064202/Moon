/*
 * 由SharpDevelop创建。
 * 用户： qinshichuan
 * 日期: 2011-12-22
 * 时间: 16:06
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;

using Moon.Orm.Util;
using System.Windows.Forms;

namespace Moon.Orm
{
	/// <summary>
	/// 全局数据
	/// </summary>
	public  static class GlobalData
	{
		/// <summary>
		/// 这是一空方法,用户调用时会初始化GlobalData
		/// </summary>
		public static void Initial(){
			
		}
		/// <summary>
		/// 是否被用于web项目
		/// </summary>
		/// <returns></returns>
		public static bool IsWeb(){
			var a=AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
			if (string.IsNullOrEmpty(a)) {
				return false;
			}else{
				if (a.ToLower().EndsWith("web.config")) {
					return true;
				}else{
					return false;
				}
			}
		}
		/// <summary>
		/// 获取系统的路径分隔符
		/// </summary>
		/// <returns>OS_SPLIT_STRING</returns>
		public static string GetOSPathSplit()
		{
			var platform=Environment.OSVersion.Platform.ToString().ToLower();
			if(platform.Contains("win")){
				return @"\";
			}else{
				return "/";
			}
		}
		
		static  GlobalData()
		{
			
			OS_SPLIT_STRING=GetOSPathSplit();
			MOON_WORK_DIRECTORY_PATH=ConfigurationManager.AppSettings["MOON_WORK_DIRECTORY_PATH"];
			
			string useTempDll=ConfigurationManager.AppSettings["USE_TEMP_DLL"];
			if (string.IsNullOrEmpty(useTempDll)==false) {
				USE_TEMP_DLL=bool.Parse(useTempDll);
			}else{
				USE_TEMP_DLL=false;
			}
			
			if (string.IsNullOrEmpty(MOON_WORK_DIRECTORY_PATH)) {
				//对于System.AppDomain.CurrentDomain.BaseDirectory,
				//如果是exe,表示exe所在的目录; 如果asp.net,表示网站的根目录路径
				//-----------------
				//相等表示exe形式的程序
				if (IsWeb()==false)//Windows应用程序则相等
				{
					DLL_EXE_DIRECTORY_PATH=Application.StartupPath+OS_SPLIT_STRING;
					MOON_WORK_DIRECTORY_PATH = DLL_EXE_DIRECTORY_PATH+"MOON_WORK_DIRECTORY_PATH"+OS_SPLIT_STRING;
					
					
				}
				else//web程序
				{
					DLL_EXE_DIRECTORY_PATH=AppDomain.CurrentDomain.BaseDirectory+"Bin"+OS_SPLIT_STRING;
					MOON_WORK_DIRECTORY_PATH = AppDomain.CurrentDomain.BaseDirectory + "MOON_WORK_DIRECTORY_PATH"+OS_SPLIT_STRING;
					IS_WEB=true;
				}
				//Console.WriteLine("MOON_WORK_DIRECTORY_PATH:"+MOON_WORK_DIRECTORY_PATH);
				IOUtil.CreateDirectoryWhenNotExist(MOON_WORK_DIRECTORY_PATH);
			}else{
				//不为空则使用此目录,但系统原来没有的话,我们需要为系统创建这个目录
				IOUtil.CreateDirectoryWhenNotExist(MOON_WORK_DIRECTORY_PATH);
			}
			string defaultsqlXmlFile=MOON_WORK_DIRECTORY_PATH+"sql.xml";
			if (File.Exists(defaultsqlXmlFile)==false) {
				StringBuilder sb=new StringBuilder();
				sb.AppendLine("<?xml version=\"1.0\"?>");
				sb.AppendLine("<sqls>");
				sb.AppendLine("	<sqlxml id=\"getdemo\">");
				sb.AppendLine("		<sql><![CDATA[select* from products where ProductId<@]]>></sql>");
				sb.AppendLine("		<description>查询用户名(描述信息)</description>");
				sb.AppendLine("	</sqlxml>");
				sb.AppendLine("</sqls>");
				StreamWriter sw=new StreamWriter(defaultsqlXmlFile,false,System.Text.Encoding.UTF8);
				sw.Write(sb.ToString());
				sw.Close();
			}
			//-----------------------------------------
			string sqlsDir=GlobalData.MOON_WORK_DIRECTORY_PATH+"sqls"+OS_SPLIT_STRING;
			IOUtil.CreateDirectoryWhenNotExist(sqlsDir);
			var defaultsqlConfigFile=sqlsDir+"sql.config";
			if (File.Exists(defaultsqlConfigFile)==false) {
				StringBuilder sb=new StringBuilder();
				sb.AppendLine("<?xml version=\"1.0\"?>");
				sb.AppendLine("<sqls>");
				sb.AppendLine("	<sqlxml id=\"getdemo\">");
				sb.AppendLine("		<defaultsql><![CDATA[所有数据库通用的查询语句,没有特别指定就使用语句]]></defaultsql>");
				sb.AppendLine("		<sqlserver><![CDATA[]]></sqlserver>");
				sb.AppendLine("		<mysql><![CDATA[]]></mysql>");
				sb.AppendLine("		<sqlite><<![CDATA[]]></sqlite>");
				sb.AppendLine("		<oracle><![CDATA[]]></oracle>");
				sb.AppendLine("		<description><![CDATA[]]></description>");
				sb.AppendLine("	</sqlxml>");
				sb.AppendLine("</sqls>");
				StreamWriter sw=new StreamWriter(defaultsqlConfigFile,false,System.Text.Encoding.UTF8);
				sw.Write(sb.ToString());
				sw.Close();
			}
			//---------------------------------
			MOON_TEMP_DLL_DIRECTORY_PATH=MOON_WORK_DIRECTORY_PATH+"moontemp"+OS_SPLIT_STRING;
			string dicrectoryName=MOON_TEMP_DLL_DIRECTORY_PATH;
			IOUtil.CreateDirectoryWhenNotExist(dicrectoryName);
			DynamicList_HandlerMap=new Dictionary<string, DynamicListHandler>();
			var close=System.Configuration.ConfigurationManager.AppSettings["CLOSE_LOG"];
			if(string.IsNullOrEmpty(close)==false){
				CLOSE_LOG=bool.Parse(close);
			}

			
		}
		/// <summary>
		/// 操作系统分隔符
		/// </summary>
		public static readonly string OS_SPLIT_STRING;
		
		
		/// <summary>
		/// 在使用GetDynamicList方法时,直接使用moontemp文件夹中程序上次运行时就已经生成好了的dll
		/// 谨记,如果使用了此节点请在数据结构发生变化是清空moontemp文件夹
		/// </summary>
		public static readonly bool USE_TEMP_DLL;
		/// <summary>
		/// 关闭日志
		/// </summary>
		public static readonly bool CLOSE_LOG=false;
		/// <summary>
		///  GetDynamicList自动编译时dll所在目录,默认就在工作目录的moontemp目录下
		/// </summary>
		public static readonly string MOON_TEMP_DLL_DIRECTORY_PATH;
		
		/// <summary>
		/// moon.orm的工作目录,如果没有另行设置,就是程序exe或dll所在的目录下的MOON_WORK_DIRECTORY_PATH目录
		/// </summary>
		public static readonly  string MOON_WORK_DIRECTORY_PATH;
		/// <summary>
		/// dll和exe所在目录,最后含有 路径分隔符
		/// </summary>
		public static readonly  string DLL_EXE_DIRECTORY_PATH;
		/// <summary>
		/// 是否是web项目
		/// </summary>
		public static readonly bool IS_WEB;

		
		
		static readonly Dictionary<string,DynamicListHandler> DynamicList_HandlerMap;
		static readonly object DynamicList_HandlerMap_LOCK=new object();
		
		/// <summary>
		/// 对应的代理在字典中存在否
		/// </summary>
		/// <param name="modelName">modelName</param>
		/// <returns></returns>
		public static bool ExistDynamicListHandlerInMap(string modelName){
			lock(DynamicList_HandlerMap_LOCK){
				return DynamicList_HandlerMap.ContainsKey(modelName);
			}
		}
		static readonly Object LOAD_DLL_LOCK=new object();
		/// <summary>
		/// 根据modelName获取DynamicListHandler
		/// </summary>
		/// <param name="modelName">modelName</param>
		/// <returns>对应的DynamicListHandler</returns>
		public static DynamicListHandler GetHandlerMapByModelName(string modelName){
			//---------------------
			lock(DynamicList_HandlerMap_LOCK){
				if( DynamicList_HandlerMap.ContainsKey(modelName)){
					return DynamicList_HandlerMap[modelName];
				}
			}
			if (GlobalData.USE_TEMP_DLL) {
				string fileName=MOON_TEMP_DLL_DIRECTORY_PATH+"moontemp_"+modelName+".dll";
				if (File.Exists(fileName)) {
					var assembly=Assembly.LoadFrom(fileName);
					string typeName="moontemp.EntityGet"+modelName;
					Type type=assembly.GetType(typeName);
					var handler = (DynamicListHandler)Delegate.CreateDelegate
						(typeof(DynamicListHandler), type, "GetList");    //静态类方法
					lock(DynamicList_HandlerMap_LOCK){
						DynamicList_HandlerMap[modelName]=handler;
					}
					return handler;
				}else{
					return null;
				}
			}else{
				return null;
			}
			//--------------------
		}
		/// <summary>
		/// 添加handler到字典中
		/// </summary>
		/// <param name="modelName">modelName</param>
		/// <param name="handler">对应handler</param>
		public static void AddDynamicListHandlerToMap(string modelName,DynamicListHandler handler){
			lock(DynamicList_HandlerMap_LOCK){
				DynamicList_HandlerMap[modelName]=handler;
			}
		}
	}
}

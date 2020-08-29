
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace Moon.Orm.Util
{
	/// <summary>
	/// 简单的日志辅助类
	/// </summary>
	public class LogUtil
	{
		static LogUtil(){
			Intial();
			
		}
		static void Intial(){
			LOG_DIRECTORY_PATH=GlobalData.MOON_WORK_DIRECTORY_PATH+"MoonLogs"+GlobalData.OS_SPLIT_STRING;
			IOUtil.CreateDirectoryWhenNotExist(LOG_DIRECTORY_PATH);
			Intialed=true;
		}
		
		static object LOG_LOCK=new object();
		static string LOG_DIRECTORY_PATH;
		static bool Intialed=false;
		
		/// <summary>
		/// 写入异常
		/// </summary>
		/// <param name="ex">要写入的异常</param>
		public static void Exception(Exception ex)
		{
			string msg=ex.Message;
			string stackTrace=ex.StackTrace;
			lock(LOG_LOCK){
				Write("Exception",msg+"\r\n"+stackTrace);
			}
		}
		/// <summary>
		/// 写入异常
		/// </summary>
		/// <param name="name">给该异常日志起一个名字便于识别</param>
		/// <param name="ex">异常</param>
		public static void Exception(string name,Exception ex)
		{
			string msg=ex.Message;
			string stackTrace=ex.StackTrace;
			lock(LOG_LOCK){
				Write(name,msg+"\r\n"+stackTrace);
			}
		}
		/// <summary>
		/// 警告
		/// </summary>
		/// <param name="content">警告内容</param>
		public static void Warning(string content){
			Write("Warning",content);
		}
		/// <summary>
		/// 错误
		/// </summary>
		/// <param name="content">错误信息</param>
		public static void Error(string content){
			Write("Error",content);
		}
		/// <summary>
		/// 调试
		/// </summary>
		/// <param name="content">调试内容</param>
		public static void Debug(string content){
			Write("Debug",content);
		}
		/// <summary>
		/// 调试
		/// </summary>
		/// <param name="key">键</param>
		/// <param name="value">值</param>
		public static void Debug(string key,string value){
			var content=key+"→"+value;
			Write("Debug",content);
		}
		/// <summary>
		/// 获取当前线程的ID信息
		/// </summary>
		/// <returns></returns>
		public static string GetCurrentThreadId(){
			return " ThreadId="+Thread.CurrentThread.ManagedThreadId;
		}
		/// <summary>
		/// 写入日志
		/// </summary>
		/// <param name="type">日志类型</param>
		/// <param name="content">日志内容</param>
		public static void Write(string type,string content)
		{
			if(GlobalData.CLOSE_LOG){
				return;
			}
			StringBuilder sb=new StringBuilder();
			sb.AppendLine();
			sb.Append("[");
			sb.Append(type);
			sb.Append("] ");
			sb.AppendLine(GetLogTime()+GetCurrentThreadId());
			sb.AppendLine(content);
			sb.AppendLine("-------------------------------------------");
			
			lock(LOG_LOCK){
				StreamWriter sw=new StreamWriter(GetLogFileFullPath(),true);
				sw.Write(sb.ToString());
				sw.Close();
			}
		}
		/// <summary>
		/// 获取日志当前时间yyyy-MM-dd HH:mm:ss.ffff
		/// </summary>
		/// <returns></returns>
		static string GetLogTime(){
			return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff");
		}
		/// <summary>
		/// 获取当前日志路径
		/// </summary>
		/// <returns></returns>
		static string GetLogFileFullPath(){
			if (Intialed==false) {
				Intial();
			}
			string name=DateTime.Now.Year+"-"+DateTime.Now.Month+"-"+DateTime.Now.Day+".log";
			return LOG_DIRECTORY_PATH+name;
		}
	}
}

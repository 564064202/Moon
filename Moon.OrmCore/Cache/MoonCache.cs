/*
 * 由SharpDevelop创建。
 * 用户： 秦仕川
 * 日期: 2013-9-4
 * 时间: 9:12
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;

namespace Moon.Orm
{
	/// <summary>
	/// MoonCache.是一个工具类，用于缓存指定表的sql数据，全由手动完成缓存操作。
	/// </summary>
	/// <typeparam name="T">于该sql相关的标记类，推荐使用 TableSet类型，当然也可以自定义</typeparam>
	public class MoonCache<T>
	{
		readonly static object _lock=new object();
		readonly static Dictionary<string,Dictionary<string,object>> Cache=new Dictionary<string,Dictionary<string,object>>();
		/// <summary>
		/// 此类所缓存的所有数据都清空
		/// </summary>
		public static void ClearSystemAllCache(){
			lock(_lock){
				Cache.Clear();
			}
		}
		/// <summary>
		/// 保存缓存数据
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="value"></param>
		public static void SaveCache(string sql,object value){
			string tableName=typeof(T).ToString();
			
			lock(_lock){
				bool exist=Cache.ContainsKey(tableName);
				if (exist==false) {
					Cache[tableName]=new Dictionary<string, object>();
				}
				Cache[tableName][sql]=value;
			}
		}
		/// <summary>
		/// 移除指定表的缓存
		/// </summary>
		public static void RemoveTableCache(){
			string name=typeof(T).ToString();
			lock(_lock){
				bool exist=Cache.ContainsKey(name);
				if (exist) {
					Cache.Remove(name);
				}
			}
		}
		/// <summary>
		/// 移除指定sql的缓存
		/// </summary>
		/// <param name="sql"></param>
		public static void RemoveSqlCache(string sql){
			string tableName=typeof(T).ToString();
			lock(_lock){
				bool exist=Cache.ContainsKey(tableName);
				if (exist) {
					Cache[tableName].Remove(sql);
				}
			}
		}
		/// <summary>
		/// 获取指定sql的缓存
		/// </summary>
		/// <param name="sql">sql语句</param>
		/// <typeparam name="TResult">对应的数据类型</typeparam>
		/// <returns>对应的实体或集合</returns>
		public static TResult GetCacheBySql<TResult>(string sql) where TResult : class{
			string tableName=typeof(T).ToString();
			lock(_lock){
				bool exist=Cache.ContainsKey(tableName);
				if (exist) {
					bool exsit2=Cache[tableName].ContainsKey(sql);
					if (exsit2) {
						return Cache[tableName][sql] as TResult;
					}
				}
				return null;
			}
		}
		
	}
}

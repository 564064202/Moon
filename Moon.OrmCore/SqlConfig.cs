/*
 * 由SharpDevelop创建。
 * 用户： qscq
 * 日期: 2015/4/26
 * 时间: 19:33
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections;
using System.Collections.Generic;

namespace Moon.Orm
{
	/// <summary>
	/// sql.config数据存储
	/// </summary>
	public class SqlConfig
	{
		/// <summary>
		/// 节点下的所有节点名-值 字典
		/// </summary>
		protected Dictionary<string,string> _map=new  Dictionary<string,string>();
		/// <summary>
		/// 如果节点中没有对应的数据库,就会使用此条默认的语句
		/// </summary>
		public string DefaultSql
		{
			get;
			set;
		}
		/// <summary>
		/// 对应的ID
		/// </summary>
		public string ID{
			get;
			set;
		}
		/// <summary>
		/// 获取或设置对应节点信息
		/// </summary>
		public string Description
		{
			get;
			set;
		}
		/// <summary>
		/// 根据节点名获取对应的节点内容,没有此节点就返回DefaultSql
		/// </summary>
		public string this[string nodeName]{
			get{
				if(_map.ContainsKey(nodeName)){
					return _map[nodeName];
				}else{
					return DefaultSql;
				}
			}set{
				_map[nodeName]=value;
			}
		}
	}
}

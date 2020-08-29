/*
 * 由SharpDevelop创建。
 * 用户： qscq
 * 日期: 2014/8/5
 * 时间: 16:26
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Moon.Orm.Util
{
	/// <summary>
	/// ModelUtil主要对model进行处理
	/// </summary>
	public class ModelUtil
	{
		/// <summary>
		/// 将JObject转换为EntityBase对象.
		/// 之所以不用JObject.ToObject是因为,
		/// EntityBase中有数据库自动设置主键这样的情况,如果不加修正直接使用就有可能出问题.
		/// </summary>
		/// <param name="jobject">jobject</param>
		/// <returns>EntityBase对象</returns>
		public static T ConvertJObjectToEntityBaseObject<T>(JObject jobject) where 	T:EntityBase
		{
			EntityBase pEntityBase=jobject.ToObject<T>();
			var pInfo=pEntityBase.GetPrimaryKeyInfo();
			if (pInfo.PrimaryKeyType== PrimaryKeyType.AutoIncrease||pInfo.PrimaryKeyType== PrimaryKeyType.AutoGUID) {
				string pkName=pInfo.PrimaryFieldName;
				if (string.IsNullOrEmpty(pkName)==false) {
					pEntityBase.ChangedMap.Remove(pkName.ToLower());
				}else{
					LogUtil.Warning(jobject.ToString()+",没有主键字段名");
				}
			}
			return pEntityBase as T;
		}
	}
}

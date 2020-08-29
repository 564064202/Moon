using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Moon.Orm.Util
{
	/// <summary>
	/// 对象克隆辅助类
	/// </summary>
	 
	public static class CloneUtil
	{
		/// <summary>
		///克隆的类型必须标记为可序列化[Serializable]
		/// </summary>
		/// <param name="obj">原来的对象</param>
		/// <returns>克隆品</returns>
		public static T CloneSerializableObject<T>(T obj) where T:class{
			if (obj == null)
				return null;
			System.IO.MemoryStream mstream = new System.IO.MemoryStream();
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize(mstream, obj);
			mstream.Position = 0;
			byte[] pBytes = new byte[mstream.Length];
			mstream.Read(pBytes, 0, pBytes.Length);
			mstream.Close();
			object newOjb = null;
			System.IO.MemoryStream mstream2 = new System.IO.MemoryStream(pBytes);
			mstream2.Position = 0;
			BinaryFormatter formatter2 = new BinaryFormatter();
			newOjb = formatter2.Deserialize(mstream2);
			mstream.Close();
			return newOjb as T;
		}
		/// <summary>
		/// 可以克隆绝大多数类型对象(利用json,如果json可以序列化这个对象且能反序列化回来的话,那么一切OK)
		/// </summary>
		/// <param name="obj">对象</param>
		/// <typeparam name="T">对象类型</typeparam>
		/// <returns>克隆品</returns>
		public static T Clone<T>(T obj) where T:class{
			
			var json=Newtonsoft.Json.JsonConvert.SerializeObject(obj);
			var newObj=Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
			var pEntityBase=newObj as EntityBase;
			if (pEntityBase!=null) {
				var pInfo=pEntityBase.GetPrimaryKeyInfo();
				if (pInfo.PrimaryKeyType== PrimaryKeyType.AutoIncrease||pInfo.PrimaryKeyType== PrimaryKeyType.AutoGUID) {
					string pkName=pInfo.PrimaryFieldName;
					if (string.IsNullOrEmpty(pkName)==false) {
						pEntityBase.ChangedMap.Remove(pkName.ToLower());
					}else{
						LogUtil.Warning(obj.ToString()+",没有主键字段名");
					}
				}
				return pEntityBase as T;
			}
			return newObj;
		}
		/// <summary>
		/// 克隆EntityBase对象
		/// </summary>
		/// <param name="obj">原来的对象</param>
		/// <returns>克隆品</returns>
		public static T CloneEntityBaseObject<T>(T obj) where T:EntityBase,new(){
			T ret=new T();
			foreach (var kvp in obj.GetValueMap()) {
				ret.GetValueMap().Add(kvp.Key,kvp.Value);
			}
			foreach (var kvp in obj.ChangedMap) {
				ret.ChangedMap.Add(kvp.Key,kvp.Value);
			}
			if (obj.WhereExpression!=null) {
				ret.WhereExpression=new WhereExpression();
				ret.WhereExpression.WhereContent=obj.WhereExpression.WhereContent;
				if (obj.WhereExpression.Parameters.Count>0) {
					foreach (var a in obj.WhereExpression.Parameters) {
						ret.WhereExpression.Parameters.Add(a);
					}
				}
				
			}
			return ret;
		}
	}
}

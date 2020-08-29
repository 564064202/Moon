/*
 * 由SharpDevelop创建。
 * 用户： qscq
 * 日期: 2014/4/8
 * 时间: 14:41
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Moon.Orm.Util
{
	/// <summary>
	/// json格式处理辅助类
	/// </summary>
	public static class JsonUtil
	{
		/// <summary>
		/// 将对象转化为json格式
		/// </summary>
		/// <param name="obj">任意对象</param>
		/// <returns>json数据</returns>
		public static string ConvertObjectToJson(object obj){
			return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
		}
		/// <summary>
		/// 将json数据转换为指定类型的对象
		/// </summary>
		/// <param name="json">json数据</param>
		/// <typeparam name="T">指定数据类型</typeparam>
		/// <returns>指定对象</returns>
		public static T ConvertJsonToObject<T>(string json){
			return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
		}
		/// <summary>
		/// 过滤特殊字符
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string StringToJString(String s)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < s.Length; i++)
			{
				char c = s.ToCharArray()[i];
				switch (c)
				{
					case '\"':
						sb.Append("\\\""); break;
					case '\\':
						sb.Append("\\\\"); break;
					case '/':
						sb.Append("\\/"); break;
					case '\b':
						sb.Append("\\b"); break;
					case '\f':
						sb.Append("\\f"); break;
					case '\n':
						sb.Append("\\n"); break;
					case '\r':
						sb.Append("\\r"); break;
					case '\t':
						sb.Append("\\t"); break;
					case '\v':
						sb.Append("\\v"); break;
					case '\0':
						sb.Append("\\0"); break;
					default:
						sb.Append(c); break;
				}
			}
			return sb.ToString();
		}
		/// <summary>
		/// 将json的数据格式还原到string
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string JStringToString(string s){
			StringBuilder sb=new StringBuilder(s);
			sb=sb.Replace("\\\"","\"");
			sb=sb.Replace("\\\\","\\");
			
			sb=sb.Replace("\\/","/");
			sb=sb.Replace("\\b","\b");
			sb=sb.Replace("\\f","\f");
			sb=sb.Replace("\\n","\n");
			sb=sb.Replace("\\r","\r");
			sb=sb.Replace("\\t","\r");
			sb=sb.Replace("\\v","\v");
			sb=sb.Replace("\\0","\0");
			return sb.ToString();
		}
		/// <summary>
		/// 将List&lt;EntityBase&gt;格式的对象转换为json
		/// </summary>
		/// <param name="list">List&lt;EntityBase&gt;格式对象</param>
		/// <returns>json</returns>
		public static string ConvertListEntityBaseToJson<T>(List<T> list) where T: EntityBase{
			StringBuilder sb=new StringBuilder();
			sb.Append("[");
			for (int i = 0; i < list.Count; i++) {
				string entityJson=list[i].ToJson();
				if (i==list.Count-1) {
					sb.Append(entityJson);
				}else{
					sb.Append(entityJson+",");
				}
			}
			sb.Append("]");
			return sb.ToString();
		}
		/// <summary>
		/// 将json转换为指定类型的List&lt;EntityBase&gt;对象
		/// </summary>
		/// <param name="json">json的对象数组</param>
		/// <returns></returns>
		public static List<T> ConvertJsonToListEntityBase<T> (string json) where T: EntityBase,new(){
			//[{"name":"dss},{d","age":3,"sex":false},{"name":"ni,nih","age":3,"sex":false}]
			int start=1;
			int length=json.Length-2;
			string value=json.Substring(start,length);
			if (string.IsNullOrEmpty(value)) {
				return null;
			}else{
				
				return JsonConvert.DeserializeObject<List<T>>(json);
			}
		}
		static object ConvertStringToObject(string str,bool hasyh){
			if (hasyh) {
				DateTime d;
				if (isDateTime(str,out d)) {
					return d;
				}else{
					
					return str;
				}
			}else{
				double d;
				if (str=="true"||str=="false") {
					return bool.Parse(str);
				}else if (isNum(str)) {
					var data= ulong.Parse(str);
					if (data<=int.MaxValue) {
						return (int)data;
					}else if (data>int.MaxValue&&data<=long.MaxValue) {
						return (long)data;
					}else{
						return data;
					}
				}else if(isDouble(str,out d)){
					if (d<=float.MaxValue) {
						return (float)d;
					}else{
						return d;
					}
				}else{
					throw new Exception("该形式的字符串不知道如何反序列化:"+str);
				}
			}
		}
		static bool isDouble(string str,out double d){
			bool r=double.TryParse(str,out d);
			return r;
		}
		static bool isDateTime(string str,out DateTime d){
			bool r=DateTime.TryParse(str,out d);
			return r;
		}
		static bool isNum(string str){
			Regex reg = new Regex("^[0-9]+$");              //判断是不是数据，要不是就表示没有选择，则从隐藏域里读出来
			Match ma = reg.Match(str);
			return ma.Success;
		}
		/// <summary>
		/// 将json转换为EntityBase对象
		/// </summary>
		/// <param name="json">json</param>
		/// <returns>EntityBase对象</returns>
		public static  T  ConvertJsonToEntityBase<T> (string json) where T: EntityBase,new(){
			// {"name":"dssd","age":3,"sex":false}
			int start=1;
			int length=json.Length-2;
			string value=json.Substring(start,length);
			if (string.IsNullOrEmpty(value)) {
				return null;
			}else{
				string[] arra=value.Split(',');
				T t=new T();
				foreach (string kvp in arra) {
					string[] kvparra=kvp.Split(':');
					string name=kvparra[0];
					string value2=kvparra[1];
					name=RemoveStartAndEndCharIfExist(name,'\"');
					if (value2.StartsWith("\"")) {
						value2=RemoveStartAndEndCharIfExist(value2,'\"');
						value2=JStringToString(value2);
					}
					t.SetPropertyValue(name,value2);
				}
				return t;
			}
			
		}
		static string RemoveStartAndEndCharIfExist(string str,char c){
			if (string.IsNullOrEmpty(str)) {
				return str;
			}else{
				if (str.Length>=2) {
					char start=str[0];
					char end=str[str.Length-1];
					if (start==end&&end==c) {
						string ret=str.Substring(1,str.Length-2);
						return ret;
					}else{
						return str;
					}
				}else{
					return str;
				}
			}
		}
		/// <summary>
		/// 格式化字符型、日期型、布尔型
		/// </summary>
		/// <param name="value">数据</param>
		/// <param name="type">数据类型</param>
		/// <returns>数据的json表示格式</returns>
		public static string StringFormat(object value, Type type)
		{
			string str=null;
			if (type == typeof(DateTime))
			{
				if (value==null||value==DBNull.Value) {
					str = "\"" + "" + "\"";
				}else{
					try {
						str=Convert.ToDateTime(value).ToString("yyyy-MM-dd hh:mm:ss");
						str = "\"" + str + "\"";
					} catch (Exception ex) {
						str = "\"" + "" + "\"";
						LogUtil.Exception(ex);
					}
					
				}
			}else{
				str=value.ToString();
			}
			if (type != typeof(string) && string.IsNullOrEmpty(str))
			{
				str = "\"" + str + "\"";
			}
			else if (type == typeof(string))
			{
				str = StringToJString(str);
				str = "\"" + str + "\"";
			}
			else if (type == typeof(bool))
			{
				str = str.ToLower();
			}
			else if (type == typeof(byte[]))
			{
				str = "\"" + str + "\"";
			}else if(type==typeof(Guid))
			{
				str = "\"" + str + "\"";
			}
			return str;
		}
		/// <summary>
		/// dicMObject to json
		/// </summary>
		/// <param name="dic"></param>
		/// <returns></returns>
		public static string DicToJson(Dictionary<string,MObject> dic){
			StringBuilder sb=new StringBuilder();
			sb.Append("{");
			int count=0;
			foreach (var kvp in dic) {
				count++;
				sb.Append("\""+kvp.Key+"\":");
				string strValue =null;
				if (kvp.Value.IsNull()) {
					strValue="null";
				}else{
					strValue = StringFormat(kvp.Value, kvp.Value.Value.GetType());
				}
				if (count==dic.Count) {
					sb.Append(strValue);
				}else{
					sb.Append(strValue+",");
				}
				
			}
			sb.Append("}");
			return sb.ToString();
		}
		/// <summary>
		/// 将json转换为 Newtonsoft.Json.Linq.JObject
		/// </summary>
		/// <param name="json">json</param>
		/// <returns>Newtonsoft.Json.Linq.JObject对象</returns>
		public static Newtonsoft.Json.Linq.JObject ConvertJsonToJObject(string json){
			return JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(json);
		}
		/// <summary>
		/// 讲一个简单的json数据(没有嵌套),转换为Dictionary&lt;string,JObject&gt;
		/// </summary>
		/// <param name="simpleDataJson">简单的json数据,如{\"A.id\":11,\"A.name\":\"qsc\",\"B.Num\":232323,\"B.Enabled\":false}</param>
		/// <param name="withoutPre">是否去掉前缀</param>
		/// <returns>Dictionary&lt;string,JObject&gt;</returns>
		public static JObjectDictionary  ConvertOneSimpleJsonToJObjectDictionary(string simpleDataJson,bool withoutPre)
		{
			var jobjDic=JsonUtil.ConvertJsonToJObject(simpleDataJson);
			JObjectDictionary dic=new JObjectDictionary();
			foreach (var kvp in jobjDic) {
				var pre=GetJObjectKeyPre(kvp.Key);
				if (dic.ContainsKey(pre)==false) {
					dic[pre]=new JObject();
				}
				string name=kvp.Key;
				if (withoutPre) {
					int index=name.LastIndexOf('.');
					if (index>-1) {
						name=name.Substring(index+1);
					}
				}
				dic[pre][name]=kvp.Value;
			}
			return dic;
		}
		static string GetJObjectKeyPre(string key){
			int index=key.LastIndexOf('.');
			if (index==-1) {
				return string.Empty;
			}else{
				return key.Substring(0,index);
			}
		}
		/// <summary>
		/// DataReader转换为Json,dataReader会自己关闭
		/// </summary>
		/// <param name="dataReader">DataReader对象</param>
		/// <returns>Json字符串</returns>
		public static string DataReaderToJson(IDataReader dataReader)
		{
			StringBuilder jsonString = new StringBuilder();
			jsonString.Append("[");
			while (dataReader.Read())
			{
				jsonString.Append("{");
				for (int i = 0; i < dataReader.FieldCount; i++)
				{
					Type type = dataReader.GetFieldType(i);
					string strKey = dataReader.GetName(i);
					string strValue =null;
					if (dataReader[i]!=null) {
						strValue=dataReader[i].ToString();
						strValue = StringFormat(strValue, type);
					}else{
						strValue="null";
					}
					jsonString.Append("\"" + strKey + "\":");
					if (i < dataReader.FieldCount - 1)
					{
						jsonString.Append(strValue + ",");
					}
					else
					{
						jsonString.Append(strValue);
					}
				}
				jsonString.Append("},");
			}
			if (!dataReader.IsClosed)
			{
				dataReader.Close();
			}
			jsonString.Remove(jsonString.Length - 1, 1);
			jsonString.Append("]");
			if (jsonString.Length == 1)
			{
				return "[]";
			}
			return jsonString.ToString();
			
		}
	}
}

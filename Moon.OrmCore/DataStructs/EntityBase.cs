using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Moon.Orm.Util;

namespace Moon.Orm
{

	/// <summary>
	/// 实体类的基类
	/// </summary>
	[Serializable]
	public class EntityBase{
		/// <summary>
		/// 构造
		/// </summary>
		public EntityBase(){
			
		}
		/// <summary>
		/// 用于存放record来的值
		/// </summary>
		protected Dictionary<string,object> _ValueMap=new Dictionary<string, object>();
		/// <summary>
		/// 用于存放变动的值
		/// </summary>
		protected Dictionary<string,object> _ChangedMap=new Dictionary<string, object>();
		/// <summary>
		/// 变动的值
		/// </summary>
		public Dictionary<string, object> ChangedMap {
			get { return _ChangedMap; }
		}
		
		/// <summary>
		/// 获取valuemap
		/// </summary>
		public Dictionary<string, object> GetValueMap() {
			return _ValueMap;
		}
		/// <summary>
		/// 设置数据值到实体中
		/// </summary>
		/// <param name="record"></param>
		public void SetDataRecordToEntity(IDataRecord record){
			for (int i = 0; i < record.FieldCount; i++) {
				string name=record.GetName(i).ToLower();
				if (record.IsDBNull(i)) {
					_ValueMap[name]=null;
				}
				else{
					_ValueMap[name]=record[i];
				}
			}
		}
		/// <summary>
		/// 获取一个具体属性的值
		/// </summary>
		/// <param name="name">属性的字段名</param>
		/// <returns></returns>
		protected virtual T GetPropertyValue<T>(string name)
		{
			name=name.ToLower();
			if (!_ValueMap.ContainsKey(name)) {
				return default(T);
			}
			object value=_ValueMap[name];
			if (value==null) {
				return default(T);
			}else{
				if (value is T) {
					return (T)value;
				}
				if (typeof(T) ==typeof( bool)||typeof(T) ==typeof( bool?)) {
					bool v= Convert.ToUInt64(value)==1;
					return (T)((object)v);
				}
				return (T)((object)value);
			}
		}
		/// <summary>
		/// 设置一个具体属性的值,只操作_ValueMap
		/// </summary>
		/// <param name="name">字段名</param>
		/// <param name="value">值</param>
		public void SetPropertyValueOnlyByValueMap(string name,object value){
			name=name.ToLower();
			_ValueMap[name]=value;
		}
		/// <summary>
		/// 设置一个具体属性的值
		/// </summary>
		/// <param name="name">字段名</param>
		/// <param name="value">值</param>
		public  void SetPropertyValue(string name,Object value)
		{
			name=name.ToLower();
			_ValueMap[name]=value;
			if (value==null)
			{
				_ChangedMap[name]=DBNull.Value;
			}
			else{
				_ChangedMap[name]=value;
			}
			
		}
		/// <summary>
		/// 获取该实体的主键信息
		/// </summary>
		/// <returns></returns>
		public TablesPrimaryKeyAttribute GetPrimaryKeyInfo(){
			var type=this.GetType();
			var array=type.GetCustomAttributes(typeof(TablesPrimaryKeyAttribute),true);
			if (array==null||array.Length==0) {
				Moon.Orm.Util.LogUtil.Warning(this.ToString()+",没有实体的主键信息");
				return new TablesPrimaryKeyAttribute(PrimaryKeyType.NoPK,typeof(NullReferenceException),"null");
			}
			var ret=array[0] as TablesPrimaryKeyAttribute;
			if (ret==null) {
				ret=array[1] as TablesPrimaryKeyAttribute;
			}
			return ret;
		}
		/// <summary>
		/// 设置实体主键的值
		/// </summary>
		/// <param name="value">主键的值</param>
		/// <returns>返回设置状态,目前1:成功,-1失败</returns>
		public int SetPrimaryKeyValue(object value){
			TablesPrimaryKeyAttribute attr=GetPrimaryKeyInfo();
			if (attr!=null&&value!=null) {
				string data=value.ToString();
				if (attr.PrimaryKeyDataType==typeof(int)) {
					value=int.Parse(data);
				}else if (attr.PrimaryKeyDataType==typeof(uint)) {
					value=uint.Parse(data);
				}
				else if (attr.PrimaryKeyDataType==typeof(long)) {
					value=long.Parse(data);
				}
				else if (attr.PrimaryKeyDataType==typeof(ulong)) {
					value=ulong.Parse(data);
				}
				else if (attr.PrimaryKeyDataType==typeof(decimal)) {
					value=decimal.Parse(data);
				}else{
					throw new Exception("主键类型"+attr.PrimaryKeyDataType+"还未设置");
				}
				this.SetPropertyValueOnlyByValueMap(attr.PrimaryFieldName,value);
				return 1;
			}
			
			return -1;
		}
		/// <summary>
		/// 将继承了EntityBase的实体对象转为json格式
		/// 如{id:3,age:4,address:"beijing"}
		/// 这里提示大家,json名都为小写
		/// </summary>
		/// <returns></returns>
		public string ToJson(){
			StringBuilder jsonString=new StringBuilder();
			jsonString.Append("{");
			int count=0;
			foreach (var kvp in _ValueMap) {
				count++;
				string name=kvp.Key;
				jsonString.Append("\"" + name + "\":");
				string value="";
				if(kvp.Value!=null){
					value = Util.JsonUtil.StringFormat(kvp.Value, kvp.Value.GetType());
				}else{
					value="null";
				}
				if (count==_ValueMap.Count) {
					jsonString.Append(value);
				}else{
					jsonString.Append(value + ",");
				}
			}
			jsonString.Append("}");
			return jsonString.ToString();
		}
		/// <summary>
		/// 通过IDataRecord获取一个具体实体类型实例
		/// </summary>
		/// <param name="record">记录</param>
		/// <returns></returns>
		public static T CreateEntity<T>(IDataRecord record) where T:EntityBase,new()
		{
			T ret=new T();
			ret.SetDataRecordToEntity(record);
			return ret;
		}
		/// <summary>
		/// 对应的条件表达式,如UserSet.Age.Equal(12).And(UserSet.Name.Equal("abc"))
		/// </summary>
		public WhereExpression WhereExpression{
			get;
			set;
		}
		/// <summary>
		/// 自身克隆,T就是本对象的类型
		/// </summary>
		/// <returns>本对象的克隆体,能够代表本对象(一个新的对象)</returns>
		public T Clone<T>() where T:EntityBase,new(){
			 T ret=new T();
			foreach (var kvp in this.GetValueMap()) {
				ret.GetValueMap().Add(kvp.Key,kvp.Value);
			}
			foreach (var kvp in this.ChangedMap) {
				ret.ChangedMap.Add(kvp.Key,kvp.Value);
			}
			if (this.WhereExpression!=null) {
				ret.WhereExpression=new WhereExpression();
				ret.WhereExpression.WhereContent=this.WhereExpression.WhereContent;
				if (this.WhereExpression.Parameters.Count>0) {
					foreach (var a in this.WhereExpression.Parameters) {
						ret.WhereExpression.Parameters.Add(a);
					}
				}
				
			}
			return ret;
		}
	}
}


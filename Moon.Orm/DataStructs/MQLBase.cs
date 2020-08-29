using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Moon.Orm
{
	/// <summary>
	/// MQL基类
	/// </summary>
	public class MQLBase
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		protected MQLBase(){
			
		}
		/// <summary>
		/// 参数用的前缀 如:@,:
		/// </summary>
		public string PName{
			get;
			set;
		}
		/// <summary>
		/// 创建一个MQLBase实例
		/// </summary>
		/// <returns></returns>
		public static MQLBase CreateOneObject(){
			MQLBase ret=new MQLBase();
			return ret;
		}
		/// <summary>
		/// Union
		/// </summary>
		/// <param name="mql"></param>
		/// <returns></returns>
		public virtual UnionMQL Union(MQLBase mql){
			UnionMQL union=new UnionMQL();
			union._mql1=this;
			union._mql2=mql;
			union.IsAll=false;
			union.PName=this.PName;
			foreach (FieldBase field in this.SelectList) {
				union.SelectList.Add(field);
			}
			foreach (FieldBase field in mql.SelectList) {
				union.SelectList.Add(field);
			}
			return union;
		}
		/// <summary>
		/// UnionAll
		/// </summary>
		/// <param name="mql"></param>
		/// <returns></returns>
		public virtual UnionMQL UnionAll(MQLBase mql){
			UnionMQL union=new UnionMQL();
			union._mql1=this;
			union._mql2=mql;
			union.IsAll=true;
			union.PName=this.PName;
			foreach (FieldBase field in this.SelectList) {
				union.SelectList.Add(field);
			}
			foreach (FieldBase field in mql.SelectList) {
				union.SelectList.Add(field);
			}
			return union;
		}
		/// <summary>
		/// LeftJoin
		/// </summary>
		/// <param name="mql"></param>
		/// <returns></returns>
		public virtual JoinMQL LeftJoin(MQLBase mql){
			JoinMQL jm=new JoinMQL();
			jm._Location="LEFT";
			jm._mql1=this;
			jm._mql2=mql;
			jm.PName=this.PName;
			foreach (FieldBase field in this.SelectList) {
				jm.SelectList.Add(field);
			}
			foreach (FieldBase field in mql.SelectList) {
				jm.SelectList.Add(field);
			}
			jm.Parameters.AddRange(this.Parameters);
			jm.Parameters.AddRange(mql.Parameters);
			return jm;
		}
		/// <summary>
		/// RightJoin
		/// </summary>
		/// <param name="mql"></param>
		/// <returns></returns>
		public virtual JoinMQL RightJoin(MQLBase mql){
			JoinMQL jm=new JoinMQL();
			jm._Location="RIGHT ";
			jm._mql1=this;
			jm._mql2=mql;
			jm.PName=this.PName;
			foreach (FieldBase field in this.SelectList) {
				jm.SelectList.Add(field);
			}
			foreach (FieldBase field in mql.SelectList) {
				jm.SelectList.Add(field);
			}
			jm.Parameters.AddRange(this.Parameters);
			jm.Parameters.AddRange(mql.Parameters);
			return jm;
		}
		/// <summary>
		/// FullJoin
		/// </summary>
		/// <param name="mql"></param>
		/// <returns></returns>
		public virtual JoinMQL FullJoin(MQLBase mql){
			JoinMQL jm=new JoinMQL();
			jm._Location="FULL ";
			jm._mql1=this;
			jm._mql2=mql;
			jm.PName=this.PName;
			foreach (FieldBase field in this.SelectList) {
				jm.SelectList.Add(field);
			}
			foreach (FieldBase field in mql.SelectList) {
				jm.SelectList.Add(field);
			}
			jm.Parameters.AddRange(this.Parameters);
			jm.Parameters.AddRange(mql.Parameters);
			return jm;
		}
		/// <summary>
		/// InnerJoin
		/// </summary>
		/// <param name="mql"></param>
		/// <returns></returns>
		public virtual JoinMQL InnerJoin(MQLBase mql){
			JoinMQL jm=new JoinMQL();
			jm._Location="INNER ";
			jm._mql1=this;
			jm._mql2=mql;
			jm.PName=this.PName;
			foreach (FieldBase field in this.SelectList) {
				jm.SelectList.Add(field);
			}
			foreach (FieldBase field in mql.SelectList) {
				jm.SelectList.Add(field);
			}
			jm.Parameters.AddRange(this.Parameters);
			jm.Parameters.AddRange(mql.Parameters);
			return jm;
		}
		
		///// <summary>
		///// 选择目标字段
		///// </summary>
		///// <param name="fields"></param>
		///// <returns></returns>
		//protected static MQLBase  Select (params FieldBase[] fields)
		//{
		//	//
		//	StackTrace st=new StackTrace(true);
		//	var type=st.GetFrame(1).GetMethod().DeclaringType;
		//	var attributes=type.GetCustomAttributes(typeof(TableAttribute),true);
		//	string tableName=string.Empty;
		//	string localPName="@";
		//	DbType dtype;
		//	if(attributes.Length>0)
		//	{
		//		TableAttribute table=attributes[0] as TableAttribute;
		//		tableName=table.TableName;
		//		dtype=table.DbType;
		//	}
		//	else
		//	{
		//		throw new Exception("实体类的没有table标记");
		//	}
		//	if (dtype== DbType.Oracle) {
		//		localPName=":";
		//	}
		//	//
		//	MQLBase ret=new MQLBase();
		//	ret.TableName=tableName;
		//	ret.PName=localPName;
		//	ret._SelectList.AddRange (fields);
		//	return ret;
		//}
		/// <summary>
		/// 选择目标字段
		/// </summary>
		/// <param name="dtype">dtype</param>
		/// <param name="tableName">tableName</param>
		/// <param name="fields">field组</param>
		/// <returns>MQLBase</returns>
		protected static MQLBase  Select(DbType dtype,string tableName,params FieldBase[] fields){
			if (fields.Length==0) {
				throw new ArgumentException("最终的sql生成的语句中没有选择字段");
			}
			string pname="@";
			if (dtype== DbType.Oracle) {
				pname=":";
			}
			MQLBase ret=new MQLBase();
			ret.TableName=tableName;
			ret.PName=pname;
			ret._SelectList.AddRange (fields);
			return ret;
		}
		static bool IsInArray(FieldBase[] fields,string fieldName){
			for (int i = 0; i < fields.Length; i++) {
				var f=fields[i];
				if(f.Name_.Equals(fieldName,StringComparison.OrdinalIgnoreCase)){
					return true;
				}
			}
			return false;
		}
		/// <summary>
		/// 选择所有字段除了......
		/// </summary>
		/// <param name="tableSetType">查询类类型名</param>
		/// <param name="dtype">dtype</param>
		/// <param name="tableName">tableName</param>
		/// <param name="fields">排除的field组</param>
		/// <returns>MQLBase</returns>
		protected static MQLBase SelectAllBut(Type tableSetType ,DbType dtype,string tableName,params FieldBase[] fields)
		{
			List<FieldBase> targets=new List<FieldBase>();
			FieldInfo[] allFields = tableSetType.GetFields(BindingFlags.Public |BindingFlags.Static);
			foreach (var f in allFields) {
				if(IsInArray(fields,f.Name)==false){
					var value=f.GetValue(null) as FieldBase;
					targets.Add(value);
				}
			}
			return Select(dtype,tableName,targets.ToArray());
		}
		/// <summary>
		/// 选择指定表的所有字段
		/// </summary>
		/// <param name="dtype">数据库类型</param>
		/// <param name="tableName">表名</param>
		/// <returns>MQLBase</returns>
		public static MQLBase SelectAll(DbType dtype,string tableName){
			string pname="@";
			if (dtype== DbType.Oracle) {
				pname=":";
			}
			FieldBase f=new FieldBase(dtype,tableName,FieldType.AllStar,"*");
			MQLBase ret=new MQLBase();
			ret.PName=pname;
			ret.TableName=tableName;
			ret._SelectList.Add (f);
			return ret;
		}
		///// <summary>
		///// 选择指定表T的所有字段
		///// </summary>
		///// <returns>MQLBase</returns>
		//public static MQLBase  SelectAll()
		//{
		//	//
		//	StackTrace st=new StackTrace(true);
		//	var type=st.GetFrame(1).GetMethod().DeclaringType;
		//	var attributes=type.GetCustomAttributes(typeof(TableAttribute),true);
		//	string tableName=string.Empty;
		//	string localPName="@";
		//	DbType dtype;
		//	if(attributes.Length>0)
		//	{
		//		TableAttribute table=attributes[0] as TableAttribute;
		//		tableName=table.TableName;
		//		dtype=table.DbType;
		//	}
		//	else
		//	{
		//		throw new Exception("实体类的没有table标记");
		//	}
		//	if (dtype== DbType.Oracle) {
		//		localPName=":";
		//	}
		//	//
		//	FieldBase f=new FieldBase(dtype,tableName,FieldType.AllStar,"*");
		//	MQLBase ret=new MQLBase();
		//	ret.PName=localPName;
		//	ret.TableName=tableName;
		//	ret._SelectList.Add (f);
		//	return ret;
		//}
		/// <summary>
		/// 查询条件
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		public MQLBase Where (WhereExpression expression)
		{
			_WhereExpression = expression;
			return this;
		}
		/// <summary>
		/// Having条件
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		public MQLBase Having (WhereExpression expression)
		{
			_HavingExpression = expression;
			return this;
		}
		/// <summary>
		/// 分组
		/// </summary>
		/// <param name="fields"></param>
		/// <returns></returns>
		public MQLBase GroupBy (params FieldBase[] fields)
		{
			this._GroupByList.AddRange (fields);
			return this;
		}
		/// <summary>
		/// 取数据中前count条
		/// </summary>
		/// <param name="count"></param>
		/// <returns></returns>
		public MQLBase Top(int count){
			this.TopCount=count.ToString();
			return this;
		}
		/// <summary>
		/// 取数据中前count条
		/// </summary>
		/// <param name="count"></param>
		/// <returns></returns>
		public MQLBase Top(long count){
			this.TopCount=count.ToString();
			return this;
		}
		/// <summary>
		/// 升序
		/// </summary>
		/// <param name="fields"></param>
		/// <returns></returns>
		public virtual MQLBase OrderByASC(params FieldBase[] fields){
			foreach (var field in fields) {
				_OrderByDictionary.Add(field,"ASC");
			}
			return this;
		}
		/// <summary>
		/// 降序
		/// </summary>
		/// <param name="fields"></param>
		/// <returns></returns>
		public virtual MQLBase OrderByDESC(params FieldBase[] fields){
			foreach (var field in fields) {
				_OrderByDictionary.Add(field,"DESC");
			}
			return this;
		}
		/// <summary>
		/// 转化纯sql表达式的
		/// </summary>
		/// <returns></returns>
		public virtual string ToSQLExpression ()
		{
			
			StringBuilder ret = ToSQLExpressionStringBuilder();
			return ret.ToString();
		}
		/// <summary>
		/// 转化纯sql表达式的StringBuilder
		/// </summary>
		/// <returns></returns>
		public virtual StringBuilder ToSQLExpressionStringBuilder()
		{
			StringBuilder ret = new StringBuilder();
			ret.Append("SELECT ");
			DbType currentDbType=this.SelectList[0].DbType;
			if (string.IsNullOrEmpty(this.TopCount)==false) {
				if (this.SelectList.Count>0&&currentDbType== DbType.SqlServer) {
					ret.Append ("TOP "+this.TopCount+" ");
				}
			}
			if (_SelectList.Count == 0) {
				ret.Append("* ");
			} else {
				for (int i = 0; i < this._SelectList.Count; i++) {
					FieldBase field =this._SelectList[i];
					if (field.FieldType == FieldType.FunctionField) {
						if (i==this._SelectList.Count-1) {
							ret.Append ( field.Name + " ");
						}else{
							ret.Append (field.Name + ",");
						}
					} else {
						if (i==this._SelectList.Count-1) {
							ret.Append (field.TableName + "." + field.Name + " ");
						}else{
							ret.Append (field.TableName + "." + field.Name + ",");
						}
					}
				}
			}
			ret.Append("FROM " + this.TableName + " ");
			if (string.IsNullOrEmpty(this._WhereExpression.WhereContent) == false) {
				ret.Append("WHERE " + this._WhereExpression.WhereContent);
			}
			if (_GroupByList.Count > 0) {
				ret.Append(" GROUP BY ");
				for (int i = 0; i < _GroupByList.Count; i++) {
					FieldBase field = _GroupByList[i];
					if (i == 0) {
						if (field.FieldType == FieldType.FunctionField) {
							ret.Append( field.Name+ " ");
						} else {
							ret.Append( field.TableName + "." + field.Name+ " ");
						}
						if (_GroupByList.Count > 1) {
							ret.Append(",");
						}
					} else if (i > 0 && i < _GroupByList.Count - 1) {
						if (field.FieldType != FieldType.FunctionField) {
							ret.Append( field.TableName + "." + field.Name + ",");
						}else{
							ret.Append( field.Name+ ",");
						}
					} else {
						if (field.FieldType != FieldType.FunctionField) {
							ret.Append( field.TableName + "." + field.Name);
						}else{
							ret.Append( field.Name+ " ");
						}
					}
				}
			}
			if (string.IsNullOrEmpty(this._HavingExpression.WhereContent) == false) {
				ret.Append(" HAVING " + this._HavingExpression.WhereContent);
			}
			if (_OrderByDictionary.Count>0) {
				ret.Append("  ORDER BY ");
			}
			int orderCount=0;
			foreach (var kvp in _OrderByDictionary) {
				orderCount++;
				string orderExpression=null;
				if (kvp.Key.FieldType== FieldType.FunctionField) {
					orderExpression= kvp.Key.Name + " "+kvp.Value;
				}else{
					orderExpression=kvp.Key.TableName + "." + kvp.Key.Name + " "+kvp.Value;
				}
				if (orderCount==_OrderByDictionary.Count) {
					ret.Append(orderExpression+" ");
				}else{
					ret.Append(orderExpression+",");
				}
			}
			if (string.IsNullOrEmpty(this.TopCount)==false) {
				if (currentDbType== DbType.SqlServer) {
					return ret;
				}
				else if (this.SelectList.Count>0&&currentDbType== DbType.MySql) {
					ret.Append ("LIMIT 0, "+this.TopCount+" ");
				}
				else if (this.SelectList.Count>0&&currentDbType== DbType.Sqlite) {
					ret.Append ("LIMIT 0, "+this.TopCount+" ");
				}
				else if (this.SelectList.Count>0&&currentDbType== DbType.PostGresql) {
					ret.Append ("LIMIT  "+this.TopCount+" ");
				}
				else if (this.SelectList.Count>0&&currentDbType== DbType.Oracle) {
					if (string.IsNullOrEmpty(this._WhereExpression.WhereContent))
						ret.Append ("WHERE ROWNUM <= "+this.TopCount+" ");
					else
						ret.Append ("ROWNUM <= "+this.TopCount+" ");
				}
			}
			return ret;
		}
		/// <summary>
		/// 转化为以@为参数的sql语句
		/// </summary>
		/// <returns></returns>
		public virtual string ToParametersSQL ()
		{
			StringBuilder ret = ToSQLExpressionStringBuilder();
			//
			string sql = ret.ToString ();
			StringBuilder retSB = new StringBuilder ();
			int index = 1;
			for (int i=0; i<sql.Length; i++) {
				Char c=sql [i];
				if ('@' == c) {
					retSB.Append (this.PName+"p" + index);
					index++;
				} else {
					retSB.Append (c);
				}
			}
			
			return retSB.ToString();
		}
		/// <summary>
		/// 将MQL转为可视化的调试sql信息
		/// </summary>
		/// <returns></returns>
		public virtual string ToDebugSQL ()
		{
			var ret=ToSQLExpression();
			string sql = ret.ToString ();
			StringBuilder retSB = new StringBuilder ();
			int index = 1;
			for (int i=0; i<sql.Length; i++) {
				Char c=sql [i];
				if ('@' == c) {
					retSB.Append (this.PName+"p" + index);
					index++;
				} else {
					retSB.Append (c);
				}
			}
			
			retSB.AppendLine();
			int k=1;
			for (; k <= Parameters.Count; k++) {
				object value=Parameters[k-1];
				string pName=this.PName+"p"+k;
				retSB.AppendLine(pName+"="+value);
			}
			return retSB.ToString();
		}
		/// <summary>
		/// 参数容器
		/// </summary>
		public virtual List<object> Parameters {
			get {
				var list=new List<object>();
				list.AddRange( _WhereExpression.Parameters);
				list.AddRange(_HavingExpression.Parameters);
				return list;
			}
		}
		private string _topCount;
		/// <summary>
		/// Top数
		/// </summary>
		public string TopCount {
			get { return _topCount; }
			set { _topCount = value; }
		}
		
		private string _tableName;
		/// <summary>
		/// 表名
		/// </summary>
		/// <value>The name.</value>
		public string TableName {
			get {
				return _tableName;
			}
			set {
				_tableName = value;
			}
		}
		/// <summary>
		/// 选择的字段的容器
		/// </summary>
		protected List<FieldBase> _SelectList = new List<FieldBase> ();
		/// <summary>
		/// 分组的容器
		/// </summary>
		protected List<FieldBase> _GroupByList = new List<FieldBase> ();
		/// <summary>
		/// 选择的字段的容器
		/// </summary>
		public virtual List<FieldBase> SelectList {
			get { return _SelectList; }
		}
		/// <summary>
		/// WhereExpression
		/// </summary>
		protected WhereExpression _WhereExpression = new WhereExpression ();
		/// <summary>
		/// HavingExpression
		/// </summary>
		protected WhereExpression _HavingExpression = new WhereExpression ();
		
		//----------2013-10-19 8:26:14 秦仕川
		/// <summary>
		/// 排序用的容器
		/// </summary>
		protected Dictionary<FieldBase,String> _OrderByDictionary=new Dictionary<FieldBase, string>();
		//----------2013-12-7 10:22:18 秦仕川
		/// <summary>
		/// 获取它的WhereExpression
		/// </summary>
		/// <returns></returns>
		public WhereExpression GetWhereExpression(){
			return _WhereExpression;
		}
	}
}


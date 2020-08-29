using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Moon.Orm
{
	/// <summary>
	/// 用于查询用的字段类型
	/// </summary>
	public class FieldBase
	{
		/// <summary>
		/// 构造
		/// </summary>
		/// <param name="dbType">数据库类型</param>
		/// <param name="tableName">表名,带有修饰符如:[]、``</param>
		/// <param name="fieldType">字段类型,用于扩展</param>
		/// <param name="name">字段名,带有修饰符如:[]、`</param>
		public FieldBase(DbType dbType,string tableName,FieldType fieldType,string name){
			this.DbType=dbType;
			this.TableName=tableName;
			this.FieldType=fieldType;
			this.Name=name;
		}
		/// <summary>
		/// min
		/// </summary>
		/// <returns></returns>
		public FieldBase Min ()
		{
			FieldBase ret = new FieldBase (this.DbType,this.TableName, FieldType.FunctionField,null);
			
			ret.Name = "MIN(" + this.TableName + "." + this.Name + ")";
			
			return ret;
		}
		/// <summary>
		/// count
		/// </summary>
		/// <returns></returns>
		public FieldBase Count ()
		{
			FieldBase ret = new FieldBase (this.DbType,this.TableName, FieldType.FunctionField,null);
			
			ret.Name = "COUNT(" + this.TableName + "." + this.Name + ")";
			
			return ret;
			
		}
		/// <summary>
		/// max
		/// </summary>
		/// <returns></returns>
		public FieldBase Max ()
		{
			FieldBase ret = new FieldBase (this.DbType,this.TableName, FieldType.FunctionField,null);
			
			ret.Name = "MAX(" + this.TableName + "." + this.Name + ")";
			
			return ret;
		}
		/// <summary>
		/// avg
		/// </summary>
		/// <returns></returns>
		public FieldBase Avg ()
		{
			FieldBase ret = new FieldBase (this.DbType,this.TableName, FieldType.FunctionField,null);
			
			ret.Name = "AVG(" + this.TableName + "." + this.Name + ")";
			
			return ret;
		}
		/// <summary>
		/// sum
		/// </summary>
		/// <returns></returns>
		public FieldBase Sum ()
		{
			FieldBase ret = new FieldBase (this.DbType,this.TableName, FieldType.FunctionField,null);
			
			ret.Name = "SUM(" + this.TableName + "." + this.Name + ")";
			
			return ret;
		}
		/// <summary>
		/// as,例如: select [name] as 'myname'
		/// </summary>
		/// <param name="Name"></param>
		/// <returns></returns>
		public FieldBase AS (string Name)
		{
			FieldBase ret = new FieldBase (this.DbType,this.TableName, FieldType.FunctionField,null);
			if (this.FieldType!= FieldType.FunctionField) {
				ret.Name =this.TableName+"." +this.Name + " as \""+Name+"\"";
			}else{
				ret.Name = this.Name + " AS \""+Name+"\"";
			}
			return ret;
		}
		/// <summary>
		/// in,例如 select * from person where classid in (select classid from class where classname='')
		/// </summary>
		/// <param name="mql"></param>
		/// <returns></returns>
		public WhereExpression In (MQLBase mql)
		{
			WhereExpression ret = new WhereExpression ();
			ret.WhereContent = this.TableName + "." + this.Name + " IN (" + mql.ToSQLExpression () + ") ";
			ret.Parameters.AddRange (mql.Parameters);
			return ret;
		}
		/// <summary>
		/// not in,例如 select * from person where classid not in (select classid from class where classname='')
		/// </summary>
		/// <param name="mql"></param>
		/// <returns></returns>
		public WhereExpression NotIn (MQLBase mql)
		{
			WhereExpression ret = new WhereExpression ();
			ret.WhereContent = this.TableName + "." + this.Name + " NOT IN (" + mql.ToSQLExpression () + ") ";
			ret.Parameters.AddRange (mql.Parameters);
			return ret;
		}
		/// <summary>
		/// 以某字符串开始
		/// </summary>
		/// <returns>The with.</returns>
		/// <param name="value">Value.</param>
		public WhereExpression StartWith (string value)
		{
			WhereExpression ret = new WhereExpression ();
			string pValue = "@";
			ret.Parameters.Add (value+"%");
			ret.WhereContent = this.TableName + "." + this.Name + " LIKE " + pValue+" ";
			return ret;
		}
		/// <summary>
		/// 含有某字符串
		/// </summary>
		/// <returns>The with.</returns>
		/// <param name="value">Value.</param>
		public WhereExpression Contains (string value)
		{
			WhereExpression ret = new WhereExpression ();
			string pValue = "@";
			ret.Parameters.Add ("%"+value+"%");
			ret.WhereContent = this.TableName + "." + this.Name + " LIKE " + pValue + " ";
			return ret;
		}
		
		/// <summary>
		/// 以某字符串结束
		/// </summary>
		/// <returns>The with.</returns>
		/// <param name="value">Value.</param>
		public WhereExpression EndWith (string value)
		{
			WhereExpression ret = new WhereExpression ();
			string pValue = "@";
			ret.Parameters.Add (value+"%");
			ret.WhereContent = this.TableName + "." + this.Name + " like " + pValue + " ";
			return ret;
		}
		/// <summary>
		/// in,例如 select * from person where classid in (23,2332,232)
		/// </summary>
		/// <param name="values">目标数据集合</param>
		/// <returns></returns>
		public WhereExpression In (params string[] values)
		{
			WhereExpression ret = new WhereExpression ();
			string pValue = "";
			for (int i=0; i<values.Length; i++) {
				if (i == values.Length - 1)
					pValue += "@";
				else
					pValue += "@,";
			}
			ret.Parameters.AddRange (values);
			ret.WhereContent = this.TableName + "." + this.Name + " IN (" + pValue + ") ";
			return ret;
		}
		/// <summary>
		///  not in,例如 select * from person where classid  not in (23,2332,232)
		/// </summary>
		/// <param name="values">目标数据集</param>
		/// <returns></returns>
		public WhereExpression NotIn (params string[] values)
		{
			WhereExpression ret = new WhereExpression ();
			string pValue = "";
			for (int i=0; i<values.Length; i++) {
				if (i == values.Length - 1)
					pValue += "@";
				else
					pValue += "@,";
			}
			ret.Parameters.AddRange (values);
			ret.WhereContent = this.TableName + "." + this.Name + " NOT IN (" + pValue + ") ";
			return ret;
		}
		/// <summary>
		/// Exists
		/// </summary>
		/// <param name="mql"></param>
		/// <returns></returns>
		public WhereExpression Exists (MQLBase mql)
		{
			WhereExpression ret = new WhereExpression ();
			ret.WhereContent = this.TableName + "." + this.Name + " EXISTS (" + mql.ToSQLExpression () + ") ";
			ret.Parameters.Add (mql.Parameters);
			return ret;
		}
		/// <summary>
		///   in,例如 select * from person where classid   in (23,2332,232)
		/// </summary>
		/// <param name="values">目标数据集</param>
		/// <returns></returns>
		public WhereExpression In (params int[] values)
		{
			WhereExpression ret = new WhereExpression ();
			string pValue = "";
			for (int i=0; i<values.Length; i++) {
				if (i == values.Length - 1)
					pValue += "@";
				else
					pValue += "@,";
				ret.Parameters.Add (values [i]);
			}

			ret.WhereContent = this.TableName + "." + this.Name + " IN (" + pValue + ") ";
			return ret;
		}
		/// <summary>
		/// not in,例如 select * from person where classid  not in (23,2332,232)
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public WhereExpression NotIn (params int[] values)
		{
			WhereExpression ret = new WhereExpression ();
			string pValue = "";
			for (int i=0; i<values.Length; i++) {
				if (i == values.Length - 1)
					pValue += "@";
				else
					pValue += "@,";
				ret.Parameters.Add (values [i]);
			}

			ret.WhereContent = this.TableName + "." + this.Name + " IN (" + pValue + ") ";
			return ret;
		}
		/// <summary>
		///    in,例如 select * from person where classid    in (23,2332,232)
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public WhereExpression In (params uint[] values)
		{
			WhereExpression ret = new WhereExpression ();
			string pValue = "";
			for (int i=0; i<values.Length; i++) {
				if (i == values.Length - 1)
					pValue += "@";
				else
					pValue += "@,";
				ret.Parameters.Add (values [i]);
			}
			
			ret.WhereContent = this.TableName + "." + this.Name + " IN (" + pValue + ") ";
			return ret;
		}
		/// <summary>
		///  not in,例如 select * from person where classid  not in (23,2332,232)
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public WhereExpression NotIn (params uint[] values)
		{
			WhereExpression ret = new WhereExpression ();
			string pValue = "";
			for (int i=0; i<values.Length; i++) {
				if (i == values.Length - 1)
					pValue += "@";
				else
					pValue += "@,";
				ret.Parameters.Add (values [i]);
			}
			
			ret.WhereContent = this.TableName + "." + this.Name + " NOT IN (" + pValue + ") ";
			return ret;
		}
		/// <summary>
		///    in,例如 select * from person where classid    in (23,2332,232)
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public WhereExpression In (params long[] values)
		{
			WhereExpression ret = new WhereExpression ();
			string pValue = "";
			for (int i=0; i<values.Length; i++) {
				if (i == values.Length - 1)
					pValue += "@";
				else
					pValue += "@,";
				ret.Parameters.Add (values [i]);
			}
			
			ret.WhereContent = this.TableName + "." + this.Name + " IN (" + pValue + ") ";
			return ret;
		}
		/// <summary>
		///  not in,例如 select * from person where classid  not in (23,2332,232)
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public WhereExpression NotIn (params long[] values)
		{
			WhereExpression ret = new WhereExpression ();
			string pValue = "";
			for (int i=0; i<values.Length; i++) {
				if (i == values.Length - 1)
					pValue += "@";
				else
					pValue += "@,";
				ret.Parameters.Add (values [i]);
			}
			
			ret.WhereContent = this.TableName + "." + this.Name + " NOT IN (" + pValue + ") ";
			return ret;
		}
		/// <summary>
		///    in,例如 select * from person where classid    in (23,2332,232)
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public WhereExpression In (params ulong[] values)
		{
			WhereExpression ret = new WhereExpression ();
			string pValue = "";
			for (int i=0; i<values.Length; i++) {
				if (i == values.Length - 1)
					pValue += "@";
				else
					pValue += "@,";
				ret.Parameters.Add (values [i]);
			}
			ret.WhereContent = this.TableName + "." + this.Name + " IN (" + pValue + ") ";
			return ret;
		}
		/// <summary>
		///  not in,例如 select * from person where classid  not in (23,2332,232)
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public WhereExpression NotIn (params ulong[] values)
		{
			WhereExpression ret = new WhereExpression ();
			string pValue = "";
			for (int i=0; i<values.Length; i++) {
				if (i == values.Length - 1)
					pValue += "@";
				else
					pValue += "@,";
				ret.Parameters.Add (values [i]);
			}
			ret.WhereContent = this.TableName + "." + this.Name + " NOT IN (" + pValue + ") ";
			return ret;
		}
		/// <summary>
		///  between a and b
		/// </summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		/// <returns></returns>
		public WhereExpression Between<T> (T v1, T v2)
		{

			WhereExpression ret = new WhereExpression ();
			string pValue = "@";
			
			ret.WhereContent = this.TableName + "." + this.Name + " between " + pValue + " and " + pValue;
			
			ret.Parameters.Add (v1);
			ret.Parameters.Add (v2);
			return ret;
		}
		/// <summary>
		/// 大于某数值
		/// </summary>
		/// <returns>The than.</returns>
		/// <param name="value">Value.</param>
		public WhereExpression BiggerThan (object value)
		{

			WhereExpression ret = new WhereExpression ();
			string pValue = "@";
			ret.Parameters.Add (value);
			if (this.FieldType!= FieldType.FunctionField) {
				ret.WhereContent = (" " + this.TableName + "." + this.Name + ">" + pValue + " ");
			}
			else  {
				ret.WhereContent = (" " +  this.Name + ">" + pValue + " ");
			}
			return ret;
		}
		/// <summary>
		/// 大于某表达式
		/// </summary>
		/// <param name="mql"></param>
		/// <returns></returns>
		public WhereExpression BiggerThan (MQLBase mql)
		{
			WhereExpression ret = new WhereExpression ();
			ret.WhereContent = this.TableName + "." + this.Name + ">(" + mql.ToSQLExpression () + ") ";
			ret.Parameters.Add (mql.Parameters);
			return ret;
		}
		/// <summary>
		/// 大于某字段
		/// </summary>
		/// <param name="field"></param>
		/// <returns></returns>
		public WhereExpression BiggerThan (FieldBase field)
		{
			WhereExpression ret = new WhereExpression ();
			ret.WhereContent = this.TableName + "." + this.Name + ">"+field.TableName + "."+field.Name + " ";
			return ret;
		}
		/// <summary>
		/// 大于等于某表达式
		/// </summary>
		/// <param name="mql"></param>
		/// <returns></returns>
		public WhereExpression BiggerThanOrEqual (MQLBase mql)
		{
			WhereExpression ret = new WhereExpression ();
			ret.WhereContent = this.TableName + "." + this.Name + ">=(" + mql.ToSQLExpression () + ") ";
			ret.Parameters.Add (mql.Parameters);
			return ret;
		}
		/// <summary>
		/// 大于等于某字段
		/// </summary>
		/// <param name="field"></param>
		/// <returns></returns>
		public WhereExpression BiggerThanOrEqual (FieldBase field)
		{
			WhereExpression ret = new WhereExpression ();
			ret.WhereContent = this.TableName + "." + this.Name + ">="+field.TableName + "."+field.Name + " ";
			
			return ret;
		}
		/// <summary>
		/// 大于等于某数值
		/// </summary>
		/// <returns>The than.</returns>
		/// <param name="value">Value.</param>
		public WhereExpression BiggerThanOrEqual (object value)
		{
			
			WhereExpression ret = new WhereExpression ();
			string pValue = "@";
			ret.Parameters.Add (value);
			if (this.FieldType!= FieldType.FunctionField) {
				ret.WhereContent = (" " + this.TableName + "." + this.Name + ">=" + pValue + " ");
			}
			else  {
				ret.WhereContent = (" " +  this.Name + ">=" + pValue + " ");
			}
			return ret;
		}
		/// <summary>
		/// 等于某表达式
		/// </summary>
		/// <param name="mql"></param>
		/// <returns></returns>
		public WhereExpression Equal (MQLBase mql)
		{
			WhereExpression ret = new WhereExpression ();
			ret.WhereContent = this.TableName + "." + this.Name + "=(" + mql.ToSQLExpression () + ") ";
			ret.Parameters.AddRange (mql.Parameters);
			return ret;
		}
		/// <summary>
		/// 不等于某表达式
		/// </summary>
		/// <param name="mql"></param>
		/// <returns></returns>
		public WhereExpression NotEqual (MQLBase mql)
		{
			WhereExpression ret = new WhereExpression ();
			ret.WhereContent = this.TableName + "." + this.Name + "<>(" + mql.ToSQLExpression () + ") ";
			ret.Parameters.Add (mql.Parameters);
			return ret;
		}
		/// <summary>
		/// 等于某字段
		/// </summary>
		/// <param name="field"></param>
		/// <returns></returns>
		public WhereExpression Equal (FieldBase field)
		{
			WhereExpression ret = new WhereExpression ();
			ret.WhereContent = this.TableName + "." + this.Name + "="+field.TableName + "."+field.Name + " ";
			
			return ret;
		}
		/// <summary>
		/// 不等于某字段
		/// </summary>
		/// <param name="field"></param>
		/// <returns></returns>
		public WhereExpression NotEqual (FieldBase field)
		{
			WhereExpression ret = new WhereExpression ();
			ret.WhereContent = this.TableName + "." + this.Name + "<>"+field.TableName + "."+field.Name + " ";
			
			return ret;
		}
		/// <summary>
		/// 相当于如sql语句中的is null
		/// </summary>
		/// <returns></returns>
		public WhereExpression IsNull(){
			WhereExpression ret = new WhereExpression ();
			string des=string.Empty;
			if(this.FieldType!= FieldType.FunctionField){
				des = this.TableName + "."+this.Name ;
			}
			else{
				des = this.TableName + " " ;
			}
			if (this.DbType == DbType.Sqlite) {
				ret.WhereContent =des+ " is null ";
			}else//警告!!!!!,还没有写其他类型的数据库
				ret.WhereContent = des + " is null ";
			return ret;
		}
		/// <summary>
		/// 等于(如果为DBNull.Value,相当于如mssql的is null,建议直接IsNull())
		/// </summary>
		/// <param name="value">Value.</param>
		public WhereExpression Equal (object value)
		{
			WhereExpression ret = new WhereExpression ();
			string pValue = "@";
			if(!(value is bool)){
				ret.Parameters.Add (value);
			}
			if (value is bool) {
				if (this.DbType == DbType.PostGresql) {
					pValue=value.ToString().ToLower();
				} else {
					pValue = "0";
					if (value.ToString () == "True") {
						pValue = "1";
					}
				}
				if(this.FieldType!= FieldType.FunctionField)
					ret.WhereContent = this.TableName + "." + this.Name + "=" + pValue + " ";
				else{
					ret.WhereContent =  this.Name + "=" + pValue + " ";
				}
			}
			else if (value == DBNull.Value) {
				//
				string des=string.Empty;
				if(this.FieldType!= FieldType.FunctionField)
					des = this.TableName + "." ;
				//
				if (this.DbType == DbType.Sqlite) {
					ret.WhereContent = " ifnull(" + des + this.Name + ",0)=0 ";
				}else//警告!!!!!,还没有写其他类型的数据库
					ret.WhereContent = des + " is null ";
			}else{
				if(this.FieldType!= FieldType.FunctionField)
					ret.WhereContent = this.TableName + "." + this.Name + "=" + pValue + " ";
				else{
					ret.WhereContent =  this.Name + "=" + pValue + " ";
				}
			}

			return ret;
		}
		/// <summary>
		/// 不等于
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public WhereExpression NotEqual (object value)
		{
			WhereExpression ret = new WhereExpression ();
			string pValue = "@";
			ret.Parameters.Add (value);
			
			if (value is bool) {
				if (this.DbType == DbType.PostGresql) {
					pValue=value.ToString().ToLower();
				} else {
					pValue = "0";
					if (value.ToString () == "True") {
						pValue = "1";
					}
				}
				if(this.FieldType!= FieldType.FunctionField)
					ret.WhereContent = this.TableName + "." + this.Name + "<>" + pValue + " ";
				else{
					ret.WhereContent =  this.Name + "<>" + pValue + " ";
				}
			} else if (value == DBNull.Value) {
				//
				string des=string.Empty;
				if(this.FieldType!= FieldType.FunctionField)
					des = this.TableName + "." ;
				//
				if (this.DbType == DbType.Sqlite) {
					ret.WhereContent = " ifnull(" + des + this.Name + ",0)<>0 ";
				}else//警告!!!!!,还没有写其他类型的数据库
					ret.WhereContent = des + " is null ";
			}else{
				if(this.FieldType!= FieldType.FunctionField)
					ret.WhereContent = this.TableName + "." + this.Name + "<>" + pValue + " ";
				else{
					ret.WhereContent =  this.Name + "<>" + pValue + " ";
				}
			}

			return ret;
		}
		/// <summary>
		/// 小于
		/// </summary>
		/// <param name="mql"></param>
		/// <returns></returns>
		public WhereExpression SmallerThan (MQLBase mql)
		{
			WhereExpression ret = new WhereExpression ();
			ret.WhereContent = this.TableName + "." + this.Name + "<(" + mql.ToSQLExpression () + ") ";
			ret.Parameters.Add (mql.Parameters);
			return ret;
		}
		/// <summary>
		/// 小于某字段或者字段的函数
		/// </summary>
		/// <param name="field"></param>
		/// <returns></returns>
		public WhereExpression SmallerThan (FieldBase field)
		{
			WhereExpression ret = new WhereExpression ();
			ret.WhereContent = this.TableName + "." + this.Name + "<"+field.TableName + "."+field.Name + " ";
			
			return ret;
		}
		/// <summary>
		/// 小于或等于某表达式
		/// </summary>
		/// <param name="mql"></param>
		/// <returns></returns>
		public WhereExpression SmallerThanOrEqual (MQLBase mql)
		{
			WhereExpression ret = new WhereExpression ();
			ret.WhereContent = this.TableName + "." + this.Name + "<=(" + mql.ToSQLExpression () + ") ";
			ret.Parameters.Add (mql.Parameters);
			return ret;
		}
		/// <summary>
		/// 小于等于某字段或者字段的函数
		/// </summary>
		/// <param name="field"></param>
		/// <returns></returns>
		public WhereExpression SmallerThanOrEqual (FieldBase field)
		{
			WhereExpression ret = new WhereExpression ();
			ret.WhereContent = this.TableName + "." + this.Name + "<="+field.TableName + "."+field.Name + " ";
			
			return ret;
		}
		/// <summary>
		/// 小于某数值
		/// </summary>
		/// <returns>The than.</returns>
		/// <param name="value">Value.</param>
		public WhereExpression SmallerThan (object value)
		{
			
			WhereExpression ret = new WhereExpression ();
			string pValue = "@";
			ret.Parameters.Add (value);
			if (this.FieldType!= FieldType.FunctionField) {
				ret.WhereContent = (" " + this.TableName + "." + this.Name + "<" + pValue + " ");
			}
			else  {
				ret.WhereContent = (" " +  this.Name + "<" + pValue + " ");
			}
			return ret;
		}

		/// <summary>
		/// 小于等于某数值
		/// </summary>
		/// <returns>The than.</returns>
		/// <param name="value">Value.</param>
		public WhereExpression SmallerThanOrEqual (object value)
		{
			
			WhereExpression ret = new WhereExpression ();
			string pValue = "@";
			ret.Parameters.Add (value);
			if (this.FieldType!= FieldType.FunctionField) {
				ret.WhereContent = (" " + this.TableName + "." + this.Name + "<=" + pValue + " ");
			}
			else  {
				ret.WhereContent = (" " +  this.Name + "<=" + pValue + " ");
			}
			return ret;
		}

		private string _name;
		/// <summary>
		/// 字段名
		/// </summary>
		/// <value>The name.</value>
		public string Name {
			get {
				return _name;
			}
			set {
				_name = value;
			}
		}
		/// <summary>
		/// 用于查看字段名,无[] ''等
		/// </summary>
		public string Name_{
			get{
				var value=_name.Trim('\'','`','[',']');
				return value;
			}
		}
		private string _TableName;
		/// <summary>
		/// 所在表
		/// </summary>
		/// <value>The name of the table.</value>
		public string TableName {
			get {
				return _TableName;
			}
			set {
				_TableName = value;
			}
		}

		private DbType _dbType;
		/// <summary>
		/// 所在数据库类型
		/// </summary>
		/// <value>The type of the db.</value>
		public DbType DbType {
			get {
				return _dbType;
			}
			set {
				_dbType = value;
			}
		}

		private FieldType _fieldType;
		/// <summary>
		/// 字段类型
		/// </summary>
		/// <value>The type of the field.</value>
		public FieldType FieldType {
			get {
				return _fieldType;
			}
			set {
				_fieldType = value;
			}
		}
	}
}


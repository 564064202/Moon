/*
 * 由SharpDevelop创建。
 * 用户： qinshichuan
 * 日期: 2012-8-4
 * 时间: 17:17
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Moon.Orm
{
	/// <summary>
	/// 第三级的连接查询对象
	/// </summary>
	public class HighJoinMQL:MQLBase
	{
		/// <summary>
		/// 连接方式
		/// </summary>
		public string _Location;
		/// <summary>
		/// _mql1
		/// </summary>
		public MQLBase _mql1;
		/// <summary>
		/// _mql2
		/// </summary>
		public MQLBase _mql2;
		WhereExpression _OnExpression=new WhereExpression();
		/// <summary>
		/// 参数列表
		/// </summary>
		public override List<object> Parameters {
			get {
				var list=new List<object>();
				list.AddRange( _mql1.Parameters);
				list.AddRange(_mql2.Parameters);
				list.AddRange(_OnExpression.Parameters);
				list.AddRange(_WhereExpression.Parameters);
				return list;
			}
		}
		/// <summary>
		/// 选择的字段的容器
		/// </summary>
		public override List<FieldBase> SelectList {
			get {
				List<FieldBase> ret=new List<FieldBase>();
				ret.AddRange(_mql1.SelectList);
				ret.AddRange(_mql2.SelectList);
				return ret;
			}
		}
		/// <summary>
		/// 转换为sql表达式
		/// </summary>
		/// <returns></returns>
		public override string ToSQLExpression()
		{
			string sql=_mql1.ToSQLExpression();
			if (sql.Contains("SELECT")) {
				StringBuilder ret=new StringBuilder();
				for (int i = 0; i < _mql2.SelectList.Count; i++) {
					FieldBase field =_mql2.SelectList[i];
					if (field.FieldType == FieldType.FunctionField) {
						if (i==_mql2.SelectList.Count-1) {
							ret.Append ( field.Name + " ");
						}else{
							ret.Append (field.Name + ",");
						}
					} else {
						if (i==_mql2.SelectList.Count-1) {
							ret.Append (field.TableName + "." + field.Name + " ");
						}else{
							ret.Append (field.TableName + "." + field.Name + ",");
						}
					}
				}
				sql=sql.Replace("FROM",", "+ret.ToString()+" FROM");
			}
			sql+=" "+_Location+" JOIN "+_mql2.TableName;
			
			if (_OnExpression!=null&&string.IsNullOrEmpty(_OnExpression.WhereContent)==false) {
				sql+=" ON "+_OnExpression.WhereContent;
			}
			if (string.IsNullOrEmpty(_WhereExpression.WhereContent)==false) {
				sql+=" WHERE "+_WhereExpression.WhereContent;
			}
			if (_OrderByDictionary.Count>0) {
				sql+=("  ORDER BY ");
			}
			int orderCount=0;
			foreach (var kvp in _OrderByDictionary) {
				orderCount++;
				string orderExpression=kvp.Key.TableName + "." + kvp.Key.Name + " "+kvp.Value;
				if (orderCount==_OrderByDictionary.Count) {
					sql+=(orderExpression+" ");
				}else{
					sql+=(orderExpression+",");
				}
			}
			DbType currentDbType=this.SelectList[0].DbType;
			if (string.IsNullOrEmpty(this.TopCount)==false) {
				if (currentDbType== DbType.SqlServer) {
					sql="SELECT TOP "+TopCount+" * FROM ("+sql+") TopTemp1";
				}
				else if (currentDbType== DbType.MySql) {
					sql="SELECT  * FROM ("+sql+") TopTemp1  LIMIT 0, "+this.TopCount+" ";
					 
				}
				else if (currentDbType== DbType.Sqlite) {
					sql="SELECT  * FROM ("+sql+") TopTemp1  LIMIT 0, "+this.TopCount+" ";
				}
				else if (currentDbType== DbType.PostGresql) {
					sql="SELECT  * FROM ("+sql+") TopTemp1  LIMIT "+this.TopCount+" ";
				}
				else if (currentDbType== DbType.Oracle) {
					sql="SELECT  * FROM ("+sql+") TopTemp1  ROWNUM<="+this.TopCount+" ";
				}
			}
			return sql;
		}
		/// <summary>
		/// Union
		/// </summary>
		/// <param name="mql"></param>
		/// <returns></returns>
		public override UnionMQL Union(MQLBase mql){
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
		public override UnionMQL UnionAll(MQLBase mql){
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
		/// 转换以@pn为参数替换符的sql
		/// </summary>
		/// <returns>以@pn为参数替换符的sql</returns>
		public override string ToParametersSQL()
		{
			string sql=ToSQLExpression();
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
		/// where条件
		/// </summary>
		/// <param name="expression">条件表达式</param>
		/// <returns>第三级的连接对象</returns>
		public new HighJoinMQL Where(WhereExpression expression){
			this._WhereExpression=expression;
			return this;
		}
		/// <summary>
		/// on条件
		/// </summary>
		/// <param name="expression">on的表达式</param>
		/// <returns>第三级的连接对象</returns>
		public  HighJoinMQL ON(WhereExpression expression){

			this._OnExpression=expression;
			return this;
		}
		
		
	}
}

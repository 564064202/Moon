/*
 * 由SharpDevelop创建。
 * 用户： 秦仕川
 * 日期: 2013-8-22
 * 时间: 16:32
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Moon.Orm
{
	/// <summary>
	/// 连接对象
	/// </summary>
	public class JoinMQL:MQLBase{
		
		/// <summary>
		/// _mql1
		/// </summary>
		public	MQLBase _mql1;
		/// <summary>
		/// _mql2
		/// </summary>
		public	MQLBase _mql2;
		/// <summary>
		/// 连接方式
		/// </summary>
		public string _Location;
		WhereExpression _OnExpression=new WhereExpression();
		List<MQLBase> _leftJoinMQLBaseList=new List<MQLBase>();
		/// <summary>
		/// on语句,如:on t1.a=t2.a 
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		public JoinMQL ON(WhereExpression expression){
			this._OnExpression=expression;
			return this;
		}
		/// <summary>
		/// 参数容器
		/// </summary>
		public override List<object> Parameters {
			get {
				var list=new List<object>();
				list.AddRange(_OnExpression.Parameters);
				list.AddRange( _WhereExpression.Parameters);
				list.AddRange(_HavingExpression.Parameters);
				return list;
			}
		}
		/// <summary>
		/// 连接语句的条件
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		public new JoinMQL Where(WhereExpression expression){
			this._WhereExpression=expression;
			return this;
		}
		/// <summary>
		/// 左连接查询
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <returns>第三级的连接对象</returns>
		public new  HighJoinMQL LeftJoin(MQLBase mql){
			HighJoinMQL hjm=new HighJoinMQL();
			hjm._Location="LEFT";
			hjm._mql1=this;
			hjm._mql2=mql;
			hjm.PName=this.PName;
			return  hjm;
		}
		/// <summary>
		/// 右连接查询
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <returns>第三级的连接对象</returns>
		public  new  HighJoinMQL  RightJoin(MQLBase mql){
			HighJoinMQL hjm=new HighJoinMQL();
			hjm._Location="RIGHT";
			hjm._mql1=this;
			hjm._mql2=mql;
			hjm.PName=this.PName;
			return  hjm;
		}
		/// <summary>
		/// full连接
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <returns>第三级的连接对象</returns>
		public  new  HighJoinMQL  FullJoin(MQLBase mql){
			HighJoinMQL hjm=new HighJoinMQL();
			hjm._Location="FULL";
			hjm._mql1=this;
			hjm._mql2=mql;
			hjm.PName=this.PName;
			return  hjm;
		}
		/// <summary>
		/// Inner Join
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <returns>第三级的连接对象</returns>
		public  new  HighJoinMQL  InnerJoin(MQLBase mql){
			HighJoinMQL hjm=new HighJoinMQL();
			hjm._Location="INNER";
			hjm._mql1=this;
			hjm._mql2=mql;
			hjm.PName=this.PName;
			return  hjm;
		}

		/// <summary>
		/// 转换为调试信息
		/// </summary>
		/// <returns>sql调试信息</returns>
		public override string ToDebugSQL()
		{
			StringBuilder ret = new StringBuilder ();
			ret.Append ("SELECT ");
			DbType currentDbType=this.SelectList[0].DbType;
			if (string.IsNullOrEmpty(this.TopCount)==false) {
				if (this.SelectList.Count>0&&currentDbType== DbType.SqlServer) {
					ret.Append ("TOP "+this.TopCount+" ");
				}
				
			}
			if (this._SelectList.Count == 0) {
				ret.Append ("* ");
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
			ret.Append ("FROM " + this._mql1.TableName + " "+_Location+" JOIN "+_mql2.TableName);
			if (_OnExpression!=null&&string.IsNullOrEmpty(_OnExpression.WhereContent)==false) {
				ret.Append(" ON ( "+_OnExpression.WhereContent+" ) ");
			}
			
			if (string.IsNullOrEmpty (this._WhereExpression.WhereContent) == false) {
				ret.Append ("WHERE " + this._WhereExpression.WhereContent);
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
						ret.Append( field.TableName + "." + field.Name + ",");
					} else {
						ret.Append( field.TableName + "." + field.Name);
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
				string orderExpression=kvp.Key.TableName + "." + kvp.Key.Name + " "+kvp.Value;
				if (orderCount==_OrderByDictionary.Count) {
					ret.Append(orderExpression+" ");
				}else{
					ret.Append(orderExpression+",");
				}
			}
			
			if (string.IsNullOrEmpty(this.TopCount)==false) {
				if (currentDbType== DbType.SqlServer) {
					
				}
				else if (this.SelectList.Count>1&&currentDbType== DbType.MySql) {
					ret.Append ("LIMIT 0, "+this.TopCount+" ");
				}
				else if (this.SelectList.Count>1&&currentDbType== DbType.Sqlite) {
					ret.Append ("LIMIT 0, "+this.TopCount+" ");
				}
				else if (this.SelectList.Count>1&&currentDbType== DbType.PostGresql) {
					ret.Append ("LIMIT  "+this.TopCount+" ");
				}
				else if (this.SelectList.Count>1&&currentDbType== DbType.Oracle) {
					ret.Append ("ROWNUM <= "+this.TopCount+" ");
				}
			}
			
			ret.AppendLine();
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
			
			for (int i = 1; i <= Parameters.Count; i++) {
				object value=Parameters[i-1];
				string pName=this.PName+"p"+i;
				retSB.AppendLine(pName+"="+value);
			}
			
			return retSB.ToString();
			
		}
		/// <summary>
		/// 转换为sql表达式
		/// </summary>
		/// <returns>sql表达式</returns>
		public override string ToSQLExpression()
		{
			StringBuilder ret = new StringBuilder ();
			ret.Append ("SELECT ");
			DbType currentDbType=this.SelectList[0].DbType;
			if (string.IsNullOrEmpty(this.TopCount)==false) {
				if (this.SelectList.Count>0&&currentDbType== DbType.SqlServer) {
					ret.Append ("TOP "+this.TopCount+" ");
				}
				
			}
			if (this._SelectList.Count == 0) {
				ret.Append ("* ");
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
			ret.Append ("FROM " + this._mql1.TableName + " "+_Location+" JOIN "+_mql2.TableName);
			if (_OnExpression!=null&&string.IsNullOrEmpty(_OnExpression.WhereContent)==false) {
				ret.Append(" ON ( "+_OnExpression.WhereContent+" ) ");
			}
			if (string.IsNullOrEmpty (this._WhereExpression.WhereContent) == false) {
				ret.Append ("WHERE " + this._WhereExpression.WhereContent);
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
						ret.Append( field.TableName + "." + field.Name + ",");
					} else {
						ret.Append( field.TableName + "." + field.Name);
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
				string orderExpression=kvp.Key.TableName + "." + kvp.Key.Name + " "+kvp.Value;
				if (orderCount==_OrderByDictionary.Count) {
					ret.Append(orderExpression+" ");
				}else{
					ret.Append(orderExpression+",");
				}
			}
			if (string.IsNullOrEmpty(this.TopCount)==false) {
				if (currentDbType== DbType.SqlServer) {
					return ret.ToString();
				}
				else if (this.SelectList.Count>1&&currentDbType== DbType.MySql) {
					ret.Append ("LIMIT 0, "+this.TopCount+" ");
				}
				else if (this.SelectList.Count>1&&currentDbType== DbType.Sqlite) {
					ret.Append ("LIMIT 0, "+this.TopCount+" ");
				}
				else if (this.SelectList.Count>1&&currentDbType== DbType.PostGresql) {
					ret.Append ("LIMIT  "+this.TopCount+" ");
				}
				else if (this.SelectList.Count>1&&currentDbType== DbType.Oracle) {
					ret.Append ("ROWNUM <= "+this.TopCount+" ");
				}
			}
			return ret.ToString();
		}
		/// <summary>
		/// 转换为以@pn为替换符的sql表达式,供参数化查询
		/// </summary>
		/// <returns>sql</returns>
		public override string ToParametersSQL()
		{
			StringBuilder ret = new StringBuilder ();
			ret.Append ("SELECT ");
			DbType currentDbType=this.SelectList[0].DbType;
			if (string.IsNullOrEmpty(this.TopCount)==false) {
				if (this.SelectList.Count>0&&currentDbType== DbType.SqlServer) {
					ret.Append ("TOP "+this.TopCount+" ");
				}
			}
			if (this._SelectList.Count == 0) {
				ret.Append ("* ");
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
			ret.Append ("FROM " + this._mql1.TableName + " "+_Location+" JOIN "+_mql2.TableName);
			if (_OnExpression!=null&&string.IsNullOrEmpty(_OnExpression.WhereContent)==false) {
				ret.Append(" ON ( "+_OnExpression.WhereContent+" ) ");
			}
			if (string.IsNullOrEmpty (this._WhereExpression.WhereContent) == false) {
				ret.Append ("WHERE " + this._WhereExpression.WhereContent);
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
						ret.Append( field.TableName + "." + field.Name + ",");
					} else {
						ret.Append( field.TableName + "." + field.Name);
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
				string orderExpression=kvp.Key.TableName + "." + kvp.Key.Name + " "+kvp.Value;
				if (orderCount==_OrderByDictionary.Count) {
					ret.Append(orderExpression+" ");
				}else{
					ret.Append(orderExpression+",");
				}
			}
			if (string.IsNullOrEmpty(this.TopCount)==false) {
				if (currentDbType== DbType.SqlServer) {
					 
				}
				else if (this.SelectList.Count>1&&currentDbType== DbType.MySql) {
					ret.Append ("LIMIT 0, "+this.TopCount+" ");
				}
				else if (this.SelectList.Count>1&&currentDbType== DbType.Sqlite) {
					ret.Append ("LIMIT 0, "+this.TopCount+" ");
				}
				else if (this.SelectList.Count>1&&currentDbType== DbType.PostGresql) {
					ret.Append ("LIMIT  "+this.TopCount+" ");
				}
				else if (this.SelectList.Count>1&&currentDbType== DbType.Oracle) {
					ret.Append ("ROWNUM <= "+this.TopCount+" ");
				}
			}
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
	}
	
	
}

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
	/// uion连接对象
	/// </summary>
	public class UnionMQL:MQLBase{
		/// <summary>
		/// _mql1
		/// </summary>
		public	MQLBase _mql1;
		/// <summary>
		/// _mql2
		/// </summary>
		public	MQLBase _mql2;
		/// <summary>
		/// 是否是Union ALL
		/// </summary>
		public	bool IsAll{
			get;
			set;
		}
		/// <summary>
		/// 参数列表
		/// </summary>
		public override List<object> Parameters {
			get {
				var list=new List<object>();
				list.AddRange( _mql1.Parameters);
				list.AddRange(_mql2.Parameters);
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
		/// 转换为调试信息sql
		/// </summary>
		/// <returns>调试信息</returns>
		public override string ToDebugSQL()
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
		/// 转换以@pn为参数替换符的sql
		/// </summary>
		/// <returns>以@pn为参数替换符的sql</returns>
		public override string ToParametersSQL()
		{
			var sql=ToSQLExpression();
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
		/// 转换为sql
		/// </summary>
		/// <returns>转换为sql</returns>
		public override string ToSQLExpression()
		{
			string link=string.Empty;
			if (IsAll) {
				link="ALL";
			}
			string sql1=_mql1.ToSQLExpression();
			string sql2=_mql2.ToSQLExpression();
			string sql=sql1+" UNION "+link+" "+sql2;
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
	}
}

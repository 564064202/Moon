using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Moon.Orm
{
	/// <summary>
	/// 条件表达式,如UserSet.Score.Eqaul(60),或者UserSet.Score.Eqaul(60).And(Age.BiggerThan(9))
	/// </summary>
	[Serializable]
	public class WhereExpression
	{
		/// <summary>
		/// 构造
		/// </summary>
		public WhereExpression ()
		{

		}
		private string _WhereContent;
		/// <summary>
		/// 内容
		/// </summary>
		public string WhereContent {
			get {
				return _WhereContent;
			}
			set {
				_WhereContent = value;
			}
		}
		/// <summary>
		/// and,如: and id=3
		/// </summary>
		/// <param name="expression">形成条件的表达式,如UserSet.Score.Eqaul(60).And(Age.BiggerThan(9))</param>
		/// <returns>新的条件表达式</returns>
		public WhereExpression And (WhereExpression expression){
			WhereExpression ret = new WhereExpression ();
			ret.Parameters = this.Parameters;
			ret.Parameters.AddRange (expression.Parameters);
			ret.WhereContent = this.WhereContent + " AND " + expression.WhereContent;
			return ret;
		}
		/// <summary>
		/// or,如: or a=3
		/// </summary>
		/// <param name="expression">形成条件的表达式,如UserSet.Score.Eqaul(60).And(Age.BiggerThan(9))</param>
		/// <returns>新的条件表达式</returns>
		public WhereExpression Or (WhereExpression expression){
			WhereExpression ret = new WhereExpression ();
			ret.Parameters = this.Parameters;
			ret.Parameters.AddRange (expression.Parameters);
			ret.WhereContent = this.WhereContent + " OR " + expression.WhereContent;
			return ret;
		}
		/// <summary>
		/// or且带有括号,如: or (id=select id from t1 where...)
		/// </summary>
		/// <param name="expression">形成条件的表达式,如UserSet.Score.Eqaul(60).And(Age.BiggerThan(9))</param>
		/// <returns>新的条件表达式</returns>
		public WhereExpression OrWithBrackets(WhereExpression expression){
			WhereExpression ret = new WhereExpression ();
			ret.Parameters = this.Parameters;
			ret.Parameters.AddRange (expression.Parameters);
			ret.WhereContent = this.WhereContent + " OR (" + expression.WhereContent+")";
			return ret;
		}
		/// <summary>
		/// and且带有括号,如: and(id=select id from t1 where...)
		/// </summary>
		/// <param name="expression">形成条件的表达式,如UserSet.Score.Eqaul(60).And(Age.BiggerThan(9))</param>
		/// <returns>新的条件表达式</returns>
		public WhereExpression AndWithBrackets (WhereExpression expression){
			WhereExpression ret = new WhereExpression ();
			ret.Parameters = this.Parameters;
			ret.Parameters.AddRange (expression.Parameters);
			ret.WhereContent = this.WhereContent + " AND (" + expression.WhereContent+")";
			return ret;
		}
		
		List<object> _parameters = new List<object> ();
		/// <summary>
		/// 参数容器
		/// </summary>
		/// <value>The parameters.</value>
		public List<object> Parameters {
			get {
				return _parameters;
			}
			set {
				_parameters = value;
			}
		}
	}
}


/*
 * 由SharpDevelop创建。
 * 用户： 秦仕川
 * 日期: 2013-8-31
 * 时间: 7:39
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace Moon.Orm
{
	/// <summary>
	/// 本质就是object的分装
	/// 加了类型转换和空判定等
	/// </summary>
	public class MObject
	{
		private object _Value;
		/// <summary>
		/// value
		/// </summary>
		public object Value {
			get { return _Value; }
			set { _Value = value; }
		}
		/// <summary>
		/// 值是否为空,null和DBNull都表示为空
		/// </summary>
		/// <returns></returns>
		public bool IsNull(){
			if (this.Value==null||this.Value.GetType()==typeof(DBNull)) {
				return true;
			}
			return false;
		}
		/// <summary>
		/// 将值转为指定类型T的类型
		/// </summary>
		/// <returns></returns>
		public T To<T>(){
			object obj=this.Value;
			try {
				T ret=(T)obj;
				return ret;
			} catch (Exception) {
				if (obj.GetType().Name.Contains("DBNull")) {
					throw new InvalidCastException("因为此结果为空(DBNull),所以转换失败!");
				}
				else{
					if (obj==null) {
						throw new InvalidCastException("因为此结果为空(null,你的查询有误,逻辑错误),所以转换失败!");
					}
					else{
						string fieldsType=obj.GetType().FullName;
						throw new InvalidCastException("该的字段类型应为:"+fieldsType);
					}
				}
				
			}
		}
		/// <summary>
		/// ToString override,如果值为null,则返回null,
		/// 其他类型(包括DBNull),返回Value.ToString()
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			if (this.Value!=null) {
				return this.Value.ToString();
			}else{
				return null;
			}
		}
	}
}

/*
 * 由SharpDevelop创建。
 * 用户： qscq
 * 日期: 2014/4/12
 * 时间: 15:40
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Data;

namespace Moon.Orm.Util
{
	/// <summary>
	/// DbUtil.辅助Db,不用自己去创建Db对象(使用默认的连接)
	/// 注意我们不推荐这么用,因为该类就是为懒人准备的.
	/// Db.CreateDefaultDb().方法(),岂不一样.只是需要关闭.
	/// </summary>
	public static partial class DbUtil
	{
		/// <summary>
		/// 添加实体到数据库中
		/// </summary>
		/// <param name="entity">实体</param>
		/// <returns>主键</returns>
		public static object Add(EntityBase entity){
			using (Db db=Db.CreateDefaultDb()) {
				return db.Add(entity);
			}
		}
		/// <summary>
		/// 修改实体
		/// </summary>
		/// <param name="entity">实体</param>
		/// <returns>被影响的行数</returns>
		public static int Update(EntityBase entity){
			using (Db db=Db.CreateDefaultDb()) {
				return db.Update(entity);
			}
		}
		/// <summary>
		/// 删除指定表达式的实体或实体集
		/// </summary>
		/// <param name="expression">条件表达式</param>
		/// <typeparam name="T">形如TableSet</typeparam>
		/// <returns>被影响的行数</returns>
		public static int Remove<T>(WhereExpression expression) where T:MQLBase{
			using (Db db=Db.CreateDefaultDb()) {
				return db.Remove<T>(expression);
			}
		}
		/// <summary>
		/// 获取指定实体集
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <typeparam name="T">T:EntityBase</typeparam>
		/// <returns>List&lt;T&gt; 实体集,T:EntityBase</returns>
		public static List<T> GetEntities<T>(MQLBase mql) where T: EntityBase,new(){
			using (Db db=Db.CreateDefaultDb()) {
				return db.GetEntities<T>(mql);
			}
		}
		 
		/// <summary>
		/// 获取实体
		/// </summary>
		/// <param name="mql">mql语句</param>
		///<typeparam name="T">注意泛型T:EntityBase</typeparam>
		/// <returns>T的实体,T:EntityBase.如果为null,表示数据不存在</returns>
		public static  T GetEntity<T>(MQLBase mql) where T: EntityBase,new(){
			var list=GetEntities<T>(mql);
			if (list.Count==0) {
				return null;
			}else{
				return list[0];
			}
		}
		/// <summary>
		/// 获取结果的第一行第一列数据到<code>MObject</code>
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <returns>MObject形式的结果,详情见<code>MObject</code></returns>
		public static  MObject GetScalarToMObject(MQLBase mql){
			using (Db db=Db.CreateDefaultDb()) {
				return db.GetScalarToMObject(mql);
			}
		}
		/// <summary>
		/// 获取自定义实体集
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <typeparam name="T">T:new()</typeparam>
		/// <returns>List&lt;T&gt; 实体集,T 是一个类就可以( T: new())</returns>
		public static List<T> GetOwnList<T>(MQLBase mql) where T:class, new(){
			using (Db db=Db.CreateDefaultDb()) {
				return db.GetOwnList<T>(mql);
			}
		}
		/// <summary>
		/// 执行mql,将结果返回到 List&lt;Dictionary&lt;string,MObject&gt;&gt;
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <returns>List&lt;Dictionary&lt;string,MObject&gt;&gt;</returns>
		public static DictionaryList GetDictionaryList(MQLBase mql){
			using (Db db=Db.CreateDefaultDb()) {
				return db.GetDictionaryList(mql);
			}
		}
		
		/// <summary>
		/// 通过mql获取json形式的结果
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <returns>json形式的查询结果</returns>
		public static string GetJSON(MQLBase mql){
			using (Db db=Db.CreateDefaultDb()) {
				return db.GetJson(mql);
			}
		}
		/// <summary>
		/// 通过mql获取dataset
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <returns>目标数据的dataset</returns>
		public static DataSet GetDataSet(MQLBase mql){
			using (Db db=Db.CreateDefaultDb()) {
				return db.GetDataSet(mql);
			}
		}
		
	}
}

/*
 * 由SharpDevelop创建。
 * 用户： 秦仕川
 * 日期: 2013-8-23
 * 时间: 12:36
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Web;
using Moon.Orm.Util;

namespace Moon.Orm
{
	/// <summary>
	/// Db操作的基类,重点了解此类的使用方法
	/// </summary>
	public class Db:IDisposable
	{
		
		/// <summary>
		/// 默认构造
		/// </summary>
		protected Db()
		{
		}
		static Assembly _defaultEngineAssembly;
		static string _DefaultEngineDbConnectionString;
		static string _DefaultEngineFullTypeName;
		static string _DefaultEngineDLLName;
		static readonly object _CreateDefaultDbLock=new object();
		/// <summary>
		/// 缓存时间
		/// </summary>
		protected int _CacheTime=0;
		/// <summary>
		/// 开启缓存
		/// </summary>
		/// <param name="seconds">缓存时间,单位秒</param>
		public void StartCache(int seconds){
			_CacheTime=seconds;
		}
        /// <summary>
        /// 创建通用的Db引擎,所有的关系型数据库(包括所谓的国产数据库,如达梦...)都可以用此方法
        /// 若不知其配置说明,可查阅技术文档3.1.3
        /// </summary>
        /// <param name="name">对应ConnectionStrings中的名字</param>
        /// <returns>对应的Db对象</returns>
        public static Db CreateSharedDbByConfigName(string name)
		{
			
			var config = ConfigurationManager.ConnectionStrings[name];
			string dbConnectionString = config.ConnectionString;
			var providerName = config.ProviderName;
			SharedDb db = new SharedDb(dbConnectionString,providerName);
			return db;
		}
		/// <summary>
		/// 根据connectionStrings下的配置name名获取指定Db对象
		/// </summary>
		/// <param name="name">对应的名字</param>
		/// <returns>对应的Db对象</returns>
		public static Db CreateDbByConfigName(string name){
			var config=ConfigurationManager.ConnectionStrings[name];
			string dbConnectionString=config.ConnectionString;
			bool existConfig=false;
			lock(Db_MAP_LOCK){
				existConfig=Db_MAP.ContainsKey(name);
			}
			if (existConfig) {
				Type typeDb=null;
				lock(Db_MAP_LOCK){
					typeDb=Db_MAP[name];
				}
				object[] constructParms = new object[] { dbConnectionString };
				var ret= Activator.CreateInstance(typeDb, constructParms) as Db;
				return ret;
			}
			else{
				var providerName=config.ProviderName;
				string[] arra=providerName.Split(',');
				string dllName=arra[0]+".dll";
				string fullTypeName=arra[1];
				if (dllName=="Moon.Orm.dll") {
					if (fullTypeName=="Moon.Orm.SqlServer") {
						lock(Db_MAP_LOCK){
							Db_MAP[name]=typeof(SqlServer);
						}
						return new SqlServer(dbConnectionString);
					}
					else if (fullTypeName=="Moon.Orm.MySql") {
						lock(Db_MAP_LOCK){
							Db_MAP[name]=typeof(MySql);
						}
						return new MySql(dbConnectionString);
					}
					else if (fullTypeName=="Moon.Orm.Oracle") {
						lock(Db_MAP_LOCK){
							Db_MAP[name]=typeof(Oracle);
						}
						return new Oracle(dbConnectionString);
					}
					else if (fullTypeName=="Moon.Orm.Sqlite") {
						lock(Db_MAP_LOCK){
							Db_MAP[name]=typeof(Sqlite);
						}
						return new Sqlite(dbConnectionString);
					}
					Type tp =Type.GetType(fullTypeName);
					if(tp==null){
						string msg="指定连接{0}所配置的数据库类型[{1}]不存在,您是不是书写错误??";
						msg=string.Format(msg,name,fullTypeName);
						LogUtil.Error(msg);
						throw new ConfigurationErrorsException(msg);
					}
					lock(Db_MAP_LOCK){
						Db_MAP[name]=tp;
					}
					object[] constructParms = new object[] { dbConnectionString };
					var ret= Activator.CreateInstance(tp, constructParms) as Db;
					return ret;
				}else{
					var otherDllPath=GlobalData.DLL_EXE_DIRECTORY_PATH+dllName;
					var otherAssembly=Assembly.LoadFrom(otherDllPath);
					Type tp=otherAssembly.GetType(fullTypeName);
					lock(Db_MAP_LOCK){
						Db_MAP[name]=tp;
					}
					object[] constructParms = new object[] { dbConnectionString };
					var ret= Activator.CreateInstance(tp, constructParms) as Db;
					return ret;
				}
			}
			
		}
		static readonly Object Db_MAP_LOCK=new Object();
		static readonly Dictionary<string,Type> Db_MAP=new Dictionary<string, Type>();
		#region 创建默认的Db
		/// <summary>
		/// 创建由ConnectionStrings["DefaultConnection"]配置来的 db对象,
		/// 如果不用using,请手动调用Dispose()或者Close()释放资源.
		/// 如果发生异常说明您的连接字符串配置有误,请查看相关文档
		/// </summary>
		/// <returns>默认的Db</returns>
		public static Db CreateDefaultDb(){
			if(_DefaultEngineDbConnectionString==null){
				lock(_CreateDefaultDbLock){
					if (_DefaultEngineDbConnectionString==null) {
						var config=ConfigurationManager.ConnectionStrings["DefaultConnection"];
						var providerName=config.ProviderName;
						string[] arra=providerName.Split(',');
						_DefaultEngineDLLName=arra[0]+".dll";
						_DefaultEngineFullTypeName=arra[1];
						_DefaultEngineDbConnectionString=config.ConnectionString;
					}
				}
			}
			if (_DefaultEngineDLLName=="Moon.OrmCore.dll") {
				if (_DefaultEngineFullTypeName=="Moon.Orm.SqlServer") {
					return new SqlServer(_DefaultEngineDbConnectionString);
				}
				else if (_DefaultEngineFullTypeName=="Moon.Orm.MySql") {
					return new MySql(_DefaultEngineDbConnectionString);
				}
				else if (_DefaultEngineFullTypeName=="Moon.Orm.Oracle") {
					return new Oracle(_DefaultEngineDbConnectionString);
				}
				else if (_DefaultEngineFullTypeName=="Moon.Orm.Sqlite") {
					return new Sqlite(_DefaultEngineDbConnectionString);
				}
				Type tp =Type.GetType(_DefaultEngineFullTypeName);
				if(tp==null){
					string msg="默认连接DefaultConnection所配置的数据库类型[{0}]不存在,您是不是书写错误??";
					msg=string.Format(msg,_DefaultEngineFullTypeName);
					LogUtil.Error(msg);
					throw new ConfigurationErrorsException(msg);
				}
				object[] constructParms = new object[] { _DefaultEngineDbConnectionString };
				var ret= Activator.CreateInstance(tp, constructParms) as Db;
				return ret;
			}else{
				if (_defaultEngineAssembly==null) {
					_defaultEngineAssembly=Assembly.LoadFrom(_DefaultEngineDLLName);
				}
				Type tp=_defaultEngineAssembly.GetType(_DefaultEngineFullTypeName);
				object[] constructParms = new object[] { _DefaultEngineDbConnectionString };
				var ret= Activator.CreateInstance(tp, constructParms) as Db;
				return ret;
			}
		}
		#endregion
		
		/// <summary>
		/// 通过连接字符串构造
		/// 如果不用using,请手动调用Dispose()或者Close()释放资源
		/// </summary>
		/// <param name="linkString">linkString</param>
		public Db(string linkString)
		{
			this.LinkString=linkString;
		}
		/// <summary>
		/// 自定义的Ado工厂方法
		/// </summary>
		public DbAdoMethod AdoMethod{
			get;
			set;
		}
		/// <summary>
		/// 参数化查询的标记,如 @、:
		/// </summary>
		protected string PName{
			get;
			set;
		}
		/// <summary>
		/// 连接字符串
		/// </summary>
		public string LinkString{
			get;
			set;
		}
		/// <summary>
		/// DebugEnabled=true时,可以用CurrentSQL查看当前系统中运行的sql(非线程安全,不要用来干别的)
		/// </summary>
		public string CurrentSQL{
			get;
			set;
		}
		/// <summary>
		/// 是否启动调试,DebugEnabled=true,就可以根据db.CurrentSQL查看当前执行sql(非线程安全,不要用来干别的)
		/// </summary>
		public bool DebugEnabled{
			get;
			set;
		}
		/// <summary>
		/// db连接
		/// </summary>
		public DbConnection Connection{
			get;
			set;
		}
		/// <summary>
		/// 事务
		/// </summary>
		public DbTransaction Transaction{
			get;
			set;
		}
		private bool _transactionEnabled;
		/// <summary>
		/// 是否启动事务功能,如果开启,则 this.Transaction=Connection.BeginTransaction();
		/// </summary>
		public bool TransactionEnabled{
			get{
				return _transactionEnabled;
			}
			set{
				_transactionEnabled=value;
				if (value) {
					this.Transaction=Connection.BeginTransaction();
				}
			}
		}
		
		/// <summary>
		/// 获取删除语句(含有@parameter的sql语句)
		/// </summary>
		/// <param name="expression">WhereExpression</param>
		/// <typeparam name="T">实体查询类</typeparam>
		/// <returns>(含有@parameter的sql语句)</returns>
		protected StringBuilder GetRemoveParametersSQL<T>(WhereExpression expression) where T:MQLBase{
			string tableName=GetTableNameFromTableSet<T>();
			string sql="delete from  "+tableName+" where "+expression.WhereContent;
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
			return retSB;
		}
		/// <summary>
		/// 获取更新语句(含有@parameter的sql语句)
		/// </summary>
		/// <param name="entity">指定的实体对象</param>
		/// <returns>UpdateSQL</returns>
		protected StringBuilder GetUpdateSQL(EntityBase entity){
			Dictionary<string,object> all=entity.ChangedMap;
			string tableName=GetEntityTableName(entity);
			StringBuilder sb=new StringBuilder();
			//
			sb.Append("update "+tableName+" set ");
			int index=0;
			
			foreach (KeyValuePair<string,object> field in all) {
				index++;
				if (index==all.Count) {
					sb.Append(field.Key+"="+this.PName+"p"+(index));
				}else{
					sb.Append(field.Key+"="+this.PName+"p"+(index)+",");
				}
			}
			if (entity.WhereExpression==null) {
				throw new Exception("entity.WhereExpression==null");
			}
			else{
				string whereContent=entity.WhereExpression.WhereContent;
				if (string.IsNullOrEmpty(whereContent)) {
					throw new Exception("entity.WhereExpression has no value.");
				}
				//
				StringBuilder retSB = new StringBuilder ();
				
				for (int i=0; i<whereContent.Length; i++) {
					Char c=whereContent [i];
					if ('@' == c) {
						index++;
						retSB.Append (PName+"p" + index);
						
					} else {
						retSB.Append (c);
					}
				}
				//
				sb.Append(" where "+retSB.ToString());
			}
			return sb;
		}
		/// <summary>
		/// 获取EntityBase类型实体对象对应的表名
		/// </summary>
		/// <param name="entity">实体对象</param>
		/// <returns>表名</returns>
		protected string GetEntityTableName(EntityBase entity){
			var attributes=entity.GetType().GetCustomAttributes(typeof(TableAttribute),true);
			string tableName=string.Empty;
			if(attributes.Length>0)
			{
				TableAttribute table=attributes[0] as TableAttribute;
				if (table==null) {
					table=attributes[1] as TableAttribute;
					if (table==null) {
						string info=entity.ToString()+"实体类的TableAttribute特性标记位置异常";
						LogUtil.Error(info);
						throw new Exception(info);
					}
				}
				tableName=table.TableName;
				return tableName;
			}
			else
			{
				string info=entity.ToString()+"实体类的没有TableAttribute特性标记";
				LogUtil.Error(info);
				throw new Exception(info);
			}
		}
		/// <summary>
		/// 获取添加数据所用的sql
		/// </summary>
		/// <param name="entity">指定的实体对象</param>
		/// <returns>AddSQL</returns>
		protected StringBuilder GetAddSQL(EntityBase entity){
			Dictionary<string,object> all=entity.ChangedMap;
			string tableName=GetEntityTableName(entity);
			StringBuilder sb=new StringBuilder();
			sb.Append("insert into "+tableName+"(");
			int index=0;
			
			foreach (KeyValuePair<string,object> field in all) {
				index++;
				if (index==all.Count) {
					sb.Append(field.Key+") values (");
				}
				else{
					sb.Append(field.Key+",");
				}
			}
			
			for (int i = index; i >0; i--) {
				var p=index-i+1;
				string mp;
				if (i==1) {
					mp=PName+"p"+p+")";
				}else{
					mp=PName+"p"+p+",";
				}
				sb.Append(mp);
			}
			return sb;
		}
		/// <summary>
		/// 添加实体
		/// </summary>
		/// <param name="entity">指定实体</param>
		/// <returns>如果系统设置了自增主键,则返回该主键的值,如不自增则返回null(当然数据已经插入成功了)</returns>
		public virtual object Add(EntityBase entity){
			return null;
		}
		/// <summary>
		/// 更新实体
		/// </summary>
		/// <param name="entity">指定实体</param>
		/// <returns>受影响的行数</returns>
		public virtual int Update(EntityBase entity){
			return -1;
		}
		/// <summary>
		/// 通过WhereExpression删除实体,注意WhereExpression描述的是同一个表
		/// </summary>
		/// <param name="expression">条件表达式,格式如:UserSet.ID.BiggerThan(9).And(UserSet.Age.BiggerThan(12))</param>
		/// <typeparam name="T">指定的表,如:UserSet</typeparam>
		/// <returns>受影响的行数</returns>
		public virtual int Remove<T>(WhereExpression expression) where T:MQLBase{
			return -1;
		}
		/// <summary>
		/// 获取数据条数,注意WhereExpression描述的是同一个表
		/// </summary>
		/// <param name="expression">条件表达式,格式如:UserSet.ID.BiggerThan(9).And(UserSet.Age.BiggerThan(12))</param>
		/// <typeparam name="T">实体查询类</typeparam>
		/// <returns>条件所指的数据条数</returns>
		public virtual long GetCount<T>(WhereExpression expression) where T:MQLBase
		{
			return -1;
		}
		/// <summary>
		/// 获取数据条数,注意WhereExpression描述的是同一个表
		/// </summary>
		/// <param name="expression">条件表达式,格式如:UserSet.ID.BiggerThan(9).And(UserSet.Age.BiggerThan(12))</param>
		/// <typeparam name="T">实体查询类</typeparam>
		/// <returns>条件所指的数据条数</returns>
		public   int GetInt32Count<T>(WhereExpression expression) where T:MQLBase
		{
			var data= GetCount<T>(expression);
			return (int)data;
		}
		/// <summary>
		/// 获取指定条件数据是否存在,注意WhereExpression描述的是同一个表
		/// </summary>
		/// <param name="expression">条件表达式,格式如:UserSet.ID.BiggerThan(9).And(UserSet.Age.BiggerThan(12))</param>
		/// <typeparam name="T">实体查询类</typeparam>
		/// <returns>是否存在</returns>
		public bool Exist<T>(WhereExpression expression) where	T:MQLBase
		{
			var data= GetCount<T>(expression);
			return data>0;
		}
		string GetWhereExpressionTableName(WhereExpression expression){
			//2014-6-27 10:21:16 还没有实现
			return null;
		}
		/// <summary>
		/// 获取当前的count sql语句(含有@parameter的sql语句)
		/// </summary>
		/// <param name="expression">条件表达式,格式如:UserSet.ID.BiggerThan(9).And(UserSet.Age.BiggerThan(12))</param>
		/// <typeparam name="T">实体查询类</typeparam>
		/// <returns>sql语句</returns>
		protected StringBuilder GetCountSQL<T>(WhereExpression expression) where T:MQLBase
		{
			string tableName = GetTableNameFromTableSet<T>();
			string sql = "select count(1) from  " + tableName + " where " + expression.WhereContent;
			StringBuilder retSB = new StringBuilder();
			int index = 1;
			for (int i = 0; i < sql.Length; i++) {
				Char c = sql[i];
				if ('@' == c) {
					retSB.Append(PName+"p" + index);
					index++;
				} else {
					retSB.Append(c);
				}
			}
			return retSB;
		}
		/// <summary>
		/// 从实体查询类中获取表名
		/// </summary>
		/// <typeparam name="T">实体查询类</typeparam>
		/// <returns>对应表名</returns>
		protected string GetTableNameFromTableSet<T>()where T:MQLBase{
			var attributes=typeof(T).GetCustomAttributes(typeof(TableAttribute),true);
			string tableName=string.Empty;
			if(attributes.Length>0)
			{
				TableAttribute table=attributes[0] as TableAttribute;
				if (table==null) {
					string err="实体查询类的没有TableAttribute标记";
					throw new Exception(err);
				}
				tableName=table.TableName;
			}
			else
			{
				string err="实体查询类的没有TableAttribute标记";
				LogUtil.Error(err);
				throw new Exception(err);
			}
			return tableName;
		}
		/// <summary>
		/// 移除指定表所有的数据
		/// </summary>
		/// <typeparam name="T">指定的表,如:UserSet</typeparam>
		/// <returns>受影响的行数</returns>
		public  int Remove<T>()where T:MQLBase{
			var cmd=AdoMethod.CreateDbCommand();
			cmd.Connection=Connection;
			if (TransactionEnabled) {
				cmd.Transaction=this.Transaction;
			}
			
			string tableName=GetTableNameFromTableSet<T>();
			
			cmd.CommandText="delete from  "+tableName;
			if (TransactionEnabled) {
				cmd.Transaction=this.Transaction;
			}
			CurrentSQL=cmd.CommandText;
			return cmd.ExecuteNonQuery();
		}
		/// <summary>
		/// 获取指定实体集
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <typeparam name="T">T:EntityBase</typeparam>
		/// <returns>List&lt;T&gt; 实体集,T:EntityBase</returns>
		public virtual List<T> GetEntities<T>(MQLBase mql) where T: EntityBase,new(){
			return null;
		}
		/// <summary>
		/// 通过mql获取dataset
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <returns>目标数据的dataset</returns>
		public virtual DataSet GetDataSet(MQLBase mql){
			return null;
		}

		/// <summary>
		/// 获取单字段的查询（按列表的形式返回结果）
		/// </summary>
		/// <typeparam name="T">基础数据类型</typeparam>
		/// <param name="mql"></param>
		/// <returns></returns>
		public virtual List<T> GetOneFieldList<T>(MQLBase mql) where T : IComparable
		{
			string debugSQL = string.Empty;
			if (this._CacheTime > 0)
			{
				debugSQL = mql.ToDebugSQL();
				object result = HttpRuntime.Cache.Get(debugSQL);
				if (result != null)
				{
					return (result as List<T>);
				}
			}
			string sql2 = mql.ToParametersSQL();
			var cmd = AdoMethod.CreateDbCommand();
			cmd.Connection = this.Connection;
			if (TransactionEnabled)
			{
				cmd.Transaction = this.Transaction;
			}
			int index = 1;
			foreach (var parameter in mql.Parameters)
			{
				DbParameter p = AdoMethod.CreateParameter();
				p.ParameterName = this.PName + "p" + index;
				p.Value = parameter;
				p.Direction = ParameterDirection.Input;
				cmd.Parameters.Add(p);
				index++;
			}
			cmd.CommandText = sql2;
			if (DebugEnabled)
			{
				index = 1;
				sql2 += "\r\n";
				foreach (var parameter in mql.Parameters)
				{
					sql2 += this.PName + "p" + index + "=" + parameter;
					index++;
				}
				this.CurrentSQL = sql2;
			}

			var reader = cmd.ExecuteReader();
			List<T> list = new List<T>();
			while (reader.Read())
			{
				T t = (T)(reader.GetValue(0));
				list.Add(t);
			}
			reader.Close();
			if (this._CacheTime > 0)
			{
				DateTime expire = DateTime.Now.AddSeconds(_CacheTime);
				HttpRuntime.Cache.Insert(debugSQL, list, null, expire, TimeSpan.Zero);

			}
			return list;
		}

		/// <summary>
		/// 获取自定义实体集
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <typeparam name="T">T:new()</typeparam>
		/// <returns>List&lt;T&gt; 实体集,T 是一个类就可以( T: class,new())</returns>
		public virtual List<T> GetOwnList<T>(MQLBase mql) where T: class, new() {
			return null;
		}
		/// <summary>
		/// 获取实体
		/// </summary>
		/// <param name="mql">mql语句</param>
		///<typeparam name="T">注意泛型T:EntityBase</typeparam>
		/// <returns>T的实体,T:EntityBase.如果为null,表示数据不存在</returns>
		public  T GetEntity<T>(MQLBase mql) where T: EntityBase,new(){
			var list=GetEntities<T>(mql);
			if (list.Count==0) {
				return null;
			}else{
				return list[0];
			}
		}
		/// <summary>
		/// 获取结果的第一行第一列数据到Object
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <returns>Object形式的结果,建议使用GetScalarToMObject</returns>
		public virtual Object GetScalar(MQLBase mql){
			return -1;
		}
		/// <summary>
		/// 获取结果的第一行第一列数据到<code>MObject</code>
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <returns>MObject形式的结果,详情见<code>MObject</code></returns>
		public  MObject GetScalarToMObject(MQLBase mql){
			var obj= GetScalar(mql);
			MObject ret=new MObject();
			ret.Value=obj;
			return ret;
		}
		
		/// <summary>
		/// 执行存储过程,结果反馈到DataSet
		/// </summary>
		/// <param name="procName">存储过程名</param>
		/// <param name="parameters">参数组</param>
		/// <returns>数据的dataset形式</returns>
		public virtual DataSet ExecuteProToDataSet(String procName,params DbParameter[] parameters){
			return null;
		}
		/// <summary>
		///  执行存储过程,返回受影响的行数
		/// </summary>
		/// <param name="procName">存储过程名</param>
		/// <param name="parameters">参数组</param>
		/// <returns>受影响的行数</returns>
		public virtual int ExecuteProWithNonQuery(String procName,params DbParameter[] parameters){
			return -1;
		}
		/// <summary>
		/// 执行存储过程,结果反馈到自定义List,只要T是类就可以了.
		/// </summary>
		/// <param name="procName">存储过程名</param>
		/// <param name="parameters">参数组</param>
		/// <typeparam name="T">注意泛型T:new()</typeparam>
		/// <returns>List&lt;T&gt;</returns>
		public virtual List<T> ExecuteProToOwnList<T>(String procName,params DbParameter[] parameters)where T:new(){
			return null;
		}
		/// <summary>
		/// 执行存储过程,结果反馈到DictionaryList
		/// </summary>
		/// <param name="procName">存储过程名</param>
		/// <param name="parameters">参数组</param>
		/// <returns>DictionaryList</returns>
		public virtual DictionaryList ExecuteProToDictionaryList(String procName,params DbParameter[] parameters){
			return null;
		}
		/// <summary>
		/// 资源释放,如果不用using,请手动调用Dispose(),或者你也可以用Close()
		/// </summary>
		public void Dispose()
		{
			if (Connection!=null&&Connection.State!= ConnectionState.Closed)
			{
				Connection.Close();
			}
			
		}
		/// <summary>
		/// 获取指定查询中数据的条数
		/// </summary>
		/// <param name="mql">查询数据的语句</param>
		/// <returns>总条数:long</returns>
		public long GetCount(MQLBase mql){
			string sql=mql.ToSQLExpression();
			string countSql="SELECT COUNT(0) FROM ("+sql+")  T_MOON_SearchCount";
			if (DebugEnabled) {
				CurrentSQL=sql;
			}
			var parameters=mql.Parameters.ToArray();
			var countData=this.ExecuteSqlToScalar(countSql,parameters);
			long sumDataCount=Convert.ToInt64(countData);
			return sumDataCount;
		}
		/// <summary>
		/// 获取指定查询中数据的条数
		/// </summary>
		/// <param name="mql">查询数据的语句</param>
		/// <returns>总条数:int</returns>
		public int GetInt32Count(MQLBase mql){
			string sql=mql.ToSQLExpression();
			string countSql="SELECT COUNT(0) FROM ("+sql+")  T_MOON_SearchCount";
			if (DebugEnabled) {
				CurrentSQL=sql;
			}
			var parameters=mql.Parameters.ToArray();
			var countData=this.ExecuteSqlToScalar(countSql,parameters);
			var sumDataCount=Convert.ToInt32(countData);
			return sumDataCount;
		}
		/// <summary>
		/// 执行sql结果反馈到DataSet,自己注意sql注入问题
		/// </summary>
		/// <param name="sql">执行的sql语句</param>
		/// <returns>DataSet</returns>
		public  DataSet ExecuteSqlToDataSet(string sql){
			var cmd=AdoMethod.CreateDbCommand();
			cmd.Connection=this.Connection;
			if (TransactionEnabled) {
				cmd.Transaction=this.Transaction ;
			}
			cmd.CommandText=sql;
			
			var adapter =AdoMethod.CreateDataAdapter();
			adapter.SelectCommand=cmd;
			DataSet dataSet = new DataSet();
			adapter.Fill(dataSet);
			return dataSet;
		}
		/// <summary>
		/// 执行sql,将结果返回到<code>DataSet</code>
		/// </summary>
		/// <param name="sql">执行的语句,其中放变量的地方仅仅用@表示(eg:select * from user wehre id>@ and age=@)</param>
		/// <param name="values">对应变量的值</param>
		/// <returns>DataSet</returns>
		public virtual DataSet ExecuteSqlToDataSet(string sql,params object[] values){
			return null;
		}
		/// <summary>
		/// 执行一条sql查询第一行第一列
		/// </summary>
		/// <param name="sql">sql语句</param>
		/// <param name="values">参数列表</param>
		/// <returns>结果</returns>
		public virtual object ExecuteSqlToScalar(string sql,params object[] values){
			return null;
		}
		/// <summary>
		/// 执行sql,返回受影响的行数,自己注意sql注入问题
		/// </summary>
		/// <param name="sql">执行的sql语句</param>
		/// <returns>受影响的行数</returns>
		public  int ExecuteSqlWithNonQuery(string sql){
			var cmd=AdoMethod.CreateDbCommand();
			cmd.Connection=this.Connection;
			if (TransactionEnabled) {
				cmd.Transaction=this.Transaction ;
			}
			cmd.CommandText=sql;
			return cmd.ExecuteNonQuery();
		}
		/// <summary>
		/// 执行sql,将结果返回到自定义List&lt;T&gt;,T只要为类就可以.
		/// </summary>
		/// <param name="sql">执行的语句,自己注意sql注入问题</param>
		///<typeparam name="T">注意泛型T:new()</typeparam>
		/// <returns>List&lt;T&gt;</returns>
		public  List<T> ExecuteSqlToOwnList<T>(string sql)where T:new(){
			var cmd = AdoMethod.CreateDbCommand();
			cmd.Connection=this.Connection;
			if (TransactionEnabled) {
				cmd.Transaction=this.Transaction;
			}
			cmd.CommandType= CommandType.Text;
			cmd.CommandText=sql;
			//
			DbDataReader reader=cmd.ExecuteReader();
			List<T>  list=new List<T>();
			while (reader.Read()) {
				T data=MoonFastInvoker<T>.GetTFrom(reader);
				list.Add(data);
				
			}reader.Close();
			return list;
		}
		
		/// <summary>
		/// 执行sql,将结果返回到自定义List&lt;T&gt;,T只要为类就可以.
		/// </summary>
		/// <param name="sql">执行的语句,其中放变量的地方仅仅用@表示(eg:select * from user wehre id>@ and age=@)</param>
		/// <param name="values">对应变量的值</param>
		/// <typeparam name="T">注意泛型T:new()</typeparam>
		/// <returns>List&lt;T&gt;</returns>
		public virtual List<T> ExecuteSqlToOwnList<T>(string sql,params object[] values)where T:new(){
			return null;
		}
		/// <summary>
		/// 执行sql,返回受影响行数
		/// </summary>
		/// <param name="sql">sql语句,其中放变量的地方用@表示</param>
		/// <param name="values">对应变量的值</param>
		/// <returns>受影响行数</returns>
		public virtual int ExecuteSqlWithNonQuery(string sql,params object[] values){
			return -1;
		}
		
		/// <summary>
		/// 执行sql,将结果返回到 List&lt;Dictionary&lt;string,MObject&gt;&gt;
		/// </summary>
		/// <param name="sql">执行的语句,其中放变量的地方仅仅用@表示(eg:select * from user wehre id>@ and age=@)</param>
		/// <param name="values">对应变量的值</param>
		/// <returns>List&lt;Dictionary&lt;string,MObject&gt;&gt;</returns>
		public virtual  DictionaryList ExecuteSqlToDictionaryList(string sql,params object[] values){
			return null;
		}
		
		/// <summary>
		/// 执行sql,将结果返回到 List&lt;Dictionary&lt;string,MObject&gt;&gt; ,自己注意sql注入问题
		/// </summary>
		/// <param name="sql">执行的语句</param>
		/// <returns>List&lt;Dictionary&lt;string,MObject&gt;&gt;</returns>
		public  DictionaryList ExecuteSqlToDictionaryList(string sql){
			//
			var cmd = AdoMethod.CreateDbCommand();
			cmd.Connection=this.Connection;
			if (TransactionEnabled) {
				cmd.Transaction=this.Transaction;
			}
			cmd.CommandType= CommandType.Text;
			cmd.CommandText=sql;
			DbDataReader reader=cmd.ExecuteReader();
			//
			DictionaryList list=new DictionaryList();
			while (reader.Read()) {
				Dictionary<string,MObject> entity=new Dictionary<string, MObject>(StringComparer.OrdinalIgnoreCase);
				for (int i = 0; i < reader.VisibleFieldCount; i++) {
					string fieldName=reader.GetName(i);
					object value=reader.GetValue(i);
					MObject v=new MObject();
					v.Value=value;
					entity.Add(fieldName,v);
				}
				list.Add(entity);
			}
			reader.Close();
			return list;
		}
		/// <summary>
		/// 执行mql,将结果返回到 List&lt;Dictionary&lt;string,MObject&gt;&gt;
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <returns>List&lt;Dictionary&lt;string,MObject&gt;&gt;</returns>
		public virtual DictionaryList GetDictionaryList(MQLBase mql){
			return null;
		}
		
		/// <summary>
		/// 获取DbDataReader
		/// </summary>
		/// <param name="commandText">cmd所用的commandText</param>
		/// <param name="commandType">cmd所用的commandType</param>
		/// <returns>DbDataReader</returns>
		public DbDataReader GetDbDataReader(string commandText,CommandType commandType )
		{
			var cmd = AdoMethod.CreateDbCommand();
			cmd.Connection=this.Connection;
			cmd.CommandType= commandType;
			cmd.CommandText=commandText;
			DbDataReader reader=cmd.ExecuteReader();
			return reader;
		}
		/// <summary>
		/// (注意您需要手动自己解决sql注入问题),
		/// 此方法可以获取强类型的List&lt;T&gt;集合,虽然返回为
		/// object,但其实质为List&lt;T&gt;(T为你自定义的类名className);,
		/// .net 4.0下面,您可以用dynamic表示返回结果,如下.
		/// dynamic list=db.GetDynamicList( sql, className);
		/// </summary>
		/// <param name="sql">您的sql语句</param>
		/// <param name="className">关乎此sql的查询所用的className(可以随意写,只要满足类名的[命名规则]),不同的sql语句仅仅参数不一样,可以用同一个className</param>
		/// <returns>虽然表面上为object,本质上强类型的List</returns>
		public  object GetDynamicList(string sql,string className)
		{
			DynamicListHandler handler=GlobalData.GetHandlerMapByModelName(className);
			if (handler==null) {
				string code=DynamicListelper.GenerateModelAndModelListsGetMethodCode(sql,this,className);
				CompilerResults result=null;
				try {
					result=DynamicListelper.CompileToResults(code,null,className);
				} catch (Exception ex) {
					StringBuilder sb=new StringBuilder();
					sb.AppendLine("GetDynamicList自动编译时发生异常,异常内容如下:");
					sb.AppendLine(ex.Message);
					sb.AppendLine("生成的代码:");
					sb.AppendLine(code);
					if (result!=null&&result.Errors.Count>0) {
						sb.AppendLine("错误信息:");
						foreach (CompilerError err in result.Errors) {
							sb.AppendLine(err.ErrorText);
						}
					}
					string content=sb.ToString();
					LogUtil.Error(content);
					throw new Exception(content);
				}
				Assembly assembly=result.CompiledAssembly;
				string typeName="moontemp.EntityGet"+className;
				Type type=assembly.GetType(typeName);
				handler = (DynamicListHandler)Delegate.CreateDelegate
					(typeof(DynamicListHandler), type, "GetList");    //静态类方法
				GlobalData.AddDynamicListHandlerToMap(className,handler);
				return handler.Invoke(sql,this);
			}
			else{
				return handler.Invoke(sql,this);
			}
		}
		/// <summary>
		/// 可以在IDE下直接获取到目标sql对应的实体类,您可以直接复制过来使用,比如使用<code>GetOwnList[生成的实体类]()</code>
		/// </summary>
		/// <param name="sql">目标sql</param>
		/// <param name="modelName">对应的实体类名</param>
		/// <returns>您要的的实体类</returns>
		public string GetModelBySql(string sql,string modelName){
			return DynamicListelper.GenerateModelCode(sql,this,modelName);
		}
		/// <summary>
		/// 获取一个分页DictionaryList,不支持sqlserver2000
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <param name="sumPageCount">总页数</param>
		/// <param name="sumDataCount">总数据条数</param>
		/// <param name="pageIndex">页码</param>
		/// <param name="onePageDataCount">每页数据的条数</param>
		/// <param name="oneOrderbyFieldName">sqlserver中会用到的排序字段(查询结果中一个字段,如:xxid desc,或 xxid asc),其他类型数据库则填写null</param>
		/// <returns>DictionaryList</returns>
		public virtual DictionaryList GetPagerToDictionaryList(MQLBase mql,out int sumPageCount,out int sumDataCount,int pageIndex,int onePageDataCount,string oneOrderbyFieldName)
		{
			sumPageCount=0;
			sumDataCount=0;
			return null;
		}
		/// <summary>
		/// 获取一个分页DictionaryList,不支持sqlserver2000
		/// </summary>
		/// <param name="sql">执行的语句,其中放变量的地方仅仅用@表示(eg:select * from user wehre id>@ and age=@)</param>
		/// <param name="parameters">对应参数列表</param>
		/// <param name="sumPageCount">总页数</param>
		/// <param name="sumDataCount">总数据条数</param>
		/// <param name="pageIndex">页码</param>
		/// <param name="onePageDataCount">每页数据的条数</param>
		/// <param name="oneOrderbyFieldName">sqlserver中会用到的排序字段(查询结果中一个字段,如:xxid desc,或 xxid asc),其他类型数据库则填写null</param>
		/// <returns>DictionaryList</returns>
		public virtual DictionaryList GetPagerToDictionaryList(string sql,object[] parameters,out int sumPageCount,out int sumDataCount,int pageIndex,int onePageDataCount,string oneOrderbyFieldName)
		{
			sumPageCount=0;
			sumDataCount=0;
			return null;
		}
        /// <summary>
		/// 获取一个分页json,不支持sqlserver2000
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <param name="sumPageCount">总页数</param>
		/// <param name="sumDataCount">总数据条数</param>
		/// <param name="pageIndex">页码</param>
		/// <param name="onePageDataCount">每页数据的条数</param>
		/// <param name="oneOrderbyFieldName">sqlserver中会用到的排序字段(查询结果中一个字段,如:xxid desc,或 xxid asc),其他类型数据库则填写null</param>
		/// <returns>获取一个分页json</returns>
		public virtual string GetPagerToJson(MQLBase mql, out int sumPageCount, out int sumDataCount, int pageIndex, int onePageDataCount, string oneOrderbyFieldName)
        {
            sumPageCount = 0;
            sumDataCount = 0;
            return null;
        }
        /// <summary>
        /// 获取一个分页json,不支持sqlserver2000
        /// </summary>
        /// <param name="sql">执行的语句,其中放变量的地方仅仅用@表示(eg:select * from user wehre id>@ and age=@)</param>
        /// <param name="parameters">对应参数列表</param>
        /// <param name="sumPageCount">总页数</param>
        /// <param name="sumDataCount">总数据条数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="onePageDataCount">每页数据的条数</param>
        /// <param name="oneOrderbyFieldName">sqlserver中会用到的排序字段(查询结果中一个字段,如:xxid desc,或 xxid asc),其他类型数据库则填写null</param>
        /// <returns>获取一个分页Json</returns>
        public virtual string GetPagerToJson(string sql, object[] parameters, out int sumPageCount, out int sumDataCount, int pageIndex, int onePageDataCount, string oneOrderbyFieldName)
        {
            sumPageCount = 0;
            sumDataCount = 0;
            return null;
        }
        /// <summary>
        /// 获取一个分页的自定义实体集,(sqlserver中,注意T对应的类中需要一个名为ROW_NUMBER的属性,请自行添加:建议用partical方式,类型为Int64)
        /// </summary>
        /// <param name="mql">mql语句</param>
        /// <param name="sumPageCount">总页数</param><param name="sumDataCount">总数据条数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="onePageDataCount">每页数据的条数</param>
        /// <param name="oneOrderbyFieldName">sqlserver中会用到的排序字段(查询结果中一个字段),其他类型数据库则填写null</param>
        /// <typeparam name="T">注意泛型T:new()</typeparam>
        /// <returns>自定义实体集</returns>
        public virtual List<T> GetPagerToOwnList<T>(MQLBase mql,out int sumPageCount,out int sumDataCount,int pageIndex,int onePageDataCount,string oneOrderbyFieldName)where T:new()
		{
			sumPageCount=0;
			sumDataCount=0;
			return null;
		}
		/// <summary>
		/// 获取一个分页的自定义实体集,(sqlserver中,注意T对应的类中需要一个名为ROW_NUMBER的属性,请自行添加:建议用partical方式,类型为Int64)
		/// </summary>
		/// <param name="sql">执行的语句,其中放变量的地方仅仅用@表示(eg:select * from user wehre id>@ and age=@)</param>
		/// <param name="parameters">对应参数列表</param>
		/// <param name="sumPageCount">总页数</param><param name="sumDataCount">总数据条数</param>
		/// <param name="pageIndex">页码</param>
		/// <param name="onePageDataCount">每页数据的条数</param>
		/// <param name="oneOrderbyFieldName">sqlserver中会用到的排序字段(查询结果中一个字段),其他类型数据库则填写null</param>
		/// <typeparam name="T">注意泛型T:new()</typeparam>
		/// <returns>自定义实体集</returns>
		public virtual List<T> GetPagerToOwnList<T>(string sql,object[] parameters,out int sumPageCount,out int sumDataCount,int pageIndex,int onePageDataCount,string oneOrderbyFieldName)where T:new()
		{
			sumPageCount=0;
			sumDataCount=0;
			return null;
		}
		/// <summary>
		/// 获取一个分页的DataSet
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <param name="sumPageCount">总页数</param>
		/// <param name="sumDataCount">总数据条数</param>
		/// <param name="pageIndex">页码</param>
		/// <param name="onePageDataCount">每页数据的条数</param>
		/// <param name="oneOrderbyFieldName">sqlserver中会用到的排序字段(查询结果中一个字段),其他类型数据库则填写null</param>
		/// <returns>分页的DataSet</returns>
		public virtual DataSet GetPagerToDataSet(MQLBase mql,out int sumPageCount,out int sumDataCount,int pageIndex,int onePageDataCount,string oneOrderbyFieldName)
		{
			sumPageCount=0;
			sumDataCount=0;
			return null;
		}
		/// <summary>
		/// 获取一个分页的DataSet
		/// </summary>
		/// <param name="sql">执行的语句,其中放变量的地方仅仅用@表示(eg:select * from user wehre id>@ and age=@)</param>
		/// <param name="parameters">对应的参数列表</param>
		/// <param name="sumPageCount">总页数</param>
		/// <param name="sumDataCount">总数据条数</param>
		/// <param name="pageIndex">页码</param>
		/// <param name="onePageDataCount">每页数据的条数</param>
		/// <param name="oneOrderbyFieldName">sqlserver中会用到的排序字段(查询结果中一个字段),其他类型数据库则填写null</param>
		/// <returns>分页的DataSet</returns>
		public virtual DataSet GetPagerToDataSet(string sql,object[] parameters,out int sumPageCount,out int sumDataCount,int pageIndex,int onePageDataCount,string oneOrderbyFieldName)
		{
			sumPageCount=0;
			sumDataCount=0;
			return null;
		}
		/// <summary>
		/// 通过mql获取json形式的结果,性能几乎就是ado.net
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <returns>json形式的查询结果</returns>
		public virtual string GetJson(MQLBase mql){
			return null;
		}
		/// <summary>
		/// 执行sql,返回json结果
		/// </summary>
		/// <param name="sql">sql语句</param>
		/// <param name="values">参数组</param>
		/// <returns>sql查询的结果,json格式</returns>
		public virtual string ExecuteSqlToJson(string sql,params object[] values){
			return null;
		}
		/// <summary>
		/// 如果不用using语句,则调用此方法手动关闭资源
		/// </summary>
		public void Close(){
			Dispose();
		}
	}
}

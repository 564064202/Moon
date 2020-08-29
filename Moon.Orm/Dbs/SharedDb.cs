using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Web;
using System.Xml;

using Moon.Orm.Util;

namespace Moon.Orm
{
	/// <summary>
	/// 通用的Db引擎
	/// </summary>
	public class SharedDb : Db, IDisposable
	{
		class SharedDbConfig
		{
			public int AutoIncreasePKSqlPosition
			{
				get;
				set;
			}
			public string AutoIncreasePKSQL
			{
				get;
				set;
			}
			public string PName
			{
				get;
				set;
			}
		}
		
		class SharedDbConfigUtil
		{
			static readonly Dictionary<string,SharedDbConfig> SharedDbConfigDIC=new Dictionary<string, SharedDb.SharedDbConfig>();
			static readonly object SharedDbConfigDIC_LOCK=new object();
			public static SharedDbConfig GetSharedDbConfig(string providerName)
			{
				lock(SharedDbConfigDIC_LOCK)
				{
					if (SharedDbConfigDIC.ContainsKey(providerName))
					{
						return SharedDbConfigDIC[providerName];
					}
					var dirPath=GlobalData.MOON_WORK_DIRECTORY_PATH+"SharedDbConfig"+GlobalData.OS_SPLIT_STRING;
					IOUtil.CreateDirectoryWhenNotExist(dirPath);
					var configFileFullPath=dirPath+providerName+".config";
					if (File.Exists(configFileFullPath)==false)
					{
						StringBuilder sb=new StringBuilder();
						sb.AppendLine("<?xml version=\"1.0\"?>");
						sb.AppendLine("<SharedDbConfigs>");
						sb.AppendLine("	<SharedDbConfig ProviderDllName=\""+providerName+"\">");
						sb.AppendLine("		<AutoIncreasePKSqlPosition>请填写获取自增长主键值的SQL语句所在位置,1:表示和插入语句形成整体执行; 2:插入之后执行</AutoIncreasePKSqlPosition>");
						sb.AppendLine("		<AutoIncreasePKSQL><![CDATA[请填写获取自增长主键值的SQL语句]]></AutoIncreasePKSQL>");
						sb.AppendLine("		<PName>请填写参数化查询所用符号,如@ :</PName>");
						sb.AppendLine("	</SharedDbConfig>");
						sb.AppendLine("</SharedDbConfigs>");
						StreamWriter sw=new StreamWriter(configFileFullPath,false,System.Text.Encoding.UTF8);
						sw.Write(sb.ToString());
						sw.Close();
						var error="您还未配置{0}的SharedDbConfig,请到{1}文件按照提示信息进行配置";
						error=string.Format(error,providerName,configFileFullPath);
						throw new Exception(error);
					}
					else
					{
						XmlDocument doc=new XmlDocument();
						doc.Load(configFileFullPath);
						var list=doc.DocumentElement.ChildNodes;
						foreach (XmlNode element in list)
						{
							SharedDbConfig data=new SharedDbConfig();
							string xProviderDllName=element.Attributes["ProviderDllName"].Value;
							if(xProviderDllName==providerName)
							{
								var allChildren=element.ChildNodes;
								foreach (XmlNode ch in allChildren)
								{
									var property=typeof(SharedDbConfig).GetProperty(ch.Name);
									if (property!=null)
									{
										if(ch.InnerText.Contains("请")){
											var error="您还未配置{0}的SharedDbConfig,请到{1}文件按照提示信息进行配置";
											error=string.Format(error,providerName,configFileFullPath);
											throw new Exception(error);
										}
										if(ch.Name=="AutoIncreasePKSqlPosition")
										{
											int autoIncreasePKSqlPosition;
											var ret=int.TryParse(ch.InnerText,out autoIncreasePKSqlPosition);
											if (ret==false) {
												var error="SharedDbConfig配置错误,AutoIncreasePKSqlPosition需要为整数,请到{0}文件按照提示信息进行配置";
												error=string.Format(error,configFileFullPath);
												throw new Exception(error);
											}else{
												data.AutoIncreasePKSqlPosition=autoIncreasePKSqlPosition;
											}
										}
										else
										{
											property.SetValue(data,ch.InnerText,null);
										}
									}
								}
								SharedDbConfigDIC[providerName]=data;
								return data;
							}
							
						}
						var err="配置文件中发生错误:"+configFileFullPath;
						throw new Exception(err);
						
					}
				}
				
			}
		}
		private string _providerName;
		private SharedDbConfig _SharedDbConfig;
		/// <summary>
		/// 构造,如果不用using,请手动调用Dispose()释放资源
		/// </summary>
		/// <param name="linkString">连接字符串</param>
		/// <param name="providerName">providerName(无后缀)</param>
		public SharedDb(string linkString, string providerName) : base(linkString)
		{
			_providerName=providerName;
			//
			try
			{
				this.AdoMethod = new AdoSharedDb(this.LinkString, providerName+".dll");
			}
			catch (Exception ex)
			{
				throw ex.InnerException;
			}
            //
            this.LinkString = linkString;
            this._SharedDbConfig = SharedDbConfigUtil.GetSharedDbConfig(providerName);
            this.PName = _SharedDbConfig.PName;

            this.Connection = AdoMethod.CreateConnection();
			this.Connection.ConnectionString = linkString;
			//
			 
			this.Connection.Open();
			
		}
		/// <summary>
		/// 添加实体
		/// </summary>
		/// <param name="entity">指定实体</param>
		/// <returns>如果系统自动设置主键,则返回该主键</returns>
		public override object Add(EntityBase entity)
		{
			var sb = GetAddSQL(entity);
			PrimaryKeyType primaryKeyType = entity.GetPrimaryKeyInfo().PrimaryKeyType;
			if (_SharedDbConfig.AutoIncreasePKSqlPosition == 1 && primaryKeyType == PrimaryKeyType.AutoIncrease)
			{
				sb.Append(" ;  " + _SharedDbConfig.AutoIncreasePKSQL);
			}
			var cmd = AdoMethod.CreateDbCommand();
			cmd.Connection = this.Connection;

			if (TransactionEnabled)
			{
				cmd.Transaction = this.Transaction;
			}
			int index = 1;
			sb.AppendLine();
			foreach (KeyValuePair<string, object> parameter in entity.ChangedMap)
			{
				DbParameter p = AdoMethod.CreateParameter();
				p.ParameterName = this.PName + "p" + index;
				p.Value = parameter.Value;
				p.Direction = ParameterDirection.Input;
				cmd.Parameters.Add(p);
				index++;
			}
			cmd.CommandText = sb.ToString();
			if (this.DebugEnabled)
			{
				index = 1;
				foreach (KeyValuePair<string, object> parameter in entity.ChangedMap)
				{
					sb.AppendLine(this.PName + "p" + index + "=" + parameter.Value);
					index++;
				}
				CurrentSQL = sb.ToString();
			}

			if (primaryKeyType == PrimaryKeyType.AutoIncrease)
			{
				if (_SharedDbConfig.AutoIncreasePKSqlPosition == 1)
				{
					var pkValue = cmd.ExecuteScalar();
					entity.SetPrimaryKeyValue(pkValue);
					return pkValue;
				}
				else if (_SharedDbConfig.AutoIncreasePKSqlPosition == 2)
				{
					cmd.ExecuteNonQuery();
					cmd.CommandText =_SharedDbConfig.AutoIncreasePKSQL;
					var pkValue = cmd.ExecuteScalar();
					entity.SetPrimaryKeyValue(pkValue);
					return pkValue;
				}
				else
				{
					throw new NotImplementedException("SharedDbConfig.AutoIncreasePKSqlPosition="+ _SharedDbConfig.AutoIncreasePKSqlPosition + " 还未实现");
				}
			}
			else if (primaryKeyType == PrimaryKeyType.MultiplePK)
			{
				cmd.ExecuteNonQuery();
				return null;
			}
			else if (primaryKeyType == PrimaryKeyType.NoPK)
			{
				cmd.ExecuteNonQuery();
				Util.LogUtil.Debug("没有设置主键!!!");
				return null;
			}
			else if (primaryKeyType == PrimaryKeyType.CustomerGUID)
			{
				cmd.ExecuteNonQuery();
				return null;
			}
			else
			{
				throw new NotImplementedException(primaryKeyType + " 还未实现");
			}
		}
		/// <summary>
		/// 获取自定义实体集
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <returns>List&lt;T&gt; 实体集,T 是一个类就可以( T: new())</returns>
		public override List<T> GetOwnList<T>(MQLBase mql)
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
				T t = MoonFastInvoker<T>.GetTFrom(reader);
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
		/// 获取指定实体集
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <returns>List&lt;T&gt; 实体集,T:EntityBase</returns>
		public override List<T> GetEntities<T>(MQLBase mql)
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
				T t = EntityBase.CreateEntity<T>(reader);
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
		/// 更新实体
		/// </summary>
		/// <param name="entity">指定实体</param>
		/// <returns>受影响的行数</returns>
		public override int Update(EntityBase entity)
		{
			var sb = GetUpdateSQL(entity);
			var cmd = AdoMethod.CreateDbCommand();
			cmd.Connection = this.Connection;
			if (TransactionEnabled)
			{
				cmd.Transaction = this.Transaction;
			}
			int index = 1;

			foreach (KeyValuePair<string, object> parameter in entity.ChangedMap)
			{
				DbParameter p = AdoMethod.CreateParameter();
				p.ParameterName = this.PName + "p" + index;
				p.Value = parameter.Value;
				p.Direction = ParameterDirection.Input;
				cmd.Parameters.Add(p);
				index++;
			}
			foreach (var a in entity.WhereExpression.Parameters)
			{
				DbParameter p = AdoMethod.CreateParameter();
				p.ParameterName = this.PName + "p" + index;
				p.Value = a;
				p.Direction = ParameterDirection.Input;
				cmd.Parameters.Add(p);
				index++;
			}
			cmd.CommandText = sb.ToString();
			//
			if (this.DebugEnabled)
			{
				index = 1;
				sb.AppendLine();
				foreach (KeyValuePair<string, object> parameter in entity.ChangedMap)
				{

					sb.AppendLine(this.PName + "p" + index + "=" + parameter.Value);
					index++;
				}
				foreach (var a in entity.WhereExpression.Parameters)
				{
					sb.AppendLine(this.PName + "p" + index + "=" + a);
					index++;
				}
				CurrentSQL = sb.ToString();
			}
			//

			return cmd.ExecuteNonQuery();
		}
		/// <summary>
		/// 获取数据条数,注意WhereExpression描述的是同一个表
		/// </summary>
		/// <param name="expression">条件表达式,格式如:UserSet.ID.BiggerThan(9).And(UserSet.Age.BiggerThan(12))</param>
		/// <returns>条件所指的数据条数</returns>
		public override long GetCount<T>(WhereExpression expression)
		{
			var cmd = AdoMethod.CreateDbCommand();
			cmd.Connection = this.Connection;
			if (TransactionEnabled)
			{
				cmd.Transaction = this.Transaction;
			}
			StringBuilder retSB = GetCountSQL<T>(expression);
			int index = 0;
			foreach (var a in expression.Parameters)
			{
				index++;
				DbParameter p = AdoMethod.CreateParameter();
				p.ParameterName = PName + "p" + index;
				p.Value = a;
				p.Direction = ParameterDirection.Input;
				cmd.Parameters.Add(p);
			}
			cmd.CommandText = retSB.ToString();
			if (DebugEnabled)
			{
				index = 0;
				retSB.AppendLine();
				foreach (var a in expression.Parameters)
				{
					index++;
					retSB.AppendLine(PName + "p" + index + "=" + a);
				}
				CurrentSQL = retSB.ToString();
			}

			Object obj = cmd.ExecuteScalar();
			return Convert.ToInt64(obj);
		}
		/// <summary>
		/// 通过WhereExpression删除实体,注意WhereExpression描述的是同一个表
		/// </summary>
		/// <param name="expression">条件表达式,格式如:UserSet.ID.BiggerThan(9).And(UserSet.Age.BiggerThan(12))</param>
		/// <returns>受影响的行数</returns>
		public override int Remove<T>(WhereExpression expression)
		{
			var cmd = AdoMethod.CreateDbCommand();
			cmd.Connection = this.Connection;
			if (TransactionEnabled)
			{
				cmd.Transaction = this.Transaction;
			}
			//
			StringBuilder retSB = GetRemoveParametersSQL<T>(expression);
			int index = 0;
			foreach (var a in expression.Parameters)
			{
				index++;
				DbParameter p = AdoMethod.CreateParameter();
				p.ParameterName = PName + "p" + index;
				p.Value = a;
				p.Direction = ParameterDirection.Input;
				cmd.Parameters.Add(p);
			}
			//
			cmd.CommandText = retSB.ToString();
			if (DebugEnabled)
			{
				index = 0;
				retSB.AppendLine();
				foreach (var a in expression.Parameters)
				{
					index++;
					retSB.AppendLine(PName + "p" + index + "=" + a);
				}
				CurrentSQL = retSB.ToString();
			}
			return cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// 执行mql,将结果返回到 List&lt;Dictionary&lt;string,MObject&gt;&gt;
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <returns>List&lt;Dictionary&lt;string,MObject&gt;&gt;</returns>
		public override DictionaryList GetDictionaryList(MQLBase mql)
		{
			string debugSQL = string.Empty;
			if (this._CacheTime > 0)
			{
				debugSQL = mql.ToDebugSQL();
				object result = HttpRuntime.Cache.Get(debugSQL);
				if (result != null)
				{
					return (result as DictionaryList);
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
				p.ParameterName = PName + "p" + index;
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
					sql2 += PName + "p" + index + "=" + parameter;
					index++;
				}
				this.CurrentSQL = sql2;
			}

			DbDataReader reader = cmd.ExecuteReader();
			//
			DictionaryList list = new DictionaryList();
			while (reader.Read())
			{
				Dictionary<string, MObject> entity = new Dictionary<string, MObject>(StringComparer.OrdinalIgnoreCase);

				for (int i = 0; i < reader.VisibleFieldCount; i++)
				{
					string fieldName = reader.GetName(i);
					object value = reader.GetValue(i);
					MObject v = new MObject();
					v.Value = value;
					entity.Add(fieldName, v);
				}
				list.Add(entity);
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
		/// 获取结果的第一行第一列数据到Object
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <returns>Object形式的结果,建议使用GetScalarToMObject</returns>
		public override Object GetScalar(MQLBase mql)
		{
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
				p.ParameterName = PName + "p" + index;
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
					sql2 += PName + "p" + index + "=" + parameter;
					index++;
				}
				this.CurrentSQL = sql2;
			}

			var ret = cmd.ExecuteScalar();

			return ret;
		}
		/// <summary>
		/// 通过mql获取dataset
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <returns>目标数据的dataset</returns>
		public override DataSet GetDataSet(MQLBase mql)
		{
			string debugSQL = string.Empty;
			if (this._CacheTime > 0)
			{
				debugSQL = mql.ToDebugSQL();
				object result = HttpRuntime.Cache.Get(debugSQL);
				if (result != null)
				{
					return (result as DataSet);
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
				p.ParameterName = PName + "p" + index;
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
					sql2 += PName + "p" + index + "=" + parameter;
					index++;
				}
				this.CurrentSQL = sql2;
			}

			var dp = AdoMethod.CreateDataAdapter();
			dp.SelectCommand = cmd;
			DataSet dataSet = new DataSet();
			// 填充dataset
			dp.Fill(dataSet);
			if (this._CacheTime > 0)
			{
				DateTime expire = DateTime.Now.AddSeconds(_CacheTime);
				HttpRuntime.Cache.Insert(debugSQL, dataSet, null, expire, TimeSpan.Zero);

			}
			return dataSet;
		}

		/// <summary>
		/// 执行存储过程,结果反馈到DictionaryList
		/// </summary>
		/// <param name="procName">存储过程名</param>
		/// <param name="parameters">参数组</param>
		/// <returns>DictionaryList</returns>
		public override DictionaryList ExecuteProToDictionaryList(String procName, params DbParameter[] parameters)
		{
			var procDbCommand = AdoMethod.CreateDbCommand();
			procDbCommand.Connection = this.Connection;
			if (TransactionEnabled)
			{
				procDbCommand.Transaction = this.Transaction;
			}
			procDbCommand.CommandType = CommandType.StoredProcedure;
			procDbCommand.CommandText = procName;

			if (parameters != null && parameters.Length > 0)
			{
				procDbCommand.Parameters.AddRange(parameters);
			}
			DictionaryList list = new DictionaryList();
			var reader = procDbCommand.ExecuteReader();
			while (reader.Read())
			{
				Dictionary<string, MObject> entity = new Dictionary<string, MObject>(StringComparer.OrdinalIgnoreCase);
				for (int i = 0; i < reader.VisibleFieldCount; i++)
				{
					string fieldName = reader.GetName(i);
					object value = reader.GetValue(i);
					MObject v = new MObject();
					v.Value = value;
					entity.Add(fieldName, v);
				}
				list.Add(entity);
			}
			reader.Close();
			return list;
		}
		/// <summary>
		/// 执行存储过程,结果反馈到DataSet
		/// </summary>
		/// <param name="procName">存储过程名</param>
		/// <param name="parameters">参数组</param>
		/// <returns>数据的dataset形式</returns>
		public override DataSet ExecuteProToDataSet(String procName, params DbParameter[] parameters)
		{

			var procDbCommand = AdoMethod.CreateDbCommand();
			procDbCommand.Connection = this.Connection;
			if (TransactionEnabled)
			{
				procDbCommand.Transaction = this.Transaction;
			}
			procDbCommand.CommandType = CommandType.StoredProcedure;
			procDbCommand.CommandText = procName;

			if (parameters != null && parameters.Length > 0)
			{

				procDbCommand.Parameters.AddRange(parameters);
			}

			var dp = AdoMethod.CreateDataAdapter();
			dp.SelectCommand = procDbCommand;
			DataSet ds = new DataSet();
			// 填充dataset
			dp.Fill(ds);
			return ds;
		}
		/// <summary>
		/// 执行sql,返回受影响行数
		/// </summary>
		/// <param name="sql">sql语句,其中放变量的地方用@表示</param>
		/// <param name="values">对应变量的值</param>
		/// <returns>受影响行数</returns>
		public override int ExecuteSqlWithNonQuery(string sql, params object[] values)
		{
			var cmd = AdoMethod.CreateDbCommand();
			cmd.Connection = this.Connection;
			if (TransactionEnabled)
			{
				cmd.Transaction = this.Transaction;
			}
			cmd.CommandType = CommandType.Text;
			//
			StringBuilder retSB = new StringBuilder();
			int index = 0;
			for (int i = 0; i < sql.Length; i++)
			{
				Char c = sql[i];
				if ('@' == c)
				{
					index++;
					retSB.Append(PName + "p" + index);

				}
				else
				{
					retSB.Append(c);
				}
			}
			sql = retSB.ToString();
			//
			int index2 = 0;
			cmd.CommandText = sql;
			if (values != null && values.Length > 0)
			{
				foreach (Object obj in values)
				{
					index2++;
					//

					DbParameter p = AdoMethod.CreateParameter();
					p.ParameterName = this.PName + "p" + index2;
					p.Value = obj;
					p.Direction = ParameterDirection.Input;
					cmd.Parameters.Add(p);

					//


				}
			}
			//
			if (index != index2)
			{
				throw new ArgumentException("params object[] values 和sql语句中指定的位置不一致");
			}
			return cmd.ExecuteNonQuery();
		}
		/// <summary>
		/// 通过mql获取json形式的结果
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <returns>json形式的查询结果</returns>
		public override string GetJson(MQLBase mql)
		{
			string debugSQL = string.Empty;
			if (this._CacheTime > 0)
			{
				debugSQL = mql.ToDebugSQL();
				object result = HttpRuntime.Cache.Get(debugSQL);
				if (result != null)
				{
					return (result.ToString());
				}
			}
			string sql2 = mql.ToParametersSQL();
			var cmd = AdoMethod.CreateDbCommand();
			cmd.CommandType = CommandType.Text;
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
			var list = Util.JsonUtil.DataReaderToJson(reader);
			if (this._CacheTime > 0)
			{
				DateTime expire = DateTime.Now.AddSeconds(_CacheTime);
				HttpRuntime.Cache.Insert(debugSQL, list, null, expire, TimeSpan.Zero);

			}
			return list;
		}
		/// <summary>
		/// 执行sql,返回json结果
		/// </summary>
		/// <param name="sql">sql语句</param>
		/// <param name="values">参数组</param>
		/// <returns>sql查询的结果,json格式</returns>
		public override string ExecuteSqlToJson(string sql, params object[] values)
		{
			string debugSQL = string.Empty;
			if (this._CacheTime > 0)
			{
				string key = sql;
				foreach (var a in values)
				{
					key += a.ToString();
				}
				debugSQL = key;
				object result = HttpRuntime.Cache.Get(debugSQL);
				if (result != null)
				{
					return (result.ToString());
				}
			}
			//
			var cmd = AdoMethod.CreateDbCommand();
			cmd.Connection = this.Connection;
			if (TransactionEnabled)
			{
				cmd.Transaction = this.Transaction;
			}
			cmd.CommandType = CommandType.Text;
			//

			StringBuilder retSB = new StringBuilder();
			int index = 0;
			for (int i = 0; i < sql.Length; i++)
			{
				Char c = sql[i];
				if ('@' == c)
				{
					index++;
					retSB.Append(PName + "p" + index);

				}
				else
				{
					retSB.Append(c);
				}
			}
			sql = retSB.ToString();
			//
			int index2 = 0;
			cmd.CommandText = sql;
			if (values != null && values.Length > 0)
			{
				foreach (Object obj in values)
				{
					index2++;
					DbParameter p = AdoMethod.CreateParameter();
					p.ParameterName = this.PName + "p" + index2;
					p.Value = obj;
					p.Direction = ParameterDirection.Input;
					cmd.Parameters.Add(p);

				}
			}
			//
			if (index != index2)
			{
				throw new ArgumentException("params object[] values 和sql语句中指定的位置不一致");
			}
			DbDataReader reader = cmd.ExecuteReader();
			string data = JsonUtil.DataReaderToJson(reader);
			if (this._CacheTime > 0)
			{
				DateTime expire = DateTime.Now.AddSeconds(_CacheTime);
				HttpRuntime.Cache.Insert(debugSQL, data, null, expire, TimeSpan.Zero);

			}
			return data;
		}
		/// <summary>
		/// 执行一条sql查询第一行第一列
		/// </summary>
		/// <param name="sql">sql语句</param>
		/// <param name="values">参数列表</param>
		/// <returns>结果</returns>
		public override object ExecuteSqlToScalar(string sql, params object[] values)
		{
			var cmd = AdoMethod.CreateDbCommand();
			cmd.Connection = this.Connection;
			if (TransactionEnabled)
			{
				cmd.Transaction = this.Transaction;
			}
			cmd.CommandType = CommandType.Text;
			//
			StringBuilder retSB = new StringBuilder();
			int index = 0;
			for (int i = 0; i < sql.Length; i++)
			{
				Char c = sql[i];
				if ('@' == c)
				{
					index++;
					retSB.Append(PName + "p" + index);

				}
				else
				{
					retSB.Append(c);
				}
			}
			sql = retSB.ToString();
			//
			int index2 = 0;
			cmd.CommandText = sql;
			if (values != null && values.Length > 0)
			{
				foreach (Object obj in values)
				{
					index2++;
					//
					DbParameter p = AdoMethod.CreateParameter();
					p.ParameterName = this.PName + "p" + index2;
					p.Value = obj;
					p.Direction = ParameterDirection.Input;
					cmd.Parameters.Add(p);
					//
				}
			}
			//
			if (index != index2)
			{
				throw new ArgumentException("params object[] values 和sql语句中指定的位置不一致");
			}
			return cmd.ExecuteScalar();
		}

		/// <summary>
		///  执行存储过程,返回受影响的行数
		/// </summary>
		/// <param name="procName">存储过程名</param>
		/// <param name="parameters"></param>
		/// <returns>受影响的行数</returns>
		public override int ExecuteProWithNonQuery(String procName, params DbParameter[] parameters)
		{

			var procDbCommand = AdoMethod.CreateDbCommand();
			procDbCommand.Connection = this.Connection;
			if (TransactionEnabled)
			{
				procDbCommand.Transaction = this.Transaction;
			}
			procDbCommand.CommandType = CommandType.StoredProcedure;
			procDbCommand.CommandText = procName;

			int num = -1;
			if (parameters != null && parameters.Length > 0)
			{

				procDbCommand.Parameters.AddRange(parameters);

			}
			num = procDbCommand.ExecuteNonQuery();
			return num;
		}
		/// <summary>
		/// 执行sql,将结果返回到自定义List T ,T只要为类就可以.
		/// </summary>
		/// <param name="sql">执行的语句,其中放变量的地方用@表示</param>
		/// <param name="values">对应变量的值</param>
		/// <returns>List&lt;T&gt;</returns>
		public override List<T> ExecuteSqlToOwnList<T>(string sql, params object[] values)
		{
			string debugSQL = string.Empty;
			if (this._CacheTime > 0)
			{
				string key = sql;
				foreach (var a in values)
				{
					key += a.ToString();
				}
				debugSQL = key;
				object result = HttpRuntime.Cache.Get(debugSQL);
				if (result != null)
				{
					return (result as List<T>);
				}
			}
			var cmd = AdoMethod.CreateDbCommand();
			cmd.Connection = this.Connection;
			if (TransactionEnabled)
			{
				cmd.Transaction = this.Transaction;
			}
			cmd.CommandType = CommandType.Text;
			//
			StringBuilder retSB = new StringBuilder();
			int index = 0;
			for (int i = 0; i < sql.Length; i++)
			{
				Char c = sql[i];
				if ('@' == c)
				{
					index++;
					retSB.Append(PName + "p" + index);

				}
				else
				{
					retSB.Append(c);
				}
			}
			sql = retSB.ToString();
			//
			int index2 = 0;
			cmd.CommandText = sql;
			if (values != null && values.Length > 0)
			{
				foreach (Object obj in values)
				{
					index2++;
					DbParameter p = AdoMethod.CreateParameter();
					p.ParameterName = this.PName + "p" + index2;
					p.Value = obj;
					p.Direction = ParameterDirection.Input;
					cmd.Parameters.Add(p);
				}
			}
			//
			if (index != index2)
			{
				throw new ArgumentException("params object[] values 和sql语句中指定的位置不一致");
			}
			DbDataReader reader = cmd.ExecuteReader();
			List<T> list = new List<T>();
			while (reader.Read())
			{
				T data = MoonFastInvoker<T>.GetTFrom(reader);
				list.Add(data);

			}
			reader.Close();
			if (this._CacheTime > 0)
			{
				DateTime expire = DateTime.Now.AddSeconds(_CacheTime);
				HttpRuntime.Cache.Insert(debugSQL, list, null, expire, TimeSpan.Zero);

			}
			return list;
			//
		}
		/// <summary>
		/// 执行存储过程,结果反馈到自定义List,只要T是类就可以了.
		/// </summary>
		/// <param name="procName">存储过程名</param>
		/// <param name="parameters">参数组</param>
		/// <returns>List&lt;T&gt;</returns>
		public override List<T> ExecuteProToOwnList<T>(String procName, params DbParameter[] parameters)
		{

			var procDbCommand = AdoMethod.CreateDbCommand();
			procDbCommand.Connection = this.Connection;
			if (TransactionEnabled)
			{
				procDbCommand.Transaction = this.Transaction;
			}
			procDbCommand.CommandType = CommandType.StoredProcedure;
			procDbCommand.CommandText = procName;

			if (parameters != null && parameters.Length > 0)
			{
				procDbCommand.Parameters.AddRange(parameters);
			}
			//
			DbDataReader reader = procDbCommand.ExecuteReader();
			List<T> list = new List<T>();
			while (reader.Read())
			{
				T data = MoonFastInvoker<T>.GetTFrom(reader);
				list.Add(data);

			}
			reader.Close();
			return list;
			//
		}
		/// <summary>
		/// 执行sql,将结果返回到<code>List&lt;Dictionary&lt;string,MObject&gt;&gt;</code>
		/// </summary>
		/// <param name="sql">sql语句,其中的值,用@表示</param>
		/// <param name="values">对应的值</param>
		/// <returns>所要数据</returns>
		public override DictionaryList ExecuteSqlToDictionaryList(string sql, params object[] values)
		{
			string debugSQL = string.Empty;
			if (this._CacheTime > 0)
			{
				string key = sql;
				foreach (var a in values)
				{
					key += a.ToString();
				}
				debugSQL = key;
				object result = HttpRuntime.Cache.Get(debugSQL);
				if (result != null)
				{
					return (result as DictionaryList);
				}
			}

			var cmd = AdoMethod.CreateDbCommand();
			cmd.Connection = this.Connection;
			if (TransactionEnabled)
			{
				cmd.Transaction = this.Transaction;
			}
			cmd.CommandType = CommandType.Text;
			//
			StringBuilder retSB = new StringBuilder();
			int index = 0;
			for (int i = 0; i < sql.Length; i++)
			{
				Char c = sql[i];
				if ('@' == c)
				{
					index++;
					retSB.Append(PName + "p" + index);

				}
				else
				{
					retSB.Append(c);
				}
			}
			sql = retSB.ToString();
			//
			int index2 = 0;
			cmd.CommandText = sql;
			if (values != null && values.Length > 0)
			{
				foreach (Object obj in values)
				{
					index2++;
					DbParameter p = AdoMethod.CreateParameter();
					p.ParameterName = this.PName + "p" + index2;
					p.Value = obj;
					p.Direction = ParameterDirection.Input;
					cmd.Parameters.Add(p);
				}
			}
			//
			if (index != index2)
			{
				throw new ArgumentException("params object[] values 和sql语句中指定的位置不一致");
			}
			DbDataReader reader = cmd.ExecuteReader();
			//
			DictionaryList list = new DictionaryList();
			while (reader.Read())
			{
				Dictionary<string, MObject> entity = new Dictionary<string, MObject>(StringComparer.OrdinalIgnoreCase);

				for (int i = 0; i < reader.VisibleFieldCount; i++)
				{
					string fieldName = reader.GetName(i);
					object value = reader.GetValue(i);
					MObject v = new MObject();
					v.Value = value;
					entity.Add(fieldName, v);
				}
				list.Add(entity);
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
		/// 执行sql,将结果返回到<code>DataSet</code>
		/// </summary>
		/// <param name="sql">执行的语句,其中放变量的地方用@表示</param>
		/// <param name="values">对应变量的值</param>
		/// <returns>DataSet</returns>
		public override DataSet ExecuteSqlToDataSet(string sql, params object[] values)
		{
			string debugSQL = string.Empty;
			if (this._CacheTime > 0)
			{
				string key = sql;
				foreach (var a in values)
				{
					key += a.ToString();
				}
				debugSQL = key;
				object result = HttpRuntime.Cache.Get(debugSQL);
				if (result != null)
				{
					return (result as DataSet);
				}
			}
			var cmd = AdoMethod.CreateDbCommand();
			cmd.Connection = this.Connection;
			if (TransactionEnabled)
			{
				cmd.Transaction = this.Transaction;
			}
			cmd.CommandType = CommandType.Text;
			//
			StringBuilder retSB = new StringBuilder();
			int index = 0;
			for (int i = 0; i < sql.Length; i++)
			{
				Char c = sql[i];
				if ('@' == c)
				{
					index++;
					retSB.Append(PName + "p" + index);

				}
				else
				{
					retSB.Append(c);
				}
			}
			sql = retSB.ToString();
			//
			int index2 = 0;
			cmd.CommandText = sql;
			if (values != null && values.Length > 0)
			{
				foreach (Object obj in values)
				{
					index2++;
					DbParameter p = AdoMethod.CreateParameter();
					p.ParameterName = this.PName + "p" + index2;
					p.Value = obj;
					p.Direction = ParameterDirection.Input;
					cmd.Parameters.Add(p);
				}
			}
			if (index != index2)
			{
				throw new ArgumentException("params object[] values 和sql语句中指定的位置不一致");
			}
			//
			var adapter = AdoMethod.CreateDataAdapter();
			adapter.SelectCommand = cmd;
			DataSet dataSet = new DataSet();
			adapter.Fill(dataSet);
			if (this._CacheTime > 0)
			{
				DateTime expire = DateTime.Now.AddSeconds(_CacheTime);
				HttpRuntime.Cache.Insert(debugSQL, dataSet, null, expire, TimeSpan.Zero);

			}
			return dataSet;
		}
		/// <summary>
		/// 获取一个分页的自定义实体集(注意:此方法在SharedDb引擎中未能提供,请自行实现)
		/// </summary>
		/// <param name="sql">执行的语句,其中放变量的地方仅仅用@表示(eg:select * from user wehre id>@ and age=@)</param>
		/// <param name="parameters">对应参数列表</param>
		/// <param name="sumPageCount">总页数</param><param name="sumDataCount">总数据条数</param>
		/// <param name="pageIndex">页码</param>
		/// <param name="onePageDataCount">每页数据的条数</param>
		/// <param name="oneOrderbyFieldName">sqlserver中会用到的排序字段(查询结果中一个字段),其他类型数据库则填写null</param>
		/// <typeparam name="T">注意泛型T:new()</typeparam>
		/// <returns>自定义实体集</returns>
		public override List<T> GetPagerToOwnList<T>(string sql, object[] parameters, out int sumPageCount, out int sumDataCount, int pageIndex, int onePageDataCount, string oneOrderbyFieldName)
		{

			throw new NotImplementedException("注意:此方法在SharedDb引擎中未能提供,请自行实现");
		}
		/// <summary>
		/// 获取一个分页的自定义实体集(注意:此方法在SharedDb引擎中未能提供,请自行实现)
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <param name="sumPageCount">总页数</param>
		/// <param name="sumDataCount">总数据条数</param>
		/// <param name="pageIndex">页码</param>
		/// <param name="onePageDataCount">每页数据的条数</param>
		/// <param name="oneOrderbyFieldName">填写null(</param>
		/// <returns>自定义实体集</returns>
		public override List<T> GetPagerToOwnList<T>(MQLBase mql, out int sumPageCount, out int sumDataCount, int pageIndex, int onePageDataCount, string oneOrderbyFieldName)
		{
			throw new NotImplementedException("注意:此方法在SharedDb引擎中未能提供,请自行实现");
		}
		/// <summary>
		/// 获取一个分页的DataSet(注意:此方法在SharedDb引擎中未能提供,请自行实现)
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <param name="sumPageCount">总页数</param>
		/// <param name="sumDataCount">总数据条数</param>
		/// <param name="pageIndex">页码</param>
		/// <param name="onePageDataCount">每页数据的条数</param>
		/// <param name="oneOrderbyFieldName">sqlserver中会用到的排序字段(查询结果中一个字段),其他类型数据库则填写null</param>
		/// <returns>分页的DataSet</returns>
		public override DataSet GetPagerToDataSet(MQLBase mql, out int sumPageCount, out int sumDataCount, int pageIndex, int onePageDataCount, string oneOrderbyFieldName)
		{
			throw new NotImplementedException("注意:此方法在SharedDb引擎中未能提供,请自行实现");
		}

		/// <summary>
		/// 获取一个分页的DataSet(注意:此方法在SharedDb引擎中未能提供,请自行实现)
		/// </summary>
		/// <param name="sql">执行的语句,其中放变量的地方仅仅用@表示(eg:select * from user wehre id>@ and age=@)</param>
		/// <param name="parameters">对应的参数列表</param>
		/// <param name="sumPageCount">总页数</param>
		/// <param name="sumDataCount">总数据条数</param>
		/// <param name="pageIndex">页码</param>
		/// <param name="onePageDataCount">每页数据的条数</param>
		/// <param name="oneOrderbyFieldName">sqlserver中会用到的排序字段(查询结果中一个字段),其他类型数据库则填写null</param>
		/// <returns>分页的DataSet</returns>
		public override DataSet GetPagerToDataSet(string sql, object[] parameters, out int sumPageCount, out int sumDataCount, int pageIndex, int onePageDataCount, string oneOrderbyFieldName)
		{
			throw new NotImplementedException("注意:此方法在SharedDb引擎中未能提供,请自行实现");
		}
		/// <summary>
		/// 获取一个分页DictionaryList(注意:此方法在SharedDb引擎中未能提供,请自行实现)
		/// </summary>
		/// <param name="mql">mql语句</param>
		/// <param name="sumPageCount">总页数</param>
		/// <param name="sumDataCount">总数据条数</param>
		/// <param name="pageIndex">页码</param>
		/// <param name="onePageDataCount">每页数据的条数</param>
		/// <param name="oneOrderbyFieldName">填写null</param>
		/// <returns>DictionaryList</returns>
		public override DictionaryList GetPagerToDictionaryList(MQLBase mql, out int sumPageCount, out int sumDataCount, int pageIndex, int onePageDataCount, string oneOrderbyFieldName)
		{
			throw new NotImplementedException("注意:此方法在SharedDb引擎中未能提供,请自行实现");
		}
		/// <summary>
		/// 获取一个分页DictionaryList,不支持sqlserver2000(注意:此方法在SharedDb引擎中未能提供,请自行实现)
		/// </summary>
		/// <param name="sql">执行的语句,其中放变量的地方仅仅用@表示(eg:select * from user wehre id>@ and age=@)</param>
		/// <param name="parameters">对应参数列表</param>
		/// <param name="sumPageCount">总页数</param>
		/// <param name="sumDataCount">总数据条数</param>
		/// <param name="pageIndex">页码</param>
		/// <param name="onePageDataCount">每页数据的条数</param>
		/// <param name="oneOrderbyFieldName">sqlserver中会用到的排序字段(查询结果中一个字段,如:xxid desc,或 xxid asc),其他类型数据库则填写null</param>
		/// <returns>DictionaryList</returns>
		public override DictionaryList GetPagerToDictionaryList(string sql, object[] parameters, out int sumPageCount, out int sumDataCount, int pageIndex, int onePageDataCount, string oneOrderbyFieldName)
		{
			throw new NotImplementedException("注意:此方法在SharedDb引擎中未能提供,请自行实现");
		}
	}
}

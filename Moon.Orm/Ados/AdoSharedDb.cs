using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using Moon.Orm.Util;
using System.Reflection;
using System.Collections.Generic;

namespace Moon.Orm
{
	/// <summary>
	/// 共用的Db
	/// </summary>
	public class AdoSharedDb : DbAdoMethod
	{
		static readonly Dictionary<string, DbProviderFactory> DbProviderFactory_MAP = new Dictionary<string, DbProviderFactory>();
		static readonly object DbProviderFactory_MAP_LOCK = new object();
		//static AdoSharedDb(){
		//	if (SecurityUtil.IsIrcLegal()==false) {
		//		string tip="提示:moon.orm可免费使用,但需要授权(所以你暂时不能使用AdoSharedDb).请联系qsmy_qin@163.com免费授权";
		//		LogUtil.Error(tip);
		//		throw new Exception(tip);
		//	}
		//}
		/// <summary>
		/// 构造
		/// </summary>
		/// <param name="linkString">连接字符串</param>
		/// <param name="providerDllName">provider dll name(带有后缀的)</param>
		public AdoSharedDb(string linkString, string providerDllName)
			: base(linkString)
		{
			lock (DbProviderFactory_MAP_LOCK)
			{
				if (DbProviderFactory_MAP.ContainsKey(providerDllName))
				{
					_dbProviderFactory = DbProviderFactory_MAP[providerDllName];
					return;
				}
			}
			var dllPath = GlobalData.DLL_EXE_DIRECTORY_PATH + providerDllName;
			if (System.IO.File.Exists(dllPath))
			{
				var ass = Assembly.LoadFrom(dllPath);
				var allTypes = ass.GetTypes();
				Type dbProviderFactoryType = null;

				for (int i = 0; i < allTypes.Length; i++)
				{
					var tp = allTypes[i];
					if (tp.IsSubclassOf(typeof(DbProviderFactory)))
					{
						dbProviderFactoryType = tp;
						break;
					}
				}

				if (dbProviderFactoryType == null)
				{
					string error = providerDllName + "中不存在DbProviderFactory";
					LogUtil.Error(error);
					throw new Exception(error);
				}

				var instance = ass.CreateInstance(dbProviderFactoryType.FullName) as DbProviderFactory;
				_dbProviderFactory = instance;
				lock (DbProviderFactory_MAP_LOCK)
				{
					DbProviderFactory_MAP[providerDllName] = instance;
				}
			}
			else
			{
				throw new Exception(GlobalData.DLL_EXE_DIRECTORY_PATH + "文件夹下不存在" + providerDllName);
			}
		}



		DbProviderFactory _dbProviderFactory;

		/// <summary>
		/// 创建一个参数
		/// </summary>
		/// <returns>该数据库类型的DbParameter</returns>
		public override DbParameter CreateParameter()
		{
			return _dbProviderFactory.CreateParameter();
		}
		/// <summary>
		/// 创建一个dbcommand
		/// </summary>
		/// <returns>该数据库类型的DbCommand</returns>
		public override DbCommand CreateDbCommand()
		{
			return _dbProviderFactory.CreateCommand();
		}
		/// <summary>
		/// 创建一个DbCommandBuilder
		/// </summary>
		/// <returns>该数据库类型的DbCommandBuilder</returns>
		public override DbCommandBuilder CreateCommandBuilder()
		{
			return _dbProviderFactory.CreateCommandBuilder();
		}
		/// <summary>
		/// 创建一个连接
		/// </summary>
		/// <returns>该数据库类型的DbConnection</returns>
		public override DbConnection CreateConnection()
		{
			return _dbProviderFactory.CreateConnection();
		}
		/// <summary>
		/// 创建一个数据适配器
		/// </summary>
		/// <returns>该数据库类型的DbDataAdapter</returns>
		public override DbDataAdapter CreateDataAdapter()
		{
			return _dbProviderFactory.CreateDataAdapter();
		}
	}
}

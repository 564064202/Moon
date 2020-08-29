/*
 * 由SharpDevelop创建。
 * 用户： 秦仕川
 * 日期: 2013-9-3
 * 时间: 10:33
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using Moon.Orm.Util;
using System.Reflection;

namespace Moon.Orm
{
    /// <summary>
    /// Mysql的Ado.net相关的方法
    /// </summary>
    internal class AdoMysql : DbAdoMethod
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="linkString">连接字符串</param>
        public AdoMysql(string linkString)
            : base(linkString)
        {

        }
        static readonly DbProviderFactory _dbProviderFactory;
        static AdoMysql()
        {
            try
            {
                //if (SecurityUtil.IsIrcLegal()) {
                try
                {
                    _dbProviderFactory = DbProviderFactories.GetFactory("MySql.Data.MySqlClient");
                }
                catch (Exception)
                {
                    LogUtil.Warning("MySql在使用DbProviderFactories.GetFactory初始化时失败,下面将尝试从DLL_EXE_DIRECTORY反射获取..,");
                    var mysqldllPath = GlobalData.DLL_EXE_DIRECTORY_PATH + "MySql.Data.dll";
                    if (System.IO.File.Exists(mysqldllPath))
                    {
                        var ass = Assembly.LoadFrom(mysqldllPath);
                        var instance = ass.CreateInstance("MySql.Data.MySqlClient.MySqlClientFactory") as DbProviderFactory;
                        if (instance == null)
                        {
                            throw new Exception("创建MySqlClientFactory失败");
                        }
                        else
                        {
                            _dbProviderFactory = instance;
                        }
                    }
                    else
                    {
                        throw new Exception(GlobalData.DLL_EXE_DIRECTORY_PATH + "文件夹下不存在MySql.Data.dll");
                    }
                }
                if (_dbProviderFactory == null)
                {
                    throw new Exception("DbProviderFactories初始化失败,如日志功能没有关闭,请您请查看日志");
                }
                //}
                //            else {
                //	string tip="提示:moon.orm可免费使用,但需要授权(所以你暂时不能使用mysql).请联系qsmy_qin@163.com免费授权";
                //	LogUtil.Error(tip);
                //	throw new Exception(tip);
                //}

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                string tip = "提示:是否含有mysql.data.dll,版本是否一致?,请查看http://files.cnblogs.com/files/humble/d.pdf 中的常见问题";
                LogUtil.Exception(ex);
                throw new Exception("DbProviderFactory初始化时,MySql发生异常:\r\n" + msg + "\r\n" + tip); ;
            }

        }
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

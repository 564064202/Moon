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
using MySql.Data.MySqlClient;

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
        /// <summary>
        /// 创建一个参数
        /// </summary>
        /// <returns>该数据库类型的DbParameter</returns>
        public override DbParameter CreateParameter()
        {
            return new MySqlParameter();
        }
        /// <summary>
        /// 创建一个dbcommand
        /// </summary>
        /// <returns>该数据库类型的DbCommand</returns>
        public override DbCommand CreateDbCommand()
        {
            return new MySqlCommand();
        }
        /// <summary>
        /// 创建一个DbCommandBuilder
        /// </summary>
        /// <returns>该数据库类型的DbCommandBuilder</returns>
        public override DbCommandBuilder CreateCommandBuilder()
        {
            return new MySqlCommandBuilder();
        }
        /// <summary>
        /// 创建一个连接
        /// </summary>
        /// <returns>该数据库类型的DbConnection</returns>
        public override DbConnection CreateConnection()
        {
            return new MySqlConnection();
        }
        /// <summary>
        /// 创建一个数据适配器
        /// </summary>
        /// <returns>该数据库类型的DbDataAdapter</returns>
        public override DbDataAdapter CreateDataAdapter()
        {
            return new MySqlDataAdapter();
        }
    }
}

using System;
using System.Collections.Generic;

using System.Text;
using Moon.Orm;
using System.Data;

namespace Moon.CodeBuider
{
    public abstract class DbObjectBase
    {
        protected string _dbType=string.Empty;
        
        protected bool _needBrackets = false;
        public Moon.Orm.DbType DbType_{
        	get;
        	set;
        }
        /// <summary>
        /// 数据库类型，对应于实体代码中的 DbType.SqlServer 枚举信息
        /// </summary>
        public string DbTypeString
        {
            get { return _dbType; }
        }

        /// <summary>
        /// 是否在表名和字段名上加中括号，Mysql中表名字段名加了括号会报错
        /// </summary>
        public bool NeedBrackets
        {
            get { return _needBrackets; }
        }

        private string _objectMarker = string.Empty;

        /// <summary>
        /// 表或字段的修饰符，如Sqlserver:[TableName],Mysql：`TableName`
        /// 该属性Sqlserver应该是[{0}],mysql应该是`{0}`
        /// </summary>
        protected string ObjectMarker
        {
            get { return _objectMarker; }
            set { _objectMarker = value; }
        }

        protected Db _db = null;

        /// <summary>
        /// 带数据库实体的构造
        /// </summary>
        /// <param name="db"></param>
        public DbObjectBase(Db db)
        {
            _db = db;
        }

        public Db CurrentDb
        {
            get { return _db; }
        }
        /// <summary>
        /// 获取表名或字段名，带修饰符
        /// </summary>
        /// <param name="tableOrColumnName"></param>
        /// <returns></returns>
        public string GetTableOrColumnName(string tableOrColumnName)
        {
            return string.Format(ObjectMarker, /*GenUtil.UpperFirstChar*/(tableOrColumnName));
        }

        /// <summary>
        /// 获取数据表信息
        /// </summary>
        /// <returns></returns>
        public abstract DataTable GetTables();
        /// <summary>
        /// 获取试图信息
        /// </summary>
        /// <returns></returns>
        public abstract DataTable GetViews();
        /// <summary>
        /// 获取表中的字段信息
        /// </summary>
        /// <returns></returns>
        public abstract List<ColumnInfo> GetTableColunms(string tableName);

        public abstract string GetCsTypeByDbType(string dataType, string colomnType, bool isNullable);

        //public abstract int GetTablePKCount(string tableName);

    }
}

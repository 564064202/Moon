using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moon.Orm;
using System.Data;

namespace Moon.CodeBuider
{
    public class DbObjectByOracle : DbObjectBase
    {
        public DbObjectByOracle(string strConnection)
            : base(new SqlServer(strConnection))//这里要改成Oracle的Db实例
        {
            this._dbType = "DbType.Oracle";
            this._needBrackets = false;
        }
        /// <summary>
        /// 获取数据表信息,由于没有Oracle环境，语句没有测试过
        /// </summary>
        /// <returns></returns>
        public override DataTable GetTables()
        {
            string qryStr = "select table_name from user_all_tables";

            DataSet ds = CurrentDb.ExecuteSqlToDataSet(qryStr);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
        /// <summary>
        /// 获取试图信息
        /// </summary>
        /// <returns></returns>
        public override DataTable GetViews()
        {
            string qryStr = "";

            DataSet ds = CurrentDb.ExecuteSqlToDataSet(qryStr);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
        /// <summary>
        /// 获取表中的字段信息
        /// </summary>
        /// <returns></returns>
        public override List<ColumnInfo> GetTableColunms(string tableName)
        {
            List<ColumnInfo> list = new List<ColumnInfo>();

            //需要修改成查询列信息的语句
            string qryStr = @"select * from sys.user_tab_columns";
            DataSet ds = CurrentDb.ExecuteSqlToDataSet(qryStr);

            if (ds != null && ds.Tables.Count > 0)
            {
                ColumnInfo col = null;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    col = ColumnInfo.DrToObj(dr);
                    list.Add(col);
                }
            }
            return list;
        }

        public  int GetTablePKCount(string tableName)
        {
            return -1;
        }

        public override string GetCsTypeByDbType(string dataType, string colomnType, bool isNullable)
        {
            string csType;
            switch (dataType)
            {
                case "char":
                case "nchar":
                case "varchar":
                case "nvarchar":
                case "text":
                case "ntext":
                case "uniqueidentifier":
                    csType = "string";
                    break;
                case "bit":
                    csType = "bool";
                    break;
                case "datetime":
                case "smalldatetime":
                    csType = "DateTime";
                    break;
                case "tinyint":
                    csType = "byte";
                    break;
                case "smallint":
                    csType = "short";
                    break;
                case "int":
                    csType = "int";
                    break;
                case "bigint":
                    csType = "long";
                    break;
                //
                case "decimal":
                case "numeric":
                case "money":
                case "smallmoney":
                case "real":
                case "float":
                case "double":
                    csType = "decimal";
                    break;
                case "image":
                case "binary":
                case "nbinary":
                case "timestamp":
                case "varbinary":
                    csType = "byte[]";
                    break;
                case "sql_variant":
                    csType = dataType;
                    break;
                default:
                    throw new Exception("Program don't process this data type:" + dataType);
            }
            return isNullable && !("string,object,byte[]".Contains(csType.ToString().ToLower())) ? csType.ToString() + "?" : csType.ToString(); ;
        }

    }
}

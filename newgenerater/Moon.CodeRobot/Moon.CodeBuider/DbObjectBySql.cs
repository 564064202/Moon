using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Moon.Orm;

namespace Moon.CodeBuider
{
    public class DbObjectBySql : DbObjectBase
    {
        public DbObjectBySql(string strConnection)
            : base(new SqlServer(strConnection))
        {
            this._dbType = "DbType.SqlServer";
            this.ObjectMarker = "[{0}]";
        }
        /// <summary>
        /// 获取数据表信息
        /// </summary>
        /// <returns></returns>
        public override DataTable GetTables()
        {
            string qryStr = "select name from sysobjects where xtype='U' and [name] not in ('sysdiagrams','DtProperties') order by name";

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
            string qryStr = "select name from sysobjects where xtype='V' order by name";

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
//            string qryStr = @"select a.name colname,b.name datatype,a.length,a.iscomputed,a.isnullable,a.prec,a.scale,pk.colid isPk,fk.constraint_column_id isFk
//                               from syscolumns a left join systypes b on a.xusertype=b.xusertype 
//                               left join sysindexkeys pk on a.colid=pk.colid and a.id=pk.id
//                               left join sys.foreign_key_columns fk on parent_object_id=a.id and fk.constraint_column_id=a.colid
//                               where a.id=object_id('" + tableName + "')";



            string qryStr = @"SELECT
                        --TableName=OBJECT_NAME(T.object_id),
                        ColumnName=T.name,
                        IsPk=case when exists(select c.name 
											 from sysindexes i  
											 join sysindexkeys k on i.id = k.id and i.indid = k.indid  
											 join sysobjects o on i.id = o.id  
											 join syscolumns c on i.id=c.id and k.colid = c.colid  
											 where o.xtype = 'U'  
											 and exists(select 1 from sysobjects where  xtype = 'PK'  and name = i.name)  
											and c.name=T.name and c.id=T.object_id) THEN 1 ELSE 0 END,
                        IsFk=case when exists(SELECT 1 FROM sys.foreign_key_columns where parent_object_id=T.object_id and parent_column_id=t.column_id) THEN 1 ELSE 0 END,
                        IsIdentity=CASE T.is_identity  WHEN 1 THEN 1 ELSE 0 END,
                        IsComputed=CASE T.is_computed WHEN 1 THEN 1 ELSE 0 END,
                        DataType=(SELECT name FROM sys.types WHERE user_type_id = T.user_type_id),
                        ColumnType='',
                        Length= T.PRECISION,
                        Scale = T.Scale,
                        IsNullable = CASE T.is_nullable  WHEN 1 THEN 1 ELSE 0 END,
                        DefaultValue= ISNULL((SELECT definition from sys.default_constraints where object_id = T.default_object_id),''),
                        Comments=(SELECT VALUE FROM sys.extended_properties WHERE major_id = T.OBJECT_ID AND minor_id  =T.column_id)
                        FROM sys.COLUMNS T
                        left JOIN sys.objects O ON T.object_id = O.object_id AND O.type = 'U'
                        where t.object_id=object_id('" + tableName+"') ORDER BY T.column_id";
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

        public   int GetTablePKCount(string tableName)
        {
            string qryStr = @"select count(1) 
							    from sysindexes i  
							    join sysindexkeys k on i.id = k.id and i.indid = k.indid  
							    join sysobjects o on i.id = o.id  
							    join syscolumns c on i.id=c.id and k.colid = c.colid  
							    where o.xtype = 'U'  
							    and exists(select 1 from sysobjects where  xtype = 'PK'  and name = i.name)  
						        and c.id=object_id('" + tableName + "')";

            DataSet ds = CurrentDb.ExecuteSqlToDataSet(qryStr);

            if (ds != null && ds.Tables.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            return -1;
        }

        public override string GetCsTypeByDbType(string dataType, string colomnType, bool isNullable)
        {
            object csType;
            switch (dataType)
            {
                case "bigint":
                    csType = System.Data.DbType.Int64;
                    break;
                case "decimal":
                    csType = System.Data.DbType.Decimal;
                    break;
                case "int":
                    csType = System.Data.DbType.Int32;
                    break;
                case "real":
                    csType = System.Data.DbType.Single;
                    break;
                case "float":
                    csType = System.Data.DbType.Double;
                    break;
                case "bit":
                    csType = System.Data.DbType.Boolean;
                    break;
                case "smallint ":
                    csType = System.Data.DbType.Int16;
                    break;
                case "tinyint":
                    csType = System.Data.DbType.Byte;
                    break;
                case "money":
                    csType = System.Data.DbType.Decimal;
                    break;
                case "numeric":
                    csType = System.Data.DbType.Decimal;
                    break;
                case "smallmoney":
                    csType = System.Data.DbType.Single;
                    break;     
                case "time":
                    csType = System.Data.DbType.Time;
                    break;
                case "smalldatetime":
                case "date":
                case "datetime":
                    csType = System.Data.DbType.DateTime;
                    break;
                case "nvarchar":
                    csType = System.Data.DbType.String;
                    break;
                case "varbinary":
                    csType = System.Data.DbType.Object;
                    break;
                case "varchar":
                    csType = System.Data.DbType.String;
                    break;
                case "nchar":
                    csType = System.Data.DbType.String;
                    break;
                case "char":
                    csType = System.Data.DbType.String;
                    break;
                case "text":
                    csType = System.Data.DbType.String;
                    break;
                case "ntext":
                    csType = System.Data.DbType.String;
                    break;
                case "uniqueidentifier":
                    csType = System.Data.DbType.Guid;
                    break;
                case "smallint":
                    csType = System.Data.DbType.Int16;
                    break;
                case "unsigned":
                    csType = System.Data.DbType.Decimal;
                    break;
                case "timestamp":
                    csType = "TimeSpan";
                    break;
                case "image":
                    csType = "byte[]";
                    break;
                default:
                    csType = "object";
                    break;
            }
            return isNullable && !("string,object,byte[]".Contains(csType.ToString().ToLower())) ? csType.ToString() + "?" : csType.ToString(); ;
        }

    }
}

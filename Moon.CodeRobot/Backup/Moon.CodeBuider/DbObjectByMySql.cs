using System;
using System.Collections.Generic;

using System.Text;
using Moon.Orm;
using System.Data;

namespace Moon.CodeBuider
{
	public class DbObjectByMySql : DbObjectBase
	{
		public DbObjectByMySql(string strConnection)
			: base(new MySql(strConnection))
		{
			this._dbType = "DbType.MySql";
			this._needBrackets = false;
			this.ObjectMarker = "`{0}`";
			this.DbType_=Moon.Orm.DbType.MySql;
		}
		/// <summary>
		/// 获取数据表信息
		/// </summary>
		/// <returns></returns>
		public override DataTable GetTables()
		{
			string strDb = GetDataBase();
			if (string.IsNullOrEmpty(strDb))
			{
				return null;
			}
			string qryStr = string.Format("select TABLE_NAME from information_schema.TABLES where table_type='BASE TABLE' and TABLE_SCHEMA='{0}'", strDb);

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
			string strDb = GetDataBase();
			if (string.IsNullOrEmpty(strDb))
			{
				return null;
			}
			string qryStr = string.Format("SELECT TABLE_NAME from information_schema.VIEWS  where TABLE_SCHEMA='{0}'",GetDataBase());

			DataSet ds = CurrentDb.ExecuteSqlToDataSet(qryStr);

			if (ds != null && ds.Tables.Count > 0)
			{
				return ds.Tables[0];
			}
			return null;
		}

		public int GetTablePKCount(string tableName)
		{
			string qryStr = string.Format(@"SELECT count(1) FROM information_schema.COLUMNS
                                where column_key='PRI' and table_schema = '{0}' AND table_name = '{1}'",GetDataBase(),tableName);

			DataSet ds = CurrentDb.ExecuteSqlToDataSet(qryStr);

			if (ds != null && ds.Tables.Count > 0)
			{
				return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
			}
			return -1;
		}
		/// <summary>
		/// 获取表中的字段信息
		/// </summary>
		/// <returns></returns>
		public override List<ColumnInfo> GetTableColunms(string tableName)
		{
			string strDb = GetDataBase();
			if (string.IsNullOrEmpty(strDb))
			{
				return null;
			}
			List<ColumnInfo> list = new List<ColumnInfo>();
			string qryStr = string.Format(@"SELECT
	                        column_name ColumnName,
	                        column_default DefaultValue,
	                        data_type DataType,
                            Column_Type ColumnType,
	                        case when column_key='PRI' then 1 else 0 end as isPK,
                            case when t.col_name is not null then 1 else 0 end isFK,
	                        column_comment Comments,
                            CASE is_nullable  WHEN 'YES' THEN 1 ELSE 0 END IsNullable,
	                        case when EXTRA='auto_increment' then 1 else 0 end IsIdentity,
	                        numeric_precision Length,
	                        numeric_scale Scale,
                            null IsComputed
                        FROM information_schema.COLUMNS
                        left JOIN
                        (
                        select COLUMN_NAME col_name
						from information_schema.key_column_usage
						where
								table_schema='{0}' and
								TABLE_NAME='{1}' and
								referenced_table_name is not null
                        ) t on column_name=t.col_name
                        WHERE table_schema = '{0}'
                        AND table_name = '{1}'
                        ORDER BY ordinal_position", strDb, tableName);
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

		public override string GetCsTypeByDbType(string dataType, string colomnType, bool isNullable)
		{
			object csType;
			dataType = dataType.ToLower();
			colomnType = colomnType.ToLower();

			switch(dataType)
			{
					case "tinyint":{
						csType = System.Data.DbType.Byte;
						if (colomnType=="tinyint(1)") {
							csType = System.Data.DbType.Boolean;
						}
					}
					break;
				case "smallint":
					csType = colomnType.Contains("unsigned") ? System.Data.DbType.UInt16 : System.Data.DbType.Int16;
					break;
				case "mediumint":
				case "int":
				case "integer":
					csType = colomnType.Contains("unsigned") ? System.Data.DbType.UInt32 : System.Data.DbType.Int32;
					break;
				case "bigint":
					csType = colomnType.Contains("unsigned") ? System.Data.DbType.UInt64 : System.Data.DbType.Int64;
					break;
				case "float":
				case "real":
					csType = System.Data.DbType.Single;
					break;
				case "double":
					csType = System.Data.DbType.Double;
					break;
				case "decimal":
				case "numeric":
					csType = System.Data.DbType.Decimal;
					break;
				case "year":
					csType = System.Data.DbType.Int32;
					break;
				case "bit":
					csType = System.Data.DbType.Boolean;
					break;
				case "char":
				case "varchar":
				case "text":
				case "tinytext":
				case "mediumtext":
				case "longtext":
				case "linestring":
				case "multilinestring":
					csType = System.Data.DbType.String;
					break;
				case "date":
				case "datetime":
				case "timestamp":
					csType = System.Data.DbType.DateTime;
					break;
				case "time":
					csType = "TimeSpan";
					break;
				case "blob":
				case "tinyblob":
				case "mediumblob":
				case "longblob":
				case "binary":
				case "varbinary":
					csType = "byte[]";
					break;
				default:
					csType = "object";
					break;

			}

			return isNullable && !("string,object,byte[]".Contains(csType.ToString().ToLower())) ? csType.ToString() + "?" : csType.ToString();

		}


		private string GetDataBase()
		{
			string strTmp = _db.LinkString.ToLower();
			if (strTmp.IndexOf("database=") > -1)
			{
				strTmp = strTmp.Substring(strTmp.IndexOf("database="));
				strTmp = strTmp.Substring(strTmp.IndexOf("=")+1);
				strTmp = strTmp.Substring(0, strTmp.IndexOf(";"));
				return strTmp;
			}
			return null;
		}
	}
}

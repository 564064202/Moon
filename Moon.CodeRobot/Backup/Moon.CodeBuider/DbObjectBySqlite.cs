using System;
using System.Collections.Generic;

using System.Text;
using Moon.Orm;
using System.Data;

namespace Moon.CodeBuider
{
	public class DbObjectBySqlite : DbObjectBase
	{
		public DbObjectBySqlite(string strConnection)
			: base(new Sqlite(strConnection))//这里要改成Oracle的Db实例
		{
			this._dbType = "DbType.Sqlite";
			this._needBrackets = false;
			this.ObjectMarker = "[{0}]";
			this.DbType_=Moon.Orm.DbType.Sqlite;
		}
		/// <summary>
		/// 获取数据表信息
		/// </summary>
		/// <returns></returns>
		public override DataTable GetTables()
		{
			string qryStr = "select name from sqlite_master where type='table' and name<>'sqlite_sequence'";

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

			string qryStr = @"PRAGMA  table_info("+tableName+")";
			var sqliteModelList=CurrentDb.ExecuteSqlToOwnList<SqliteModel>(qryStr);
			foreach (var a in sqliteModelList) {
				ColumnInfo cinfo=new ColumnInfo();
				cinfo.ColumnName=a.name;
				cinfo.ColumnType=a.type;
				cinfo.Comments="";
				cinfo.DataType=GetCsTypeByDbType(a.type,null,a.notnull!=1);
				cinfo.IsComputed=false;
				cinfo.IsFk=false;
				cinfo.Length=0;
				cinfo.Scale=0;
				cinfo.IsIdentity=(a.pk==1&&a.type=="INTEGER");
				cinfo.IsPk=a.pk==1;
				list.Add(cinfo);
			}
			
//		 
//			DataSet ds = CurrentDb.ExecuteSqlToDataSet(qryStr);
//
//			if (ds != null && ds.Tables.Count > 0)
//			{
//				ColumnInfo col = null;
//				foreach (DataRow dr in ds.Tables[0].Rows)
//				{
//					col = ColumnInfo.DrToObj(dr);
//					list.Add(col);
//				}
//			}
			return list;
		}

		public  int GetTablePKCount(string tableName)
		{
			return -1;
		}

		public override string GetCsTypeByDbType(string typeName, string colomnType, bool isNullable)
		{
			object csType = typeof(object);
			typeName = typeName.Trim().ToUpper();
			if (typeName.Contains("INT64"))
			{
				csType = System.Data.DbType.Int64;
			}
			else if (typeName.Contains("INTEGER"))
			{
				csType = System.Data.DbType.Int64;
			}
			else if (typeName.Contains("INT"))
			{
				csType = System.Data.DbType.Int32;
			}
			else if (typeName.Contains("DOUBLE"))
			{
				csType = System.Data.DbType.Double;
			}
			else if (typeName.Contains("REAL"))
			{
				csType = System.Data.DbType.Double;
			}
			else if (typeName.Contains("BOOLEAN"))
			{
				csType = System.Data.DbType.Boolean;
			}
			else if (typeName.Contains("DATETIME"))
			{
				csType = System.Data.DbType.DateTime;
			}
			else if (typeName.Contains("DATE"))
			{
				csType = System.Data.DbType.DateTime;
			}
			else if (typeName.Equals("BLOB"))
			{
				csType = "Byte[]";
			}
			else if (typeName.Contains("BOOL"))
			{
				csType = System.Data.DbType.Boolean;
			}
			else if (typeName.Contains("BIT"))
			{
				csType = System.Data.DbType.Boolean;
			}
			else if (typeName.Contains("CHAR"))
			{
				csType = System.Data.DbType.String;
			}
			else if (typeName.Contains("CURRENCY"))
			{
				csType = System.Data.DbType.Decimal;
			}
			else if (typeName.Contains("DECIMAL"))
			{
				csType = System.Data.DbType.Decimal;
			}
			else if (typeName.Contains("FLOAT"))
			{
				csType = System.Data.DbType.Single;
			}
			else if (typeName.Contains("GRAPHIC"))
			{
				csType = "Byte[]";
			}
			else if (typeName.Contains("GUID"))
			{
				csType = "Guid";
			}
			else if (typeName.Contains("MONEY"))
			{
				csType = System.Data.DbType.Decimal;
			}
			else if (typeName.Contains("CHAR"))
			{
				csType = "String";
			}
			else if (typeName.Contains("TEXT"))
			{
				csType = "String";
			}
			else if (typeName.Contains("SMALLINT"))
			{
				csType = "Int16";
			}
			else if (typeName.Contains("NUMBER"))
			{
				csType = System.Data.DbType.Decimal;
			}
			else if (typeName.Contains("STRING"))
			{
				csType="String";
			}
			else if (typeName.Contains("BYTE[]"))
			{
				csType ="byte[]";
			}
			else
			{
				csType = typeof(object);
			}

			return isNullable && !("string,object,byte[]".Contains(csType.ToString().ToLower())) ? csType.ToString() + "?" : csType.ToString(); ;
		}
	}
}

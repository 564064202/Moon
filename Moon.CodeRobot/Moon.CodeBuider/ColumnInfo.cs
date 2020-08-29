using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Moon.CodeBuider
{
    public class ColumnInfo
    {
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public string ColumnType { get; set; }
        public int Length { get; set; }
        public int Scale { get; set; }
        public bool IsComputed { get; set; }
        public bool IsNullable { get; set; }
        public bool IsPk { get; set; }
        public bool IsFk { get; set; }
        public bool IsIdentity { get; set; }
        public string Comments { get; set; }

        public static ColumnInfo DrToObj(DataRow dr)
        {
            ColumnInfo col = new ColumnInfo();

            col.ColumnName = dr["ColumnName"] == DBNull.Value ? "" : dr["ColumnName"].ToString();
            col.DataType = dr["DataType"] == DBNull.Value ? "" : dr["DataType"].ToString();
            col.ColumnType = dr["ColumnType"] == DBNull.Value ? "" : dr["ColumnType"].ToString();
            col.Length = dr["Length"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Length"].ToString());            
            col.Scale = dr["Scale"] == DBNull.Value ? 0 :  Convert.ToInt32(dr["Scale"].ToString());
            col.IsComputed = dr["IsComputed"] == DBNull.Value ? false : dr["IsComputed"].ToString() == "1";
            col.IsNullable = dr["IsNullable"] == DBNull.Value ? false : dr["IsNullable"].ToString() == "1";
            col.IsPk = dr["IsPk"] == DBNull.Value ? false : dr["IsPk"].ToString() == "1";
            col.IsFk = dr["IsFk"] == DBNull.Value ? false : dr["IsFk"].ToString() == "1";
            col.IsIdentity = dr["IsIdentity"] == DBNull.Value ? false : dr["IsIdentity"].ToString() == "1";
            col.Comments = dr["Comments"] == DBNull.Value ? "" : dr["Comments"].ToString();

            return col;
        }

    }
}

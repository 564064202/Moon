using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
 
using System.Text.RegularExpressions;
using Moon.Orm;
namespace Moon.CodeBuider
{
	public class GenUtil {
		/// <summary>
		/// 将指定数据库类型fromType的model代码,
		/// 转换为另一种数据库类型toType的model代码;
		/// </summary>
		/// <param name="modelContent">指定的内容</param>
		/// <param name="fromType">该内容对应的数据库类型</param>
		/// <param name="toType">目标数据库类型</param>
		/// <returns></returns>
		public static string ConvertModelString(string modelContent,DbType fromType,DbType toType)
		{
			var fromName= fromType.ToString();
			var toName=toType.ToString();
			
			var ret=modelContent.Replace(fromName,toName);
			
			var pName1=GetSE(fromType);
			var pName2=GetSE(toType);
			
			var fromPName_start="\""+pName1.Start;
			var toPName_start="\""+pName2.Start;
			ret=ret.Replace(fromPName_start,toPName_start);
			
			var fromPName_end=pName1.End+"\"";
			var toPName_end=pName2.End+"\"";
			ret=ret.Replace(fromPName_end,toPName_end);
			return ret;
		}
		public struct SE{
			
			public SE(string start,string end){
				_Start=start;
				_End=end;
			}
			private string _Start;
			
			public string Start {
				get { return _Start; }
			}
			private string _End;
			
			public string End {
				get { return _End; }
			}
		}
		public static SE GetSE(DbType db){
			if(db== DbType.MySql){
				return new SE("`","`");
			}else if(db== DbType.Oracle){
				return new SE("\"","\\\"");
			}
			else if(db== DbType.Sqlite){
				return new SE("[","]");
			}
			else if(db== DbType.SqlServer){
				return new SE("[","]");
			}else if(db== DbType.PostGresql){
				return new SE("\"","\\\"");
			}
			return new SE("[","]");
		}
		public static string GetPName(DbType db){
			if(db== DbType.MySql){
				return "@";
			}else if(db== DbType.Oracle){
				return ":";
			}
			else if(db== DbType.Sqlite){
				return ":";
			}
			else if(db== DbType.SqlServer){
				return "@";
			}else if(db== DbType.PostGresql){
				return ":";
			}
			return "@";
		}
		public static string UpperFirstChar(string strValue) {          //Upper the first letter of string
			string s1;
			s1 = strValue.Substring(0, 1);
			s1 = s1.ToUpper();
			return s1 + strValue.Substring(1, strValue.Length - 1);
		}
		public static string LowerFirstChar(string strValue) {          //Lower the first letter of string
			strValue = Regex.Replace(strValue, @"[^a-zA-Z0-9\u4e00-\u9fa5]", "");//只保留中文英文和数字
			string s1;
			s1 = strValue.Substring(0, 1);
			s1 = s1.ToLower();
			return s1 + strValue.Substring(1, strValue.Length - 1);
		}
		public static string UnderLineAndLowerFirstChar(string strValue) {     //underLine & Lower the first letter of string
			strValue = Regex.Replace(strValue, @"[^a-zA-Z0-9\u4e00-\u9fa5]", "");//只保留中文英文和数字
			string s1;
			s1 = strValue.Substring(0, 1);
			s1 = s1.ToLower();
			return "_" + s1 + strValue.Substring(1, strValue.Length - 1);
		}
		public  static bool ChkNoUnderline=false;
		/// <summary>
		/// 去掉下划线，并且把首字母和下划线后的首字母大写
		/// </summary>
		/// <param name="strValue"></param>
		/// <returns></returns>
		public static string RemoveUnderLineAndUpperChar(string strValue)
		{
			if(ChkNoUnderline){
				string temp = string.Empty;
				string[] strArr = strValue.Split('_');

				foreach (string s1 in strArr)
				{
					if (!string.IsNullOrEmpty(s1))
					{
						temp += UpperFirstChar(s1);
					}
				}
				return temp;
			}else{
				return strValue;
			}
		}


		/// <summary>
		/// 对Oracle,comboBox.Text的值是owner.tablename，从中分离出表名
		/// </summary>
		/// <param name="ownerDotTablename"></param>
		/// <returns></returns>
		public static string GetTableName(string ownerDotTablename) {
			string returnVal = ownerDotTablename;
			int pos = 0;
			pos = ownerDotTablename.IndexOf(".");
			if (pos > 0) {
				returnVal = ownerDotTablename.Substring(pos + 1);
			}
			return returnVal;
		}

		/// <summary>
		/// 从中分离出表拥有者(For Oracle)
		/// </summary>
		/// <param name="ownerDotTablename"></param>
		/// <returns></returns>
		public static string GetTableOwner(string ownerDotTablename) {
			string returnVal = ownerDotTablename;
			int pos = 0;
			pos = ownerDotTablename.IndexOf(".");
			if (pos > 0) {
				returnVal = ownerDotTablename.Substring(0, pos);
			}
			return returnVal;
		}

		public static string RemoveBracket(string strValue) {
			strValue = strValue.Trim();
			if (strValue.StartsWith("("))
				strValue = strValue.Substring(1);
			if (strValue.EndsWith(")"))
				strValue = strValue.Substring(0, strValue.Length - 1);
			return strValue;
		}

		#region GetCSTypeFromDb
		//public static string GetCSTypeFromDb(string dbColumnType)
		//{
		//    string tmpStr;
		//    switch (dbColumnType)
		//    {
		//        case "char":
		//        case "nchar":
		//        case "varchar":
		//        case "nvarchar":
		//        case "text":
		//        case "ntext":
		//        case "uniqueidentifier":
		//            tmpStr = "string";
		//            break;
		//        //
		//        case "bit":
		//            tmpStr = "bool";
		//            break;
		//        //
		//        case "datetime":
		//        case "smalldatetime":
		//            tmpStr = "DateTime";
		//            break;
		//        //
		//        case "tinyint":
		//            tmpStr = "byte";
		//            break;
		//        case "smallint":
		//            tmpStr = "short";
		//            break;
		//        case "int":
		//            tmpStr = "int";
		//            break;
		//        case "bigint":
		//            tmpStr = "long";
		//            break;
		//        //
		//        case "decimal":
		//        case "numeric":
		//        case "money":
		//        case "smallmoney":
		//        case "real":
		//        case "float":
		//        case "double":
		//            tmpStr = "decimal";
		//            break;
		//        //
		//        case "image":
		//        case "binary":
		//        case "nbinary":
		//        case "timestamp":
		//        case "varbinary":     //sql2005
		//            tmpStr = "byte[]";
		//            break;
		//        //
		//        case "sql_variant":
		//            tmpStr = dbColumnType;
		//            break;
		//        default:
		//            throw new Exception("Program don't process this data type:" + dbColumnType);
		//    }
		//    return tmpStr;
		//}
		#endregion


		public static string Replicate(string str, int count)
		{
			string result = "";
			int i;
			for (i = 1; i <= count; i++)
				result += str;
			return result;
		}


	}

	public class Tab
	{

		public static string TabChar1 = GenUtil.Replicate(" ", 4);
		public static string TabChar2 = GenUtil.Replicate(" ", 8);
		public static string TabChar3 = GenUtil.Replicate(" ", 12);
		public static string TabChar4 = GenUtil.Replicate(" ", 16);
		public static string TabChar5 = GenUtil.Replicate(" ", 20);
		public static string TabChar6 = GenUtil.Replicate(" ", 24);
		public static string TabChar7 = GenUtil.Replicate(" ", 28);
		public static string TabChar = "\t";
	}
}

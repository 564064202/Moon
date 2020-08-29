using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;

namespace Moon.CodeBuider
{
    public class GenUtil {

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

        /// <summary>
        /// 去掉下划线，并且把首字母和下划线后的首字母大写
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static string RemoveUnderLineAndUpperChar(string strValue)
        {
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

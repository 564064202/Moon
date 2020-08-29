using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;

namespace Moon.CodeBuider
{
	public class ClassBuilder
	{
		protected string _tableName = string.Empty;
		protected DbObjectBase _builder = null;

		/// <summary>
		/// 构造
		/// </summary>
		/// <param name="tableName">表名</param>
		/// <param name="builder"></param>
		public ClassBuilder(DbObjectBase builder)
		{
			_builder = builder;
		}

		/// <summary>
		/// 构造
		/// </summary>
		/// <param name="tableName">表名</param>
		/// <param name="builder"></param>
		public ClassBuilder(string tableName, DbObjectBase builder)
		{
			_tableName = tableName;
			_builder = builder;
		}


		/// <summary>
		/// 根据构造的表名转换成类名
		/// </summary>
		public string ClassName
		{
			get
			{
				return GetObjName(_tableName);
			}
		}
		public string ClassSetName
		{
			get
			{
				return ClassName + "Set";
			}
		}

		/// <summary>
		/// 把表名或字段名转换成类名或者属性名
		/// </summary>
		/// <param name="tabNameOrColName"></param>
		/// <returns></returns>
		public string GetObjName(string tabNameOrColName)
		{
			tabNameOrColName = Regex.Replace(tabNameOrColName, @"^[0-9]*", "");
			tabNameOrColName = Regex.Replace(tabNameOrColName, @"[^a-zA-Z0-9\u4e00-\u9fa5_]", "");//只保留中文英文和数字
			string objName = GenUtil.RemoveUnderLineAndUpperChar(tabNameOrColName);
			if (KeyWordsList.ExistsKeyWords(objName))
			{
				objName = objName + "_";
			}
			return objName;
		}
		

		/// <summary>
		/// 获取主键类型
		/// </summary>
		/// <param name="col"></param>
		/// <param name="pKCount"></param>
		/// <param name="fKCount"></param>
		/// <returns></returns>
		public string GetFieldType(ColumnInfo col, int pKCount)
		{
			string fieldType = "FieldType.Common";
			if (col.IsPk)
			{
				if (pKCount > 1)
					fieldType = "FieldType.OnePrimaryKey";
				else
					fieldType = "FieldType.OnlyPrimaryKey";

			}
			else if (col.IsFk)
			{
				fieldType = "FieldType.ForeignKey";
			}
			else if (col.IsComputed)
			{
				fieldType = "FieldType.FunctionField";
			}

			return fieldType;
		}

		/// <summary>
		/// 获取主键类型
		/// </summary>
		/// <param name="col"></param>
		/// <param name="pKCount"></param>
		/// <param name="fKCount"></param>
		/// <returns></returns>
		public string GetKeyType(ColumnInfo col)
		{
			string keyType = "PrimaryKeyType.CustomerGUID";
			if (col.IsIdentity)
			{
				keyType = "PrimaryKeyType.AutoIncrease";
			}
			else if (col.IsPk && col.DataType.ToLower().Contains("char") && col.Length>=36)
			{
				keyType = "AutoGUID";
			}
			return keyType;
		}
		public List<ColumnInfo> GetIsPkTrue(List<ColumnInfo> list){
			List<ColumnInfo> ret=new List<ColumnInfo>();
			foreach (var a in list) {
				if(a.IsPk==true){
					ret.Add(a);
				}
			}
			return ret;
		}
		/// <summary>
		/// 生成Class类的具体内容
		/// </summary>
		/// <returns></returns>
		public string GenerateClass()
		{
			string strError = string.Empty;
			string columnPropertyName;
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(Tab.TabChar1 + string.Format("[Table(\"{0}\", {1})]", _builder.GetTableOrColumnName(_tableName), _builder.DbTypeString));

			List<ColumnInfo> colList = _builder.GetTableColunms(_tableName);
			var list = GetIsPkTrue(colList);
			string strPrimaryKey = string.Empty;
			string strAttrPrimaryKey = string.Empty;
			foreach (ColumnInfo col in list)
			{
				strPrimaryKey += string.IsNullOrEmpty(strPrimaryKey) ? col.ColumnName : "," + col.ColumnName;
				strAttrPrimaryKey = Tab.TabChar1 + string.Format("[TablesPrimaryKey({0}, typeof({1}), \"{2}\")]", GetKeyType(col), _builder.GetCsTypeByDbType(col.DataType,col.ColumnType, col.IsNullable), col.ColumnName);
			}
			if (list.Count > 1)
			{
				sb.AppendLine(Tab.TabChar1 + string.Format("[TablesPrimaryKey(PrimaryKeyType.MultiplePK, typeof(Object), \"{0}\")]", strPrimaryKey));
			}
			else
			{
				sb.AppendLine(strAttrPrimaryKey);
			}
			sb.AppendLine(Tab.TabChar1 + string.Format("public partial class {0} : EntityBase", ClassName));
			sb.AppendLine(Tab.TabChar1 + "{");


			foreach (ColumnInfo col in colList)
			{
				columnPropertyName = GetObjName(col.ColumnName);
				if (columnPropertyName == ClassName)//表名和字段名重复的情况
				{
					columnPropertyName = columnPropertyName + "_";
				}
				sb.AppendLine();
				sb.AppendLine(Tab.TabChar2 + "/// <summary>");
				sb.AppendLine(Tab.TabChar2 + "/// " + col.Comments.Replace("\r\n",Tab.TabChar2 +"\r\n/// "));
				sb.AppendLine(Tab.TabChar2 + "/// </summary>");
				sb.AppendLine(Tab.TabChar2 + string.Format("public {0} {1}", _builder.GetCsTypeByDbType(col.DataType, col.ColumnType, col.IsNullable), columnPropertyName));
				sb.AppendLine(Tab.TabChar2 + "{");


				sb.AppendLine(Tab.TabChar3 + string.Format("get {{ return GetPropertyValue<{0}>(\"{1}\"); }}", _builder.GetCsTypeByDbType(col.DataType, col.ColumnType, col.IsNullable), col.ColumnName));
				sb.AppendLine(Tab.TabChar3 + string.Format("set {{ SetPropertyValue(\"{0}\", value); }}", col.ColumnName));
				sb.AppendLine(Tab.TabChar2 + "}");
			}

			sb.AppendLine(Tab.TabChar1 + "}");

			return sb.ToString();
		}
		/// <summary>
		/// 生成ClassSet类的具体内容
		/// </summary>
		/// <returns></returns>
		public string GenerateClassSet()
		{
			string tableName = _builder.GetTableOrColumnName(_tableName);
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(Tab.TabChar1 + string.Format("[Table(\"{0}\", {1})]", tableName, _builder.DbTypeString));
			sb.AppendLine(Tab.TabChar1 + string.Format("public  partial class {0} : MQLBase", ClassSetName));
			sb.AppendLine(Tab.TabChar1 + "{");
			sb.AppendLine(Tab.TabChar2 + "public static new MQLBase Select(params FieldBase[] fields)");
			sb.AppendLine(Tab.TabChar2 + "{");
			sb.AppendLine(Tab.TabChar3 + "return MQLBase.Select("+_builder.DbTypeString+",\""+tableName+"\",fields);");
			sb.AppendLine(Tab.TabChar2 + "}");
			sb.AppendLine(Tab.TabChar2 + "public static new MQLBase SelectAll()");
			sb.AppendLine(Tab.TabChar2 + "{");
			sb.AppendLine(Tab.TabChar3 + "return MQLBase.SelectAll("+_builder.DbTypeString+",\""+tableName+"\");");
			sb.AppendLine(Tab.TabChar2 + "}");

			List<ColumnInfo> colList = _builder.GetTableColunms(_tableName);
			int pKCount = GetIsPkTrue(colList).Count;
			foreach (ColumnInfo col in colList)
			{
				sb.AppendLine();
				sb.AppendLine(Tab.TabChar2 + "/// <summary>");
				sb.AppendLine(Tab.TabChar2 + "/// " + col.Comments.Replace("\r\n",Tab.TabChar2 +"\r\n/// "));
				sb.AppendLine(Tab.TabChar2 + "/// </summary>");
				sb.AppendLine(string.Format(Tab.TabChar2 + "public static readonly FieldBase {0} = new FieldBase({1}, \"{2}\", {3}, \"{4}\");",
				                            GetObjName(col.ColumnName), _builder.DbTypeString, tableName, GetFieldType(col, pKCount), _builder.GetTableOrColumnName(col.ColumnName)));
			}
			sb.AppendLine(Tab.TabChar1 + "}");

			return sb.ToString();
		}

		/// <summary>
		/// 将Class类生成在一个文件中
		/// </summary>
		/// <param name="targetFloder"></param>
		/// <param name="nameSpace"></param>
		public void BuildClassEntityToFile(string targetFloder, string nameSpace)
		{
			if (!Directory.Exists(targetFloder))
			{
				Directory.CreateDirectory(targetFloder);
			}
			string destFile = targetFloder + ClassName + ".cs";
			StreamWriter sw = new StreamWriter(destFile, false, Encoding.UTF8);

			sw.WriteLine(CodeBuiderMain.GenerateHeader(nameSpace));
			sw.WriteLine(GenerateClass());
			sw.WriteLine(CodeBuiderMain.GenerateEnd());

			//sw.WriteLine("using System;");
			//sw.WriteLine("using System.Text;");
			//sw.WriteLine("using System.Collections;");
			//sw.WriteLine("using System.Collections.Generic;");
			//sw.WriteLine("using Moon.Orm;");
			//sw.WriteLine(string.Format("namespace {0}", _nameSpace));
			//sw.WriteLine("{");

			//sw.WriteLine(Tab.TabChar1 + string.Format("[Table(\"{0}\", {1})]", _tableName, _builder.DbType));

			//List<ColumnInfo> colList = _builder.GetTableColunms(_tableName);
			//var list = colList.Where<ColumnInfo>(n => n.IsPk == true);
			//foreach (ColumnInfo col in list)
			//{
			//    sw.WriteLine(Tab.TabChar1 + string.Format("[TablesPrimaryKeyAttribute(PrimaryKeyType.AutoIncrease, typeof({0}), \"{1}\")]", GenUtil.GetCSTypeFromDb(col.DataType), col.ColumnName));
			//}
			//sw.WriteLine(Tab.TabChar1 + string.Format("public class {0} : MQLBase", ClassName));
			//sw.WriteLine(Tab.TabChar1 + "{");


			//foreach (ColumnInfo col in colList)
			//{
			//    sw.WriteLine(Tab.TabChar2 + string.Format("public string {0}", GetObjName(col.ColumnName)));
			//    sw.WriteLine(Tab.TabChar2 + "{");

			//    sw.WriteLine(Tab.TabChar3 + string.Format("get {{ return GetPropertyValue<{0}>(\"{1}\"); }}", GenUtil.GetCSTypeFromDb(col.DataType), col.ColumnName));
			//    sw.WriteLine(Tab.TabChar3 + string.Format("set {{ SetPropertyValue(\"{0}\", value); }}", col.ColumnName));
			//    sw.WriteLine(Tab.TabChar2 + "}");
			//}

			//sw.WriteLine(Tab.TabChar1 + "}");
			//sw.WriteLine("}");

			sw.Flush();
			sw.Close();
		}
		/// <summary>
		///  将ClassSet类生成在一个文件中
		/// </summary>
		/// <param name="codeFloder"></param>
		/// <param name="nameSpace"></param>
		public void BuildClassSetEntityToFile(string targetFloder, string nameSpace)
		{
			targetFloder = targetFloder.EndsWith("\\") ? targetFloder : targetFloder + "\\";
			if (!Directory.Exists(targetFloder))
			{
				Directory.CreateDirectory(targetFloder);
			}
			string destFile = targetFloder + ClassSetName + ".cs";
			StreamWriter sw = new StreamWriter(destFile, false, Encoding.UTF8);

			sw.WriteLine(CodeBuiderMain.GenerateHeader(nameSpace));
			sw.WriteLine(GenerateClassSet());
			sw.WriteLine(CodeBuiderMain.GenerateEnd());

			//sw.WriteLine("using System;");
			//sw.WriteLine("using System.Text;");
			//sw.WriteLine("using System.Collections;");
			//sw.WriteLine("using System.Collections.Generic;");
			//sw.WriteLine("using Moon.Orm;");
			//sw.WriteLine(string.Format("namespace {0}", _nameSpace));
			//sw.WriteLine("{");

			//sw.WriteLine(Tab.TabChar1 + string.Format("[Table(\"{0}\", {1})]", _tableName, _builder.DbType));
			//sw.WriteLine(Tab.TabChar1 + string.Format("public class {0} : MQLBase", ClassSetName));
			//sw.WriteLine(Tab.TabChar1 + "{");
			//sw.WriteLine(Tab.TabChar2 + "public static new MQLBase Select(params FieldBase[] fields)");
			//sw.WriteLine(Tab.TabChar2 + "{");
			//sw.WriteLine(Tab.TabChar3 + "return MQLBase.Select(fields);");
			//sw.WriteLine(Tab.TabChar2 + "}");
			//sw.WriteLine(Tab.TabChar2 + "public static new MQLBase SelectAll()");
			//sw.WriteLine(Tab.TabChar2 + "{");
			//sw.WriteLine(Tab.TabChar3 + "return MQLBase.SelectAll();");
			//sw.WriteLine(Tab.TabChar2 + "}");

			//List<ColumnInfo> colList = _builder.GetTableColunms(_tableName);
			//int pKCount = colList.Where(n => n.IsPk == true).Count();
			//foreach (ColumnInfo col in colList)
			//{
			//    sw.WriteLine(string.Format(Tab.TabChar2 + "public static readonly FieldBase {0} = new FieldBase({1}, \"{2}\", {3}, \"{4}\");",
			//        GetObjName(col.ColumnName), _builder.DbType, _tableName, GetFieldType(col, pKCount), col.ColumnName));
			//}
			//sw.WriteLine(Tab.TabChar1 + "}");
			//sw.WriteLine("}");

			sw.Flush();
			sw.Close();
		}

		/// <summary>
		/// 把Class和ClassSet生成在一个文件中
		/// </summary>
		/// <param name="nameSpace"></param>
		/// <param name="targetFloder"></param>
		public void BuildClassToFile(string nameSpace,string targetFloder)
		{
			targetFloder = targetFloder.EndsWith("\\") ? targetFloder : targetFloder + "\\";
			if (!Directory.Exists(targetFloder))
			{
				Directory.CreateDirectory(targetFloder);
			}
			string destFile = targetFloder + ClassName + ".cs";
			StreamWriter sw = new StreamWriter(destFile, false, Encoding.UTF8);
			sw.WriteLine(CodeBuiderMain.GenerateHeader(nameSpace));
			sw.WriteLine(GenerateClass());
			sw.WriteLine(GenerateClassSet());
			sw.WriteLine(CodeBuiderMain.GenerateEnd());
			sw.Flush();
			sw.Close();
		}

		/// <summary>
		/// 通过SQL语句生成实体
		/// </summary>
		/// <param name="entityName"></param>
		/// <param name="sql"></param>
		public string BuildClassBySQL(string entityName,bool inheritEntityBase, string sql)
		{
			DataSet ds = null;
			try
			{
				ds = _builder.CurrentDb.ExecuteSqlToDataSet(sql);
			}
			catch (Exception ex)
			{
				throw new Exception("执行SQL语句出现错误！错误信息：\r\n" + ex.Message);
			}
			StringBuilder sb = new StringBuilder();
			if(ds!=null && ds.Tables.Count>0)
			{
				DataTable table=ds.Tables[0];
				DataColumnCollection datacolumns=table.Columns;
				sb.AppendLine(Tab.TabChar1 + string.Format("public class {0} {1}", entityName, inheritEntityBase ? ": EntityBase" : ""));
				sb.AppendLine(Tab.TabChar1 + "{");

				foreach (DataColumn dc in datacolumns)
				{
					string colName = dc.ColumnName;
					string type = dc.DataType.ToString();
					int index = type.LastIndexOf(".");
					type = type.Substring(index + 1);

					string columnPropertyName = GetObjName(colName);

					sb.AppendLine(Tab.TabChar2 + string.Format("public {0} {1}", type, columnPropertyName));
					sb.AppendLine(Tab.TabChar2 + "{");
					if (inheritEntityBase)
					{
						sb.AppendLine(Tab.TabChar3 + string.Format("	get {{ return GetPropertyValue<{0}>(\"{1}\"); }}", type, columnPropertyName));
						sb.AppendLine(Tab.TabChar3 + string.Format("	set {{ SetPropertyValue(\"{0}\", value); }}", columnPropertyName));
					}
					else
					{
						sb.AppendLine(" 	get; set; ");
					}
					sb.AppendLine(Tab.TabChar2 + "}");
					
				}
				sb.AppendLine(Tab.TabChar1 + "}");
			}
			return sb.ToString();
			
		}

		/// <summary>
		/// 把Class和ClassSet生成在一个文件中
		/// </summary>
		/// <param name="nameSpace"></param>
		/// <param name="targetFloder"></param>
		public string BuildClassBySQLToFile(string nameSpace, string targetFloder, string entityName, bool inheritEntityBase, string sql)
		{
			targetFloder = targetFloder.EndsWith("\\") ? targetFloder : targetFloder + "\\";
			targetFloder += "CustomClass\\";
			if (!Directory.Exists(targetFloder))
			{
				Directory.CreateDirectory(targetFloder);
			}
			string destFile = targetFloder + entityName + ".cs";
			StreamWriter sw = new StreamWriter(destFile, false, Encoding.UTF8);
			StringBuilder sb=new StringBuilder();
			
			sb.AppendLine(CodeBuiderMain.GenerateHeader(nameSpace));
			sb.AppendLine(BuildClassBySQL(entityName,inheritEntityBase, sql));
			sb.AppendLine(CodeBuiderMain.GenerateEnd());
			string content=sb.ToString();
			sw.Write(content);
			sw.Flush();
			sw.Close();
			return content;
		}
	}
}

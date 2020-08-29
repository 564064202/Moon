using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;

using Microsoft.CSharp;
using Moon.Orm;

namespace Moon.Orm
{
	/// <summary>
	/// DynamicListsHelper.
	/// </summary>
	public class DynamicListelper
	{
		/// <summary>
		/// 获取字段名-类型的字典
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="db"></param>
		/// <returns></returns>
		private static Dictionary<string,string> GetFieldsNameTypeMap(string sql,Db db)
		{
			Dictionary<string,string> dic=new Dictionary<string, string>();
			DbDataReader reader=db.GetDbDataReader(sql, CommandType.Text);
			int fieldsCount=reader.FieldCount;
			for (int i = 0; i < fieldsCount; i++) {
				string fName=reader.GetName(i);
				string type=reader.GetFieldType(i).ToString().Replace("System.","");
				if (dic.ContainsKey(fName))
				{
					int index=1;
				lbl:
					fName=fName+index;
					if (dic.ContainsKey(fName)) {
						index++;
						goto lbl;
					}else{
						dic[fName]=type;
					}
				}
				else
					dic[fName]=type;
			}
			reader.Close();
			return dic;
			
		}
		/// <summary>
		/// 根据sql获取对应的model类型
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="db"></param>
		/// <param name="modelName"></param>
		/// <returns></returns>
		public static string GenerateModelCode(string sql,Db db,string modelName){
			Dictionary<string,string> fieldsName=GetFieldsNameTypeMap(sql,db);
			StringBuilder code=new StringBuilder();
			code.AppendLine("using System;");
			code.AppendLine("using System.Collections.Generic;");
			code.AppendLine("namespace moontemp{");//1
			code.AppendLine("public class "+modelName+" {");//2
			int index=0;
			foreach (KeyValuePair<string,string> kvp in fieldsName) {
				code.AppendLine("private "+kvp.Value+" _"+kvp.Key+";");
				code.AppendLine("public "+kvp.Value+" "+kvp.Key+"{");
				code.AppendLine("get{return _"+kvp.Key+";}");
				code.AppendLine("set{_"+kvp.Key+"=value;}");
				code.AppendLine("}");
				index++;
			}
			code.AppendLine("}");//2
			code.AppendLine("}");//1
			return code.ToString();
		}
		/// <summary>
		/// 根据sql生成对应的model和获取model集合的方法
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="db"></param>
		/// <param name="modelName"></param>
		/// <returns></returns>
		public static String GenerateModelAndModelListsGetMethodCode(string sql,Db db,string modelName){
			Dictionary<string,string> fieldsName=GetFieldsNameTypeMap(sql,db);
			StringBuilder code=new StringBuilder();
			code.AppendLine("using System;");
			code.AppendLine("using System.Collections.Generic;");
			code.AppendLine("using System.Data;");
			code.AppendLine("using System.Data.Common;");
			code.AppendLine("using System.Text;");
			code.AppendLine("using Moon.Orm;");
			code.AppendLine("using System.Configuration;");
			code.AppendLine("namespace moontemp{");//1
			code.AppendLine("public class "+modelName+" {");//2
			int index=0;
			foreach (KeyValuePair<string,string> kvp in fieldsName) {
				code.AppendLine("private "+kvp.Value+" _"+kvp.Key+";");
				code.AppendLine("public "+kvp.Value+" "+kvp.Key+"{");
				code.AppendLine("get{return _"+kvp.Key+";}");
				code.AppendLine("set{_"+kvp.Key+"=value;}");
				code.AppendLine("}");
				index++;
			}
			code.AppendLine("}");//2
			//------------------------
			
			
			code.AppendLine("public class EntityGet"+modelName+" {");//2
			code.AppendLine("public static object GetList(string sql,Db db){");//3
			code.AppendLine("List<moontemp."+modelName+"> list=new List<moontemp."+modelName+">();");
			code.AppendLine("DbDataReader reader=db.GetDbDataReader(sql,CommandType.Text);");
			code.AppendLine("while (reader.Read()) {");//4
			
			code.AppendLine("moontemp."+modelName+" obj=new moontemp."+modelName+"();");
			
			index=0;
			foreach (KeyValuePair<string,string> kvp in fieldsName) {
				code.AppendLine("if(!reader.IsDBNull("+index+")){");//5
				code.AppendLine("	obj."+kvp.Key+"=Convert.To"+kvp.Value+"(reader.GetValue("+index+"));");
				code.AppendLine("}");//5
				index++;
			}
			code.AppendLine("list.Add(obj);");
			
			code.AppendLine("}");//4
			code.AppendLine("reader.Close();");
			code.AppendLine("return list;");
			code.AppendLine("}");//3
			code.AppendLine("}");//2
			
			
			//-----------------
			code.AppendLine("}");//1
			return code.ToString();
		}
		
		
		/// <summary>
		/// (类名,程序集)字典
		/// </summary>
		private static readonly Dictionary<string,Assembly> CLASS_NAME_ASSEMBLY_MAP=new Dictionary<string, Assembly>();
		/// <summary>
		/// (类名,程序集)字典的锁
		/// </summary>
		private static readonly object CLASS_NAME_ASSEMBLY_LOCK=new object();
		/// <summary>
		/// 把代码编译为程序集
		/// </summary>
		/// <param name="sql">查询所用的sql语句</param>
		/// <param name="db">数据获取引擎</param>
		/// <param name="className">使用的类名</param>
		/// <returns></returns>
		public static Assembly CompileCodeToAssembly(string sql,Db db,string className){
			string fileName=GlobalData.MOON_TEMP_DLL_DIRECTORY_PATH+"moontemp_"+className+".dll";
			//--------------------------------
			lock(CLASS_NAME_ASSEMBLY_LOCK){
				if (CLASS_NAME_ASSEMBLY_MAP.ContainsKey(className)) {
					return CLASS_NAME_ASSEMBLY_MAP[className];
				}
			}
			if (File.Exists(fileName)) {
				var na=Assembly.LoadFrom(fileName);
				lock(CLASS_NAME_ASSEMBLY_LOCK){
					CLASS_NAME_ASSEMBLY_MAP[className]=na;
				}
				return na;
			}
			//---------------------------------------
			string code=GenerateModelCode(sql,db,className);
			CompilerResults result=CompileToResults(code,null,className);
			string error=null;
			if(result.Errors.Count>0){
				for (int i = 0; i < result.Errors.Count; i++) {
					error+="\r\n"+result.Errors[i];
				}
				throw new DataException(error);
			}
			Assembly assembly=result.CompiledAssembly;
			lock(CLASS_NAME_ASSEMBLY_MAP){
				CLASS_NAME_ASSEMBLY_MAP[className]=assembly;
			}
			return assembly;
		}
		/// <summary>
		/// 将代码编译为自己所要的类型
		/// </summary>
		/// <param name="code">代码</param>
		/// <param name="strArray">引用的程序集名</param>
		/// <param name="modelName">所用的类名</param>
		/// <returns></returns>
		public static CompilerResults CompileToResults(string code,string[] strArray,string modelName)
		{
			CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
			CompilerParameters cp = new CompilerParameters();
			cp.GenerateExecutable = false;
			cp.GenerateInMemory = true;
			cp.TreatWarningsAsErrors = false;
			
			string root=GlobalData.DLL_EXE_DIRECTORY_PATH;
			cp.ReferencedAssemblies.Add( root+"Moon.Orm.dll" );
			cp.ReferencedAssemblies.Add( "System.Data.dll" );
			if (strArray!=null) {
				cp.ReferencedAssemblies.AddRange(strArray);
			}
			string fileName=GlobalData.MOON_TEMP_DLL_DIRECTORY_PATH+"moontemp_"+modelName+".dll";
			cp.OutputAssembly =fileName;
			CompilerResults cr = provider.CompileAssemblyFromSource(cp,
			                                                        new string[]{code});
			return cr;
		}
		
		
	}
}

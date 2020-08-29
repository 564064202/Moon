/*
 * 由SharpDevelop创建。
 * 用户： 秦仕川
 * 日期: 2013-8-22
 * 时间: 14:56
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Moon.Orm;
using mysql;
using Moon.Orm.Util;


namespace TestMySql
{
	enum Person{
		ZH=0,
		EN,
		JP,
		UK
	}
	class Program
	{
		public static void Main(string[] args)
		{
			
			string aaa = "{\"A.id\":11,\"A.name\":\"qsc\",\"B.Num\":232323,\"B.Enabled\":false}";
			LogUtil.Debug(aaa);
			var dic=JsonUtil.ConvertOneSimpleJsonToJObjectDictionary(aaa,true);
			dic.ShowInConsole();
			
			
			 
			using (var db = Db.CreateSharedDbByConfigName("DefaultConnection3"))
			{
				var ar=SqlConfigUtil.GetSqlByID(db,"getdemo");
				Console.WriteLine(ar);
				//db.ExecuteSql***(XmlHelper.GetSqlByID("getdemo"),12);
				db.DebugEnabled=true;
				mtest m=new mtest();
				m.CharTypeId=Guid.NewGuid().ToString();
				//Console.WriteLine(m.CharTypeId.Length);
				m.CharTypeName="CharTypeName"+DateTime.Now;
				m.CharTypeNum="'CharTypeNum\''\"";
				m.Is_Delete=false;
				m.IsVisible=true;
				m.SerialNo=int.MaxValue;
				m.Status=false;
				var a=db.Add(m);
                Console.WriteLine(a);
				string jj=m.ToJson();
				LogUtil.Debug(StringUtil.ConvertStringToCSharpString(jj));
				var sql=mtestSet.Select(mtestSet.CharTypeId.AS("mtest.CharTypeId"),mtestSet.CharTypeName.AS("mtest.CharTypeName")).Top(4);
				var list=db.GetEntities<mtest>(sql);
				Console.WriteLine(JsonUtil.ConvertListEntityBaseToJson(list));
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}
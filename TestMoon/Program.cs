/*
 * 由SharpDevelop创建。
 * 用户： 秦仕川
 * 日期: 2013-11-3
 * 时间: 18:28
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using Moon.Orm;
using sqlite;
 
using Moon.Orm.Util;

namespace TestMoon
{
	class Program
	{
		public static void Main(string[] args)
		{
			//var a=PagerUtil.GetAjaxPagerControlScripts();
			//Console.WriteLine(a);
            using (var db = Db.CreateDbByConfigName("DefaultConnection")) {


                var list = db.GetOwnList<LinkHistory>(LinkHistorySet.SelectAll());
                Console.WriteLine(list[7].DatabaseName);
                
            }
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);Console.ReadKey(true);
		}
	}
}
using System;
using System.IO;
using System.Reflection;
using Moon.Orm;

namespace TestCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Moon.Orm.GlobalData.Initial(false);
            using (var db = Db.CreateDefaultDb())
            {
                var sql = "select* FROM book";
                var model = db.GetModelBySql(sql,"Book");
                var list = db.ExecuteSqlToOwnList<moontemp.Book>(sql);
                Console.WriteLine(list);
            }
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}

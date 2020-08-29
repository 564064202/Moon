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
            using (var db=Db.CreateDefaultDb())
            {
               var list= db.ExecuteSqlToJson("select * FROM book");
                Console.WriteLine(list);
            }
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}

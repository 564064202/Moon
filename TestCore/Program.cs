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
            var path = Assembly.GetEntryAssembly().Location;
            FileInfo fi = new FileInfo(path);

            var path2 = fi.Directory.FullName+Path.DirectorySeparatorChar;

            Moon.Orm.GlobalData.Initial(false, path2);
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

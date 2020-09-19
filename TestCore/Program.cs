using System;
using System.IO;
using System.Reflection;
using Moon.Orm;
using moontemp;
using sqlite;

namespace TestCore
{
    class Program
    {
        static void Main(string[] args)
        {
            // Moon.Orm.GlobalData.Initial(false);
            Console.WriteLine(GlobalData.IS_WEB);
            using (var db = Db.CreateDefaultDb())
            {
                var sql = "select* FROM book";
                var model = db.GetModelBySql(sql,"Book");
                var list = db.ExecuteSqlToOwnList<moontemp.Book>(sql);
                Console.WriteLine(list);
            }
            Console.WriteLine("Hello World!");
            TestSqlite();
            Console.ReadLine();
        }

        static void TestSqlite()
        {
            using (var db = Db.CreateDbByConfigName("sqlite_test"))
            {
                
                var list = db.GetEntities<User>(UserSet.SelectAll()).FindLast(m=>m.Id>0).Name;
                Console.WriteLine(list);

                var id = db.GetScalarToMObject(UserSet.Select(UserSet.Id.Max())).To<Int64>();
                User user = new User();
                user.Age = id+1;
                user.Name = "Name"+user.Age;
                db.Add(user);

                Console.WriteLine(user.Id);
                 
            }
        }
    }
}

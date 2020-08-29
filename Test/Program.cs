/*
 * 由SharpDevelop创建。
 * 用户： 秦仕川
 * 日期: 2013-8-22
 * 时间: 14:56
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Threading;
using Moon.Orm;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using TestContext;

using Moon.Orm.Util;
namespace Test
{
	
	class Program
	{
		/// <summary>
		/// 测试group及having语句
		/// </summary>
		public static DictionaryList TestHaving(){
			using (var db=Db.CreateDefaultDb()) {
				var mql=OrdersSet.Select(OrdersSet.OrderId.Count(),OrdersSet.CustomerId,OrdersSet.Finished)
					.Where(OrdersSet.CustomerId.SmallerThan(20))
					.GroupBy(OrdersSet.CustomerId,OrdersSet.Finished)
					.Having(OrdersSet.OrderId.Count().BiggerThan(2)).Top(5);
				var sql=mql.ToDebugSQL();//等价sql语句
				var list=db.GetDictionaryList(mql);
				return list;
			}
		}
		/// <summary>
		/// 测试join语句
		/// </summary>
		public static DictionaryList TestJoin(){
			using (var db=Db.CreateDefaultDb()) {
				var mql1=CustomersSet.Select(CustomersSet.CustomerName);
				var join=mql1.LeftJoin(OrdersSet.SelectAll())
					.ON(OrdersSet.CustomerId.Equal(CustomersSet.CustomerId).And(OrdersSet.OrderId.SmallerThan(1000)))
					.Where(OrdersSet.OrderId.BiggerThan(1)).Top(10);
				var sql=join.ToDebugSQL();//等价sql语句
				var list=db.GetDictionaryList(join);
				return list;
			}
		}
		/// <summary>
		/// 测试三条jion的语句
		/// </summary>
		public static DictionaryList TestHighJoinMQL(){
			using (var db=Db.CreateDefaultDb()) {
				var mql1=CustomersSet.Select(CustomersSet.CustomerName);
				var doubleJoin=mql1.LeftJoin(OrdersSet.Select(OrdersSet.OrderId.AS("_OrderId")))
					.ON(OrdersSet.CustomerId.Equal(CustomersSet.CustomerId).And(OrdersSet.OrderId.SmallerThan(100)))
					;
				var threeJoin=doubleJoin.LeftJoin(OrderDetailsSet.SelectAll())
					.ON(OrderDetailsSet.OrderId.Equal(OrdersSet.OrderId).And(OrderDetailsSet.OrderId.BiggerThan(2)))
					.Where(OrdersSet.OrderId.SmallerThan(999)).Top(10);
				
				var sql=threeJoin.ToDebugSQL();//等价sql语句
				var list=db.GetDictionaryList(threeJoin);
				return list;
			}
		}
		/// <summary>
		/// bool判断测试
		/// </summary>
		/// <returns></returns>
		public static DictionaryList TestBool(){
			using (var db=Db.CreateDefaultDb()) {
				var testBool=OrdersSet.SelectAll().Where(OrdersSet.Finished.Equal(false));
				var sql=testBool.ToDebugSQL();//等价sql语句
				return db.GetDictionaryList(testBool);
			}
		}
		/// <summary>
		/// 嵌套查询
		/// </summary>
		/// <returns></returns>
		public static DictionaryList QianTao(){
			using (var db=Db.CreateDefaultDb()) {
				var testBool=OrdersSet.SelectAll().Where(
					OrdersSet.CustomerId.In(
						CustomersSet.Select(CustomersSet.CustomerId).Where(CustomersSet.CustomerName.Contains("00"))
					).And(OrdersSet.OrderId.BiggerThan(8))
				);
				var sql=testBool.ToDebugSQL();//等价sql语句
				return db.GetDictionaryList(testBool);
			}
		}
		/// <summary>
		/// Union测试
		/// </summary>
		/// <returns></returns>
		public static DictionaryList TestUnion(){
			using (var db=Db.CreateDefaultDb()) {
				var mql1=CustomersSet.SelectAll().Where(CustomersSet.CustomerId.BiggerThan(10));
				var mql2=CustomersSet.SelectAll().Where(CustomersSet.CustomerId.SmallerThan(10));
				var mql3=CustomersSet.SelectAll().Where(CustomersSet.CustomerId.Equal(10));
				var mql=mql1.Union(mql2).Union(mql3).Top(1);
				var sql=mql.ToDebugSQL();//等价sql语句
				return db.GetDictionaryList(mql);
				
			}
		}
		/// <summary>
		/// 获取Products表数据的总条数
		/// </summary>
		/// <returns></returns>
		public static int GetProductCount(){
			using (var db=Db.CreateDefaultDb()) {
				var count2=db.GetInt32Count<ProductsSet>(ProductsSet.ProductId.BiggerThan(0));
				return count2;
			}
		}
		/// <summary>
		/// 添加实体对象的测试
		/// </summary>
		/// <returns></returns>
		public static void TestAddEntity(){
			using (var db=Db.CreateDefaultDb()) {
				var startCount=GetProductCount();
				Products p=new Products();
				p.ProductName="ProductName"+DateTime.Now;
				p.Quantity=100;
				p.Remark="标记";
				p.Unit="单元";
				p.UnitPrice=12m;
				p.CategoryId=3;
				db.Add(p);
				//克隆一个p对象,然后添加到数据库中
				var p2=p.Clone<Products>();
				db.Add(p2);
				var endCount=GetProductCount();
				Console.WriteLine("添加条数为:"+(endCount-startCount));
			}
		}
		/// <summary>
		/// 删除实体对象的测试
		/// </summary>
		public static void TestRemoveEntity(){
			using (var db=Db.CreateDefaultDb()) {
				var startCount=GetProductCount();
				Products p=new Products();
				p.ProductName="ProductName"+DateTime.Now;
				p.Quantity=100;
				p.Remark="标记";
				p.Unit="单元";
				p.UnitPrice=12m;
				p.CategoryId=3;
				db.Add(p);
				//删除这条新加的数据
				db.Remove<ProductsSet>(ProductsSet.ProductId.Equal(p.ProductId));
				var endCount=GetProductCount();
				Console.WriteLine("添加条数为:"+(endCount-startCount));
			}
		}
		public static void TestUpdateEntity(){
			using (var db=Db.CreateDefaultDb()) {
				db.DebugEnabled=true;
				var p=db.GetEntity<Products>(ProductsSet.SelectAll().Top(1));
				Console.WriteLine(p.ProductName);
				p.ProductName=p.ProductName+DateTime.Now;
				p.Quantity=11;
				//必须通过设置WhereExpression来指定需要更新哪些数据
				//--的确让用户有点误解,但这样可以指定更广泛的合符条件的数据如>100 and a<100
				p.WhereExpression=ProductsSet.ProductId.Equal(p.ProductId);
				db.Update(p);
				var sql=db.CurrentSQL;
				p=db.GetEntity<Products>(ProductsSet.SelectAll().Top(1));
				Console.WriteLine(p.ProductName);
			}
			
		}
		/// <summary>
		/// 嵌套查询2
		/// </summary>
		/// <returns></returns>
		public static DictionaryList QianTao2(){
			using (var db=Db.CreateDefaultDb()) {
				var testBool=OrdersSet.SelectAll().Where(
					OrdersSet.OrderId.BiggerThan(2)
					.And(
						OrdersSet.CustomerId.In(
							CustomersSet.Select(CustomersSet.CustomerId).Where(CustomersSet.CustomerName.Contains("00"))
						)).And(OrdersSet.OrderId.BiggerThan(8))
				);
				var sql=testBool.ToDebugSQL();//等价sql语句
				return db.GetDictionaryList(testBool);
			}
		}
		/// <summary>
		/// deep嵌套查询
		/// </summary>
		/// <returns></returns>
		public static DictionaryList QianTao3(){
			using (var db=Db.CreateDefaultDb()) {
				var mql1=CustomersSet.Select(CustomersSet.CustomerId).Where(CustomersSet.CustomerName.Contains("00"));
				var mql2=OrdersSet.Select(OrdersSet.OrderId).Where(OrdersSet.CustomerId.In(mql1));
				var mql3=OrderDetailsSet.Select(OrderDetailsSet.ProductId).Where(OrderDetailsSet.OrderId.In(mql2));
				var mqlEnd=ProductsSet.SelectAll().Where(ProductsSet.ProductId.In(mql3).And(ProductsSet.Quantity.BiggerThan(2)));
				var sql=mqlEnd.ToDebugSQL();
				return db.GetDictionaryList(mqlEnd);
			}
		}
		public static void TestProc()
		{
			var addID=-11;
			using (var db=Db.CreateDefaultDb())
			{
				db.DebugEnabled=true;
				//开启事务功能
				db.TransactionEnabled=true;
				try {
					Products p=new Products();
					p.ProductName="ProductName_TestProc"+DateTime.Now;
					p.Quantity=100;
					p.Remark="标记";
					p.Unit="单元";
					p.UnitPrice=12m;
					p.CategoryId=3;
					db.Add(p);
					
					addID=p.ProductId;
					Console.WriteLine("p.ProductId:"+addID);
					Orders order=new Orders();
					order.Comment="test";
					order.CustomerId=-43;//故意制造错误
					order.Finished=false;
					order.OrderDate=DateTime.Now;
					order.SumMoney=33;
					
					db.Add(order);
					db.Transaction.Commit();
					
					
				} catch (Exception ex) {
					db.Transaction.Rollback();
					var aa=ex.Message;
					Console.WriteLine(aa);
				}
				
				
			}
			Thread.Sleep(1000);
			using (var db=Db.CreateDefaultDb())
			{
				Console.WriteLine("p.ProductId:"+addID);
				var exist=db.Exist<ProductsSet>(ProductsSet.ProductId.Equal(addID));
				Console.WriteLine("添加的数据存在吗?"+exist);
			}
		}
		public static void Main(string[] args)
		{
			var sql=ProductsSet.SelectAll().Where(ProductsSet.ProductId.IsNull());
			Console.WriteLine(sql.ToDebugSQL());
          
			//TestProc();
			
//			var list=QianTao3();
//			list.ShowInConsole();
//			Console.WriteLine(list.Count);
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
			
			
		}
	}}

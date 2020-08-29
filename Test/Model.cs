using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Moon.Orm;

namespace TestContext
{

    [Table("[Categories]", DbType.SqlServer)]
    public class CategoriesSet : MQLBase
    {
        public static new MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.SqlServer,"[Categories]",fields);
        }
        public static new MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.SqlServer,"[Categories]");
        }
        public static readonly FieldBase CategoryId = new FieldBase(DbType.SqlServer, "[Categories]", FieldType.OnlyPrimaryKey, "[CategoryId]");
        public static readonly FieldBase CategoryName = new FieldBase(DbType.SqlServer, "[Categories]", FieldType.Common, "[CategoryName]");
    }

    [Table("[Customers]", DbType.SqlServer)]
    public class CustomersSet : MQLBase
    {
        public static new MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.SqlServer,"[Customers]",fields);
        }
        public static new MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.SqlServer,"[Customers]");
        }
        public static readonly FieldBase CustomerId = new FieldBase(DbType.SqlServer, "[Customers]", FieldType.OnlyPrimaryKey, "[CustomerId]");
        public static readonly FieldBase CustomerName = new FieldBase(DbType.SqlServer, "[Customers]", FieldType.Common, "[CustomerName]");
        public static readonly FieldBase ContactName = new FieldBase(DbType.SqlServer, "[Customers]", FieldType.Common, "[ContactName]");
        public static readonly FieldBase Address = new FieldBase(DbType.SqlServer, "[Customers]", FieldType.Common, "[Address]");
        public static readonly FieldBase PostalCode = new FieldBase(DbType.SqlServer, "[Customers]", FieldType.Common, "[PostalCode]");
        public static readonly FieldBase Tel = new FieldBase(DbType.SqlServer, "[Customers]", FieldType.Common, "[Tel]");
    }

    [Table("[OrderDetails]", DbType.SqlServer)]
    public class OrderDetailsSet : MQLBase
    {
        public static new MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.SqlServer,"[OrderDetails]",fields);
        }
        public static new MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.SqlServer,"[OrderDetails]");
        }
        public static readonly FieldBase DetailId = new FieldBase(DbType.SqlServer, "[OrderDetails]", FieldType.OnlyPrimaryKey, "[DetailId]");
        public static readonly FieldBase UnitPrice = new FieldBase(DbType.SqlServer, "[OrderDetails]", FieldType.Common, "[UnitPrice]");
        public static readonly FieldBase Quantity = new FieldBase(DbType.SqlServer, "[OrderDetails]", FieldType.Common, "[Quantity]");
        public static readonly FieldBase ProductId = new FieldBase(DbType.SqlServer, "[OrderDetails]", FieldType.ForeignKey, "[ProductId]");
        public static readonly FieldBase OrderId = new FieldBase(DbType.SqlServer, "[OrderDetails]", FieldType.ForeignKey, "[OrderId]");
    }

    [Table("[Orders]", DbType.SqlServer)]
    public class OrdersSet : MQLBase
    {
        public static new MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.SqlServer,"[Orders]",fields);
        }
        public static new MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.SqlServer,"[Orders]");
        }
        public static readonly FieldBase OrderId = new FieldBase(DbType.SqlServer, "[Orders]", FieldType.OnlyPrimaryKey, "[OrderId]");
        public static readonly FieldBase OrderDate = new FieldBase(DbType.SqlServer, "[Orders]", FieldType.Common, "[OrderDate]");
        public static readonly FieldBase SumMoney = new FieldBase(DbType.SqlServer, "[Orders]", FieldType.Common, "[SumMoney]");
        public static readonly FieldBase Comment = new FieldBase(DbType.SqlServer, "[Orders]", FieldType.Common, "[Comment]");
        public static readonly FieldBase Finished = new FieldBase(DbType.SqlServer, "[Orders]", FieldType.Common, "[Finished]");
        public static readonly FieldBase CustomerId = new FieldBase(DbType.SqlServer, "[Orders]", FieldType.ForeignKey, "[CustomerId]");
    }

    [Table("[Products]", DbType.SqlServer)]
    public class ProductsSet : MQLBase
    {
        public static new MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.SqlServer,"[Products]",fields);
        }
        public static new MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.SqlServer,"[Products]");
        }
        public static readonly FieldBase ProductId = new FieldBase(DbType.SqlServer, "[Products]", FieldType.OnlyPrimaryKey, "[ProductId]");
        public static readonly FieldBase ProductName = new FieldBase(DbType.SqlServer, "[Products]", FieldType.Common, "[ProductName]");
        public static readonly FieldBase Unit = new FieldBase(DbType.SqlServer, "[Products]", FieldType.Common, "[Unit]");
        public static readonly FieldBase UnitPrice = new FieldBase(DbType.SqlServer, "[Products]", FieldType.Common, "[UnitPrice]");
        public static readonly FieldBase Remark = new FieldBase(DbType.SqlServer, "[Products]", FieldType.Common, "[Remark]");
        public static readonly FieldBase Quantity = new FieldBase(DbType.SqlServer, "[Products]", FieldType.Common, "[Quantity]");
        public static readonly FieldBase CategoryId = new FieldBase(DbType.SqlServer, "[Products]", FieldType.ForeignKey, "[CategoryId]");
    }


    [Table("[Categories]", DbType.SqlServer)]
    [TablesPrimaryKey(PrimaryKeyType.AutoIncrease, typeof(Int32), "CategoryId")]
    public class Categories : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public Int32 CategoryId
        {
            get { return GetPropertyValue<Int32>("CategoryId"); }
            set { SetPropertyValue("CategoryId", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String CategoryName
        {
            get { return GetPropertyValue<String>("CategoryName"); }
            set { SetPropertyValue("CategoryName", value); }
        }
    }

    [Table("[Customers]", DbType.SqlServer)]
    [TablesPrimaryKey(PrimaryKeyType.AutoIncrease, typeof(Int32), "CustomerId")]
    public class Customers : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public Int32 CustomerId
        {
            get { return GetPropertyValue<Int32>("CustomerId"); }
            set { SetPropertyValue("CustomerId", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String CustomerName
        {
            get { return GetPropertyValue<String>("CustomerName"); }
            set { SetPropertyValue("CustomerName", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String ContactName
        {
            get { return GetPropertyValue<String>("ContactName"); }
            set { SetPropertyValue("ContactName", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String Address
        {
            get { return GetPropertyValue<String>("Address"); }
            set { SetPropertyValue("Address", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String PostalCode
        {
            get { return GetPropertyValue<String>("PostalCode"); }
            set { SetPropertyValue("PostalCode", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String Tel
        {
            get { return GetPropertyValue<String>("Tel"); }
            set { SetPropertyValue("Tel", value); }
        }
    }

    [Table("[OrderDetails]", DbType.SqlServer)]
    [TablesPrimaryKey(PrimaryKeyType.AutoIncrease, typeof(Int32), "DetailId")]
    public class OrderDetails : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public Int32 DetailId
        {
            get { return GetPropertyValue<Int32>("DetailId"); }
            set { SetPropertyValue("DetailId", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal UnitPrice
        {
            get { return GetPropertyValue<Decimal>("UnitPrice"); }
            set { SetPropertyValue("UnitPrice", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 Quantity
        {
            get { return GetPropertyValue<Int32>("Quantity"); }
            set { SetPropertyValue("Quantity", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 ProductId
        {
            get { return GetPropertyValue<Int32>("ProductId"); }
            set { SetPropertyValue("ProductId", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 OrderId
        {
            get { return GetPropertyValue<Int32>("OrderId"); }
            set { SetPropertyValue("OrderId", value); }
        }
    }

    [Table("[Orders]", DbType.SqlServer)]
    [TablesPrimaryKey(PrimaryKeyType.AutoIncrease, typeof(Int32), "OrderId")]
    public class Orders : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public Int32 OrderId
        {
            get { return GetPropertyValue<Int32>("OrderId"); }
            set { SetPropertyValue("OrderId", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime OrderDate
        {
            get { return GetPropertyValue<DateTime>("OrderDate"); }
            set { SetPropertyValue("OrderDate", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal SumMoney
        {
            get { return GetPropertyValue<Decimal>("SumMoney"); }
            set { SetPropertyValue("SumMoney", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String Comment
        {
            get { return GetPropertyValue<String>("Comment"); }
            set { SetPropertyValue("Comment", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean Finished
        {
            get { return GetPropertyValue<Boolean>("Finished"); }
            set { SetPropertyValue("Finished", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 CustomerId
        {
            get { return GetPropertyValue<Int32>("CustomerId"); }
            set { SetPropertyValue("CustomerId", value); }
        }
    }

    [Table("[Products]", DbType.SqlServer)]
    [TablesPrimaryKey(PrimaryKeyType.AutoIncrease, typeof(Int32), "ProductId")]
     
    public class Products : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public Int32 ProductId
        {
            get { return GetPropertyValue<Int32>("ProductId"); }
            set { SetPropertyValue("ProductId", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String ProductName
        {
            get { return GetPropertyValue<String>("ProductName"); }
            set { SetPropertyValue("ProductName", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String Unit
        {
            get { return GetPropertyValue<String>("Unit"); }
            set { SetPropertyValue("Unit", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal UnitPrice
        {
            get { return GetPropertyValue<Decimal>("UnitPrice"); }
            set { SetPropertyValue("UnitPrice", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String Remark
        {
            get { return GetPropertyValue<String>("Remark"); }
            set { SetPropertyValue("Remark", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 Quantity
        {
            get { return GetPropertyValue<Int32>("Quantity"); }
            set { SetPropertyValue("Quantity", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 CategoryId
        {
            get { return GetPropertyValue<Int32>("CategoryId"); }
            set { SetPropertyValue("CategoryId", value); }
        }
    }


}

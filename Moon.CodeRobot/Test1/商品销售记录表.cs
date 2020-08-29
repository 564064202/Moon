using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Moon.Orm;
namespace mysql
{

    [Table("`商品销售记录表`", DbType.MySql)]
    [TablesPrimaryKeyAttribute(PrimaryKeyType.AutoIncrease, typeof(int), "销售记录号")]
    public class 商品销售记录表 : EntityBase
    {
        public int 销售记录号
        {
            get { return GetPropertyValue<int>("销售记录号"); }
            set { SetPropertyValue("销售记录号", value); }
        }
        public int 销售单号
        {
            get { return GetPropertyValue<int>("销售单号"); }
            set { SetPropertyValue("销售单号", value); }
        }
        public string 商品条码
        {
            get { return GetPropertyValue<string>("商品条码"); }
            set { SetPropertyValue("商品条码", value); }
        }
        public decimal 单价
        {
            get { return GetPropertyValue<decimal>("单价"); }
            set { SetPropertyValue("单价", value); }
        }
        public int 数量
        {
            get { return GetPropertyValue<int>("数量"); }
            set { SetPropertyValue("数量", value); }
        }
    }

    [Table("`商品销售记录表`", DbType.MySql)]
    public class 商品销售记录表Set : MQLBase
    {
        public static new MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(fields);
        }
        public static new MQLBase SelectAll()
        {
            return MQLBase.SelectAll();
        }
        public static readonly FieldBase 销售记录号 = new FieldBase(DbType.MySql, "`商品销售记录表`", FieldType.OnlyPrimaryKey, "`销售记录号`");
        public static readonly FieldBase 销售单号 = new FieldBase(DbType.MySql, "`商品销售记录表`", FieldType.Common, "`销售单号`");
        public static readonly FieldBase 商品条码 = new FieldBase(DbType.MySql, "`商品销售记录表`", FieldType.Common, "`商品条码`");
        public static readonly FieldBase 单价 = new FieldBase(DbType.MySql, "`商品销售记录表`", FieldType.Common, "`单价`");
        public static readonly FieldBase 数量 = new FieldBase(DbType.MySql, "`商品销售记录表`", FieldType.Common, "`数量`");
    }

}

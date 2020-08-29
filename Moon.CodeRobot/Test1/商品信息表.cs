using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Moon.Orm;
namespace mysql
{

    [Table("`商品信息表`", DbType.MySql)]
    [TablesPrimaryKeyAttribute(PrimaryKeyType.CustomerGUID, typeof(string), "条码号")]
    public class 商品信息表 : EntityBase
    {
        public string 条码号
        {
            get { return GetPropertyValue<string>("条码号"); }
            set { SetPropertyValue("条码号", value); }
        }
        public string 商品名称
        {
            get { return GetPropertyValue<string>("商品名称"); }
            set { SetPropertyValue("商品名称", value); }
        }
        public string 厂商名称
        {
            get { return GetPropertyValue<string>("厂商名称"); }
            set { SetPropertyValue("厂商名称", value); }
        }
        public int 保质期
        {
            get { return GetPropertyValue<int>("保质期"); }
            set { SetPropertyValue("保质期", value); }
        }
    }

    [Table("`商品信息表`", DbType.MySql)]
    public class 商品信息表Set : MQLBase
    {
        public static new MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(fields);
        }
        public static new MQLBase SelectAll()
        {
            return MQLBase.SelectAll();
        }
        public static readonly FieldBase 条码号 = new FieldBase(DbType.MySql, "`商品信息表`", FieldType.OnlyPrimaryKey, "`条码号`");
        public static readonly FieldBase 商品名称 = new FieldBase(DbType.MySql, "`商品信息表`", FieldType.Common, "`商品名称`");
        public static readonly FieldBase 厂商名称 = new FieldBase(DbType.MySql, "`商品信息表`", FieldType.Common, "`厂商名称`");
        public static readonly FieldBase 保质期 = new FieldBase(DbType.MySql, "`商品信息表`", FieldType.Common, "`保质期`");
    }

}

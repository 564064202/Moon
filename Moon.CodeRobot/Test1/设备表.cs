using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Moon.Orm;
namespace mysql
{

    [Table("`设备表`", DbType.MySql)]
    [TablesPrimaryKeyAttribute(PrimaryKeyType.CustomerGUID, typeof(string), "编号")]
    public class 设备表 : EntityBase
    {
        public string 编号
        {
            get { return GetPropertyValue<string>("编号"); }
            set { SetPropertyValue("编号", value); }
        }
        public string 设备名称
        {
            get { return GetPropertyValue<string>("设备名称"); }
            set { SetPropertyValue("设备名称", value); }
        }
        public string 型号
        {
            get { return GetPropertyValue<string>("型号"); }
            set { SetPropertyValue("型号", value); }
        }
        public DateTime 购置时间
        {
            get { return GetPropertyValue<DateTime>("购置时间"); }
            set { SetPropertyValue("购置时间", value); }
        }
        public string 备注
        {
            get { return GetPropertyValue<string>("备注"); }
            set { SetPropertyValue("备注", value); }
        }
    }

    [Table("`设备表`", DbType.MySql)]
    public class 设备表Set : MQLBase
    {
        public static new MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(fields);
        }
        public static new MQLBase SelectAll()
        {
            return MQLBase.SelectAll();
        }
        public static readonly FieldBase 编号 = new FieldBase(DbType.MySql, "`设备表`", FieldType.OnlyPrimaryKey, "`编号`");
        public static readonly FieldBase 设备名称 = new FieldBase(DbType.MySql, "`设备表`", FieldType.Common, "`设备名称`");
        public static readonly FieldBase 型号 = new FieldBase(DbType.MySql, "`设备表`", FieldType.Common, "`型号`");
        public static readonly FieldBase 购置时间 = new FieldBase(DbType.MySql, "`设备表`", FieldType.Common, "`购置时间`");
        public static readonly FieldBase 备注 = new FieldBase(DbType.MySql, "`设备表`", FieldType.Common, "`备注`");
    }

}

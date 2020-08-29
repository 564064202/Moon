using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Moon.Orm;
namespace mysql
{

    [Table("`雇员表`", DbType.MySql)]
    [TablesPrimaryKeyAttribute(PrimaryKeyType.CustomerGUID, typeof(string), "工号")]
    public class 雇员表 : EntityBase
    {
        public string 工号
        {
            get { return GetPropertyValue<string>("工号"); }
            set { SetPropertyValue("工号", value); }
        }
        public string 姓名
        {
            get { return GetPropertyValue<string>("姓名"); }
            set { SetPropertyValue("姓名", value); }
        }
        public bool 性别
        {
            get { return GetPropertyValue<bool>("性别"); }
            set { SetPropertyValue("性别", value); }
        }
        public DateTime 出生日期
        {
            get { return GetPropertyValue<DateTime>("出生日期"); }
            set { SetPropertyValue("出生日期", value); }
        }
        public DateTime 入职时间
        {
            get { return GetPropertyValue<DateTime>("入职时间"); }
            set { SetPropertyValue("入职时间", value); }
        }
        public string 职务名称
        {
            get { return GetPropertyValue<string>("职务名称"); }
            set { SetPropertyValue("职务名称", value); }
        }
    }

    [Table("`雇员表`", DbType.MySql)]
    public class 雇员表Set : MQLBase
    {
        public static new MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(fields);
        }
        public static new MQLBase SelectAll()
        {
            return MQLBase.SelectAll();
        }
        public static readonly FieldBase 工号 = new FieldBase(DbType.MySql, "`雇员表`", FieldType.OnlyPrimaryKey, "`工号`");
        public static readonly FieldBase 姓名 = new FieldBase(DbType.MySql, "`雇员表`", FieldType.Common, "`姓名`");
        public static readonly FieldBase 性别 = new FieldBase(DbType.MySql, "`雇员表`", FieldType.Common, "`性别`");
        public static readonly FieldBase 出生日期 = new FieldBase(DbType.MySql, "`雇员表`", FieldType.Common, "`出生日期`");
        public static readonly FieldBase 入职时间 = new FieldBase(DbType.MySql, "`雇员表`", FieldType.Common, "`入职时间`");
        public static readonly FieldBase 职务名称 = new FieldBase(DbType.MySql, "`雇员表`", FieldType.Common, "`职务名称`");
    }

}

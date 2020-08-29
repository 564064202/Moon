using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Moon.Orm;
namespace mysql
{

    [Table("`Class`", DbType.MySql)]
    [TablesPrimaryKeyAttribute(PrimaryKeyType.AutoIncrease, typeof(int), "ClassID")]
    public class Class : EntityBase
    {
        public int ClassID
        {
            get { return GetPropertyValue<int>("ClassID"); }
            set { SetPropertyValue("ClassID", value); }
        }
        public string ClassName
        {
            get { return GetPropertyValue<string>("ClassName"); }
            set { SetPropertyValue("ClassName", value); }
        }
    }

    [Table("`Class`", DbType.MySql)]
    public class ClassSet : MQLBase
    {
        public static new MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(fields);
        }
        public static new MQLBase SelectAll()
        {
            return MQLBase.SelectAll();
        }
        public static readonly FieldBase ClassID = new FieldBase(DbType.MySql, "`Class`", FieldType.OnlyPrimaryKey, "`ClassID`");
        public static readonly FieldBase ClassName = new FieldBase(DbType.MySql, "`Class`", FieldType.Common, "`ClassName`");
    }

}

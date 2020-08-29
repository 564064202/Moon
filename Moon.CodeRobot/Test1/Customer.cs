using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Moon.Orm;
namespace mysql
{

    [Table("`Customer`", DbType.MySql)]
    public class Customer : EntityBase
    {
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }
    }

    [Table("`Customer`", DbType.MySql)]
    public class CustomerSet : MQLBase
    {
        public static new MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(fields);
        }
        public static new MQLBase SelectAll()
        {
            return MQLBase.SelectAll();
        }
        public static readonly FieldBase Id = new FieldBase(DbType.MySql, "`Customer`", FieldType.Common, "`Id`");
    }

}

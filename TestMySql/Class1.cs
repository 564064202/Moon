using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Moon.Orm;

namespace mysql
{

    [Table("`area`", DbType.MySql)]
    public class areaSet : MQLBase
    {
        public static new MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.MySql,"`area`",fields);
        }
        public static new MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.MySql,"`area`");
        }
        public static readonly FieldBase AreaCode = new FieldBase(DbType.MySql, "`area`", FieldType.OnlyPrimaryKey, "`AreaCode`");
        public static readonly FieldBase AreaName = new FieldBase(DbType.MySql, "`area`", FieldType.Common, "`AreaName`");
        public static readonly FieldBase ParentCode = new FieldBase(DbType.MySql, "`area`", FieldType.Common, "`ParentCode`");
        public static readonly FieldBase Short = new FieldBase(DbType.MySql, "`area`", FieldType.Common, "`Short`");
        public static readonly FieldBase Sort = new FieldBase(DbType.MySql, "`area`", FieldType.Common, "`Sort`");
        public static readonly FieldBase IsActive = new FieldBase(DbType.MySql, "`area`", FieldType.Common, "`IsActive`");
    }

    [Table("`mtest`", DbType.MySql)]
    public class mtestSet : MQLBase
    {
        public static new MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.MySql,"`mtest`",fields);
        }
        public static new MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.MySql,"`mtest`");
        }
        public static readonly FieldBase CharTypeId = new FieldBase(DbType.MySql, "`mtest`", FieldType.OnlyPrimaryKey, "`CharTypeId`");
        public static readonly FieldBase CharTypeName = new FieldBase(DbType.MySql, "`mtest`", FieldType.Common, "`CharTypeName`");
        public static readonly FieldBase CharTypeNum = new FieldBase(DbType.MySql, "`mtest`", FieldType.Common, "`CharTypeNum`");
        public static readonly FieldBase Is_Delete = new FieldBase(DbType.MySql, "`mtest`", FieldType.Common, "`Is_Delete`");
        public static readonly FieldBase Status = new FieldBase(DbType.MySql, "`mtest`", FieldType.Common, "`Status`");
        public static readonly FieldBase SerialNo = new FieldBase(DbType.MySql, "`mtest`", FieldType.Common, "`SerialNo`");
        public static readonly FieldBase IsVisible = new FieldBase(DbType.MySql, "`mtest`", FieldType.Common, "`IsVisible`");
    }


    [Table("`area`", DbType.MySql)]
    [TablesPrimaryKey(PrimaryKeyType.CustomerGUID, typeof(Int32), "AreaCode")]
    public class area : EntityBase
    {

        /// <summary>
        /// 区域编码
        /// </summary>
        public Int32 AreaCode
        {
            get { return GetPropertyValue<Int32>("AreaCode"); }
            set { SetPropertyValue("AreaCode", value); }
        }

        /// <summary>
        /// 区域名称
        /// </summary>
        public String AreaName
        {
            get { return GetPropertyValue<String>("AreaName"); }
            set { SetPropertyValue("AreaName", value); }
        }

        /// <summary>
        /// 父级编码
        /// </summary>
        public Int32 ParentCode
        {
            get { return GetPropertyValue<Int32>("ParentCode"); }
            set { SetPropertyValue("ParentCode", value); }
        }

        /// <summary>
        /// 简拼
        /// </summary>
        public String Short
        {
            get { return GetPropertyValue<String>("Short"); }
            set { SetPropertyValue("Short", value); }
        }

        /// <summary>
        /// 排序
        /// </summary>
        public Int32 Sort
        {
            get { return GetPropertyValue<Int32>("Sort"); }
            set { SetPropertyValue("Sort", value); }
        }

        /// <summary>
        /// 状态
        /// </summary>
        public Boolean IsActive
        {
            get { return GetPropertyValue<Boolean>("IsActive"); }
            set { SetPropertyValue("IsActive", value); }
        }
    }

    [Table("`mtest`", DbType.MySql)]
    [TablesPrimaryKey(PrimaryKeyType.CustomerGUID, typeof(String), "CharTypeId")]
    public class mtest : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public String CharTypeId
        {
            get { return GetPropertyValue<String>("CharTypeId"); }
            set { SetPropertyValue("CharTypeId", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String CharTypeName
        {
            get { return GetPropertyValue<String>("CharTypeName"); }
            set { SetPropertyValue("CharTypeName", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String CharTypeNum
        {
            get { return GetPropertyValue<String>("CharTypeNum"); }
            set { SetPropertyValue("CharTypeNum", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean? Is_Delete
        {
            get { return GetPropertyValue<Boolean?>("Is_Delete"); }
            set { SetPropertyValue("Is_Delete", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean? Status
        {
            get { return GetPropertyValue<Boolean?>("Status"); }
            set { SetPropertyValue("Status", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32? SerialNo
        {
            get { return GetPropertyValue<Int32?>("SerialNo"); }
            set { SetPropertyValue("SerialNo", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean? IsVisible
        {
            get { return GetPropertyValue<Boolean?>("IsVisible"); }
            set { SetPropertyValue("IsVisible", value); }
        }
    }


}

 using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Moon.Orm;

namespace sqlite
{

    [Table("[Student]", DbType.Sqlite)]
    public  partial class StudentSet : MQLBase
    {
        public static  MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite,"[Student]",fields);
        }
        public static  MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite,"[Student]");
        }
        public static MQLBase SelectAllBut(params FieldBase[] fields)
        {
            return MQLBase.SelectAllBut(typeof(StudentSet),DbType.Sqlite,"[Student]",fields);
        }

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase ID = new FieldBase(DbType.Sqlite, "[Student]", FieldType.OnlyPrimaryKey, "[ID]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase Name = new FieldBase(DbType.Sqlite, "[Student]", FieldType.Common, "[Name]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase Age = new FieldBase(DbType.Sqlite, "[Student]", FieldType.Common, "[Age]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase BirthDay = new FieldBase(DbType.Sqlite, "[Student]", FieldType.Common, "[BirthDay]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase Sex = new FieldBase(DbType.Sqlite, "[Student]", FieldType.Common, "[Sex]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase Class_ID = new FieldBase(DbType.Sqlite, "[Student]", FieldType.Common, "[Class_ID]");
    }

    [Table("[Class]", DbType.Sqlite)]
    public  partial class ClassSet : MQLBase
    {
        public static  MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite,"[Class]",fields);
        }
        public static  MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite,"[Class]");
        }
        public static MQLBase SelectAllBut(params FieldBase[] fields)
        {
            return MQLBase.SelectAllBut(typeof(ClassSet),DbType.Sqlite,"[Class]",fields);
        }

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase ID = new FieldBase(DbType.Sqlite, "[Class]", FieldType.OnlyPrimaryKey, "[ID]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase ClassName = new FieldBase(DbType.Sqlite, "[Class]", FieldType.Common, "[ClassName]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase ClassLevel = new FieldBase(DbType.Sqlite, "[Class]", FieldType.Common, "[ClassLevel]");
    }

    [Table("[Score]", DbType.Sqlite)]
    public  partial class ScoreSet : MQLBase
    {
        public static  MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite,"[Score]",fields);
        }
        public static  MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite,"[Score]");
        }
        public static MQLBase SelectAllBut(params FieldBase[] fields)
        {
            return MQLBase.SelectAllBut(typeof(ScoreSet),DbType.Sqlite,"[Score]",fields);
        }

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase ID = new FieldBase(DbType.Sqlite, "[Score]", FieldType.OnlyPrimaryKey, "[ID]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase Score = new FieldBase(DbType.Sqlite, "[Score]", FieldType.Common, "[Score]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase Student_ID = new FieldBase(DbType.Sqlite, "[Score]", FieldType.Common, "[Student_ID]");
    }


    [Table("[Student]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.AutoIncrease, typeof(Int64), "ID")]
    public partial class Student : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public Int64 ID
        {
            get { return GetPropertyValue<Int64>("ID"); }
            set { SetPropertyValue("ID", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String Name
        {
            get { return GetPropertyValue<String>("Name"); }
            set { SetPropertyValue("Name", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 Age
        {
            get { return GetPropertyValue<Int32>("Age"); }
            set { SetPropertyValue("Age", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime BirthDay
        {
            get { return GetPropertyValue<DateTime>("BirthDay"); }
            set { SetPropertyValue("BirthDay", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean Sex
        {
            get { return GetPropertyValue<Boolean>("Sex"); }
            set { SetPropertyValue("Sex", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 Class_ID
        {
            get { return GetPropertyValue<Int64>("Class_ID"); }
            set { SetPropertyValue("Class_ID", value); }
        }
    }

    [Table("[Class]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.AutoIncrease, typeof(Int64), "ID")]
    public partial class Class : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public Int64 ID
        {
            get { return GetPropertyValue<Int64>("ID"); }
            set { SetPropertyValue("ID", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String ClassName
        {
            get { return GetPropertyValue<String>("ClassName"); }
            set { SetPropertyValue("ClassName", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 ClassLevel
        {
            get { return GetPropertyValue<Int32>("ClassLevel"); }
            set { SetPropertyValue("ClassLevel", value); }
        }
    }

    [Table("[Score]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.AutoIncrease, typeof(Int64), "ID")]
    public partial class Score : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public Int64 ID
        {
            get { return GetPropertyValue<Int64>("ID"); }
            set { SetPropertyValue("ID", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 Score_
        {
            get { return GetPropertyValue<Int32>("Score"); }
            set { SetPropertyValue("Score", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 Student_ID
        {
            get { return GetPropertyValue<Int64>("Student_ID"); }
            set { SetPropertyValue("Student_ID", value); }
        }
    }


}

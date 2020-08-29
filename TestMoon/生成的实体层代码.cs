using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Moon.Orm;

namespace sqlite
{

    [Table("[tb_LoginSet]", DbType.Sqlite)]
    public partial class tb_LoginSetSet : MQLBase
    {
        public static MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite, "[tb_LoginSet]", fields);
        }
        public static MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite, "[tb_LoginSet]");
        }
        public static MQLBase SelectAllBut(params FieldBase[] fields)
        {
            return MQLBase.SelectAllBut(typeof(tb_LoginSetSet), DbType.Sqlite, "[tb_LoginSet]", fields);
        }

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase _needLogin = new FieldBase(DbType.Sqlite, "[tb_LoginSet]", FieldType.Common, "[_needLogin]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase _cancelPower = new FieldBase(DbType.Sqlite, "[tb_LoginSet]", FieldType.Common, "[_cancelPower]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase _id = new FieldBase(DbType.Sqlite, "[tb_LoginSet]", FieldType.OnlyPrimaryKey, "[_id]");
    }

    [Table("[tb_UserInfo]", DbType.Sqlite)]
    public partial class tb_UserInfoSet : MQLBase
    {
        public static MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite, "[tb_UserInfo]", fields);
        }
        public static MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite, "[tb_UserInfo]");
        }
        public static MQLBase SelectAllBut(params FieldBase[] fields)
        {
            return MQLBase.SelectAllBut(typeof(tb_UserInfoSet), DbType.Sqlite, "[tb_UserInfo]", fields);
        }

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase _userName = new FieldBase(DbType.Sqlite, "[tb_UserInfo]", FieldType.OnlyPrimaryKey, "[_userName]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase _passWord = new FieldBase(DbType.Sqlite, "[tb_UserInfo]", FieldType.Common, "[_passWord]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase _isSuperMgr = new FieldBase(DbType.Sqlite, "[tb_UserInfo]", FieldType.Common, "[_isSuperMgr]");
    }

    [Table("[UserInfo]", DbType.Sqlite)]
    public partial class UserInfoSet : MQLBase
    {
        public static MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite, "[UserInfo]", fields);
        }
        public static MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite, "[UserInfo]");
        }
        public static MQLBase SelectAllBut(params FieldBase[] fields)
        {
            return MQLBase.SelectAllBut(typeof(UserInfoSet), DbType.Sqlite, "[UserInfo]", fields);
        }

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase id = new FieldBase(DbType.Sqlite, "[UserInfo]", FieldType.OnlyPrimaryKey, "[id]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase userName = new FieldBase(DbType.Sqlite, "[UserInfo]", FieldType.Common, "[userName]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase passWord = new FieldBase(DbType.Sqlite, "[UserInfo]", FieldType.Common, "[passWord]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase loginTime = new FieldBase(DbType.Sqlite, "[UserInfo]", FieldType.Common, "[loginTime]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase powerGrade = new FieldBase(DbType.Sqlite, "[UserInfo]", FieldType.Common, "[powerGrade]");
    }

    [Table("[ProjectTree]", DbType.Sqlite)]
    public partial class ProjectTreeSet : MQLBase
    {
        public static MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite, "[ProjectTree]", fields);
        }
        public static MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite, "[ProjectTree]");
        }
        public static MQLBase SelectAllBut(params FieldBase[] fields)
        {
            return MQLBase.SelectAllBut(typeof(ProjectTreeSet), DbType.Sqlite, "[ProjectTree]", fields);
        }

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase location = new FieldBase(DbType.Sqlite, "[ProjectTree]", FieldType.OnlyPrimaryKey, "[location]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase nodeName = new FieldBase(DbType.Sqlite, "[ProjectTree]", FieldType.Common, "[nodeName]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase parentLocation = new FieldBase(DbType.Sqlite, "[ProjectTree]", FieldType.Common, "[parentLocation]");
    }

    [Table("[Attachment]", DbType.Sqlite)]
    public partial class AttachmentSet : MQLBase
    {
        public static MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite, "[Attachment]", fields);
        }
        public static MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite, "[Attachment]");
        }
        public static MQLBase SelectAllBut(params FieldBase[] fields)
        {
            return MQLBase.SelectAllBut(typeof(AttachmentSet), DbType.Sqlite, "[Attachment]", fields);
        }

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase fileName = new FieldBase(DbType.Sqlite, "[Attachment]", FieldType.Common, "[fileName]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase codeID = new FieldBase(DbType.Sqlite, "[Attachment]", FieldType.Common, "[codeID]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase id = new FieldBase(DbType.Sqlite, "[Attachment]", FieldType.OnlyPrimaryKey, "[id]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase fileSize = new FieldBase(DbType.Sqlite, "[Attachment]", FieldType.Common, "[fileSize]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase fileBinary = new FieldBase(DbType.Sqlite, "[Attachment]", FieldType.Common, "[fileBinary]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase fileExtension = new FieldBase(DbType.Sqlite, "[Attachment]", FieldType.Common, "[fileExtension]");
    }

    [Table("[test]", DbType.Sqlite)]
    public partial class testSet : MQLBase
    {
        public static MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite, "[test]", fields);
        }
        public static MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite, "[test]");
        }
        public static MQLBase SelectAllBut(params FieldBase[] fields)
        {
            return MQLBase.SelectAllBut(typeof(testSet), DbType.Sqlite, "[test]", fields);
        }

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase id = new FieldBase(DbType.Sqlite, "[test]", FieldType.OnlyPrimaryKey, "[id]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase name = new FieldBase(DbType.Sqlite, "[test]", FieldType.Common, "[name]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase addTime = new FieldBase(DbType.Sqlite, "[test]", FieldType.Common, "[addTime]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase stuID = new FieldBase(DbType.Sqlite, "[test]", FieldType.Common, "[stuID]");
    }

    [Table("[CodeInfo]", DbType.Sqlite)]
    public partial class CodeInfoSet : MQLBase
    {
        public static MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite, "[CodeInfo]", fields);
        }
        public static MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite, "[CodeInfo]");
        }
        public static MQLBase SelectAllBut(params FieldBase[] fields)
        {
            return MQLBase.SelectAllBut(typeof(CodeInfoSet), DbType.Sqlite, "[CodeInfo]", fields);
        }

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase id = new FieldBase(DbType.Sqlite, "[CodeInfo]", FieldType.OnlyPrimaryKey, "[id]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase treeLocation = new FieldBase(DbType.Sqlite, "[CodeInfo]", FieldType.Common, "[treeLocation]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase codeCaption = new FieldBase(DbType.Sqlite, "[CodeInfo]", FieldType.Common, "[codeCaption]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase useLanguage = new FieldBase(DbType.Sqlite, "[CodeInfo]", FieldType.Common, "[useLanguage]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase introduce = new FieldBase(DbType.Sqlite, "[CodeInfo]", FieldType.Common, "[introduce]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase importGrade = new FieldBase(DbType.Sqlite, "[CodeInfo]", FieldType.Common, "[importGrade]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase code = new FieldBase(DbType.Sqlite, "[CodeInfo]", FieldType.Common, "[code]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase addDateTime = new FieldBase(DbType.Sqlite, "[CodeInfo]", FieldType.Common, "[addDateTime]");
    }

    [Table("[tb_Priority]", DbType.Sqlite)]
    public partial class tb_PrioritySet : MQLBase
    {
        public static MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite, "[tb_Priority]", fields);
        }
        public static MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite, "[tb_Priority]");
        }
        public static MQLBase SelectAllBut(params FieldBase[] fields)
        {
            return MQLBase.SelectAllBut(typeof(tb_PrioritySet), DbType.Sqlite, "[tb_Priority]", fields);
        }

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase priorityName = new FieldBase(DbType.Sqlite, "[tb_Priority]", FieldType.OnlyPrimaryKey, "[priorityName]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase isFirstItem = new FieldBase(DbType.Sqlite, "[tb_Priority]", FieldType.Common, "[isFirstItem]");
    }

    [Table("[tb_Languages]", DbType.Sqlite)]
    public partial class tb_LanguagesSet : MQLBase
    {
        public static MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite, "[tb_Languages]", fields);
        }
        public static MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite, "[tb_Languages]");
        }
        public static MQLBase SelectAllBut(params FieldBase[] fields)
        {
            return MQLBase.SelectAllBut(typeof(tb_LanguagesSet), DbType.Sqlite, "[tb_Languages]", fields);
        }

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase languageName = new FieldBase(DbType.Sqlite, "[tb_Languages]", FieldType.OnlyPrimaryKey, "[languageName]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase isFirstItem = new FieldBase(DbType.Sqlite, "[tb_Languages]", FieldType.Common, "[isFirstItem]");
    }

    [Table("[NetNameInfo]", DbType.Sqlite)]
    public partial class NetNameInfoSet : MQLBase
    {
        public static MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite, "[NetNameInfo]", fields);
        }
        public static MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite, "[NetNameInfo]");
        }
        public static MQLBase SelectAllBut(params FieldBase[] fields)
        {
            return MQLBase.SelectAllBut(typeof(NetNameInfoSet), DbType.Sqlite, "[NetNameInfo]", fields);
        }

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase Name = new FieldBase(DbType.Sqlite, "[NetNameInfo]", FieldType.Common, "[Name]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase PassWord = new FieldBase(DbType.Sqlite, "[NetNameInfo]", FieldType.Common, "[PassWord]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase id = new FieldBase(DbType.Sqlite, "[NetNameInfo]", FieldType.OnlyPrimaryKey, "[id]");
    }

    [Table("[Administrator]", DbType.Sqlite)]
    public partial class AdministratorSet : MQLBase
    {
        public static MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite, "[Administrator]", fields);
        }
        public static MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite, "[Administrator]");
        }
        public static MQLBase SelectAllBut(params FieldBase[] fields)
        {
            return MQLBase.SelectAllBut(typeof(AdministratorSet), DbType.Sqlite, "[Administrator]", fields);
        }

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase UserName = new FieldBase(DbType.Sqlite, "[Administrator]", FieldType.Common, "[UserName]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase Password = new FieldBase(DbType.Sqlite, "[Administrator]", FieldType.Common, "[Password]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase ID = new FieldBase(DbType.Sqlite, "[Administrator]", FieldType.OnlyPrimaryKey, "[ID]");
    }

    [Table("[TT]", DbType.Sqlite)]
    public partial class TTSet : MQLBase
    {
        public static MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite, "[TT]", fields);
        }
        public static MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite, "[TT]");
        }
        public static MQLBase SelectAllBut(params FieldBase[] fields)
        {
            return MQLBase.SelectAllBut(typeof(TTSet), DbType.Sqlite, "[TT]", fields);
        }

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase ID = new FieldBase(DbType.Sqlite, "[TT]", FieldType.OnlyPrimaryKey, "[ID]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase Name = new FieldBase(DbType.Sqlite, "[TT]", FieldType.Common, "[Name]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase IsHigh = new FieldBase(DbType.Sqlite, "[TT]", FieldType.Common, "[IsHigh]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase Birth = new FieldBase(DbType.Sqlite, "[TT]", FieldType.Common, "[Birth]");
    }

    [Table("[UsersSystemInfo]", DbType.Sqlite)]
    public partial class UsersSystemInfoSet : MQLBase
    {
        public static MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite, "[UsersSystemInfo]", fields);
        }
        public static MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite, "[UsersSystemInfo]");
        }
        public static MQLBase SelectAllBut(params FieldBase[] fields)
        {
            return MQLBase.SelectAllBut(typeof(UsersSystemInfoSet), DbType.Sqlite, "[UsersSystemInfo]", fields);
        }

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase SystemKey = new FieldBase(DbType.Sqlite, "[UsersSystemInfo]", FieldType.Common, "[SystemKey]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase Email = new FieldBase(DbType.Sqlite, "[UsersSystemInfo]", FieldType.Common, "[Email]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase ID = new FieldBase(DbType.Sqlite, "[UsersSystemInfo]", FieldType.OnlyPrimaryKey, "[ID]");
    }

    [Table("[LinkHistory]", DbType.Sqlite)]
    public partial class LinkHistorySet : MQLBase
    {
        public static MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite, "[LinkHistory]", fields);
        }
        public static MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite, "[LinkHistory]");
        }
        public static MQLBase SelectAllBut(params FieldBase[] fields)
        {
            return MQLBase.SelectAllBut(typeof(LinkHistorySet), DbType.Sqlite, "[LinkHistory]", fields);
        }

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase DbType_ = new FieldBase(DbType.Sqlite, "[LinkHistory]", FieldType.Common, "[DbType]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase LinkString = new FieldBase(DbType.Sqlite, "[LinkHistory]", FieldType.Common, "[LinkString]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase MarkPrimaryField = new FieldBase(DbType.Sqlite, "[LinkHistory]", FieldType.Common, "[MarkPrimaryField]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase AddTime = new FieldBase(DbType.Sqlite, "[LinkHistory]", FieldType.Common, "[AddTime]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase ProjectName = new FieldBase(DbType.Sqlite, "[LinkHistory]", FieldType.Common, "[ProjectName]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase FilesGeneratingPath = new FieldBase(DbType.Sqlite, "[LinkHistory]", FieldType.Common, "[FilesGeneratingPath]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase DatabaseName = new FieldBase(DbType.Sqlite, "[LinkHistory]", FieldType.Common, "[DatabaseName]");

        /// <summary>
        /// 
        /// </summary>
        public static readonly FieldBase ID = new FieldBase(DbType.Sqlite, "[LinkHistory]", FieldType.OnlyPrimaryKey, "[ID]");
    }


    [Table("[tb_LoginSet]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.AutoIncrease, typeof(Int64), "_id")]
    public partial class tb_LoginSet : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public Boolean _needLogin
        {
            get { return GetPropertyValue<Boolean>("_needLogin"); }
            set { SetPropertyValue("_needLogin", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean _cancelPower
        {
            get { return GetPropertyValue<Boolean>("_cancelPower"); }
            set { SetPropertyValue("_cancelPower", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 _id
        {
            get { return GetPropertyValue<Int64>("_id"); }
            set { SetPropertyValue("_id", value); }
        }
    }

    [Table("[tb_UserInfo]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.CustomerGUID, typeof(String), "_userName")]
    public partial class tb_UserInfo : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public String _userName
        {
            get { return GetPropertyValue<String>("_userName"); }
            set { SetPropertyValue("_userName", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String _passWord
        {
            get { return GetPropertyValue<String>("_passWord"); }
            set { SetPropertyValue("_passWord", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean _isSuperMgr
        {
            get { return GetPropertyValue<Boolean>("_isSuperMgr"); }
            set { SetPropertyValue("_isSuperMgr", value); }
        }
    }

    [Table("[UserInfo]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.AutoIncrease, typeof(Int64), "id")]
    public partial class UserInfo : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public Int64 id
        {
            get { return GetPropertyValue<Int64>("id"); }
            set { SetPropertyValue("id", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String userName
        {
            get { return GetPropertyValue<String>("userName"); }
            set { SetPropertyValue("userName", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String passWord
        {
            get { return GetPropertyValue<String>("passWord"); }
            set { SetPropertyValue("passWord", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime loginTime
        {
            get { return GetPropertyValue<DateTime>("loginTime"); }
            set { SetPropertyValue("loginTime", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 powerGrade
        {
            get { return GetPropertyValue<Int32>("powerGrade"); }
            set { SetPropertyValue("powerGrade", value); }
        }
    }

    [Table("[ProjectTree]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.CustomerGUID, typeof(String), "location")]
    public partial class ProjectTree : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public String location
        {
            get { return GetPropertyValue<String>("location"); }
            set { SetPropertyValue("location", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String nodeName
        {
            get { return GetPropertyValue<String>("nodeName"); }
            set { SetPropertyValue("nodeName", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String parentLocation
        {
            get { return GetPropertyValue<String>("parentLocation"); }
            set { SetPropertyValue("parentLocation", value); }
        }
    }

    [Table("[Attachment]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.AutoIncrease, typeof(Int64), "id")]
    public partial class Attachment : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public String fileName
        {
            get { return GetPropertyValue<String>("fileName"); }
            set { SetPropertyValue("fileName", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 codeID
        {
            get { return GetPropertyValue<Int64>("codeID"); }
            set { SetPropertyValue("codeID", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 id
        {
            get { return GetPropertyValue<Int64>("id"); }
            set { SetPropertyValue("id", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal fileSize
        {
            get { return GetPropertyValue<Decimal>("fileSize"); }
            set { SetPropertyValue("fileSize", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public byte[] fileBinary
        {
            get { return GetPropertyValue<byte[]>("fileBinary"); }
            set { SetPropertyValue("fileBinary", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String fileExtension
        {
            get { return GetPropertyValue<String>("fileExtension"); }
            set { SetPropertyValue("fileExtension", value); }
        }
    }

    [Table("[test]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.AutoIncrease, typeof(Int64), "id")]
    public partial class test : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public Int64 id
        {
            get { return GetPropertyValue<Int64>("id"); }
            set { SetPropertyValue("id", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String name
        {
            get { return GetPropertyValue<String>("name"); }
            set { SetPropertyValue("name", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime addTime
        {
            get { return GetPropertyValue<DateTime>("addTime"); }
            set { SetPropertyValue("addTime", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String stuID
        {
            get { return GetPropertyValue<String>("stuID"); }
            set { SetPropertyValue("stuID", value); }
        }
    }

    [Table("[CodeInfo]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.AutoIncrease, typeof(Int64), "id")]
    public partial class CodeInfo : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public Int64 id
        {
            get { return GetPropertyValue<Int64>("id"); }
            set { SetPropertyValue("id", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String treeLocation
        {
            get { return GetPropertyValue<String>("treeLocation"); }
            set { SetPropertyValue("treeLocation", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String codeCaption
        {
            get { return GetPropertyValue<String>("codeCaption"); }
            set { SetPropertyValue("codeCaption", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String useLanguage
        {
            get { return GetPropertyValue<String>("useLanguage"); }
            set { SetPropertyValue("useLanguage", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String introduce
        {
            get { return GetPropertyValue<String>("introduce"); }
            set { SetPropertyValue("introduce", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String importGrade
        {
            get { return GetPropertyValue<String>("importGrade"); }
            set { SetPropertyValue("importGrade", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String code
        {
            get { return GetPropertyValue<String>("code"); }
            set { SetPropertyValue("code", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime addDateTime
        {
            get { return GetPropertyValue<DateTime>("addDateTime"); }
            set { SetPropertyValue("addDateTime", value); }
        }
    }

    [Table("[tb_Priority]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.CustomerGUID, typeof(String), "priorityName")]
    public partial class tb_Priority : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public String priorityName
        {
            get { return GetPropertyValue<String>("priorityName"); }
            set { SetPropertyValue("priorityName", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean isFirstItem
        {
            get { return GetPropertyValue<Boolean>("isFirstItem"); }
            set { SetPropertyValue("isFirstItem", value); }
        }
    }

    [Table("[tb_Languages]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.CustomerGUID, typeof(String), "languageName")]
    public partial class tb_Languages : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public String languageName
        {
            get { return GetPropertyValue<String>("languageName"); }
            set { SetPropertyValue("languageName", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean isFirstItem
        {
            get { return GetPropertyValue<Boolean>("isFirstItem"); }
            set { SetPropertyValue("isFirstItem", value); }
        }
    }

    [Table("[NetNameInfo]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.AutoIncrease, typeof(Int64), "id")]
    public partial class NetNameInfo : EntityBase
    {

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
        public String PassWord
        {
            get { return GetPropertyValue<String>("PassWord"); }
            set { SetPropertyValue("PassWord", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 id
        {
            get { return GetPropertyValue<Int64>("id"); }
            set { SetPropertyValue("id", value); }
        }
    }

    [Table("[Administrator]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.AutoIncrease, typeof(Int64), "ID")]
    public partial class Administrator : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public String UserName
        {
            get { return GetPropertyValue<String>("UserName"); }
            set { SetPropertyValue("UserName", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String Password
        {
            get { return GetPropertyValue<String>("Password"); }
            set { SetPropertyValue("Password", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 ID
        {
            get { return GetPropertyValue<Int64>("ID"); }
            set { SetPropertyValue("ID", value); }
        }
    }

    [Table("[TT]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.CustomerGUID, typeof(Int64), "ID")]
    public partial class TT : EntityBase
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
        public Boolean IsHigh
        {
            get { return GetPropertyValue<Boolean>("IsHigh"); }
            set { SetPropertyValue("IsHigh", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Birth
        {
            get { return GetPropertyValue<DateTime>("Birth"); }
            set { SetPropertyValue("Birth", value); }
        }
    }

    [Table("[UsersSystemInfo]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.AutoIncrease, typeof(Int64), "ID")]
    public partial class UsersSystemInfo : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public String SystemKey
        {
            get { return GetPropertyValue<String>("SystemKey"); }
            set { SetPropertyValue("SystemKey", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String Email
        {
            get { return GetPropertyValue<String>("Email"); }
            set { SetPropertyValue("Email", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 ID
        {
            get { return GetPropertyValue<Int64>("ID"); }
            set { SetPropertyValue("ID", value); }
        }
    }

    [Table("[LinkHistory]", Moon.Orm.DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.AutoIncrease, typeof(Int64), "ID")]
    public partial class LinkHistory : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public String DbType
        {
            get { return GetPropertyValue<String>("DbType"); }
            set { SetPropertyValue("DbType", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String LinkString
        {
            get { return GetPropertyValue<String>("LinkString"); }
            set { SetPropertyValue("LinkString", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean MarkPrimaryField
        {
            get { return GetPropertyValue<Boolean>("MarkPrimaryField"); }
            set { SetPropertyValue("MarkPrimaryField", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime
        {
            get { return GetPropertyValue<DateTime>("AddTime"); }
            set { SetPropertyValue("AddTime", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String ProjectName
        {
            get { return GetPropertyValue<String>("ProjectName"); }
            set { SetPropertyValue("ProjectName", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String FilesGeneratingPath
        {
            get { return GetPropertyValue<String>("FilesGeneratingPath"); }
            set { SetPropertyValue("FilesGeneratingPath", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String DatabaseName
        {
            get { return GetPropertyValue<String>("DatabaseName"); }
            set { SetPropertyValue("DatabaseName", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String ID
        {
            get { return GetPropertyValue<String>("ID"); }
            set { SetPropertyValue("ID", value); }
        }
    }


}

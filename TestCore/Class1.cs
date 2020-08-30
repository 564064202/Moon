using System;
using System.Collections.Generic;
namespace moontemp
{
    public class Book
    {
        private Int32 _Id;
        public Int32 Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private String _Name;
        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private Int32 _TB_Admin_Admin_ID;
        public Int32 TB_Admin_Admin_ID
        {
            get { return _TB_Admin_Admin_ID; }
            set { _TB_Admin_Admin_ID = value; }
        }
    }
}

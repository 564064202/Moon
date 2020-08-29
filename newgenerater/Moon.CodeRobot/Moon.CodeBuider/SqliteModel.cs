using System;
using System.Collections.Generic;

namespace Moon.CodeBuider{
	public class SqliteModel {
		private Int64 _cid;
		public Int64 cid{
			get{return _cid;}
			set{_cid=value;}
		}
		private String _name;
		public String name{
			get{return _name;}
			set{_name=value;}
		}
		private String _type;
		public String type{
			get{return _type;}
			set{_type=value;}
		}
		private Int64 _notnull;
		public Int64 notnull{
			get{return _notnull;}
			set{_notnull=value;}
		}
		private Object _dflt_value;
		public Object dflt_value{
			get{return _dflt_value;}
			set{_dflt_value=value;}
		}
		private Int64 _pk;
		public Int64 pk{
			get{return _pk;}
			set{_pk=value;}
		}
	}
}
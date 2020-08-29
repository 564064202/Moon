using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moon.Orm;
using Moon.Orm.Util;
using System.Web;

namespace Moon.LigerUI
{
    public static class DbExtensions
    {
        /// <summary>
        /// 获取grid的json数据
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sql">查询语句</param>
        /// <param name="parameters">查询参数</param>
        /// <param name="oneOrderbyFieldName">排序字段,如果id desc ,仅仅sqlserver需要</param>
        /// <returns></returns>
        public static string GetGridData(this Db db, string sql, object[] parameters, string oneOrderbyFieldName)
        {
            var request = HttpContext.Current.Request;
            int page = int.Parse(request["page"]);
            int pagesize = int.Parse(request["pagesize"]);
            int sumPageCount;
            int sumDataCount;
            var json = db.GetPagerToJson(sql, parameters, out sumPageCount, out sumDataCount, page, pagesize, oneOrderbyFieldName);
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("Rows:" + json);
            sb.Append(",Total:" + sumDataCount);
            sb.Append("}");
            return sb.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="mql">查询语句</param>
        /// <param name="oneOrderbyFieldName">排序字段,如果id desc ,仅仅sqlserver需要</param>
        /// <returns></returns>
        public static string GetGridData(this Db db, MQLBase mql, string oneOrderbyFieldName)
        {
            var request = HttpContext.Current.Request;
            int page = int.Parse(request["page"]);
            int pagesize = int.Parse(request["pagesize"]);
            int sumPageCount;
            int sumDataCount;
            var json = db.GetPagerToJson(mql, out sumPageCount, out sumDataCount, page, pagesize, oneOrderbyFieldName);
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("Rows:" + json);
            sb.Append(",Total:" + sumDataCount);
            sb.Append("}");
            return sb.ToString();
        }
    }
}

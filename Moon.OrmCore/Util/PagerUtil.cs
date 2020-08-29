/*
 * 由SharpDevelop创建。
 * 用户： 秦仕川
 * 日期: 2013-12-7
 * 时间: 15:50
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Web;

namespace Moon.Orm.Util
{

	/// <summary>
	/// 分页辅助类(注意只能在网站中使用)
	/// </summary>
	public static class PagerUtil
	{
		/// <summary>
		/// 获取Pager(分页数据(DictionaryList)及分页控件),注意db会自动关闭.
		/// </summary>
		/// <param name="db">数据查询引擎</param>
		/// <param name="pageBaseUrl">分页的基础Url(这是最基础的请求部分)</param>
		/// <param name="parameters">额外指定的参数(格式如a=7&amp;b=4),可以为空</param>
		/// <param name="mql">mql语句</param>
		/// <param name="sumPageCount">总页数</param>
		/// <param name="sumDataCount">总数据条数</param>
		/// <param name="pageIndex">页码</param>
		/// <param name="onePageDataCount">每页数据的条数</param>
		/// <param name="oneOrderbyFieldName">sqlserver中会用到的排序字段(查询结果中一个字段),其他类型数据库则填写null</param>
		/// <returns>分页数据及分页控件</returns>
		public static Pager GetUrlPager(Db db,string pageBaseUrl,string parameters,MQLBase mql,
		                                out int sumPageCount,out int sumDataCount,
		                                int pageIndex,int onePageDataCount,string oneOrderbyFieldName)
		{
			var pager=new Pager();
			pager.Data=db.GetPagerToDictionaryList(mql,out sumPageCount,out  sumDataCount,pageIndex,onePageDataCount,oneOrderbyFieldName);
			pager.UrlPagerControl=GetUrlPagerControl(sumPageCount,pageIndex,onePageDataCount,pageBaseUrl,parameters);
			db.Close();
			return pager;
		}
		
		/// <summary>
		/// 获取Pager(分页数据(DictionaryList)及分页控件),注意db会自动关闭.
		/// </summary>
		/// <param name="db">数据查询引擎</param>
		/// <param name="pageBaseUrl">分页的基础Url(这是最基础的请求部分)</param>
		/// <param name="parameters">额外指定的参数(格式如a=7&amp;b=4),可以为空</param>
		/// <param name="sql">执行的语句,其中放变量的地方仅仅用@表示(eg:select * from user wehre id>@ and age=@)</param>
		/// <param name="sqlParameters">sql对应参数值列表</param>
		/// <param name="sumPageCount">总页数</param>
		/// <param name="sumDataCount">总数据条数</param>
		/// <param name="pageIndex">页码</param>
		/// <param name="onePageDataCount">每页数据的条数</param>
		/// <param name="oneOrderbyFieldName">sqlserver中会用到的排序字段(查询结果中一个字段),其他类型数据库则填写null</param>
		/// <returns>分页数据及分页控件</returns>
		public static Pager GetUrlPager(Db db,string pageBaseUrl,string parameters,string sql,object[] sqlParameters,
		                                out int sumPageCount,out int sumDataCount,
		                                int pageIndex,int onePageDataCount,string oneOrderbyFieldName)
		{
			var pager=new Pager();
			pager.Data=db.GetPagerToDictionaryList(sql,sqlParameters,out sumPageCount,out  sumDataCount,pageIndex,onePageDataCount,oneOrderbyFieldName);
			pager.UrlPagerControl=GetUrlPagerControl(sumPageCount,pageIndex,onePageDataCount,pageBaseUrl,parameters);
			db.Close();
			return pager;
		}
		
		/// <summary>
		/// 获取Ajax分页控件的脚本:&lt;script&gt;....&lt;/script&gt;
		/// </summary>
		/// <returns>Ajax分页控件的脚本</returns>
		public static string GetAjaxPagerControlScripts(){
			string script="<script>"+OrmResourceUtil.GetValue("ajaxscripts")+"</script>";
			return script;
		}
		/// <summary>
		/// 获取Ajax分页控件的脚本和样式
		/// </summary>
		/// <returns>分页控件的脚本和样式</returns>
		public static string GetAjaxPagerControlScriptsAndCss(){
			return GetAjaxPagerControlScripts()+Environment.NewLine+GetPagerControlDefaultStyle();
		}
		
//		public static string GetAjaxPager(){
//
//		}
		/// <summary>
		/// 获取分页控件的默认样式:&lt;style&gt;....&lt;/style&gt;
		/// </summary>
		/// <returns>样式内容</returns>
		public static string GetPagerControlDefaultStyle(){
			string style=@"<style>
		 .pageNav a { color:#2B4A78; text-decoration:none;margin-right:1px; }
		 .pageNav a:hover { color:#2B4A78;text-decoration:underline; }
		 .pageNav  a:focus,
		 .pageNav input:focus {outline-style:none; outline-width:medium; }
		 .pageNav .pageNum{border: 1px solid #999;padding:2px 8px;display: inline-block;}
		 .pageNav .cPageNum{font-weight: bold;padding:2px 5px;}
		 .pageNav  a:hover{text-decoration:none;background: #fff4d8; }
		 .pageNav {text-align:right;margin-right:5px;margin-top:5px;margin-bottom:5px;}
				</style>";
			return style;
		}
		/// <summary>
		/// 获取分页控件(html的形式)
		/// </summary>
		/// <param name="sumPageCount">总页数</param>
		/// <param name="pageIndex">当前页码</param>
		/// <param name="pageSize">每页的数据条数</param>
		/// <param name="pageBaseUrl">分页的基础Url(这是最基础的请求部分)</param>
		/// <param name="parameters">额外指定的参数(格式如a=7&amp;b=4),可以为空</param>
		/// <returns>分页控件:Html形式</returns>
		public static string GetUrlPagerControl(int sumPageCount, int pageIndex, int pageSize, string pageBaseUrl, string parameters)
		{
			if (pageIndex <= 0)
			{
				throw new Exception("pageIndex can't be "+pageIndex);
			}
			if (pageSize <= 0)
			{
				throw new Exception("pageSize can't be "+pageSize);
			}
			
			StringBuilder strHtml = new StringBuilder();
			strHtml.Append("<div class=\"pageNav\">");
			
			if (pageIndex > 1)
			{
				strHtml.Append(string.Format("<a class='pageNum ' href=\"{0}?pageSize={1}&pageIndex={2}{3}\">首页</a>", pageBaseUrl
				                             , pageSize
				                             , 1
				                             , string.IsNullOrEmpty(parameters) ? "" : "&" + parameters));
			}
			
			if (pageIndex > 1)
			{
				strHtml.Append(string.Format("<a class='pageNum ' href=\"{0}?pageSize={1}&pageIndex={2}{3}\">上一页</a>", pageBaseUrl
				                             , pageSize
				                             , pageIndex - 1
				                             , string.IsNullOrEmpty(parameters) ? "" : "&" + parameters));
			}
			int i = pageIndex; //起始页
			int Count = sumPageCount;  //循环的页码
			
			//设置分页起始页
			if ((pageIndex - 1) % 5 == 0)
			{
				i = pageIndex;
			}
			else
			{
				i = pageIndex - ((pageIndex - 1) % 5);
			}
			
			if ((pageIndex - 1) % 5 == 0 && (sumPageCount - pageIndex + 1) % 5 == 0)
			{
				Count = pageIndex + 4;
			}
			else
			{
				Count = pageIndex + ((sumPageCount - pageIndex + 1) % 5);
			}
			
			if (Count > sumPageCount)
			{
				Count = sumPageCount;
			}
			
			for (; i <= Count; i++)
			{
				//当前页
				if (i == pageIndex)
				{
					if (sumPageCount>1) {
						strHtml.Append(string.Format("<a href=\"#\" class=\"cPageNum\" >{0}</a>", i.ToString()));
					}
					
				}
				else
				{
					//其他页
					strHtml.Append(string.Format("<a class='pageNum ' href=\"{0}?pageSize={1}&pageIndex={2}{3}\">{4}</a>", pageBaseUrl
					                             , pageSize
					                             , i
					                             , string.IsNullOrEmpty(parameters) ? "" : "&" + parameters
					                             , i.ToString()));
				}
			}
			
			if (pageIndex < sumPageCount)
			{
				strHtml.Append(string.Format("<a class='pageNum ' href=\"{0}?pageSize={1}&pageIndex={2}{3}\">下一页</a>", pageBaseUrl
				                             , pageSize
				                             , pageIndex + 1
				                             , string.IsNullOrEmpty(parameters) ? "" : "&" + parameters));
			}
			
			if (pageIndex < sumPageCount)
			{
				strHtml.Append(string.Format("<a class='pageNum ' href=\"{0}?pageSize={1}&pageIndex={2}{3}\">尾页</a>", pageBaseUrl
				                             , pageSize
				                             , sumPageCount
				                             , string.IsNullOrEmpty(parameters) ? "" : "&" + parameters));
			}
			if (sumPageCount>1) {
				strHtml.Append("&nbsp;共"+sumPageCount+"页");
			}
			
			strHtml.Append("</div>");
			return strHtml.ToString();
		}
		//-------------------------------
		/// <summary>
		/// 获取一个网页形式的分页布局
		/// </summary>
		/// <param name="db">db引擎</param>
		/// <param name="smallPageURL">去这个页面地址取数据</param>
		/// <param name="contentDomID">用于存放数据的domID</param>
		/// <param name="mql">mql语句</param>
		/// <param name="onePageDataCount">每页的数据条数</param>
		/// <param name="oneOrderbyFieldName">如果没有则填写null(提示:似乎只有sqlserver中可能会用上)</param>
		/// <returns>分页布局</returns>
		public static string GetWebPager(Db db,string smallPageURL,string contentDomID,MQLBase mql,int onePageDataCount,string oneOrderbyFieldName){
			string scriptsLink="<div id='pageNav'></div><script src='/Resources/Framework/pagenav.js'></script>";
			string css="<style type='text/css' media='screen'>a { color:#2B4A78; text-decoration:none; }a:hover { color:#2B4A78;text-decoration:underline; }a:focus, input:focus {outline-style:none; outline-width:medium; }.pageNum{border: 1px solid #999;padding:2px 8px;display: inline-block;}.cPageNum{font-weight: bold;padding:2px 5px;}#pageNav a:hover{text-decoration:none;background: #fff4d8; }</style>";
			int sumPageCount;
			string sql=mql.ToSQLExpression();
			string countSql="SELECT COUNT(0) FROM ("+sql+")  T_MOON_Search0";
			var parameters=mql.Parameters.ToArray();
			var countData=db.ExecuteSqlToScalar(countSql,parameters);
			var sumDataCount=Convert.ToInt32(countData);
			sumPageCount=sumDataCount/onePageDataCount;
			if (sumDataCount%onePageDataCount>0) {
				sumPageCount++;
			}
			string script="<script>var _perCount="+onePageDataCount+";var _pageSum="+sumPageCount+";var _listDivID='"+contentDomID+"';var _listActionPlace='"+smallPageURL+"';function GetPage(currentPageIndex,pageSum){$.ajax({url:_listActionPlace,async:true,cache:false,data:{PageIndex:currentPageIndex,onePageDataCount:"+onePageDataCount+"},success:function(html){$('#'+_listDivID).html('');$('#'+_listDivID).html(html);}});}$(function(){pageNav.pre='前一页';pageNav.next='下一页';pageNav.fn=function(currentPageIndex,pageSum){GetPage(currentPageIndex,pageSum);};pageNav.go(1,_pageSum);});</script>";
			db.Close();
			return scriptsLink+css+script;
			
		}
		/// <summary>
		/// smallPageURL中的数据
		/// </summary>
		/// <param name="db">db引擎</param>
		/// <param name="mql">mql</param>
		/// <param name="oneOrderbyFieldName">如果没有则填写null(提示:似乎只有sqlserver中可能会用上)</param>
		/// <returns></returns>
		public static DictionaryList GetOneWebPagesData(Db db,MQLBase mql,string oneOrderbyFieldName){
			throw new NotImplementedException();
		}
	}
}

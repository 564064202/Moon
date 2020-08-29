/*
 * 由SharpDevelop创建。
 * 用户： qscq
 * 日期: 2015/7/4
 * 时间: 11:25
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Web;
namespace Moon.CodeBuider
{
    /// <summary>
    /// Description of EmailUtil.
    /// </summary>
    public class EmailUtil
    {
        const string Url = "http://lko2o.com/Home/Send.ajax";
        public static bool Send(string title, string content, string receiver)
        {
            return true;
            try
            {
                title = HttpUtility.UrlEncode(title);
                content = HttpUtility.UrlEncode(content);
                receiver = HttpUtility.UrlEncode(receiver);
                HttpWebRequestHelper helper = new HttpWebRequestHelper();
                helper.GetContent(Url, "title=" + title + "&content=" + content + "&receiver=" + receiver);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public static string GetValue(object instance)
        {
            var type = instance.GetType(); //获取类型
            System.Reflection.PropertyInfo propertyInfo = type.GetProperty("ConnectionStr"); //获取指定名称的属性
            var ret = propertyInfo.GetValue(instance, null); //获取属性值
            return ret.ToString();

        }
    }
}

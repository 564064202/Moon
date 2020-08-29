/*
 * 由SharpDevelop创建。
 * 用户： qscq
 * 日期: 2014/5/10
 * 时间: 16:35
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using Moon.Orm;
using Moon.Orm.Util;
using System.IO;

namespace CodeRobot
{
    /// <summary>
    /// Description of Class1.
    /// </summary>
    public class Util
    {
        public static void SetProjectPath(string pname, string value)
        {
            var path = GlobalData.DLL_EXE_DIRECTORY_PATH + "path" + GlobalData.OS_SPLIT_STRING + pname + ".txt";
            IOUtil.CreateDirectoryWhenNotExist(GlobalData.DLL_EXE_DIRECTORY_PATH + "path");
            StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8);
            sw.Write(value);
            sw.Close();
        }
        public static void DeleteProjectPath(string pname)
        {
            var path = GlobalData.DLL_EXE_DIRECTORY_PATH + "path" + GlobalData.OS_SPLIT_STRING + pname + ".txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        public static string GetProjectPath(string pname)
        {
            var path = GlobalData.DLL_EXE_DIRECTORY_PATH + "path" + GlobalData.OS_SPLIT_STRING + pname + ".txt";
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8);
                var ret = sr.ReadToEnd();
                sr.Close();
                return ret;
            }
            else
            {
                return "";
            }
        }
        public static string GetHostName()
        {
            String hostName = Dns.GetHostName();
            return hostName;
        }
        public static void ShowMessageBox(string text)
        {
            System.Windows.Forms.MessageBox.Show(text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Send(string title, string content, string receiver)
        {
            //创建 SmtpClient 以发送 Email
            SmtpClient client = new SmtpClient();
            MailMessage message = new MailMessage();
            //设置发信人的EMAIL地址
            message.From = new MailAddress("flameskyorg@126.com");
            //设置收信人的EMAIL地址
            message.To.Add(receiver);
            //设置回复的EMAIL地址
            message.ReplyTo = new MailAddress("564064202@qq.com");
            //设置发信主题及内容
            message.Subject = title;
            message.Body = content;
            message.IsBodyHtml = true;
            //设置SMTP服务器
            client.Host = "smtp.126.com";
            //设置SMTP 端口
            client.Port = 25;
            client.UseDefaultCredentials = false;
            //设置SMTP的登录名和密码
            System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("flameskyorg@126.com", "705507");
            client.Credentials = basicAuthenticationInfo;
            client.EnableSsl = false;
            try
            {
                client.Send(message);//发送邮件
            }
            catch (Exception)
            {

            }
        }
    }
}

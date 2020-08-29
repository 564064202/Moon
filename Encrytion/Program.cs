/*
 * 由SharpDevelop创建。
 * 用户： qscq
 * 日期: 2014/8/6
 * 时间: 19:27
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Net.Mail;
using System.Net;
namespace Encrytion
{
	class Program
	{
		public static void Send(string title,string content,string receiver){
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
			message.Body =content;
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
			try {
				client.Send(message);//发送邮件
			} catch (Exception  ) {
				
			}
		}
		public static void Main(string[] args)
		{
			string name=System.Configuration.ConfigurationSettings.AppSettings["name"];
			string email=System.Configuration.ConfigurationSettings.AppSettings["email"];
			string econtent=name+email;
			EncryptUtil.CreateFile(econtent);
			
			var a=EncryptUtil.EncryptByDes(econtent);
			string content=(econtent+"↑"+a);
			string title="请将以下授权信息保存到一个名为moon.license的文件中(utf-8),然后将此文件放到moon.orm.dll所在的每一个项目中;收到请回复,谢谢";
			Send(title,content,email);
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}
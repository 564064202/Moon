using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Moon.Orm;
using Moon.Orm.EntityBuilder;
using Microsoft.CSharp;
using System.Net.Mail;
using System.CodeDom.Compiler;

namespace Enterprise
{
	/// <summary>
	/// Description of Tool.
	/// </summary>
	public class Tool
	{
		public static  bool SendEmail(string title,string content,string sendTo,string ownEmail)
		{
			try {
				SmtpClient client = new SmtpClient ();
				MailMessage message = new MailMessage ();
				//设置发信人的EMAIL地址
				message.From = new MailAddress ("panjiayuan_com@126.com");
				//设置收信人的EMAIL地址
				message.To.Add (sendTo);
				//设置回复的EMAIL地址
				message.ReplyTo = new MailAddress (ownEmail);
				//设置发信主题及内容
				message.Subject = title;
				message.Body = content;
				message.IsBodyHtml = true;
				//设置SMTP服务器
				client.Host = "smtp.126.com";
				message.BodyEncoding = System.Text.Encoding.UTF8;
				//设置SMTP 端口
				client.Port = 25;
				client.UseDefaultCredentials = false;
				//设置SMTP的登录名和密码
				System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential ("panjiayuan_com@126.com", "yuanjiapan");
				client.Credentials = basicAuthenticationInfo;
				client.EnableSsl = false;
				client.Send (message);
				return true;
				
			} catch (Exception) {
				
				return false;
			}
		}
		
		public static string Complie(string content,string fileFullPath){
			var provider = CodeDomProvider.CreateProvider("CSharp");
			CompilerParameters cp = new CompilerParameters();
			cp.GenerateExecutable = false;
			cp.OutputAssembly =fileFullPath;
			cp.GenerateInMemory = false;
			cp.TreatWarningsAsErrors = false;
			cp.ReferencedAssemblies.Add( "Moon.Orm.dll" );
			CompilerResults cr = provider.CompileAssemblyFromSource(cp,
			                                                        new string[]{content});
			string ret=null;
			if(cr.Errors.Count > 0)
			{
				
				foreach(CompilerError ce in cr.Errors)
				{
					ret+=ce.ToString();
				}
			}
			else
			{
				ret=string.Format("恭喜您,实体集成功已经生成到: {0}.",
				                  cr.PathToAssembly);
			}
			return ret;
		}
	}
}

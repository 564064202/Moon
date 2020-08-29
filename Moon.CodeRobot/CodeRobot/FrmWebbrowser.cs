/*
 * 由SharpDevelop创建。
 * 用户： qscq
 * 日期: 2014/3/8
 * 时间: 12:52
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using CodeRobot;
using Qios.DevSuite.Components;
using Qios.DevSuite.Components.Ribbon;

namespace Moon.LanguageExpert
{
	/// <summary>
	/// Description of FrmWebbrowser.
	/// </summary>
	public partial class FrmWebbrowser :QRibbonForm
	{
		public string URL{
			get;
			set;
		}
		public FrmWebbrowser(string url,Point location)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			location=new Point(location.X-this.Width,location.Y);
			this.Location=location;
			this.URL=url;
			wbLogin.DocumentCompleted+= new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
			this.wbLogin.DocumentTitleChanged += new EventHandler(this.wbLogin_DocumentTitleChanged);
			
		}
		public void SetLocation(Point location){
			location=new Point(location.X-this.Width,location.Y);
			this.Location=location;
		}
		private void wbLogin_DocumentTitleChanged(object sender, EventArgs e)
		{
			this.tsbtnGoBack.Enabled = this.wbLogin.CanGoBack;
			this.tsbtnForward.Enabled = this.wbLogin.CanGoForward;
			this.Text=wbLogin.DocumentTitle+"   语言专家浏览器";
		}
		void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			WebBrowser webBrowser = sender as WebBrowser;
			if (!(e.Url.ToString() != webBrowser.Url.ToString()) && webBrowser.ReadyState == WebBrowserReadyState.Complete)
			{
				
			}
		}
		public static bool IsUrl(string url)
		{
			bool result;
			try
			{
				Uri uri = new Uri(url);
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		void FrmWebbrowserLoad(object sender, EventArgs e)
		{
			tstbURL.Text=this.URL;
			wbLogin.Navigate(this.URL);
		}
		
		void TsbtnGOCClick(object sender, EventArgs e)
		{
			if (IsUrl(this.tstbURL.Text))
			{
				this.wbLogin.Navigate(new Uri(this.tstbURL.Text));
			}
			else
			{
				string content = "您的url格式有误";
				Util.ShowMessageBox(content);
			}
		}
		
		void TsbtnRefreshClick(object sender, EventArgs e)
		{
			this.wbLogin.Refresh();
		}
		
		void TsbtnGoBackClick(object sender, EventArgs e)
		{
			if (wbLogin.CanGoBack) {
				wbLogin.GoBack();
			}
		}
		
		void TsbtnForwardClick(object sender, EventArgs e)
		{
			if (wbLogin.CanGoForward) {
				wbLogin.GoForward();
			}
		}
	}
}

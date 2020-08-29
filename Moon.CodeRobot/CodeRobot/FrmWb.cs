/*
 * 由SharpDevelop创建。
 * 用户： qscq
 * 日期: 2015/7/6
 * 时间: 21:01
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using Qios.DevSuite.Components.Ribbon;

namespace CodeRobot
{
	/// <summary>
	/// Description of FrmWb.
	/// </summary>
	public partial class FrmWb : QRibbonForm
	{
		public FrmWb()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public FrmWb(string tite,string url):this(){
			
			
			this.StartPosition= FormStartPosition.CenterScreen;
			this.Text=tite;
			URL= url ;
		}
		public string URL{
			get;
			set;
		}
		void Form1_NewWindow3(ref object ppDisp, ref bool Cancel, uint dwFlags, string bstrUrlContext, string bstrUrl)
		{
			Cancel = true;
			this.wb1.Navigate(bstrUrl);
			
		}
		void SetEnvent(){
			var axwb= (this.wb1.ActiveXInstance as SHDocVw.WebBrowser);
			axwb.NewWindow3 += new SHDocVw.DWebBrowserEvents2_NewWindow3EventHandler(Form1_NewWindow3);
			axwb.Silent=true;
		}
		
		
		
		void FrmWbLoad(object sender, EventArgs e)
		{
			wb1.Navigate(this.URL);
			SetEnvent();
            this.WindowState = FormWindowState.Maximized;
		}
		
	}
}

/*
 * 由SharpDevelop创建。
 * 用户： qinshichuan
 * 日期: 2012-9-1
 * 时间: 21:12
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Enterprise
{
	/// <summary>
	/// Description of FrmGCode.
	/// </summary>
	public partial class FrmGCode : Form
	{
		public FrmGCode(string code)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			this.MaximizeBox=false;
			InitializeComponent();
			tbCode.Text=code;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void BtnCopyClick(object sender, EventArgs e)
		{
			if (tbCode.Text!="") {
				try{
					Clipboard.SetText(tbCode.Text);
				}
				catch{
					MessageBox.Show("复制失败");
				}
			}
		}
	}
}

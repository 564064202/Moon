/*
 * 由SharpDevelop创建。
 * 用户： qinshichuan
 * 日期: 2012-9-8
 * 时间: 9:50
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Enterprise
{
	/// <summary>
	/// Description of FrmProgress.
	/// </summary>
	public partial class FrmProgress : Form
	{
		public FrmProgress()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void TimerProgerssTick(object sender, EventArgs e)
		{
			if (progressBar1.Value<progressBar1.Maximum) {
				progressBar1.Value++;
			}
			else{
				progressBar1.Value=0;
			}
		}
	}
}

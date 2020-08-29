/*
 * 由SharpDevelop创建。
 * 用户： qinshichuan
 * 日期: 2012-12-29
 * 时间: 15:09
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Moon.Orm;
using MoonDB;
 

namespace Enterprise
{
	/// <summary>
	/// Description of BaseForm.
	/// </summary>
	public class BaseForm:Form
	{
		public void First(){
			this._sm = new SkinFramework.SkinningManager();
			this._sm.DefaultSkin = SkinFramework.DefaultSkin.Office2007Luna;
			this._sm.ParentForm = this;
		}
		 private SkinFramework.SkinningManager _sm;
	}
}

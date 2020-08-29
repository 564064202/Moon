using System;
using System.Collections.Generic;
using System.Drawing;
 
using System.Windows.Forms;

using Qios.DevSuite.Components;

namespace CodeRobot
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
           Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			QGlobalFont.Instance.InheritFromWindows = false;
			try
			{
				FontFamily family = new FontFamily("Segoe UI");
				QGlobalFont.Instance.Font = new Font(family, 9f);
			}
			catch
			{
				QGlobalFont.Instance.Font = new Font("Tahoma", 8.25f);
			}
			QColorScheme.Global.InheritCurrentThemeFromWindows = true;
			QColorScheme.Global.CurrentTheme = "LunaBlue";
			Application.Run(new frmMain());
        }
    }
}

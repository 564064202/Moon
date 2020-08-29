using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Management;
using System.Windows.Forms;
namespace Moon.LanguageExpert
{
	public static class SystemHelper
	{
		public static bool Is64System()
		{
			ConnectionOptions oConn = new ConnectionOptions();
			System.Management.ManagementScope oMs = new System.Management.ManagementScope("\\\\localhost", oConn);
			System.Management.ObjectQuery oQuery = new System.Management.ObjectQuery("select AddressWidth from Win32_Processor");
			ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs, oQuery);
			ManagementObjectCollection oReturnCollection = oSearcher.Get();
			string addressWidth = null;
			foreach (ManagementObject oReturn in oReturnCollection)
			{
				addressWidth = oReturn["AddressWidth"].ToString();
			}
			return addressWidth.Contains("64");
		}
		public static	void RunCmd(string cmd)
		{
			 
			System.Diagnostics.Process p = new System.Diagnostics.Process();
			p.StartInfo.FileName = "cmd.exe";
			// 关闭Shell的使用
			p.StartInfo.UseShellExecute = false;
			// 重定向标准输入
			p.StartInfo.RedirectStandardInput = true;
			// 重定向标准输出
			p.StartInfo.RedirectStandardOutput = true;
			//重定向错误输出
			p.StartInfo.RedirectStandardError = true;
			p.StartInfo.CreateNoWindow = true;
			p.Start();
			p.StandardInput.WriteLine(cmd);
			p.StandardInput.WriteLine("exit");
		}
		public static string GETIEVERSION()
		{
			try
			{
				string osVersionBit = Distinguish64or32System();
				if (osVersionBit == "64")
				{
					RegistryKey ry = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\Version Vector", true);
					string version = ry.GetValue("IE").ToString();
					if (!string.IsNullOrEmpty(version))
					{
						//Global.IEVERSION = "IE Version " + version;
						return version;
					}else{
						return null;
					}
				}else{
					RegistryKey ry = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Version Vector", true);
					string version = ry.GetValue("IE").ToString();
					if (!string.IsNullOrEmpty(version))
					{
						//Global.IEVERSION = "IE Version " + version;
						return version;
					}else{
						return null;
					}
				}
			}
			catch
			{
				return null;
			}
		}
		public static  bool RegistersetValue()
		{
			string key = string.Empty; string name;
			name = System.IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath) + ".exe";
			string osVersionBit = Distinguish64or32System();
			string osPlatVersion = OSPlatVersion();
			try
			{
				string regKey = string.Empty;
				if (osVersionBit == "64")
				{
					regKey = @"SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl";
					

					RegistryKey rk = Registry.LocalMachine.OpenSubKey(regKey, true);
					key = "FEATURE_BROWSER_EMULATION";
					RegistryKey rkt = rk.CreateSubKey(key);
					if (rkt != null){
						string version=GETIEVERSION();
						if (string.IsNullOrEmpty(version)==false) {
							double d=double.Parse(version);
							if (d>=9d) {
								var versionTag="9000";
								if(d==10d)
									 versionTag="10000";
								if(d==11d)
									versionTag="11000";
								rkt.SetValue(name, versionTag , RegistryValueKind.DWord);
							}else{
								rkt.SetValue(name, 8000, RegistryValueKind.DWord);
							}
						}
						else
							rkt.SetValue(name, 8000, RegistryValueKind.DWord);
						
					}
					rk.Close();
					rkt.Close();
				}
				else
				{

					regKey = @"SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl";
					
					RegistryKey rk = Registry.LocalMachine.OpenSubKey(regKey, RegistryKeyPermissionCheck.ReadWriteSubTree);
					key = "FEATURE_BROWSER_EMULATION";
					RegistryKey rkt = rk.CreateSubKey(key);


					if (rkt != null){
						string version=GETIEVERSION();
						
						if (string.IsNullOrEmpty(version)==false) {
							double d=double.Parse(version);
							if (d>=9d) {
								var versionTag="9000";
								if(d==10d)
									 versionTag="10000";
								if(d==11d)
									versionTag="11000";
								rkt.SetValue(name, versionTag , RegistryValueKind.DWord);
							}else{
								rkt.SetValue(name, 8000, RegistryValueKind.DWord);
							}
						}
						else
							rkt.SetValue(name, 8000, RegistryValueKind.DWord);
						
					}
					rk.Close();
					rkt.Close();
					//}
				}

				return true;
			}
			catch(Exception ex)
			{
				var a = ex.Message;
				return false;
			}
		}
		/// <summary>
		/// 判断操作系统位数
		/// </summary>
		/// <returns></returns>
		public static string Distinguish64or32System()
		{
			try
			{
				string addressWidth = String.Empty;
				ConnectionOptions mConnOption = new ConnectionOptions();
				ManagementScope mMs = new ManagementScope("//localhost", mConnOption);
				ObjectQuery mQuery = new ObjectQuery("select AddressWidth from Win32_Processor");
				ManagementObjectSearcher mSearcher = new ManagementObjectSearcher(mMs, mQuery);
				ManagementObjectCollection mObjectCollection = mSearcher.Get();
				foreach (ManagementObject mObject in mObjectCollection)
				{
					addressWidth = mObject["AddressWidth"].ToString();
				}
				return addressWidth;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
				return String.Empty;
			}
		}
		/// <summary>
		/// 判断注册表中是否已经存在该值
		/// </summary>
		/// <param name="name"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public static bool IsRegeditExit(string name, string key)
		{
			bool exit = false;
			RegistryKey rk = Registry.LocalMachine;
			try
			{
				RegistryKey software = rk.OpenSubKey(key + "\\FEATURE_BROWSER_EMULATION");
				string[] na = software.GetValueNames();
				foreach (var n in na)
				{
					if (n == name)
					{
						exit = true;
						return exit;
					}
				}
			}
			catch
			{
				return exit;
			}
			return exit;
		}
		public static string OSPlatVersion()
		{
			Version ver = System.Environment.OSVersion.Version;
			string osVersion = string.Empty;
			if (ver.Major == 5 & ver.Minor == 1)
			{
				osVersion = "XP";
			}
			if (ver.Major == 6 && ver.Minor == 0)
			{
				osVersion = "Vista";
			}
			if (ver.Major == 6 && ver.Minor == 1)
			{
				osVersion = "Win7";
			}
			if (ver.Major == 5 && ver.Minor == 0)
			{
				osVersion = "win2000";
			}
			if (ver.Major == 6 && ver.Minor == 2)
			{
				osVersion = "Win8.1";
			}
			return osVersion;
		}
	}
}

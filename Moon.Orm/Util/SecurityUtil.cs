/*
 * 由SharpDevelop创建。
 * 用户： qscq
 * 日期: 2014/8/6
 * 时间: 15:58
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;﻿﻿﻿﻿
﻿﻿using System.Collections.Generic;
﻿﻿using System.ComponentModel;
﻿﻿using System.Data;
﻿﻿using System.Text;﻿﻿
﻿﻿using System.Security.Cryptography;//加密部分
﻿﻿using System.IO;

namespace Moon.Orm.Util
{
	/// <summary>
	/// 安全类
	/// </summary>
	internal class SecurityUtil
	{
		private const string MOON_KEY="qinshich";
		readonly static byte[] KEYS = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
		internal static bool IsIrcLegal(){
			string filePath=GlobalData.DLL_EXE_DIRECTORY_PATH+"moon.license";
			LogUtil.Debug("IsIrcLegal moon.license path:"+filePath);
			if (File.Exists(filePath)==false) {
				LogUtil.Warning("工作目录下不存在授权文件moon.license");
				return false;
			}else{
				string content=null;
				StreamReader sr=new StreamReader(filePath,Encoding.GetEncoding("utf-8"));
				try {
					content=sr.ReadToEnd();
				} catch (Exception ex) {
					LogUtil.Exception(ex);
					return false;
				}
				sr.Close();
				string[] arra=content.Split('↑');
				if (arra.Length==2) {
					var ret= EncryptByDes(arra[0])==arra[1];
					if (ret==false) {
						LogUtil.Debug("授权失败,授权内容:"+content);
					}
					return ret;
				}else{
					LogUtil.Debug("授权失败,授权内容:"+content);
					return false;
				}
			}
		}
		internal static string EncryptByDes(string encryptString)
		{
			string encryptKey=MOON_KEY;
			try
			{
				byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
				byte[] rgbIV = KEYS;
				byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
				DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
				MemoryStream mStream = new MemoryStream();
				CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
				cStream.Write(inputByteArray, 0, inputByteArray.Length);
				cStream.FlushFinalBlock();
				string ret= Convert.ToBase64String(mStream.ToArray());
				cStream.Close();
				return ret;
			}
			catch(Exception ex)
			{
				LogUtil.Exception(ex);
				return encryptString;
			}
		}
		internal static string DecryptByDes(string decryptString )
		{
			string decryptKey=MOON_KEY;
			try
			{
				byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
				byte[] rgbIV = KEYS;
				byte[] inputByteArray = Convert.FromBase64String(decryptString);
				DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
				MemoryStream mStream = new MemoryStream();
				CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
				cStream.Write(inputByteArray, 0, inputByteArray.Length);
				cStream.FlushFinalBlock();
				string ret= Encoding.UTF8.GetString(mStream.ToArray());
				cStream.Close();
				return ret;
			}
			catch(Exception ex)
			{
				LogUtil.Exception(ex);
				return decryptString;
			}
		}
	}
}

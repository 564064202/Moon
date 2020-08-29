 
using System;
﻿﻿﻿﻿
using System.Collections.Generic;
﻿﻿using System.ComponentModel;
﻿﻿using System.Data;
﻿﻿using System.Text;
﻿﻿
using System.Security.Cryptography;//加密部分
﻿﻿using System.IO;
using Moon.Orm.Util;

namespace Encrytion
{
	/// <summary>
	/// 安全类 
	/// </summary>
	internal class EncryptUtil 
	{
		private const string MOON_KEY="qinshich";
		readonly static byte[] KEYS = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
		public static void CreateFile(string name){
			var a=EncryptUtil.EncryptByDes(name);
			string content=(name+"↑"+a);
			StreamWriter sw=new StreamWriter(Moon.Orm.GlobalData.MOON_WORK_DIRECTORY_PATH+name+".license",false,Encoding.GetEncoding("utf-8"));
			sw.Write(content);
			sw.Close();
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

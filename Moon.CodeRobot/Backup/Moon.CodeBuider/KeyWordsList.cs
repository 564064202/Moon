using System;
using System.Collections.Generic;

using System.Text;
using System.Collections;

namespace Moon.CodeBuider
{
	/// <summary>
	/// 敏感的关键词
	/// </summary>
	public class KeyWordsList
	{
		private static Dictionary<string, string> keyWords;
		static KeyWordsList()
		{
			keyWords = new Dictionary<string, string>();
			keyWords.Add("DbType", "DbType");
			keyWords.Add("TableName", "TableName");
			keyWords.Add("public", "public");
			keyWords.Add("int", "int");
			keyWords.Add("long", "long");
			keyWords.Add("byte", "byte");
			keyWords.Add("class", "class");
			keyWords.Add("static", "static");
			keyWords.Add("bool", "bool");
		}
		public static bool ExistsKeyWords(string key)
		{
			return keyWords.ContainsKey(key);
		}
	}
}

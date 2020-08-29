using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Moon.CodeBuider
{
    public class KeyWordsList
    {
        private static Dictionary<string, string> keyWords;
        static KeyWordsList()
        {
            keyWords = new Dictionary<string, string>();
            keyWords.Add("DbType", "DbType");
            keyWords.Add("TableName", "TableName");
        }
        public static bool ExistsKeyWords(string key)
        {
            return keyWords.ContainsKey(key);
        }
    }
}

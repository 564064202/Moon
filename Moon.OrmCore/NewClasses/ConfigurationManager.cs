using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Moon.Orm.Util;

namespace Moon.Orm

{
    /// <summary>
    /// 自定义的配置文件处理类,仅仅为了兼容处理
    /// </summary>
    public class ConfigurationManager
    {
        private static readonly object ConfigurationRootLock = new object();

        private static IConfigurationRoot _configurationRoot;


        public static string GetValue(string key)
        {
            if (_configurationRoot == null)
            {
                lock (ConfigurationRootLock)
                {
                    if (_configurationRoot == null)
                    {
                        var dirPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                        var builder = new ConfigurationBuilder()
                            .SetBasePath(dirPath)
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                        _configurationRoot = builder.Build();
                    }
                }
            }

            var value = _configurationRoot["AppSettings:" + key];
            return value;
        }


        private static IConfiguration Configuration;
        private static IDictionary<string, string> NameValueCollection;

        /// <summary>
        /// 获取AppSettings
        /// </summary>
        public static IDictionary<string, string> Maps

        {
            get
            {
                if (NameValueCollection == null)
                {
                    lock (ConfigurationRootLock)
                    {
                        if (NameValueCollection == null)
                        {
                            var builder = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                            Configuration = builder.Build();
                            ChangeToken.OnChange(() => Configuration.GetReloadToken(), () =>
                            {
                                NameValueCollection = Configuration.AsEnumerable()
                                .ToDictionary(i => i.Key, i => i.Value);
                            });
                            NameValueCollection = Configuration.AsEnumerable()
                                .ToDictionary(i => i.Key, i => i.Value);
                        }
                    }
                }
                return NameValueCollection;
            }
        }

        /// <summary>
        /// 获取ConnectionStrings
        /// </summary>
        public static IDictionary<string, string> AppSettings
        {
            get
            {
                return Maps.Where(i => i.Key.StartsWith("AppSettings:")).ToDictionary(i => i.Key, i => i.Value);
            }
        }

        public static IDictionary<string, ConnectionStringSettings> ConnectionStrings
        {
            get
            {
                IDictionary<string, ConnectionStringSettings> result = new Dictionary<string, ConnectionStringSettings>();
                var all = Maps.Where(i => i.Key.StartsWith("ConnectionsStrings:")).ToDictionary(i => i.Key, i => i.Value);
                foreach (var item in all)
                {
                    var jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<ConnectionStringSettings>(item.Value);
                    jsonObj.Name = item.Key;
                    result[item.Key] = jsonObj;
                }
                return result;

            }
        }
    }
}

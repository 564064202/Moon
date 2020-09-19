using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Moon.Orm
{
    public static class ConfigurationManager
    {
        private static NameValueCollection AppSettingsData;
        private static ConnectionStringSettingsCollection ConnectionStringsData;
        private static readonly IConfiguration Configuration;
        private static readonly object ConfigurationRootLock = new object();

        static ConfigurationManager()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
            ChangeToken.OnChange(() => Configuration.GetReloadToken(), () =>
            {
                AppSettingsData = ParseNameValueCollection();
                ConnectionStringsData = ParseConnectionStringSettings();
            });
        }

        /// <summary>
        /// 获取AppSettings
        /// </summary>
        public static NameValueCollection AppSettings
        {
            get
            {
                if (AppSettingsData == null)
                {
                    lock (ConfigurationRootLock)
                    {
                        if (AppSettingsData == null)
                        {
                            AppSettingsData = ParseNameValueCollection();
                        }
                    }
                }
                return AppSettingsData;
            }
        }

        /// <summary>
        /// 获取ConnectionStrings
        /// </summary>
        public static ConnectionStringSettingsCollection ConnectionStrings
        {
            get
            {
                if (ConnectionStringsData == null)
                {
                    lock (ConfigurationRootLock)
                    {
                        if (ConnectionStringsData == null)
                        {
                            ConnectionStringsData = ParseConnectionStringSettings();
                        }
                    }
                }
                return ConnectionStringsData;
            }
        }

        /// <summary>
        /// 转换ConnectionStringSettingsCollection
        /// </summary>
        /// <returns></returns>
        private static ConnectionStringSettingsCollection ParseConnectionStringSettings()
        {
            var connectionData = Configuration.GetSection("ConnectionStrings").AsEnumerable();
            var dataSectionNames = connectionData.Where(i => i.Key.Split(':').Length == 2).Select(i => i.Key);
            ConnectionStringSettingsCollection connectionStringSettingsCollection = new ConnectionStringSettingsCollection();
            foreach (var sectionName in dataSectionNames)
            {
                var dbSection = Configuration.GetSection(sectionName);
                ConnectionStringSettings connectionStringSettings = null;
                connectionStringSettings = dbSection.Get<ConnectionStringSettings>();
               // connectionStringSettings.Name = dbSection.Key;
                connectionStringSettingsCollection.Add(connectionStringSettings);
            }
            return connectionStringSettingsCollection;
        }

        /// <summary>
        /// 转换NameValueCollection
        /// </summary>
        /// <returns></returns>
        private static NameValueCollection ParseNameValueCollection()
        {
            NameValueCollection nameValueCollection = new NameValueCollection();
            foreach (var item in Configuration.GetSection("AppSettings").AsEnumerable())
            {
                nameValueCollection.Add(item.Key.Replace("AppSettings:", ""), item.Value);
            }
            return nameValueCollection;
        }
    }

    public class ConnectionStringSettingsCollection
    {
        private readonly List<ConnectionStringSettings> _connectionStringSettings = new List<ConnectionStringSettings>();

        public ConnectionStringSettings this[int index]
        {
            get
            {
                if (index > _connectionStringSettings.Count - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException("下标超出读取范围");
                }
                return _connectionStringSettings[index] ?? new ConnectionStringSettings();
            }
        }

        public ConnectionStringSettings this[string name]
        {
            get
            {
                return _connectionStringSettings.FirstOrDefault(i => i.Name == name) ?? new ConnectionStringSettings();
            }
        }

        internal void Add(ConnectionStringSettings connectionStringSettings)
        {
            _connectionStringSettings.Add(connectionStringSettings);
        }
    }

    public class ConnectionStringSettings
    {
        /// <summary>
        /// 连接名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 驱动程序集名称
        /// </summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// DbProviderFactory程序集唯一名称
        /// </summary>
        public string FactoryTypeAssemblyQualifiedName { get; set; }
    }
}

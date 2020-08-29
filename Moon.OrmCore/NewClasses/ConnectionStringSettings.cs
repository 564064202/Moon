using System.Collections.Generic;
using System.Text;

namespace Moon.Orm
{

    /// <summary>
    ///  表示连接字符串配置文件节中的单个命名连接字符串。
    /// </summary>
    public sealed class ConnectionStringSettings
    {
       
        public string Name { get; set; }
       
        public string ConnectionString { get; set; }
       
        public string ProviderName { get; set; }
       
    }

}

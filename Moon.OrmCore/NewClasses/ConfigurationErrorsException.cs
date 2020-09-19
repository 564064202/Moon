using System;
using System.Collections.Generic;
using System.Text;

namespace Moon.Orm
{
    internal class ConfigurationErrorsException : Exception
    {
        public ConfigurationErrorsException(string message) : base(message)
        {
        }
    }
}

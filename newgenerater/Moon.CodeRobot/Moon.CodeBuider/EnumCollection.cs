using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moon.CodeBuider
{
    public enum BuildClassFileType
    {
        /// <summary>
        /// 将所有文件生成在一个文件中
        /// </summary>
        AllInOneFile,
        /// <summary>
        /// 将Class和ClassSet生成在一个文件中
        /// </summary>
        OneClassOneFile
    }    
}

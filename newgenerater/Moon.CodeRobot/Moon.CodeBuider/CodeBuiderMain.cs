using System;
using System.Collections.Generic;
using System.Text;
using Moon.Orm;
using System.IO;
using System.CodeDom.Compiler;

namespace Moon.CodeBuider
{
    public class CodeBuiderMain
    {
        private string _nameSpace = string.Empty;
        private string _floder = string.Empty;
        private string _filePath = string.Empty;
        private string _complieFilePath = string.Empty;
        private DbObjectBase _dbObj = null;


        public CodeBuiderMain(DbObjectBase dbObj, string nameSpace, string targetFloder)
        {
            _dbObj = dbObj;
            _nameSpace = nameSpace;
            //用户指定的文件目录
            _floder = targetFloder.EndsWith("\\") ? targetFloder : targetFloder+"\\";
            //生成文件存放的目录，默认在用户指定目录中添加一个文件夹Moon.Model
            _filePath = _floder + "Moon.Model\\";
            _complieFilePath = _filePath + "DLL\\";
        }
        /// <summary>
        /// 生成实体代码文件
        /// </summary>
        /// <param name="arrTableName"></param>
        /// <param name="buildFileType"></param>
        public void BuildeEntityCode(List<string> arrTableName,BuildClassFileType buildFileType, System.Windows.Forms.ProgressBar processBar, ref string strError)
        {            
            string destFile = null;
            StreamWriter sw = null;
            ClassBuilder classBuild = null;

            StringBuilder sbClassSet = null;
            StringBuilder sbClass = null;
            try
            {
                if (Directory.Exists(_filePath))
                {
                    Directory.Delete(_filePath, true);
                }
                Directory.CreateDirectory(_filePath);

                //将所有实体生成在一个文件中
                if (buildFileType == BuildClassFileType.AllInOneFile)
                {
                    sbClassSet = new StringBuilder();
                    sbClass = new StringBuilder();

                    destFile = _filePath + "Model.cs";
                    sw = new StreamWriter(destFile, false, Encoding.UTF8);
                    sw.WriteLine(GenerateHeader(_nameSpace));
                }
                processBar.Maximum = arrTableName.Count;
                processBar.Value = 0;
                foreach (string tableName in arrTableName)
                {
                    //if (_dbObj.GetTablePKCount(tableName) > 1)
                    //{
                    //    strError += string.IsNullOrEmpty(strError) ? tableName : "," + tableName;
                    //    processBar.Value++;
                    //    continue;
                    //}
                    classBuild = new ClassBuilder(tableName, _dbObj);
                    //将一个表对应的Class和ClassSet生成在一个文件中
                    if (buildFileType == BuildClassFileType.OneClassOneFile)
                    {
                        classBuild.BuildClassToFile(_nameSpace, _filePath);
                    }
                    else
                    {
                        sbClassSet.AppendLine(classBuild.GenerateClassSet());
                        sbClass.AppendLine(classBuild.GenerateClass());
                    }
                    processBar.Value ++;
                }
                //将所有实体生成在一个文件中
                if (buildFileType == BuildClassFileType.AllInOneFile)
                {
                    sw.WriteLine(sbClassSet);
                    sw.WriteLine(sbClass);
                    sw.WriteLine(GenerateEnd());
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Close();
                }
                throw ex;
            }
        }

        /// <summary>
        /// 通过SQL语句生成实体文件，文件存放到生成目录的CustomClass文件夹下
        /// </summary>
        /// <param name="nameSpace"></param>
        /// <param name="targetFloder"></param>
        /// <param name="entityName"></param>
        /// <param name="inheritEntityBase"></param>
        /// <param name="sql"></param>
        public void BuildClassBySQL(string nameSpace, string entityName, bool inheritEntityBase, string sql)
        {
            try
            {               
                ClassBuilder classBuild = new ClassBuilder(_dbObj);
                classBuild.BuildClassBySQLToFile(nameSpace, _filePath, entityName, inheritEntityBase, sql);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 生成类的头
        /// </summary>
        /// <returns></returns>
        public static string GenerateHeader(string nameSpace)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Collections;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using Moon.Orm;");
            sb.AppendLine();
            sb.AppendLine(string.Format("namespace {0}", nameSpace));
            sb.AppendLine("{");

            return sb.ToString();
        }
        /// <summary>
        /// 与GenerateHeader配套
        /// </summary>
        /// <returns></returns>
        public static string GenerateEnd()
        {
            return "}";
        }

       /// <summary>
       /// 编译生成的代码成一个.dll
       /// </summary>
       /// <param name="content"></param>
       /// <param name="fileFullPath"></param>
       /// <returns></returns>
        public bool Complie(ref string errorMsg)
        {
            bool isSucuss = true;
            var provider = CodeDomProvider.CreateProvider("CSharp");

            if (!Directory.Exists(_complieFilePath))
            {
                Directory.CreateDirectory(_complieFilePath);
            }            

            CompilerParameters cp = new CompilerParameters();

            cp.GenerateExecutable = false;
            cp.OutputAssembly = _complieFilePath + _nameSpace + ".dll";            
            cp.GenerateInMemory = true;
            cp.TreatWarningsAsErrors = false;
            cp.ReferencedAssemblies.Add("Moon.Orm.dll");

            string[] files = Directory.GetFiles(_filePath);

            CompilerResults cr = provider.CompileAssemblyFromFile(cp, files);

            if (cr.Errors.Count > 0)
            {
                isSucuss = false;
                foreach (CompilerError ce in cr.Errors)
                {
                    errorMsg += ce.ToString();
                }
            }

            return isSucuss;
        }
    }

}

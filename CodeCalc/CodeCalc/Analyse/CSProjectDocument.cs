using CodeCalc.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeCalc.Analyse
{
    /// <summary>
    /// C# 工程文档
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-05-04
    /// 修改日期：2018-05-04
    /// </remarks>
    public class CSProjectDocument : ProjectDocument
    {
        #region 初始化工程文档
        /// <summary>
        /// 初始化工程文档
        /// </summary>
        public CSProjectDocument()
        {
            analysers.Add(new CSFileAnalyser());
        }
        #endregion

        #region 校验文件名
        /// <summary>
        /// 校验文件名
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <returns>校验结果</returns>
        public override bool CheckFileName(string fileName)
        {
            return FileHelper.GetExtension(fileName) == "CSPROJ";
        }
        #endregion

        #region 载入C#工程项目文件
        /// <summary>
        /// 载入C#工程项目文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        public override void LoadProjectFile(string fileName)
        {
            this.projectFileName = fileName;

            System.IO.StreamReader myReader = new System.IO.StreamReader(fileName, System.Text.Encoding.GetEncoding(936));
            string strText = myReader.ReadToEnd();
            myReader.Close();

            System.Xml.XmlDocument myXMLDoc = new System.Xml.XmlDocument();
            myXMLDoc.LoadXml(strText);

            this.rootPath = System.IO.Path.GetDirectoryName(fileName);
            this.files.Clear();

            bool For2005 = false;
            if (myXMLDoc.DocumentElement.Name == "Project")
            {
                if (myXMLDoc.DocumentElement.GetAttribute("xmlns") == "http://schemas.microsoft.com/developer/msbuild/2003")
                {
                    For2005 = true;
                }
            }

            if (For2005)
            {
                System.Xml.XmlNamespaceManager ns = new System.Xml.XmlNamespaceManager(myXMLDoc.NameTable);
                ns.AddNamespace("a", "http://schemas.microsoft.com/developer/msbuild/2003");
                foreach (System.Xml.XmlElement myFileElement in myXMLDoc.SelectNodes("a:Project/a:ItemGroup/a:Compile", ns))
                {
                    ProjectFileEntity NewFile = new ProjectFileEntity();
                    NewFile.FileName = myFileElement.GetAttribute("Include");
                    string name = NewFile.FileName;
                    name = name.Trim().ToLower();
                    if (name.EndsWith(".cs"))
                    {
                        NewFile.CanAnalyse = true;
                    }
                    else
                    {
                        NewFile.CanAnalyse = false;
                    }
                    this.files.Add(NewFile);
                }
            }
            else
            {
                foreach (System.Xml.XmlElement myFileElement in myXMLDoc.SelectNodes("VisualStudioProject/CSHARP/Files/Include/File"))
                {
                    ProjectFileEntity NewFile = new ProjectFileEntity();
                    NewFile.FileName = myFileElement.GetAttribute("RelPath");
                    NewFile.CanAnalyse = (myFileElement.GetAttribute("BuildAction") == "Compile");
                    this.files.Add(NewFile);
                }
            }
        }
        #endregion

    }
}

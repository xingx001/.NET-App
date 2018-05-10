using CodeCalc.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeCalc.Analyse
{
    /// <summary>
    /// VB工程文件对象
    /// </summary>
    public class VBProjectDocument : ProjectDocument
    {
        /// <summary>
        /// 初始化对象
        /// </summary>
        public VBProjectDocument()
        {
            this.analysers.Add(new VBFileAnalyser());
        }
        /// <summary>
        /// 检测项目文件名扩展名
        /// </summary>
        /// <param name="fileName">项目文件名</param>
        /// <returns>是否通过检测</returns>
        public override bool CheckFileName(string fileName)
        {
            string ext = FileHelper.GetExtension(fileName);
            return ext == "VBP" || ext == "VBPROJ";
        }
        /// <summary>
        /// 加载项目文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        public override void LoadProjectFile(string fileName)
        {
            string ext = FileHelper.GetExtension(fileName);
            if (ext == "VBPROJ")
            {
                string txt = FileHelper.LoadAnsiFile(fileName);
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.LoadXml(txt);
                foreach (System.Xml.XmlElement element in doc.SelectNodes("VisualStudioProject/VisualBasic/Files/Include/File"))
                {
                    ProjectFileEntity NewFile = new ProjectFileEntity();
                    NewFile.FileName = element.GetAttribute("RelPath");
                    NewFile.CanAnalyse = (element.GetAttribute("BuildAction") == "Compile");
                    this.files.Add(NewFile);
                }
                this.projectFileName = fileName;
                this.rootPath = System.IO.Path.GetDirectoryName(fileName);
            }
            else if (ext == "VBP")
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(
                           fileName,
                           System.Text.Encoding.GetEncoding(936)))
                {
                    string strLine = reader.ReadLine();
                    while (strLine != null)
                    {
                        int index = strLine.IndexOf("=");
                        string strName = strLine.Substring(0, index);
                        string strValue = strLine.Substring(index + 1);

                        if (strName == "Form"
                            || strName == "Module"
                            || strName == "Class"
                            || strName == "UserControl")
                        {
                            index = strValue.IndexOf(";");
                            if (index > 0)
                                strValue = strValue.Substring(index + 1);
                            strValue = strValue.Trim();
                            if (strValue.Length > 0)
                            {
                                ProjectFileEntity NewFile = new ProjectFileEntity();
                                NewFile.FileName = strValue;
                                NewFile.CanAnalyse = true;
                                this.files.Add(NewFile);
                            }
                        }
                        strLine = reader.ReadLine();
                    }
                    this.projectFileName = fileName;
                    this.rootPath = System.IO.Path.GetDirectoryName(fileName);
                }
            }
        }
    }
}

using CodeCalc.Analyse;
using CodeCalc.Collection;
using CodeCalc.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeCalc.Abstract
{
    /// <summary>
    /// 工程文档
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-05-04
    /// 修改日期：2018-05-04
    /// </remarks>
    public abstract class ProjectDocument
    {

        #region 耗时毫秒数
        /// <summary>
        /// 耗时毫秒数
        /// </summary>
        protected int tick = 0;
        /// <summary>
        /// 耗时毫秒数
        /// </summary>
        public int TickCount
        {
            get { return tick; }
        }
        #endregion

        #region 分析对象动态数组
        /// <summary>
        /// 分析对象动态数组
        /// </summary>
        protected System.Collections.ArrayList analysers = new System.Collections.ArrayList();
        /// <summary>
        /// 分析对象动态数组
        /// </summary>
        public System.Collections.ArrayList Analysers
        {
            get { return analysers; }
            set { analysers = value; }
        }
        #endregion

        #region 分析结果动态数组
        /// <summary>
        /// 分析结果动态数组
        /// </summary>
        protected System.Collections.ArrayList results = new System.Collections.ArrayList();
        /// <summary>
        /// 分析结果动态数组
        /// </summary>
        public System.Collections.ArrayList Results
        {
            get { return results; }
        }
        #endregion

        #region 文件动态数组
        /// <summary>
        /// 文件动态数组
        /// </summary>
        protected System.Collections.ArrayList files = new System.Collections.ArrayList();
        /// <summary>
        /// 文件动态数组
        /// </summary>
        public System.Collections.ArrayList Files
        {
            get { return files; }
        }
        #endregion

        #region 工程文件名称
        /// <summary>
        /// 工程文件名称
        /// </summary>
        protected string projectFileName = null;
        /// <summary>
        /// 工程文件名称
        /// </summary>
        public string ProjectFileName
        {
            get { return projectFileName; }
            set { projectFileName = value; }
        }
        #endregion

        #region 根目录名称
        /// <summary>
        /// 根目录名称
        /// </summary>
        protected string rootPath = null;
        /// <summary>
        /// 根目录名称
        /// </summary>
        public string RootPath
        {
            get { return rootPath; }
            set { rootPath = value; }
        }
        #endregion

        #region 创建工程文档对象
        /// <summary>
        /// 创建工程文档对象
        /// </summary>
        /// <param name="projectFileName"></param>
        /// <returns></returns>
        public static ProjectDocument Create(string projectFileName)
        {
            string ext = FileHelper.GetExtension(projectFileName);
            ProjectDocument project = null;
            switch (ext)//根据后缀判断是什么工程
            {
                case "CSPROJ":
                    project = new Analyse.CSProjectDocument();
                    break;
                //case "VBP":
                //    myDoc = new VBProjectDocument();
                //    break;
                //case "VBPROJ":
                //    myDoc = new VBProjectDocument();
                //    break;
            }
            if (project != null)
                project.LoadProjectFile(projectFileName);
            return project;
        }
        #endregion

        #region 载入工程文件
        /// <summary>
        /// 载入工程文件
        /// </summary>
        /// <param name="fileName">文件名称</param>
        public virtual void LoadProjectFile(string fileName)
        {
        }
        #endregion

        #region 校验文件名
        /// <summary>
        /// 校验文件名
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public virtual bool CheckFileName(string fileName)
        {
            return false;
        }
        #endregion

        #region GB2312编码字节流
        /// <summary>
        /// GB2312编码字节流
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public virtual System.IO.StreamReader GetReader(string path)
        {
            return new System.IO.StreamReader(path, System.Text.Encoding.GetEncoding(936));
        }
        #endregion

        #region 完全文件路径名称
        /// <summary>
        /// 完全文件路径名称
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public virtual string GetFullName(string fileName)
        {
            if (System.IO.Path.IsPathRooted(fileName))
                return fileName;
            else
                return System.IO.Path.Combine(rootPath, fileName);
        }
        #endregion

        #region 分析所有文件
        /// <summary>
        /// 分析所有文件
        /// </summary>
        public virtual void AnalyseAllFile()
        {
            FileCollection mResults = new FileCollection();
            mResults.AnalyseTime = System.DateTime.Now;
            mResults.Document = this;
            int iTick = System.Environment.TickCount;
            foreach (ProjectFileEntity item in this.files)
            {
                FileEntity mResult = mResults.Add(item.FileName);
                mResult.Analysed = false;
                if (item.CanAnalyse == false)
                    continue;
                foreach (FileAnalyser mAnalyser in this.analysers)
                {
                    mAnalyser.Document = this;
                    if (mAnalyser.CheckFileName(mResult.FullName))
                    {
                        if (System.IO.File.Exists(mResult.FullName))
                        {
                            mAnalyser.Analyse(mResult);
                            mResult.Analysed = true;
                        }
                        else
                            mResult.Analysed = false;
                    }
                }
            }
            this.results.Add(mResults);
            this.tick = System.Environment.TickCount - iTick;
        }
        #endregion

        #region 最后一次分析结果
        /// <summary>
        /// 最后一次分析结果
        /// </summary>
        public FileCollection LastResult
        {
            get
            {
                if (results.Count > 0)
                    return (FileCollection)results[results.Count - 1];
                else
                    return null;
            }
        }
        #endregion

        #region 清除分析结果
        /// <summary>
        /// 清除分析结果
        /// </summary>
        public void ClearResults()
        {
            results.Clear();
        }
        #endregion

        #region 载入XML分析结果
        /// <summary>
        /// 载入XML分析结果
        /// </summary>
        /// <param name="fileName"></param>
        public void LoadAnalyseResult(string fileName)
        {
            System.Xml.XmlDocument myXMLDoc = new System.Xml.XmlDocument();
            myXMLDoc.Load(fileName);
            results.Clear();
            foreach (System.Xml.XmlElement myResultsElement in myXMLDoc.DocumentElement.SelectNodes("results"))
            {
                FileCollection myResults = new FileCollection();
                results.Add(myResults);
                myResults.Document = this;
                myResults.Time = myResultsElement.GetAttribute("time");
                foreach (System.Xml.XmlElement myElement in myResultsElement.SelectNodes("result"))
                {
                    string vFileName = myElement.GetAttribute("filename");
                    foreach (ProjectFileEntity myFile in files)
                    {
                        if (myFile.FileName == vFileName)
                        {
                            FileEntity NewResult = myResults.Add(vFileName);
                            NewResult.CharCount = StringHelper.ToInt32Value(myElement.GetAttribute("charcount"), 0);
                            NewResult.LineCount = StringHelper.ToInt32Value(myElement.GetAttribute("linecount"), 0);
                            NewResult.CodeCount = StringHelper.ToInt32Value(myElement.GetAttribute("codecount"), 0);
                            NewResult.CommentCount = StringHelper.ToInt32Value(myElement.GetAttribute("commentcount"), 0);
                            NewResult.BlankCount = StringHelper.ToInt32Value(myElement.GetAttribute("blankcount"), 0);
                            NewResult.Analysed = true;
                        }
                    }
                }
            }
        }
        #endregion

        #region 保存XML分析结果
        /// <summary>
        /// 保存XML分析结果
        /// </summary>
        /// <param name="fileName"></param>
        public void SaveAnalyseResult(string fileName)
        {
            System.Xml.XmlDocument xml = new System.Xml.XmlDocument();
            this.SaveAnalyseResult(xml);
            xml.Save(fileName);
        }
        #endregion

        #region 保存XML分析结果
        /// <summary>
        /// 保存XML分析结果
        /// </summary>
        /// <param name="xml"></param>
        public void SaveAnalyseResult(System.Xml.XmlDocument xml)
        {
            if (xml.DocumentElement != null)
                xml.RemoveChild(xml.DocumentElement);
            xml.AppendChild(xml.CreateElement("project"));
            xml.DocumentElement.SetAttribute("filename", this.projectFileName);
            xml.DocumentElement.SetAttribute("tickcount", this.tick.ToString());
            int iCount = 0;
            foreach (FileCollection mResults in results)
            {
                iCount++;
                System.Xml.XmlElement myResultsElement = xml.CreateElement("results");
                xml.DocumentElement.AppendChild(myResultsElement);
                myResultsElement.SetAttribute("time", mResults.Time);
                if (iCount == results.Count)
                    myResultsElement.SetAttribute("last", "1");
                foreach (FileEntity item in mResults)
                {
                    if (item.Analysed)
                    {
                        System.Xml.XmlElement myElement = xml.CreateElement("result");
                        myResultsElement.AppendChild(myElement);
                        myElement.SetAttribute("filename", item.FileName);
                        myElement.SetAttribute("filesize", item.FileSize.ToString());
                        myElement.SetAttribute("linecount", item.LineCount.ToString());
                        myElement.SetAttribute("codecount", item.CodeCount.ToString());
                        myElement.SetAttribute("commentcount", item.CommentCount.ToString());
                        myElement.SetAttribute("blankcount", item.BlankCount.ToString());
                        myElement.SetAttribute("charcount", item.CharCount.ToString());
                        myElement.SetAttribute("time", item.Time.ToString());
                    }
                }
            }
        }
        #endregion
    }
}

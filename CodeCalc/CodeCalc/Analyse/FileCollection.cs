using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeCalc.Abstract
{
    /// <summary>
    /// 文件实体集合
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-05-04
    /// 修改日期：2018-05-04
    /// </remarks>
    public class FileCollection : System.Collections.CollectionBase
    {
        #region 工程文档
        /// <summary>
        /// 工程文档
        /// </summary>
        private ProjectDocument document;
        /// <summary>
        /// 工程文档
        /// </summary>
        public ProjectDocument Document
        {
            get { return document; }
            set
            {
                document = value;
                foreach (FileEntity entity in this)
                    entity.Document = document;
            }
        }
        #endregion

        /// <summary>
        /// 分析时间
        /// </summary>
        public string Time { get; set; }

        #region 分析时间
        /// <summary>
        /// 分析时间
        /// </summary>
        public System.DateTime AnalyseTime { get; set; }
        #endregion

        #region 分析文件个数总和
        /// <summary>
        /// 分析文件个数总和
        /// </summary>
        public int AnalysedCount
        {
            get
            {
                int count = 0;
                foreach (FileEntity item in this)
                {
                    if (item.Analysed)
                        count++;
                }
                return count;
            }
        }
        #endregion

        #region 文件大小总和
        /// <summary>
        /// 文件大小总和
        /// </summary>
        public int TotalFileSize
        {
            get
            {
                int count = 0;
                foreach (FileEntity item in this)
                    count += item.FileSize;
                return count;
            }
        }
        #endregion

        #region 分析文件字符数总和
        /// <summary>
        /// 分析文件字符数总和
        /// </summary>
        public int TotalCharCount
        {
            get
            {
                int count = 0;
                foreach (FileEntity item in this)
                {
                    if (item.Analysed)
                        count += item.CharCount;
                }
                return count;
            }
        }
        #endregion

        #region 分析文件行数总和
        /// <summary>
        /// 分析文件行数总和
        /// </summary>
        public int TotalLineCount
        {
            get
            {
                int count = 0;
                foreach (FileEntity item in this)
                {
                    if (item.Analysed)
                        count += item.LineCount;
                }
                return count;
            }
        }
        #endregion

        #region 分析文件注释行数总和
        /// <summary>
        /// 分析文件注释行数总和
        /// </summary>
        public int TotalCommentCount
        {
            get
            {
                int count = 0;
                foreach (FileEntity item in this)
                {
                    if (item.Analysed)
                        count += item.CommentCount;
                }
                return count;
            }
        }
        #endregion

        #region 分析文件空白行数总和
        /// <summary>
        /// 分析文件空白行数总和
        /// </summary>
        public int TotalBlankCount
        {
            get
            {
                int count = 0;
                foreach (FileEntity item in this)
                {
                    if (item.Analysed)
                        count += item.BlankCount;
                }
                return count;
            }
        }
        #endregion

        #region 分析文件代码行数总和
        /// <summary>
        /// 分析文件代码行数总和
        /// </summary>
        public int TotalCodeCount
        {
            get
            {
                int count = 0;
                foreach (FileEntity item in this)
                {
                    if (item.Analysed)
                        count += item.CodeCount;
                }
                return count;
            }
        }
        #endregion

        #region 按索引返回文件实体
        /// <summary>
        /// 按索引返回文件实体
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public FileEntity this[int index]
        {
            get { return (FileEntity)this.InnerList[index]; }
        }
        #endregion

        #region 添加文件实体到集合
        /// <summary>
        /// 添加文件实体到集合
        /// </summary>
        /// <param name="result"></param>
        public void Add(FileEntity result)
        {
            this.InnerList.Add(result);
            result.Document = this.document;
        }
        #endregion

        #region 按文件名添加实体到集合
        /// <summary>
        /// 按文件名添加实体到集合
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public FileEntity Add(string fileName)
        {
            FileEntity entity = new FileEntity();
            entity.Document = this.document;
            entity.FileName = fileName;
            entity.FullName = this.document.GetFullName(fileName);
            entity.Extension = FileHelper.GetExtension(fileName);
            this.InnerList.Add(entity);
            return entity;
        }
        #endregion
    }
}

using CodeCalc.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeCalc.Abstract
{
    /// <summary>
    /// 文件分析抽象类
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-05-04
    /// 修改日期：2018-05-04
    /// </remarks>
    public abstract class FileAnalyser
    {
        #region 工程文档
        protected ProjectDocument document;
        /// <summary>
        /// 工程文档
        /// </summary>
        public ProjectDocument Document { get { return this.document; } set { this.document = value; } }
        #endregion

        protected System.Collections.ArrayList lines = new System.Collections.ArrayList();

        #region 校验文件名称
        /// <summary>
        /// 校验文件名称
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public virtual bool CheckFileName(string fileName)
        {
            return this.CheckFileExtension(FileHelper.GetExtension(fileName));
        }
        #endregion

        #region 校验文件后缀
        /// <summary>
        /// 校验文件后缀
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        public virtual bool CheckFileExtension(string extension)
        {
            return false;
        }
        #endregion

        #region 分析文件
        /// <summary>
        /// 分析文件
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Analyse(FileEntity entity)
        {
            lines.Clear();
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(entity.FullName);
            entity.FileSize = (int)fileInfo.Length;
            entity.CreationTime = fileInfo.CreationTime;
            entity.ModifiedTime = fileInfo.LastWriteTime;

            using (System.IO.StreamReader reader = this.document.GetReader(entity.FullName))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    LineEntity item = new LineEntity();
                    item.LineText = line;
                    lines.Add(item);
                    entity.CharCount += (line.Length + 2);
                    line = reader.ReadLine();
                }
                reader.Close();
            }
            InnerAnalyse();
            entity.LineCount = lines.Count;
            entity.CommentCount = 0;
            entity.CodeCount = 0;
            entity.BlankCount = 0;
            foreach (LineEntity info in lines)
            {
                if (info.CommentFlag)
                    entity.CommentCount++;
                if (info.CodeFlag)
                    entity.CodeCount++;
                if (info.BlankLine)
                    entity.BlankCount++;
            }
            return true;
        }
        #endregion

        protected virtual void InnerAnalyse()
        {
        }
    }
}

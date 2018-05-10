using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeCalc.Abstract
{
    /// <summary>
    /// 文件实体对象
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-05-04
    /// 修改日期：2018-05-04
    /// </remarks>
    public class FileEntity
    {
        /// <summary>
        /// 项目文档对象
        /// </summary>
        public ProjectDocument Document { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件路径名称
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 文件扩展名
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// 该文件是否分析过
        /// </summary>
        public bool Analysed { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public int FileSize { get; set; }
        /// <summary>
        /// 文件创建时间
        /// </summary>
        public System.DateTime CreationTime { get; set; }
        /// <summary>
        /// 文件修改时间
        /// </summary>
        public System.DateTime ModifiedTime { get; set; }
        /// <summary>
        /// 字符数
        /// </summary>
        public int CharCount { get; set; }
        /// <summary>
        /// 总行数
        /// </summary>
        public int LineCount { get; set; }
        /// <summary>
        /// 注释行数
        /// </summary>
        public int CommentCount { get; set; }
        /// <summary>
        /// 空白行数
        /// </summary>
        public int BlankCount { get; set; }
        /// <summary>
        /// 代码行数
        /// </summary>
        public int CodeCount { get; set; }
        /// <summary>
        /// 分析时间
        /// </summary>
        public int Time { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeCalc.Entity
{
    /// <summary>
    /// 行实体
    /// </summary>
    public class LineEntity
    {
        /// <summary>
        /// 行文本
        /// </summary>
        public string LineText { get; set; }
        /// <summary>
        /// 该文本行为注释行标志
        /// </summary>
        public bool CommentFlag { get; set; }
        /// <summary>
        /// 该文本行为空白行标志
        /// </summary>
        public bool BlankLine { get; set; }
        /// <summary>
        /// 该文本行为代码行标志
        /// </summary>
        public bool CodeFlag { get; set; }
    }
}

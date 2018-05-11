using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeCalc.Entity
{
    /// <summary>
    /// 工程文件实体
    /// </summary>
    public class ProjectFileEntity
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 是否进行分析
        /// </summary>
        public bool CanAnalyse { get; set; }
    }
}

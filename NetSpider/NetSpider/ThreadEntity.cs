using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetSpider
{
    /// <summary>
    /// 爬取线程实体
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-05-15
    /// 修改日期：2018-05-15
    /// 注：仅在本命名空间调用
    /// </remarks>
    internal class ThreadEntity
    {
        #region 爬取对象
        /// <summary>
        /// 爬取对象
        /// </summary>
        private Crawl _crawl;
        /// <summary>
        /// 爬取对象
        /// </summary>
        internal Crawl Crawl
        {
            get { return _crawl; }
            set { _crawl = value; }
        }
        #endregion

        #region 线程
        /// <summary>
        /// 线程
        /// </summary>
        private System.Threading.Thread _thread;
        /// <summary>
        /// 线程
        /// </summary>
        internal System.Threading.Thread Thread
        {
            get { return _thread; }
            set { _thread = value; }
        }
        #endregion

    }
}

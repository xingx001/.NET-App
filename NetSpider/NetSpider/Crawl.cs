using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetSpider
{
    /// <summary>
    /// 爬取对象
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-05-15
    /// 修改日期：2018-05-15
    /// 注：仅在本命名空间调用
    /// </remarks>
    internal class Crawl
    {
        #region URL队列
        /// <summary>
        /// URL队列
        /// </summary>
        public UrlQueue UrlQueue
        {
            get
            {
                return UrlQueue.GetInstance();
            }
        }
        #endregion

        #region 职责链
        /// <summary>
        /// 职责链
        /// </summary>
        private MainChain _mainChain = new MainChain();
        /// <summary>
        /// 职责链
        /// </summary>
        public MainChain MainChain
        {
            get
            {
                return _mainChain;
            }
        }
        #endregion

        #region HTTP Get类
        /// <summary>
        /// HTTP Get类
        /// </summary>
        private HttpGet _httpGet = new HttpGet();
        /// <summary>
        /// HTTP Get类
        /// </summary>
        public HttpGet HttpGet
        {
            get
            {
                return _httpGet;
            }
        }
        #endregion

        #region 是否运行
        /// <summary>
        /// 是否运行
        /// </summary>
        private bool _isRun = false;
        /// <summary>
        /// 是否运行
        /// </summary>
        public bool IsRun
        {
            get { return _isRun; }
        }
        #endregion

        #region 工作线程开始运行
        /// <summary>
        /// 工作线程开始运行
        /// </summary>
        public void Start()
        {
            try
            {
                this._isRun = true;
                while (this._isRun)
                {
                    string url = this.UrlQueue.Dequeue();
                    if (!string.IsNullOrEmpty(url))
                    {
                        string html = this._httpGet.GetResponse(url);
                        if (!string.IsNullOrEmpty(html))
                        {
                            this._mainChain.Url = url;
                            this._mainChain.Start(html);
                        }
                    }
                }
            }
            catch
            {
            }
        }
        #endregion

        #region 停止工作线程
        /// <summary>
        /// 停止工作线程
        /// </summary>
        public void Stop()
        {
            this._isRun = false;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetSpider
{
    /// <summary>
    /// 线程管理抽象类
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-05-15
    /// 修改日期：2018-05-15
    /// </remarks>
    public abstract class AbsThreadManager
    {
        /// <summary>
        /// 线程实体类
        /// </summary>
        internal List<ThreadEntity> threadList = new List<ThreadEntity>();

        /// <summary>
        /// 最大运行线程数
        /// </summary>
        private int _maxCount = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["MaxCount"]);
        /// <summary>
        /// 是否运行
        /// </summary>
        private bool _isRun = false;
        /// <summary>
        /// 守望线程
        /// </summary>
        private System.Threading.Thread watch_thread = null;
        /// <summary>
        /// 当前队列深度
        /// </summary>
        public int Current
        {
            get { return UrlQueue.GetInstance().Count; }
        }

        #region 开启线程
        /// <summary>
        /// 开启线程
        /// </summary>
        public void Start()
        {
            this._isRun = true;
            for (int i = 0; i < this._maxCount; i++)
            {
                this.AddThread();
            }
            this.watch_thread = new System.Threading.Thread(Watch);
            this.watch_thread.Start();
        }
        #endregion

        #region 停止线程
        /// <summary>
        /// 停止线程
        /// </summary>
        public void Stop()
        {
            this._isRun = false;
            this.watch_thread.Join();
            foreach (ThreadEntity thread in this.threadList)
            {
                thread.Crawl.Stop();
                thread.Thread.Abort();
                thread.Thread.Join();
            }
            this.threadList.RemoveRange(0, threadList.Count);
        }
        #endregion

        #region 添加线程
        /// <summary>
        /// 添加线程
        /// </summary>
        private void AddThread()
        {
            ThreadEntity thread = new ThreadEntity();
            thread.Crawl = new Crawl();
            thread.Crawl.MainChain.SetProcessHandler(this.GetChainHeader());
            thread.Thread = new System.Threading.Thread(thread.Crawl.Start);
            this.threadList.Add(thread);
            thread.Thread.Start();
        }
        #endregion

        /// <summary>
        /// 设置职责链头节点
        /// </summary>
        /// <returns>返回用户定义的Chain</returns>
        protected abstract AbsChain GetChainHeader();

        #region 守望方法
        /// <summary>
        /// 守望方法
        /// </summary>
        internal void Watch()
        {
            List<ThreadEntity> newList = new List<ThreadEntity>();
            while (this._isRun)
            {
                try
                {
                    foreach (ThreadEntity thread in this.threadList)
                    {
                        if (thread.Crawl.IsRun && thread.Thread.IsAlive)
                        {
                            newList.Add(thread);
                        }
                    }
                    this.threadList.RemoveRange(0, threadList.Count);
                    this.threadList.AddRange(newList);
                    int newCount = this._maxCount - this.threadList.Count;
                    for (int i = 0; i < newCount; i++)
                    {
                        this.AddThread();
                    }
                    newList.RemoveRange(0, newList.Count);
                    System.Threading.Thread.Sleep(5 * 1000);
                }
                catch
                {
                }
            }
        }
        #endregion
    }
}

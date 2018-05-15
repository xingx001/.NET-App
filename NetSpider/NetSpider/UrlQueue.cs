using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetSpider
{
    /// <summary>
    /// URL队列
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-05-15
    /// 修改日期：2018-05-15
    /// </remarks>
    public class UrlQueue
    {
        #region 单例模式
        /// <summary>
        /// 静态私有变量初始化实例
        /// </summary>
        private static readonly UrlQueue _urlstack = new UrlQueue();
        /// <summary>
        ///  私有化构造方法，防止被实例化
        /// </summary>
        private UrlQueue() { }
        /// <summary>
        /// 恶汉模式
        /// </summary>
        /// <returns>实例化对象</returns>
        public static UrlQueue GetInstance()
        {
            return _urlstack;
        }
        #endregion

        /// <summary>
        /// 字符串队列
        /// </summary>
        private Queue<string> _queue = new Queue<string>();

        /// <summary>
        /// 队列最大长度
        /// </summary>
        private readonly int _maxLength = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["MaxLength"]);

        /// <summary>
        /// 队列长度
        /// </summary>
        public int Count
        {
            get { return _queue.Count; }
        }

        #region URL入列
        /// <summary>
        /// URL入列
        /// </summary>
        /// <param name="url"></param>
        public void Enqueue(string url)
        {
            lock (this)
            {
                if (!this._queue.Contains(url))
                {
                    if (this._queue.Count >= _maxLength)
                    {
                        this._queue.Dequeue();
                    }
                    this._queue.Enqueue(url);
                }
            }
        }
        #endregion

        #region URL出列
        /// <summary>
        /// URL出列
        /// </summary>
        /// <returns></returns>
        public string Dequeue()
        {
            lock (this)
            {
                if (this._queue.Count > 0)
                {
                    return this._queue.Dequeue();
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetSpider
{
    /// <summary>
    /// 职责链抽象类
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-05-15
    /// 修改日期：2018-05-15
    /// </remarks>
    public abstract class AbsChain
    {
        #region 职责链对象
        /// <summary>
        /// 职责链对象
        /// </summary>
        private AbsChain _chain = null;
        /// <summary>
        /// 职责链对象
        /// </summary>
        internal AbsChain Chain
        {
            get
            {
                return _chain;
            }
        }
        #endregion

        #region URL
        /// <summary>
        /// URL
        /// </summary>
        private string _url = string.Empty;
        /// <summary>
        /// URL
        /// </summary>
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        #endregion

        /// <summary>
        /// HTML处理
        /// </summary>
        /// <param name="html">html字符串</param>
        protected abstract void Process(string html);

        /// <summary>
        /// 设置下一个处理节点
        /// </summary>
        /// <param name="chain">下一个处理节点</param>
        public void SetProcessHandler(AbsChain chain)
        {
            _chain = chain;
        }

        #region 开始递归处理
        /// <summary>
        /// 开始递归处理
        /// </summary>
        /// <param name="html"></param>
        public void Start(string html)
        {
            this.Process(html); //处理用户重载方法
            if (this._chain != null)
            {
                this._chain.Url = Url;
                this._chain.Start(html);
            }
        }
        #endregion
    }

    /// <summary>
    /// 职责链继承类
    /// </summary>
    /// 作者：北冥冰皇
    /// 创建日期：2018-05-15
    /// 修改日期：2018-05-15
    /// 注：仅在本命名空间调用
    /// </remarks>
    internal class MainChain : AbsChain
    {
        protected override void Process(string html) { }
    }
}

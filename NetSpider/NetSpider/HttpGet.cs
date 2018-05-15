using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace NetSpider
{
    /// <summary>
    /// Http请求类
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-05-15
    /// 修改日期：2018-05-15
    /// 注：仅在本命名空间调用
    /// </remarks>
    internal class HttpGet
    {
        /// <summary>
        /// 最大HTML读取空间
        /// </summary>
        private readonly int _maxBuffer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["MaxBuffer"]);

        #region 组建Get请求
        /// <summary>
        /// 组建Get请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private HttpWebRequest GetRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "get";
            request.ContentType = "text/html";
            return request;
        }
        #endregion

        #region 获取HTML编码格式
        /// <summary>
        /// 获取HTML编码格式
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        private string GetEncode(string html)
        {
            if (string.IsNullOrEmpty(html))
            {
                return string.Empty;
            }
            else
            {
                //解析html的编码格式
                Regex re = new Regex(@"charset=(?<charset>[\s\S]*?)""");
                Match m = re.Match(html.ToLower());
                return m.Groups["charset"].ToString();
            }
        }
        #endregion

        #region Get请求HTML文本
        /// <summary>
        /// Get请求HTML文本
        /// </summary>
        /// <param name="url">URL</param>
        /// <returns></returns>
        public string GetResponse(string url)
        {
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)this.GetRequest(url).GetResponse())
                {
                    using (Stream reader = response.GetResponseStream())
                    {
                        using (MemoryStream memory = new MemoryStream())
                        {
                            int index = 1;
                            int sum = 0;
                            byte[] buffer = new byte[1024];//1K缓冲区
                            //限制的读取的大小不超过100k
                            while (index > 0 && sum < this._maxBuffer * 1024)
                            {
                                index = reader.Read(buffer, 0, 1024);
                                if (index > 0)
                                {
                                    memory.Write(buffer, 0, index);
                                    sum += index;
                                }
                            }
                            string html = Encoding.GetEncoding("gb2312").GetString(memory.ToArray());
                            string encoding = this.GetEncode(html);

                            if (string.IsNullOrEmpty(encoding) || string.Equals(encoding.ToLower(), "gb2312"))
                                return html;
                            else//不是gb2312编码则按charset值的编码进行读取
                                return Encoding.GetEncoding(encoding).GetString(memory.ToArray());
                        }
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
        }
        #endregion

    }
}

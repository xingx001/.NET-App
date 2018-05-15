using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NetSpider.Demo
{
    public class NodeChain : AbsChain
    {
        #region 去除头部的'与"
        /// <summary>
        /// 去除头部的'与"
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string RemoveQuotation(string url)
        {
            if ((url.IndexOf("'") == 0) || (url.IndexOf("\"") == 0))
            {
                url = url.Remove(0, 1);
                if (url.IndexOf("'") != -1)
                {
                    url = url.Remove(url.IndexOf("'"), 1);
                }
                if (url.IndexOf("\"") != -1)
                {
                    url = url.Remove(url.IndexOf("\""), 1);
                }
            }
            if (url.IndexOf(" ") != -1)
            {
                url = url.Remove(url.IndexOf(" "));
            }
            return url;
        }
        #endregion

        #region 处理网页
        /// <summary>
        /// 处理网页
        /// </summary>
        /// <param name="html"></param>
        protected override void Process(string html)
        {
            try
            {
                Regex re = new Regex(@"href=(?<web_url>[\s\S]*?)>|href=""(?<web_url>[\s\S]*?)""|href='(?<web_url>[\s\S]*?)'");
                MatchCollection mc = re.Matches(html);
                foreach (Match m in mc)
                {
                    string url = m.Groups["web_url"].ToString();
                    url = this.RemoveQuotation(url);
                    if (url.IndexOf("http://") != -1)
                    {
                        UrlQueue.GetInstance().Enqueue(url);
                    }
                }
                string title = string.Empty;
                re = new Regex(@"<title[\s\S]*?>(?<title>[\s\S]*?)</title>");
                Match temp = re.Match(html.ToLower());
                title = temp.Groups["title"].ToString();
                if (!string.IsNullOrEmpty(title))
                {
                    Console.WriteLine(string.Format("网页标题：{0}",title));
                    Console.WriteLine(string.Format("网页URL：{0}", this.Url));
                }
            }
            catch
            {
            }
        }
        #endregion
    }
}

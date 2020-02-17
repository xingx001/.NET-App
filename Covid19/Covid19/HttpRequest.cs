#region AUTHOR
/*******************************
**  AUTHOR:     ZHANGYP
**    TIME:     2020/2/14 8:57:11
** VERSION:     V1.0.0
**    GUID:     dfc1561c-5c56-406a-bdc9-455cb477746a
*******************************/
#endregion

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Covid19
{
    public class HttpRequest
    {
        /// <summary>
        /// 默认User-Agent
        /// </summary>
        private static readonly string USER_AGENT = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        /// <summary>
        /// UTF-8
        /// </summary>
        private static readonly string UTF_8 = "application/json;charset=UTF-8";
        //private static readonly string X_WWW_FORM = "application/x-www-form-urlencoded";

        /// <summary>
        /// 进度条开始
        /// </summary>
        public event Action<int> ProgressBarStart;
        /// <summary>
        /// 进度条执行
        /// </summary>
        public event Action<int> ProgressBarProcess;

        #region public function

        #region Get请求
        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="headers">HTTP Request Headers</param>
        /// <param name="cookies">Cookie集合</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="contentType">Content-Type</param>
        /// <param name="userAgent">User-Agent</param>
        /// <returns>GET请求结果</returns>
        public string Get(string url, string[] headers, CookieCollection cookies,
             int? timeout = null, string contentType = null, string userAgent = null)
        {
            HttpWebResponse response = GetResponse(url, headers, cookies, timeout, contentType, userAgent);
            return this.GetResult(response);
        }
        #endregion

        #region Post表单请求
        /// <summary>
        /// Post表单请求
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="requestEncoding">请求的字符编码</param>
        /// <param name="parameters">POST请求的参数字典</param>
        /// <param name="userAgent">User-Agent</param>
        /// <param name="headers">HTTP Request Headers</param>
        /// <param name="cookies">Cookie集合</param>
        /// <param name="timeout">超时时间</param>
        /// <returns>POST请求结果</returns>
        public string PostForm(string url, Encoding requestEncoding, NameValueCollection parameters, string userAgent = null,
            string[] headers = null, CookieCollection cookies = null, int? timeout = null)
        {
            return PostFormResult(url, requestEncoding, parameters, userAgent, headers, cookies, timeout);
        }

        /// <summary>
        /// POST表单请求
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="requestEncoding">请求的字符编码</param>
        /// <param name="parameters">POST请求的参数字典</param>
        /// <param name="userAgent">User-Agent</param>
        /// <param name="headers">HTTP Request Headers</param>
        /// <param name="cookies">Cookie集合</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public HttpWebResponse PostFormReponse(string url, Encoding requestEncoding, NameValueCollection parameters, string userAgent = null,
            string[] headers = null, CookieCollection cookies = null, int? timeout = null)
        {
            //vue中使用的是"Content-Type: application/json;charset=UTF-8"，但是这个类型在后台不能转换，必须使用如下Content-Type
            string contentType = "application/x-www-form-urlencoded;charset=utf-8";
            return PostResponse(url, requestEncoding, parameters, contentType, userAgent, headers, cookies, timeout);
        }
        #endregion

        #region 下载文件Post
        /// <summary>
        /// 下载文件Post
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="fileName">文件路径</param>
        /// <param name="requestEncoding">请求的字符编码</param>
        /// <param name="parameters">POST请求的参数字典</param>
        /// <param name="userAgent">User-Agent</param>
        /// <param name="headers">HTTP Request Headers</param>
        /// <param name="cookies">Cookie集合</param>
        /// <param name="timeout">超时时间</param>
        public void PostDownLoad(string url, string fileName, Encoding requestEncoding, NameValueCollection parameters, string userAgent = null,
            string[] headers = null, CookieCollection cookies = null, int? timeout = null)
        {
            this.PostDownLoadResult(url, fileName, requestEncoding, parameters, userAgent, headers, cookies, timeout);
        }
        #endregion

        #region 上传文件Post
        /// <summary>
        /// 上传文件Post
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="requestEncoding">请求的字符编码</param>
        /// <param name="parameters">POST请求的参数字典</param>
        /// <param name="filePath">文件路径</param>
        /// <param name="boundary">边界符</param>
        /// <param name="contentType">Content-Type</param>
        /// <param name="userAgent">User-Agent</param>
        /// <param name="headers">HTTP Request Headers</param>
        /// <param name="cookies">Cookie集合</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public string PostUpload(string url, NameValueCollection parameters, string filePath, string userAgent = null,
            string[] headers = null, CookieCollection cookies = null, int? timeout = null)
        {
            return PostUploadResult(url, parameters, filePath, userAgent, headers, cookies, timeout);
        }
        #endregion

        #endregion

        #region private function

        #region Post请求返回结果
        /// <summary>
        /// Post请求返回结果
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="requestEncoding">请求的字符编码</param>
        /// <param name="parameters">POST请求的参数字典</param>
        /// <param name="userAgent">User-Agent</param>
        /// <param name="headers">HTTP Request Headers</param>
        /// <param name="cookies">Cookie集合</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        private string PostFormResult(string url, Encoding requestEncoding, NameValueCollection parameters, string userAgent = null,
            string[] headers = null, CookieCollection cookies = null, int? timeout = null)
        {
            //vue中使用的是"Content-Type: application/json;charset=UTF-8"，但是这个类型在后台不能转换，必须使用如下Content-Type
            string contentType = "application/x-www-form-urlencoded;charset=utf-8";
            HttpWebResponse response = PostResponse(url, requestEncoding, parameters, contentType, userAgent, headers, cookies, timeout);
            return this.GetResult(response);
        }
        #endregion

        #region 上传文件Post请求返回结果
        /// <summary>
        /// 上传文件Post请求返回结果
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="parameters">POST请求的参数字典</param>
        /// <param name="filePath">文件路径</param>
        /// <param name="userAgent">User-Agent</param>
        /// <param name="headers">HTTP Request Headers</param>
        /// <param name="cookies">Cookie集合</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        private string PostUploadResult(string url, NameValueCollection parameters, string filePath, string userAgent = null,
            string[] headers = null, CookieCollection cookies = null, int? timeout = null)
        {
            string boundary = "----------------" + DateTime.Now.Ticks.ToString("x");// 边界符
            string contentType = "multipart/form-data;boundary=" + boundary;//内容类型
            Encoding requestEncoding = Encoding.Default;

            HttpWebResponse response = this.PostUploadResponse(url, requestEncoding, parameters, filePath, boundary, contentType, userAgent,
                headers, cookies, timeout);
            return GetResult(response);
        }
        #endregion

        #region 下载文件Post请求写入文件流
        /// <summary>
        /// 下载文件Post请求写入文件流
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="fileName">文件路径</param>
        /// <param name="requestEncoding">请求的字符编码</param>
        /// <param name="parameters">POST请求的参数字典</param>
        /// <param name="userAgent">User-Agent</param>
        /// <param name="headers">HTTP Request Headers</param>
        /// <param name="cookies">Cookie集合</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        private void PostDownLoadResult(string url, string fileName, Encoding requestEncoding, NameValueCollection parameters, string userAgent = null,
            string[] headers = null, CookieCollection cookies = null, int? timeout = null)
        {
            //if (!fileName.IsFilePath())
            //    return;
            if (string.IsNullOrEmpty(fileName))
                return;

            //vue中使用的是"Content-Type: application/json;charset=UTF-8"，但是这个类型在后台不能转换，必须使用如下Content-Type
            string contentType = "application/x-www-form-urlencoded;charset=utf-8";
            HttpWebResponse response = PostResponse(url, requestEncoding, parameters, contentType, userAgent, headers, cookies, timeout);

            long length = response.ContentLength;
            ProgressBarStart(int.MaxValue);

            using (Stream responseStream = response.GetResponseStream())
            {
                using (Stream fileStream = new FileStream(fileName, FileMode.Create))
                {

                    byte[] readBytes = new byte[1024];
                    long downLoadSize = 0;
                    int tmpSize = responseStream.Read(readBytes, 0, readBytes.Length);
                    while (tmpSize > 0)
                    {
                        downLoadSize += tmpSize;
                        System.Windows.Forms.Application.DoEvents();
                        fileStream.Write(readBytes, 0, tmpSize);

                        ProgressProcess((int)(downLoadSize * (int.MaxValue / length)));//按比例计算进度

                        tmpSize = responseStream.Read(readBytes, 0, readBytes.Length);
                        System.Windows.Forms.Application.DoEvents();
                    }
                    //return fileStream;
                }
            }
        }
        #endregion

        #region GET请求并返回结果
        /// <summary>
        /// GET请求并返回结果
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="headers">HTTP Request Headers</param>
        /// <param name="cookies">Cookie集合</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="contentType">Content-Type</param>
        /// <param name="userAgent">User-Agent</param>
        /// <returns>GET请求结果</returns>
        private HttpWebResponse GetResponse(string url, string[] headers, CookieCollection cookies,
             int? timeout = null, string contentType = null, string userAgent = null)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("url");

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = string.IsNullOrEmpty(contentType) ? UTF_8 : contentType;
            request.UserAgent = string.IsNullOrEmpty(userAgent) ? USER_AGENT : userAgent;
            if (timeout.HasValue)
                request.Timeout = timeout.Value;

            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookies);
            }

            WebHeaderCollection headerCollection = request.Headers;
            if (headers != null && headers.Length > 0)
                foreach (var header in headers)
                    headerCollection.Add(header);

            return request.GetResponse() as HttpWebResponse;
        }
        #endregion

        #region POST请求并应答(包含下载)
        /// <summary>
        /// POST请求并应答(包含下载)
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="requestEncoding">请求的字符编码</param>
        /// <param name="parameters">POST请求的参数字典</param>
        /// <param name="contentType">Content-Type</param>
        /// <param name="userAgent">User-Agent</param>
        /// <param name="headers">HTTP Request Headers</param>
        /// <param name="cookies">Cookie集合</param>
        /// <param name="timeout">超时时间</param>
        /// <returns>POST请求结果</returns>
        private HttpWebResponse PostResponse(string url, Encoding requestEncoding, NameValueCollection parameters,
            string contentType = null, string userAgent = null, string[] headers = null,
            CookieCollection cookies = null, int? timeout = null)
        {
            HttpWebRequest request = GetPostRequest(url, requestEncoding, headers, cookies, timeout, contentType, userAgent);

            byte[] data = GetPostParameters(requestEncoding, parameters);
            if (data != null && data.Length > 0)
                using (Stream stream = request.GetRequestStream())
                    stream.Write(data, 0, data.Length);

            return request.GetResponse() as HttpWebResponse;
        }
        #endregion

        #region POST上传请求并应答
        /// <summary>
        /// POST上传请求并应答
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="requestEncoding">请求的字符编码</param>
        /// <param name="formData">POST上传请求的参数字典</param>
        /// <param name="filePath">文件路径</param>
        /// <param name="headers">HTTP Request Headers</param>
        /// <param name="cookies">Cookie集合</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="contentType">Content-Type</param>
        /// <param name="userAgent">User-Agent</param>
        /// <returns></returns>
        private HttpWebResponse PostUploadResponse(string url, Encoding requestEncoding, NameValueCollection formData, string filePath, string boundary,
            string contentType = null, string userAgent = null, string[] headers = null,
            CookieCollection cookies = null, int? timeout = null)
        {
            HttpWebRequest request = GetPostRequest(url, requestEncoding, headers, cookies, timeout, contentType, userAgent);
            request.KeepAlive = true;
            request.Credentials = CredentialCache.DefaultCredentials;

            byte[] data = this.GetPostFormStream(boundary, requestEncoding, formData, filePath);
            request.ContentLength = data.Length;

            if (data != null && data.Length > 0)
                using (Stream stream = request.GetRequestStream())
                    stream.Write(data, 0, data.Length);

            return request.GetResponse() as HttpWebResponse;
        }
        #endregion

        #region 组装Post请求对象
        /// <summary>
        /// 组装Post请求对象
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="requestEncoding">请求的字符编码</param>
        /// <param name="headers">HTTP Request Headers</param>
        /// <param name="cookies">Cookie集合</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="contentType">Content-Type</param>
        /// <param name="userAgent"></param>
        /// <returns>Post请求对象</returns>
        private HttpWebRequest GetPostRequest(string url, Encoding requestEncoding, string[] headers, CookieCollection cookies, int? timeout, string contentType, string userAgent)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("url");
            if (requestEncoding == null)
                throw new ArgumentNullException("requestEncoding");

            HttpWebRequest request = null;
            //如果是发送HTTPS请求  
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            request.Method = "POST";
            if (!string.IsNullOrEmpty(contentType))
                request.ContentType = contentType;
            //request.UserAgent = string.IsNullOrEmpty(userAgent) ? USER_AGENT : userAgent;
            if (timeout.HasValue)
                request.Timeout = timeout.Value;

            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookies);
            }

            WebHeaderCollection headerCollection = request.Headers;
            if (headers != null && headers.Length > 0)
                foreach (var header in headers)
                    headerCollection.Add(header);
            return request;
        }
        #endregion

        #region 组装Post请求参数字节数组
        /// <summary>
        /// 组装Post请求参数字节数组
        /// </summary>
        /// <param name="requestEncoding">请求参数字符编码</param>
        /// <param name="parameters">参数集合</param>
        /// <returns></returns>
        private byte[] GetPostParameters(Encoding requestEncoding, NameValueCollection parameters)
        {
            if (parameters == null || parameters.Count <= 0)
                return null;

            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (string key in parameters.Keys)
            {
                sb.AppendFormat((i > 0) ? "&{0}={1}" : "{0}={1}", key, parameters[key]);
                i++;
            }
            string data = sb.ToString();
            if (string.IsNullOrEmpty(data))
                return null;

            return requestEncoding.GetBytes(data);
        }
        #endregion

        #region 组装包含文件的Post表单请求字节数组
        /// <summary>
        /// 组装包含文件的Post表单请求字节数组
        /// </summary>
        /// <param name="boundary">边界符</param>
        /// <param name="requestEncoding">请求字符编码</param>
        /// <param name="formData">表单数据参数</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        private byte[] GetPostFormStream(string boundary, Encoding requestEncoding, NameValueCollection formData, string filePath)
        {
            using (MemoryStream postDataStream = new System.IO.MemoryStream())
            {
                byte[] beginBoundary = Encoding.ASCII.GetBytes(Environment.NewLine + "--" + boundary + Environment.NewLine);
                byte[] endBoundary = Encoding.ASCII.GetBytes(Environment.NewLine + "--" + boundary + "--" + Environment.NewLine);
                //adding form data
                if (formData != null && formData.Count > 0)
                {
                    //1.组装表单参数头分界线数据
                    string formDataHeaderTemplate = "Content-Disposition: form-data; name=\"{0}\";" + Environment.NewLine
                        + Environment.NewLine + "{1}";
                    //2.组装表单参数数据
                    foreach (string key in formData.Keys)
                    {
                        byte[] formItemBytes = requestEncoding.GetBytes(string.Format(formDataHeaderTemplate, key, formData[key]));
                        postDataStream.Write(beginBoundary, 0, beginBoundary.Length);// 写入开始边界符
                        postDataStream.Write(formItemBytes, 0, formItemBytes.Length);
                    }
                }
                //adding file data
                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    //3.组装文件头分界线数据
                    string fileHeaderTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"" +
                        Environment.NewLine + "Content-Type: application/octet-stream" + Environment.NewLine + Environment.NewLine;
                    byte[] fileHeaderBytes = requestEncoding.GetBytes(string.Format(fileHeaderTemplate, "file", fileInfo.FullName));
                    postDataStream.Write(beginBoundary, 0, beginBoundary.Length);// 写入开始边界符
                    postDataStream.Write(fileHeaderBytes, 0, fileHeaderBytes.Length);
                    //4.组装文件流数据
                    FileStream fileStream = fileInfo.OpenRead();
                    long length = fileStream.Length;//总字节数
                    ProgressBarStart(int.MaxValue);//设置进度条长度为int.MaxValue，因为long类型转换为int类型，可能损失精度

                    byte[] buffer = new byte[1024];
                    int bytesRead = 0;
                    long offset = 0;
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        postDataStream.Write(buffer, 0, bytesRead);
                        offset += bytesRead;
                        ProgressProcess((int)(offset * (int.MaxValue / length)));//按比例计算进度
                    }
                    fileStream.Close();
                    //5.组装结束分界线数据
                    postDataStream.Write(endBoundary, 0, endBoundary.Length);
                }
                return postDataStream.ToArray();
            }
        }
        #endregion

        #region 获取返回结果字符串
        /// <summary>
        /// 获取返回结果字符串
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private string GetResult(HttpWebResponse response)
        {
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
        #endregion

        private bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }

        #region 执行进度条开始动作
        /// <summary>
        /// 执行进度条开始动作
        /// </summary>
        /// <param name="total"></param>
        private void ProgressStart(int total)
        {
            if (ProgressBarStart != null)
                ProgressBarStart(total);
        }
        #endregion

        #region 执行进度条推进动作
        /// <summary>
        /// 执行进度条推进动作
        /// </summary>
        /// <param name="total"></param>
        private void ProgressProcess(int total)
        {
            if (ProgressBarProcess != null)
                ProgressBarProcess(total);
        }
        #endregion

        #endregion
    }
}

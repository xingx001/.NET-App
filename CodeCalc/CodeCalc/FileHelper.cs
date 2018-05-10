using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeCalc.Abstract
{
    /// <summary>
    /// 文件处理工具类
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-05-04
    /// 修改日期：2018-05-04
    /// </remarks>
    public sealed class FileHelper
    {

        [System.Runtime.InteropServices.DllImport("shlwapi.dll")]
        private static extern int StrFormatByteSizeA(int dw, byte[] buf, int bufSize);

        #region 完整路径字符串转换为目录名和文件名
        /// <summary>
        /// 完整路径字符串转换为目录名和文件名
        /// </summary>
        /// <param name="path">完整路径字符串</param>
        /// <returns>字符串数组</returns>
        public static string[] SplitPattern(string path)
        {
            string dir = null;
            string pattern = null;
            int index = path.LastIndexOfAny("/\\".ToCharArray());
            if (index > 0)
            {
                dir = path.Substring(0, index) + System.IO.Path.DirectorySeparatorChar;
                pattern = path.Substring(index + 1);
            }
            else
            {
                dir = null;
                pattern = path;
            }
            if (path.IndexOf('*') >= 0 || path.IndexOf('?') >= 0)
            {

            }
            else
            {
                if (System.IO.Directory.Exists(path))
                {
                    dir = path;
                    pattern = "*";
                }
            }
            return new string[] { dir, pattern };
        }
        #endregion

        #region 格式化输出文件字节数
        /// <summary>
        /// 格式化输出文件字节数
        /// </summary>
        /// <param name="FileSize">文件字节数</param>
        /// <returns>输出的字符串</returns>
        public static string FormatFileSize(int FileSize)
        {
            byte[] buffer = new byte[30];
            StrFormatByteSizeA(FileSize, buffer, buffer.Length);
            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] == 0)
                    return System.Text.Encoding.GetEncoding(936).GetString(buffer, 0, i);
            }
            return null;
        }
        #endregion

        #region 读取文件二进制数据
        /// <summary>
        /// 读取文件二进制数据
        /// </summary>
        /// <param name="file">文件完整路径</param>
        /// <returns>字节数组</returns>
        public static byte[] LoadBinaryFile(string file)
        {
            try
            {
                if (file != null && System.IO.File.Exists(file))
                {
                    System.IO.FileInfo info = new System.IO.FileInfo(file);
                    if (info.Length == 0)
                        return null;
                    using (System.IO.FileStream myStream = info.Open(System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        byte[] byts = new byte[myStream.Length];
                        myStream.Read(byts, 0, byts.Length);
                        myStream.Close();
                        return byts;
                    }
                }
            }
            catch
            {
            }
            return null;
        }
        #endregion

        #region 保存文件二进制数据
        /// <summary>
        /// 保存文件二进制数据
        /// </summary>
        /// <param name="file">文件完整路径</param>
        /// <param name="bytes">字节数组</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool SaveBinaryFile(string file, byte[] bytes)
        {
            try
            {
                if (file != null)
                {
                    using (System.IO.FileStream myStream = new System.IO.FileStream(
                               file,
                               System.IO.FileMode.Create,
                               System.IO.FileAccess.Write))
                    {
                        myStream.Write(bytes, 0, bytes.Length);
                        myStream.Close();
                        return true;
                    }
                }
            }
            catch
            {
            }
            return false;
        }
        #endregion

        #region GB2312编码格式读取文件
        /// <summary>
        /// GB2312编码格式读取文件
        /// </summary>
        /// <param name="file">文件完整路径</param>
        /// <returns>字符串</returns>
        public static string LoadAnsiFile(string file)
        {
            System.IO.StreamReader myReader = null;
            try
            {
                if (System.IO.File.Exists(file))
                {
                    myReader = new System.IO.StreamReader(file, System.Text.Encoding.GetEncoding(936));
                    string txt = myReader.ReadToEnd();
                    myReader.Close();
                    return txt;
                }
            }
            catch
            {
                if (myReader != null)
                    myReader.Close();
            }
            return null;
        }
        #endregion

        #region GB2312编码格式保存文件
        /// <summary>
        /// GB2312编码格式保存文件
        /// </summary>
        /// <param name="file">文件完整路径</param>
        /// <param name="txt">保存文本</param>
        /// <returns></returns>
        public static bool SaveAnsiFile(string file, string txt)
        {
            using (System.IO.StreamWriter myWriter = new System.IO.StreamWriter(
                       file,
                       false,
                       System.Text.Encoding.GetEncoding(936)))
            {
                myWriter.Write(txt);
                myWriter.Close();
                return true;
            }
        }
        #endregion

        #region 检测文件名是否合法
        /// <summary>
        /// 检测文件名是否合法
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>不合法返回false，否则返回true</returns>
        public static bool CheckFileNameInValidChar(string fileName)
        {
            if (fileName == null
                || fileName.Length == 0
                || fileName.Length > 255)
                return false;
            // 在Windows操作系统文件名中不可出现的字符列表
            const string InValidChars = "\\/:*?\"<>|";
            // 检测文件名对于Windows操作系统是否合法
            foreach (char c in fileName)
            {
                if (InValidChars.IndexOf(c) >= 0)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region 文件名扩展名-大写形式
        /// <summary>
        /// 文件名扩展名-大写形式
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>正常返回扩展名字符串，否则返回null</returns>
        public static string GetExtension(string fileName)
        {
            if (fileName != null && fileName.Length > 0)
            {
                int index = fileName.LastIndexOf('.');
                int index2 = fileName.LastIndexOfAny("/\\".ToCharArray());
                if (index >= 0 && index > index2)
                {
                    string ext = fileName.Substring(index + 1).Trim().ToUpper();
                    if (ext.Length > 0)
                        return ext;
                }
            }
            return null;
        }
        #endregion

        #region 修正文件夹结尾分隔符
        /// <summary>
        /// 修正文件夹结尾分隔符
        /// </summary>
        /// <param name="dir">文件夹路径</param>
        /// <returns></returns>
        public static string FixDirectoryName(string dir)
        {
            if (dir != null && dir.Length > 0)
            {
                if (dir[dir.Length - 1] != System.IO.Path.DirectorySeparatorChar)
                    dir = dir + System.IO.Path.DirectorySeparatorChar;
            }
            return dir;
        }
        #endregion

        #region 无目录无扩展名简单文件名
        /// <summary>
        /// 无目录无扩展名简单文件名
        /// </summary>
        /// <param name="path">路径名</param>
        /// <returns></returns>
        public static string GetSimpleName(string path)
        {
            string strName = System.IO.Path.GetFileName(path);
            int index = strName.LastIndexOf('.');
            if (index >= 0)
                return strName.Substring(0, index);
            else
                return strName;
        }
        #endregion

    }
}

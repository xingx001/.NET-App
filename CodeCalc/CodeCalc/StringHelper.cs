using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeCalc
{
    public class StringHelper
    {
        #region 字符串转换为整数
        /// <summary>
        /// 字符串转换为整数
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns>转换结果</returns>
        public static int ToInt32Value(string str, int DefaultValue)
        {
            try
            {
                if (str == null || str.Length == 0)
                    return DefaultValue;
                char[] chars = str.ToCharArray();
                int count = 0;
                bool bolNegative = false;
                int intLen = chars.Length;
                for (int index = 0; index < intLen; index++)
                {
                    char c = chars[index];
                    if (c >= 48 && c <= 57)
                    {
                        for (int index2 = index; index2 < intLen; index2++)
                        {
                            char c2 = chars[index2];
                            if (c2 >= 48 && c2 <= 57)
                                count = count * 10 + c2 - 48;
                            else
                                break;
                        }
                        break;
                    }
                    else if (c == '-')
                    {
                        bolNegative = true;
                    }
                }
                if (bolNegative)
                    return 0 - count;
                else
                    return count;
            }
            catch
            {
                return DefaultValue;
            }
        }
        #endregion

        #region 是否空白字符串
        /// <summary>
        /// 是否空白字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>若字符串为空或者全部有空白字符组成则返回True,否则返回false</returns>
        public static bool isBlankString(string str)
        {
            if (str == null)
                return true;
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (Char.IsWhiteSpace(str[i]) == false)
                        return false;
                }
                return true;
            }
        }
        #endregion

        #region 是否内容字符串
        /// <summary>
        /// 是否内容字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>若字符串不为空且存在非空白字符则返回True 否则返回False</returns>
        public static bool HasContent(string str)
        {
            if (str != null && str.Length > 0)
            {
                foreach (char c in str)
                {
                    if (Char.IsWhiteSpace(c) == false)
                        return true;
                }
            }
            return false;
        }
        #endregion

    }
}

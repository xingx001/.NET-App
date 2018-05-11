using CodeCalc.Abstract;
using CodeCalc.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeCalc.Analyse
{
    /// <summary>
    /// VB代码文件分析器
    /// </summary>
    public class VBFileAnalyser : FileAnalyser
    {
        /// <summary>
        /// 初始化对象
        /// </summary>
        public VBFileAnalyser()
        {
        }
        /// <summary>
        /// 检测文件扩展名
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        public override bool CheckFileExtension(string extension)
        {
            return extension == "VB"
                || extension == "CLS"
                || extension == "BAS"
                || extension == "CTL"
                || extension == "FRM";
        }
        /// <summary>
        /// 源代码分析
        /// </summary>
        protected override void InnerAnalyse()
        {
            foreach (LineEntity item in this.lines)
            {
                item.CodeFlag = false;
                item.CommentFlag = false;
                item.BlankLine = true;
                if (item.LineText.Length == 0)
                {
                    item.BlankLine = true;
                    continue;
                }
                bool DefineString = false;

                for (int iCount = 0; iCount < item.LineText.Length; iCount++)
                {
                    // 当前字符
                    char c = item.LineText[iCount];
                    // 下一个字符
                    char c2 = (char)0;
                    if (iCount < item.LineText.Length - 1)
                        c2 = item.LineText[iCount + 1];

                    if (!char.IsWhiteSpace(c))
                        item.BlankLine = false;

                    // 正在定义字符串
                    if (DefineString)
                    {
                        if (c == '\"')
                        {
                            if (c2 != '\"')
                            {
                                DefineString = false;
                            }
                        }
                    }
                    else
                    {
                        if (c == '\'')
                        {
                            // 定义注释
                            item.CommentFlag = true;
                            break;
                        }
                        // 开始定义字符串
                        if (c == '\"')
                        {
                            DefineString = true;
                        }
                    }
                    if (!char.IsWhiteSpace(c))
                        item.CodeFlag = true;
                }
            }
        }
    }
}

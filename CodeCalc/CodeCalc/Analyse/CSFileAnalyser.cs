using CodeCalc.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeCalc.Analyse
{
    /// <summary>
    /// 分析CS 代码文件的对象
    /// </summary>
    /// <remarks>
    /// 本分析器用于分析C#代码文件，统计出源代码的一些信息
    /// </remarks>
    public class CSFileAnalyser : FileAnalyser
    {
        public override bool CheckFileExtension(string strExtension)
        {
            return strExtension == "CS";
        }

        protected override void InnerAnalyse()
        {
            //string a = @"aaa/* */aaaaa";
            // 字符串定义标志 0:未定义字符串 1:定义单行字符串 2:定义多行字符串
            int DefineString = 0;
            // 注释定义标志
            bool DefineComment = false;
            foreach (LineEntity item in this.lines)
            {
                item.CodeFlag = false;
                if (item.LineText.Length == 0 && DefineString == 2)
                    item.BlankLine = false;
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

                    // 若正在定义注释
                    if (DefineComment)
                    {
                        item.BlankLine = false;
                        item.CommentFlag = true;
                        // 遇到 */ 结束注释
                        if (c == '*' && c2 == '/')
                        {
                            DefineComment = false;
                            iCount++;
                        }
                        continue;
                    }
                    if (DefineString == 0)
                    {
                        // 若未开始定义字符串
                        if (c == '/' && c2 != 0)
                        {
                            if (c2 == '/')
                            {
                                // 遇到 // 开始单行注释
                                item.CommentFlag = true;
                                goto NextLine;
                            }
                            if (c2 == '*')
                            {
                                // 遇到 /* 开始多行注释
                                if (iCount > 0)
                                    item.CodeFlag = true;
                                item.CommentFlag = true;
                                DefineComment = true;
                                iCount++;
                                continue;
                                //goto NextLine ;
                            }
                        }
                        if (c == '\"')
                        {
                            if (iCount > 0 && item.LineText[iCount - 1] == '@')
                                // 遇到 @" 开始定义多行字符串
                                DefineString = 2;
                            else
                                // 遇到 " 开始定义单行字符串
                                DefineString = 1;
                        }
                    }
                    else
                    {
                        item.BlankLine = false;
                        // 正在定义字符串
                        if (c == '\"')
                        {
                            // 若定义了字符串且遇到 " 则结束定义字符串
                            if (iCount > 0 && item.LineText[iCount - 1] != '\\')
                                DefineString = 0;
                        }
                    }
                    if (!char.IsWhiteSpace(c))
                        item.CodeFlag = true;
                }
            NextLine: ;
            }
        }
    }
}

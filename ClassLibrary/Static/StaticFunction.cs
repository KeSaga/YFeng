using ClassLibrary.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Static
{
    /// <summary>
    /// 静态函数类
    /// </summary>
    public static class StaticFunction
    {
        /// <summary>
        /// 将字符串列表转换成以竖线（|）分隔符分隔的字符串形式
        /// </summary>
        /// <param name="strList">待处理的字符串列表</param>
        /// <returns>
        /// 返回一个被竖线（|）分隔的字符串，如果 strList 为 null 或无任何元素，则返回 string.Empty
        /// </returns>
        public static string ToStringWithDelimiterFromStringArray(List<string> strList)
        {
            if (strList == null || strList.Count == 0) return string.Empty;

            string firstStr = strList.First();
            StringBuilder strB = new StringBuilder();
            List<string> otherStringList = strList.GetRange(1, strList.Count - 1);

            //Add First
            strB.Append(firstStr);
            //Add others and Delimiter
            otherStringList.ForEach((str) =>
                {
                    strB.Append(DelimiterConst.VerticalLine);
                    strB.Append(str);
                });

            return strB.ToString();
        }

        /// <summary>
        /// 将字符串数组使用指定分隔符组合成字符串
        /// </summary>
        /// <param name="separator">要用作分隔符的字符串</param>
        /// <param name="values">一个包含要串联的字符串的集合</param>
        /// <returns>一个由 values 的成员组成的字符串，这些成员以 separator 字符串分隔</returns>
        public static string JoinStringArrayToStringWithDelimiter(string separator, List<string> values)
        {
            return string.Join(separator, values);
        }

        /// <summary>
        /// 将由竖线（|）分割的字符串转换成数组形式
        /// </summary>
        /// <param name="delimiterString">待处理的字符串</param>
        /// <returns>返回一个 List&lt;string&gt; 字符串数组</returns>
        public static List<string> ToStringArrayFromStringWithDelimiter(string delimiterString)
        {
            return delimiterString.Split(DelimiterConst.VerticalLine).ToList();
        }

    }
}

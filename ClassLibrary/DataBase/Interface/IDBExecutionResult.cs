using ClassLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DataBase.Interface
{
    /// <summary>
    /// 提供数据库操作的执行结果的定义
    /// </summary>
    public interface IDBExecutionResult : IExecutionResult
    {
        /// <summary>
        /// 是否执行成功，默认值为 false
        /// </summary>
        bool IsSucceed { get; set; }
        /// <summary>
        /// 执行结果，如果执行成功，则默认返回 “成功” 字符串，否则则默认返回 “失败” 字符串
        /// </summary>
        string Result { get; set; }
        /// <summary>
        /// 执行后得到的数据，如果没有则为null
        /// </summary>
        object Data { get; set; }
    }
}

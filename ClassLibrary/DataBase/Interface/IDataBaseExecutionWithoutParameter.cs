using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DataBase.Interface
{
    /// <summary>
    /// 提供数据库操作执行功能的统一接口——不带参数的执行
    /// </summary>
    public interface IDataBaseExecutionWithoutParameter : IDataBaseExecution
    {
        /// <summary>
        /// 无参数的数据库执行函数
        /// </summary>
        /// <returns>返回一个 IDBExecutionResult 类型的结果</returns>
        IDBExecutionResult Execution();
    }
}

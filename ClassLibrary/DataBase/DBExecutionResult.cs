using ClassLibrary.DataBase.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.DataBase
{
    public class DBExecutionResult : IDBExecutionResult
    {
        private bool _isSucceed = false;
        /// <summary>
        /// 是否执行成功，默认值为 false
        /// </summary>
        public bool IsSucceed
        {
            get { return this._isSucceed; }
            set { this._isSucceed = value; }
        }

        private string _result = string.Empty;
        /// <summary>
        /// 执行结果，如果执行成功，则默认返回 “成功” 字符串，否则则默认返回 “失败” 字符串
        /// </summary>
        public string Result
        {
            get
            {
                if (this._isSucceed && string.IsNullOrEmpty(this._result))
                {
                    this._result = "成功";
                }
                else if (!this._isSucceed && string.IsNullOrEmpty(this._result))
                {
                    this._result = "失败";
                }
                return this._result;
            }
            set
            {
                this._result = value;
            }
        }

        private object _data = null;
        /// <summary>
        /// 执行后得到的数据，如果没有则为null
        /// </summary>
        public object Data { get { return this._data; } set { this._data = value; } }

    }
}

using ClassLibrary.DataBase.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.DataBase
{
    public class DataBaseExecution : IDataBaseExecutionWithParameter, IDataBaseExecutionWithoutParameter
    {
        public IDBExecutionResult Execution(List<IDBExecutionFunParameter> funParaList)
        {
            throw new NotImplementedException();
        }

        public IDBExecutionResult Execution()
        {
            throw new NotImplementedException();
        }
    }
}

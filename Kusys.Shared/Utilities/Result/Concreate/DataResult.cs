using Kusys.Shared.Utilities.Result.Abstract;
using Kusys.Shared.Utilities.Result.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kusys.Shared.Utilities.Result.Concreate
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(ResultStatus ResultStatus,T data)
        {
            this.Data = data;
            this.ResultStatus = ResultStatus;

        }
        public DataResult(ResultStatus ResultStatus, string Message, T data)
        {
            this.Data = data;
            this.ResultStatus = ResultStatus;
            this.Message = Message;
        }
        public DataResult(ResultStatus ResultStatus, string Message, Exception Exception, T data)
        {
            this.Data = data;
            this.ResultStatus = ResultStatus;
            this.Message = Message;
            this.Exception = Exception;
        }
        public T Data { get; }

        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }
    }
}

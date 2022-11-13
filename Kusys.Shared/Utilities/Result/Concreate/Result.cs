using Kusys.Shared.Utilities.Result.Abstract;
using Kusys.Shared.Utilities.Result.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kusys.Shared.Utilities.Result.Concreate
{
    public class Result : IResult
    {
        public Result(ResultStatus ResultStatus)
        {
            this.ResultStatus = ResultStatus;

        }
        public Result(ResultStatus ResultStatus, string Message)
        {
            this.ResultStatus = ResultStatus;
            this.Message = Message;
        }
        public Result(ResultStatus ResultStatus, string Message, Exception Exception)
        {
            this.ResultStatus = ResultStatus;
            this.Message = Message;
            this.Exception = Exception;
        }
        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }
    }
}

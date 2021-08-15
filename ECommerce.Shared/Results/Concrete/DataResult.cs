using System;
using ECommmerce.Shared.Results.Abstract;

namespace ECommmerce.Shared.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public T Data { get; set; }
        public ResultStatus ResultStatus { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }

        public DataResult(ResultStatus resultStatus, T data)
        {
            ResultStatus = resultStatus;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, string message, T data)
        {
            ResultStatus = resultStatus;
            Message = message;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, string message, T data, Exception exception)
        {
            ResultStatus = resultStatus;
            Message = message;
            Data = data;
            Exception = exception;
        }
    }
}

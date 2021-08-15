using System;
using ECommmerce.Shared.Results.Concrete;

namespace ECommerce.Shared.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get;}
        public string Message { get;}
        public Exception Exception { get;}
    }
}

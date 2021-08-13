using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommmerce.Service.Results.Concrete;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;

namespace ECommmerce.Service.Results.Abstract
{
    public interface IDataResult<out T> : IResult
    {
        public T Data { get; }
    }
}

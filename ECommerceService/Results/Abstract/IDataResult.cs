using ECommerce.Shared.Results.Abstract;

namespace ECommmerce.Shared.Results.Abstract
{
    public interface IDataResult<out T> : IResult
    {
        public T Data { get; }
    }
}

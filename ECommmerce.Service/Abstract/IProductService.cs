using ECommerce.Entities.Concrete;
using ECommmerce.Entities.Dtos;
using ECommmerce.Shared.Results.Abstract;

namespace ECommmerce.Service.Abstract
{
    public interface IProductService
    {
        public IDataResult<ProductDto> Get(int productId);
        public IDataResult<ProductListDto> GetAll();
        public IDataResult<ProductListDto> GetAllByNonDeleted();
        public IDataResult<ProductListDto> GetAllByNonDeletedAndActive();
        public IDataResult<ProductListDto> GetAllByCategory(int categoryId);
        public IDataResult<ProductDto> Add(Product product, string createdByName);
        public IDataResult<ProductDto> Update(Product product, string modifiedByName);
        public IDataResult<ProductDto> Delete(int productId, string modifiedByName);
        public IDataResult<ProductDto> HardDelete(int productId);
    }
}

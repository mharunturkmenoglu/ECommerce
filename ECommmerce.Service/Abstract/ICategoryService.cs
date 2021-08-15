using ECommerce.Entities.Concrete;
using ECommmerce.Entities.Dtos;
using ECommmerce.Shared.Results.Abstract;

namespace ECommmerce.Service.Abstract
{
    public interface ICategoryService
    {
        public IDataResult<CategoryDto> Get(int categoryID);
        public IDataResult<CategoryListDto> GetAll();
        public IDataResult<CategoryListDto> GetAllByNonDeleted();
        public IDataResult<CategoryListDto> GetAllByNonDeletedAndActive();
        public IDataResult<CategoryDto> Add(Category category, string createdByName);
        public IDataResult<CategoryDto> Update(Category category, string modifiedByName);
        public IDataResult<CategoryDto> Delete(int categoryID, string modifiedByName);
        public IDataResult<CategoryDto> HardDelete(int categoryID);
    }
}

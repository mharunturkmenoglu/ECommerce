using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using ECommerce.Data.Abstract;
using ECommerce.Entities.Concrete;
using ECommmerce.Entities.Dtos;
using ECommmerce.Service.Abstract;
using ECommmerce.Service.Results.Abstract;
using ECommmerce.Service.Results.Concrete;
using Microsoft.Extensions.Configuration;

namespace ECommmerce.Service.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IAdoNetDataReader _adoNetDataReader;

        public CategoryManager(IAdoNetDataReader adoNetDataReader)
        {
            _adoNetDataReader = adoNetDataReader;
        }

        public IDataResult<CategoryDto> Get(int categoryID)
        {
            var queryScript = $"select * from dbo.Categories where Id = {categoryID}";
            var category = _adoNetDataReader.GetCategoryDataReader(queryScript);
            if (category.Name != null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, "The Category has been successfully found.",new CategoryDto
                {
                    Category = category
                });
            }
            else
            {
                return new DataResult<CategoryDto>(ResultStatus.Error, "Any Category has not been found.", null);
            }
        }

        public IDataResult<CategoryListDto> GetAll()
        {
            string queryScript = "select * from dbo.Categories";
            var categoryList = _adoNetDataReader.GetCategoryListDataReader(queryScript);
            if (categoryList.Count > 0)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, "Categories have been successfully found.",
                    new CategoryListDto
                    {
                        Categories = categoryList
                    });
            }
            else
            {
                return new DataResult<CategoryListDto>(ResultStatus.Error, "Any category has not been found.", null);
            }
        }

        public IDataResult<CategoryListDto> GetAllByNonDeleted()
        {
            string queryScript = "select * from dbo.Categories where IsDeleted = false";
            var categoryList = _adoNetDataReader.GetCategoryListDataReader(queryScript);
            if (categoryList.Count > 0)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, "Categories have been successfully found.",
                    new CategoryListDto
                    {
                        Categories = categoryList
                    });
            }
            else
            {
                return new DataResult<CategoryListDto>(ResultStatus.Error, "Any category has not been found.", null);
            }
        }

        public IDataResult<CategoryListDto> GetAllByNonDeletedAndActive()
        {
            string queryScript = "select * from dbo.Categories where IsDeleted = false and IsActive = true";
            var categoryList = _adoNetDataReader.GetCategoryListDataReader(queryScript);
            if (categoryList.Count > 0)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, "Categories have been successfully found.",
                    new CategoryListDto
                    {
                        Categories = categoryList
                    });
            }
            else
            {
                return new DataResult<CategoryListDto>(ResultStatus.Error, "Any category has not been found.", null);
            }
        }

        public IDataResult<CategoryDto> Add(Category category, string createdByName)
        {
            var categoryAdd =
                _adoNetDataReader.GetCategoryDataReader($"select * from dbo.Categories where Name = '{category.Name}'");

            if (categoryAdd.Name == null)
            {
                string script = $"Insert Into Categories(Name,Description,IsDeleted,IsActive,CreatedDate,ModifiedDate,CreatedByName,ModifiedByName,Note)" +
                                $"Values('{category.Name}','{category.Description}','{category.IsDeleted}','{category.IsActive}','{DateTime.Now}'," +
                                $"'{DateTime.Now}','{createdByName}','{createdByName}','{category.Note}')";
                _adoNetDataReader.ExecuteNonQuery(script);
                return new DataResult<CategoryDto>(ResultStatus.Success, "The Product has been successfully added.", new CategoryDto
                {
                    Category = categoryAdd
                });
            }
            else
            {
                return new DataResult<CategoryDto>(ResultStatus.Error, "The Category has been already created.", null);
            }
        }

        public IDataResult<CategoryDto> Update(Category category, string modifiedByName)
        {
            var categoryUpdate =
                _adoNetDataReader.GetCategoryDataReader($"select * from dbo.Categories where Id = '{category.Id}'");

            if (categoryUpdate.Name != null)
            {
                string script = $"Update Categories " +
                                     $"Set Name = '{category.Name}',Description='{category.Description}',IsDeleted='{category.IsDeleted}',IsActive='{category.IsActive}'," +
                                     $"CreatedDate ='{category.CreatedDate}',ModifiedDate = '{DateTime.Now}',CreatedByName = '{category.CreatedByName}'," +
                                     $"ModifiedByName = '{modifiedByName}',Note = '{category.Note}'" +
                                     $"where Id = '{category.Id}'";
                _adoNetDataReader.ExecuteNonQuery(script);
                return new DataResult<CategoryDto>(ResultStatus.Success, "The Product has been successfully updated.", new CategoryDto
                {
                    Category = categoryUpdate
                });
            }
            else
            {
                return new DataResult<CategoryDto>(ResultStatus.Error, "The Category has been found.", null);
            }
        }

        public IDataResult<CategoryDto> Delete(int categoryID, string modifiedByName)
        {
            var categoryDelete =
                _adoNetDataReader.GetCategoryDataReader($"select * from dbo.Categories where Id = '{categoryID}'");

            if (categoryDelete.Name != null)
            {
                string script = $"Update Categories " +
                                $"Set IsDeleted = 'true',ModifiedByName ='{modifiedByName}', ModifiedDate='{DateTime.Now}' " +
                                $"where Id = {categoryID}";
                _adoNetDataReader.ExecuteNonQuery(script);
                return new DataResult<CategoryDto>(ResultStatus.Success, "The Product has been successfully deleted.", new CategoryDto
                {
                    Category = categoryDelete
                });
            }
            else
            {
                throw new Exception("The category has not been found.");
            }
        }

        public IDataResult<CategoryDto> HardDelete(int categoryID)
        {
            throw new NotImplementedException();
        }
    }
}

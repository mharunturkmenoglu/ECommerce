using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using ECommerce.Data.Abstract;
using ECommerce.Entities.Concrete;
using ECommmerce.Service.Abstract;
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

        public Category Get(int categoryID)
        {
            var queryScript = $"select * from dbo.Categories where Id = {categoryID}";
            var category = _adoNetDataReader.GetCategoryDataReader(queryScript);
            return category;
        }

        public List<Category> GetAll()
        {
            string queryScript = "select * from dbo.Categories";
            var categoryList = _adoNetDataReader.GetCategoryListDataReader(queryScript);
            return categoryList;
        }

        public List<Category> GetAllByNonDeleted()
        {
            string queryScript = "select * from dbo.Categories where IsDeleted = false";
            var categoryList = _adoNetDataReader.GetCategoryListDataReader(queryScript);
            return categoryList;
        }

        public List<Category> GetAllByNonDeletedAndActive()
        {
            string queryScript = "select * from dbo.Categories where IsDeleted = false and IsActive = true";
            var categoryList = _adoNetDataReader.GetCategoryListDataReader(queryScript);
            return categoryList;
        }

        public void Add(Category category, string createdByName)
        {
            var categoryAdd =
                _adoNetDataReader.GetCategoryDataReader($"select * from dbo.Categories where Name = '{category.Name}'");

            if (categoryAdd.Name == null)
            {
                string queryScript = $"Insert Into Categories(Name,Description,IsDeleted,IsActive,CreatedDate,ModifiedDate,CreatedByName,ModifiedByName,Note)" +
                                     $"Values('{category.Name}','{category.Description}','{category.IsDeleted}','{category.IsActive}','{category.CreatedDate}'," +
                                     $"'{category.ModifiedDate}','{category.CreatedByName}','{category.ModifiedByName}','{category.Note}')";
                _adoNetDataReader.AddCategory(queryScript);
            }
            else
            {
                throw new Exception("It s already created.");
                // It s already created.
            }
        }

        public void Update(Category category, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public void Delete(int categoryID, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public void HardDelete(int categoryID)
        {
            throw new NotImplementedException();
        }
    }
}

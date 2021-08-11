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
                string script = $"Insert Into Categories(Name,Description,IsDeleted,IsActive,CreatedDate,ModifiedDate,CreatedByName,ModifiedByName,Note)" +
                                $"Values('{category.Name}','{category.Description}','{category.IsDeleted}','{category.IsActive}','{category.CreatedDate}'," +
                                $"'{category.ModifiedDate}','{createdByName}','{category.ModifiedByName}','{category.Note}')";
                _adoNetDataReader.ExecuteNonQuery(script);
            }
            else
            {
                throw new Exception("It s already created.");
                // It s already created.
            }
        }

        public void Update(Category category, string modifiedByName)
        {
            var categoryUpdate =
                _adoNetDataReader.GetCategoryDataReader($"select * from dbo.Categories where Id = '{category.Id}'");

            if (categoryUpdate.Name != null)
            {
                string script = $"Update Categories " +
                                     $"Set Name = '{category.Name}',Description='{category.Description}',IsDeleted='{category.IsDeleted}',IsActive='{category.IsActive}'," +
                                     $"CreatedDate ='{category.CreatedDate}',ModifiedDate = '{category.ModifiedDate}',CreatedByName = '{category.CreatedByName}'," +
                                     $"ModifiedByName = '{modifiedByName}',Note = '{category.Note}'" +
                                     $"where Id = '{category.Id}'";
                _adoNetDataReader.ExecuteNonQuery(script);
            }
            else
            {
                throw new Exception("The category has not been find.");
            }
        }

        public void Delete(int categoryID, string modifiedByName)
        {
            var categoryDelete =
                _adoNetDataReader.GetCategoryDataReader($"select * from dbo.Categories where Id = '{categoryID}'");

            if (categoryDelete.Name != null)
            {
                string script = $"Update Categories " +
                                $"Set IsDeleted = 'true',ModifiedByName ='{modifiedByName}' " +
                                $"where Id = {categoryID}";
                _adoNetDataReader.ExecuteNonQuery(script);
            }
            else
            {
                throw new Exception("The category has not been find.");
            }
        }

        public void HardDelete(int categoryID)
        {
            throw new NotImplementedException();
        }
    }
}

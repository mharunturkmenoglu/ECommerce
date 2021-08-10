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

        public void Add(Category category, string createdByName)
        {
            throw new NotImplementedException();
        }

        public void Delete(int categoryID, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public void Get(int categoryID)
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            var categoryList = new List<Category>();
            var queryScript = "select * from dbo.Categories where [Id] = 1";

            var dataReader = _adoNetDataReader.GetDataReader(queryScript);
            while (dataReader.Read())
            {
                var category = new Category();
                category.Id = 1;
                category.Name = (string)dataReader["Name"];
                category.Description = (string)dataReader["Description"];
                category.IsDeleted = true;
                category.IsActive = true;
                category.CreatedDate = DateTime.Now;
                category.ModifiedDate = DateTime.Now;
                category.CreatedByName = (string)dataReader["CreatedByName"];
                category.ModifiedByName = (string)dataReader["ModifiedByName"];
                category.Note = "note";
                categoryList.Add(category);
            }
        }

        public void GetAllByNonDeleted()
        {
            throw new NotImplementedException();
        }

        public void GetAllByNonDeletedAndActive()
        {
            throw new NotImplementedException();
        }

        public void HardDelete(int categoryID)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category, string modifiedByName)
        {
            throw new NotImplementedException();
        }
    }
}

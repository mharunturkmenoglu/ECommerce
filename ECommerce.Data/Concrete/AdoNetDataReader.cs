using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ECommerce.Data.Abstract;
using ECommerce.Entities.Concrete;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Data.Concrete
{
    public class AdoNetDataReader : IAdoNetDataReader
    {
        private readonly IConfiguration _config;

        public AdoNetDataReader(IConfiguration config)
        {
            _config = config;
        }

        public List<Category> GetCategoryListDataReader(string queryScript)
        {
            var categoryList = new List<Category>();
            var connectionString = _config.GetConnectionString("LocalDB");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(queryScript, connection);
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                var category = new Category();
                category.Id = Convert.ToInt32(dataReader["Id"]);
                category.Name = (string)dataReader["Name"];
                category.Description = (string)dataReader["Description"];
                category.IsDeleted = Convert.ToBoolean(dataReader["IsDeleted"]);
                category.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                category.CreatedDate = DateTime.Now;
                category.ModifiedDate = DateTime.Now;
                category.CreatedByName = (string)dataReader["CreatedByName"];
                category.ModifiedByName = (string)dataReader["ModifiedByName"];
                category.Note = (string)dataReader["Note"];
                category.Products = null;
                categoryList.Add(category);
            }
            connection.Close();
            dataReader.Close();
            foreach (var category in categoryList)
            {
                category.Products = GetProductListDataReader($"select * from Products where CategoryId = {category.Id}");
            }
            return categoryList;
        }

        public Category GetCategoryDataReader(string queryScript)
        {
            var category = new Category();
            var connectionString = _config.GetConnectionString("LocalDB");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(queryScript, connection);
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                category.Id = Convert.ToInt32(dataReader["Id"]);
                category.Name = (string)dataReader["Name"];
                category.Description = (string)dataReader["Description"];
                category.IsDeleted = Convert.ToBoolean(dataReader["IsDeleted"]);
                category.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                category.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]);
                category.ModifiedDate = Convert.ToDateTime(dataReader["ModifiedDate"]);
                category.CreatedByName = (string)dataReader["CreatedByName"];
                category.ModifiedByName = (string)dataReader["ModifiedByName"];
                category.Note = (string)dataReader["Note"];
            }
            category.Products = null;
            category.Products = GetProductListDataReader($"select * from Products where CategoryId = {category.Id}");
            return category;
        }

        public void ExecuteNonQuery(string script)
        {
            var connectionString = _config.GetConnectionString("LocalDB");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(script, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<Product> GetProductListDataReader(string queryScript)
        {
            var productList = new List<Product>();
            var connectionString = _config.GetConnectionString("LocalDB");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(queryScript, connection);
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                var product = new Product();
                product.Id = Convert.ToInt32(dataReader["Id"]);
                product.Name = (string)dataReader["Name"];
                product.Quantity = Convert.ToInt32(dataReader["Quantity"]);
                product.Coast = Convert.ToDouble(dataReader["Quantity"]);
                product.Description = (string)dataReader["Description"];
                product.IsDeleted = Convert.ToBoolean(dataReader["IsDeleted"]);
                product.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                product.CreatedDate = DateTime.Now;
                product.ModifiedDate = DateTime.Now;
                product.CreatedByName = (string)dataReader["CreatedByName"];
                product.ModifiedByName = (string)dataReader["ModifiedByName"];
                product.Note = "note";
                product.CategoryId = Convert.ToInt32(dataReader["CategoryId"]);
                product.Category = null;
                productList.Add(product);
            }
            return productList;
        }

        public Product GetProductDataReader(string queryScript)
        {
            var product = new Product();
            var connectionString = _config.GetConnectionString("LocalDB");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(queryScript, connection);
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                product.Id = Convert.ToInt32(dataReader["Id"]);
                product.Name = (string)dataReader["Name"];
                product.Quantity = Convert.ToInt32(dataReader["Quantity"]);
                product.Coast = Convert.ToDouble(dataReader["Quantity"]);
                product.Description = (string)dataReader["Description"];
                product.IsDeleted = Convert.ToBoolean(dataReader["IsDeleted"]);
                product.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                product.CreatedDate = DateTime.Now;
                product.ModifiedDate = DateTime.Now;
                product.CreatedByName = (string)dataReader["CreatedByName"];
                product.ModifiedByName = (string)dataReader["ModifiedByName"];
                product.Note = "note";
                product.CategoryId = Convert.ToInt32(dataReader["CategoryId"]);
            }
            product.Category = null;
            return product;
        }

        public List<User> GetUserListDataReader(string queryScript)
        {
            var userList = new List<User>();
            var connectionString = _config.GetConnectionString("LocalDB");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(queryScript, connection);
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                var user = new User();
                user.Id = Convert.ToInt32(dataReader["Id"]);
                user.Email = (string)dataReader["Email"];
                user.UserName = (string)dataReader["UserName"];
                user.Password = (string)dataReader["Password"];
                user.Description = (string)dataReader["Description"];
                user.IsDeleted = Convert.ToBoolean(dataReader["IsDeleted"]);
                user.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                user.CreatedDate = DateTime.Now;
                user.ModifiedDate = DateTime.Now;
                user.CreatedByName = (string)dataReader["CreatedByName"];
                user.ModifiedByName = (string)dataReader["ModifiedByName"];
                user.Note = "note";
            }
            return userList;
        }

        public User GetUserDataReader(string queryScript)
        {
            var user = new User();
            var connectionString = _config.GetConnectionString("LocalDB");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(queryScript, connection);
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                user.Id = Convert.ToInt32(dataReader["Id"]);
                user.Email = (string)dataReader["Email"];
                user.UserName = (string)dataReader["UserName"];
                user.Password = (string)dataReader["Password"];
                user.Description = (string)dataReader["Description"];
                user.IsDeleted = Convert.ToBoolean(dataReader["IsDeleted"]);
                user.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                user.CreatedDate = DateTime.Now;
                user.ModifiedDate = DateTime.Now;
                user.CreatedByName = (string)dataReader["CreatedByName"];
                user.ModifiedByName = (string)dataReader["ModifiedByName"];
                user.Note = "note";
            }
            return user;
        }
    }
}

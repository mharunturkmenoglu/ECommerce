using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Data.Abstract;
using ECommerce.Entities.Concrete;
using ECommmerce.Service.Abstract;

namespace ECommmerce.Service.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IAdoNetDataReader _adoNetDataReader;

        public ProductManager(IAdoNetDataReader adoNetDataReader)
        {
            _adoNetDataReader = adoNetDataReader;
        }

        public Product Get(int productId)
        {
            var queryScript = $"select * from dbo.Products where Id = {productId}";
            var product = _adoNetDataReader.GetProductDataReader(queryScript);
            return product;
        }

        public List<Product> GetAll()
        {
            var queryScript = "select * from dbo.Products";
            var productList = _adoNetDataReader.GetProductListDataReader(queryScript);
            return productList;
        }

        public List<Product> GetAllByNonDeleted()
        {
            string queryScript = "select * from dbo.Products where IsDeleted = false";
            var productList = _adoNetDataReader.GetProductListDataReader(queryScript);
            return productList;
        }

        public List<Product> GetAllByNonDeletedAndActive()
        {
            string queryScript = "select * from dbo.Products where IsDeleted = false and IsActive = true";
            var productList = _adoNetDataReader.GetProductListDataReader(queryScript);
            return productList;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            string queryScript = $"select * from dbo.Products where CategoryId = '{categoryId}'";
            var productList = _adoNetDataReader.GetProductListDataReader(queryScript);
            return productList;
        }

        public void Add(Product product, string createdByName)
        {
            var productAdd =
                _adoNetDataReader.GetProductDataReader($"select * from dbo.Products where Name = '{product.Name}'");

            if (productAdd.Name == null)
            {
                string script = $"Insert Into Products(Name,Description,IsDeleted,IsActive,CreatedDate,ModifiedDate,CreatedByName,ModifiedByName,Note,Quantity,Coast,CategoryId)" +
                                $"Values('{product.Name}','{product.Description}','{product.IsDeleted}','{product.IsActive}','{product.CreatedDate}'," +
                                $"'{product.CreatedDate}','{createdByName}','{product.ModifiedByName}','{product.Note}', '{product.Quantity}', '{product.Coast}', '{product.CategoryId}')";
                _adoNetDataReader.ExecuteNonQuery(script);
            }
            else
            {
                throw new Exception("It s already created.");
            }
        }

        public void Update(Product product, string modifiedByName)
        {
            var productUpdate =
                _adoNetDataReader.GetProductDataReader($"select * from dbo.Categories where Id = '{product.Id}'");

            if (productUpdate.Name != null)
            {
                string script = $"Update Products " +
                                $"Set Name = '{product.Name}',Description='{product.Description}',IsDeleted='{product.IsDeleted}',IsActive='{product.IsActive}'," +
                                $"CreatedDate ='{product.CreatedDate}',ModifiedDate = '{product.ModifiedDate}',CreatedByName = '{product.CreatedByName}'," +
                                $"ModifiedByName = '{modifiedByName}',Note = '{product.Note}',Quantity ='{product.Quantity}',Coast ='{product.Coast}',CategoryId ='{product.CategoryId}'" +
                                $"where Id = '{product.Id}'";
                _adoNetDataReader.ExecuteNonQuery(script);
            }
            else
            {
                throw new Exception("The product has not been find.");
            }
        }

        public void Delete(int productId, string modifiedByName)
        {
            var productDelete =
                _adoNetDataReader.GetCategoryDataReader($"select * from dbo.Categories where Id = '{productId}'");

            if (productDelete.Name != null)
            {
                string script = $"Update Products " +
                                $"Set IsDeleted = 'true',ModifiedByName ='{modifiedByName}' " +
                                $"where Id = {productId}";
                _adoNetDataReader.ExecuteNonQuery(script);
            }
            else
            {
                throw new Exception("The product has not been find.");
            }
        }

        public void HardDelete(int productId)
        {
            throw new NotImplementedException();
        }
    }
}

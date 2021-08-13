using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Data.Abstract;
using ECommerce.Entities.Concrete;
using ECommmerce.Entities.Dtos;
using ECommmerce.Service.Abstract;
using ECommmerce.Service.Results.Abstract;
using ECommmerce.Service.Results.Concrete;

namespace ECommmerce.Service.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IAdoNetDataReader _adoNetDataReader;

        public ProductManager(IAdoNetDataReader adoNetDataReader)
        {
            _adoNetDataReader = adoNetDataReader;
        }

        public IDataResult<ProductDto> Get(int productId)
        {
            var queryScript = $"select * from dbo.Products where Id = {productId}";
            var product = _adoNetDataReader.GetProductDataReader(queryScript);
            if (product.Name != null)
            {
                return new DataResult<ProductDto>(ResultStatus.Success, "The Product has been successfully find.", new ProductDto
                {
                    Product = product
                });
            }
            return new DataResult<ProductDto>(ResultStatus.Error, "The Product has not been find.", null);
        }

        public IDataResult<ProductListDto> GetAll()
        {
            var queryScript = "select * from dbo.Products";
            var productList = _adoNetDataReader.GetProductListDataReader(queryScript);

            if (productList.Count > 1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, "Products have been successfully find.",
                    new ProductListDto
                    {
                        Articles = productList
                    });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, "Any product has not been found.", null);
        }

        public IDataResult<ProductListDto> GetAllByNonDeleted()
        {
            string queryScript = "select * from dbo.Products where IsDeleted = 0";
            var productList = _adoNetDataReader.GetProductListDataReader(queryScript);
            if (productList.Count > 1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, "Products have been successfully find.",
                    new ProductListDto
                    {
                        Articles = productList
                    });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, "Any product has not been found.", null);
        }

        public IDataResult<ProductListDto> GetAllByNonDeletedAndActive()
        {
            string queryScript = "select * from dbo.Products where IsDeleted = 0 and IsActive = 1";
            var productList = _adoNetDataReader.GetProductListDataReader(queryScript);
            if (productList.Count > 1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, "Products have been successfully find.",
                    new ProductListDto
                    {
                        Articles = productList
                    });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, "Any product has not been found.", null);
        }

        public IDataResult<ProductListDto> GetAllByCategory(int categoryId)
        {
            string queryScript = $"select * from dbo.Products where CategoryId = '{categoryId}'";
            var productList = _adoNetDataReader.GetProductListDataReader(queryScript);
            if (productList.Count > 1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, "Products have been successfully find.",
                    new ProductListDto
                    {
                        Articles = productList
                    });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, "Any product has not been found.", null);
        }

        public IDataResult<ProductDto> Add(Product product, string createdByName)
        {
            var productAdd =
                _adoNetDataReader.GetProductDataReader($"select * from dbo.Products where Name = '{product.Name}'");

            if (productAdd.Name == null)
            {
                string script = $"Insert Into Products(Name,Description,IsDeleted,IsActive,CreatedDate,ModifiedDate,CreatedByName,ModifiedByName,Note,Quantity,Coast,CategoryId)" +
                                $"Values('{product.Name}','{product.Description}','{product.IsDeleted}','{product.IsActive}','{DateTime.Now}'," +
                                $"'{DateTime.Now}','{createdByName}','{createdByName}','{product.Note}', '{product.Quantity}', '{product.Coast}', '{product.CategoryId}')";
                _adoNetDataReader.ExecuteNonQuery(script);
                return new DataResult<ProductDto>(ResultStatus.Success, "The Product has been successfully added.", new ProductDto
                {
                    Product = product
                });
            }
            else
            {
                return new DataResult<ProductDto>(ResultStatus.Error, "The Product has been already created.", null);
            }
        }

        public IDataResult<ProductDto> Update(Product product, string modifiedByName)
        {
            var productUpdate =
                _adoNetDataReader.GetProductDataReader($"select * from dbo.Products where Id = '{product.Id}'");

            if (productUpdate.Name != null)
            {
                string script = $"Update Products " +
                                $"Set Name = '{product.Name}',Description='{product.Description}',IsDeleted='{product.IsDeleted}',IsActive='{product.IsActive}'," +
                                $"CreatedDate ='{product.CreatedDate}',ModifiedDate = '{DateTime.Now}',CreatedByName = '{product.CreatedByName}'," +
                                $"ModifiedByName = '{modifiedByName}',Note = '{product.Note}',Quantity ='{product.Quantity}',Coast ='{product.Coast}',CategoryId ='{product.CategoryId}'" +
                                $"where Id = '{product.Id}'";
                _adoNetDataReader.ExecuteNonQuery(script);
                return new DataResult<ProductDto>(ResultStatus.Success, "The Product has been successfully updated.", new ProductDto
                {
                    Product = product
                });
            }
            else
            {
                return new DataResult<ProductDto>(ResultStatus.Error, "The product has not been find.", null);
            }
        }

        public IDataResult<ProductDto> Delete(int productId, string modifiedByName)
        {
            var productDelete =
                _adoNetDataReader.GetProductDataReader($"select * from dbo.Products where Id = {productId}");

            if (productDelete.Name != null)
            {
                string script = $"Update Products " +
                                $"Set IsDeleted = 'true',ModifiedByName ='{modifiedByName}',ModifiedDate='{DateTime.Now}' " +
                                $"where Id = {productId}";
                _adoNetDataReader.ExecuteNonQuery(script);
                return new DataResult<ProductDto>(ResultStatus.Success, "The Product has been successfully deleted.", new ProductDto
                {
                    Product = productDelete
                });
            }
            else
            {
                return new DataResult<ProductDto>(ResultStatus.Error, "The product has not been find.", null);
            }
        }

        public IDataResult<ProductDto> HardDelete(int productId)
        {
            throw new NotImplementedException();
        }
    }
}

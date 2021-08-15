using System;
using ECommerce.Data.Abstract;
using ECommerce.Entities.Concrete;
using ECommerce.Shared.Authentication;
using ECommmerce.Entities.Dtos;
using ECommmerce.Service.Abstract;
using ECommmerce.Shared.Authentication;
using ECommmerce.Shared.Results.Abstract;
using ECommmerce.Shared.Results.Concrete;

namespace ECommmerce.Service.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IAdoNetDataReader _adoNetDataReader;
        private readonly IAuthenticationService _authenticationService;

        public ProductManager(IAdoNetDataReader adoNetDataReader, IAuthenticationService authenticationService)
        {
            _adoNetDataReader = adoNetDataReader;
            _authenticationService = authenticationService;
        }

        public IDataResult<ProductDto> Get(int productId)
        {
            var queryScript = $"select * from dbo.Products where Id = {productId}";
            var currentLanguage = _authenticationService.GetLanguage();
            if (currentLanguage != Languages.English)
            {
                queryScript =
                    $"select P.Id,P.IsDeleted,P.IsActive,P.CreatedDate,P.ModifiedDate,P.CreatedByName,P.ModifiedByName," +
                    $"P.Quantity,P.Coast,P.CategoryId,ProductLanguages.Name,ProductLanguages.Note,ProductLanguages.Description " +
                    $"from Products P " +
                    $"inner join ProductLanguages " +
                    $"on P.Id = ProductLanguages.ProductId and ProductLanguages.LanguageId = {(int)currentLanguage} and P.Id = {productId}";
            }
            var product = _adoNetDataReader.GetProductDataReader(queryScript);
            if (product.Name != null)
            {
                return new DataResult<ProductDto>(ResultStatus.Success, "The Product has been successfully found.", new ProductDto
                {
                    Product = product
                });
            }
            return new DataResult<ProductDto>(ResultStatus.Error, "The Product has not been found.", null);
        }

        public IDataResult<ProductListDto> GetAll()
        {
            var queryScript = "select * from dbo.Products";
            var currentLanguage = _authenticationService.GetLanguage();
            if (currentLanguage != Languages.English)
            {
                queryScript =
                    $"select P.Id,P.IsDeleted,P.IsActive,P.CreatedDate,P.ModifiedDate,P.CreatedByName,P.ModifiedByName," +
                    $"P.Quantity,P.Coast,P.CategoryId,ProductLanguages.Name,ProductLanguages.Note,ProductLanguages.Description " +
                    $"from Products P " +
                    $"inner join ProductLanguages " +
                    $"on P.Id = ProductLanguages.ProductId and ProductLanguages.LanguageId = {(int)currentLanguage}";
            }
            var productList = _adoNetDataReader.GetProductListDataReader(queryScript);
            if (productList.Count > 1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, "Products have been successfully found.",
                    new ProductListDto
                    {
                        Articles = productList
                    });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, "Any product has not been found.", null);
        }

        public IDataResult<ProductListDto> GetAllByNonDeleted()
        {
            var queryScript = "select * from dbo.Products where IsDeleted = 0";
            var currentLanguage = _authenticationService.GetLanguage();
            if (currentLanguage != Languages.English)
            {
                queryScript =
                    $"select P.Id,P.IsDeleted,P.IsActive,P.CreatedDate,P.ModifiedDate,P.CreatedByName,P.ModifiedByName," +
                    $"P.Quantity,P.Coast,P.CategoryId,ProductLanguages.Name,ProductLanguages.Note,ProductLanguages.Description " +
                    $"from Products P " +
                    $"inner join ProductLanguages " +
                    $"on P.Id = ProductLanguages.ProductId and P.IsDeleted = 0 and ProductLanguages.LanguageId = {(int)currentLanguage}";
            }
            var productList = _adoNetDataReader.GetProductListDataReader(queryScript);
            if (productList.Count > 1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, "Products have been successfully found.",
                    new ProductListDto
                    {
                        Articles = productList
                    });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, "Any product has not been found.", null);
        }

        public IDataResult<ProductListDto> GetAllByNonDeletedAndActive()
        {
            var queryScript = "select * from dbo.Products where IsDeleted = 0 and IsActive = 1";
            var currentLanguage = _authenticationService.GetLanguage();
            if (currentLanguage != Languages.English)
            {
                queryScript =
                    $"select P.Id,P.IsDeleted,P.IsActive,P.CreatedDate,P.ModifiedDate,P.CreatedByName,P.ModifiedByName," +
                    $"P.Quantity,P.Coast,P.CategoryId,ProductLanguages.Name,ProductLanguages.Note,ProductLanguages.Description " +
                    $"from Products P " +
                    $"inner join ProductLanguages " +
                    $"on P.Id = ProductLanguages.ProductId and P.IsDeleted = 0 and P.IsActive = 1 and ProductLanguages.LanguageId = {(int)currentLanguage}";
            }
                
            var productList = _adoNetDataReader.GetProductListDataReader(queryScript);
            if (productList.Count > 1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, "Products have been successfully found.",
                    new ProductListDto
                    {
                        Articles = productList
                    });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, "Any product has not been found.", null);
        }

        public IDataResult<ProductListDto> GetAllByCategory(int categoryId)
        {
            var queryScript = $"select * from dbo.Products where CategoryId = '{categoryId}'";
            var currentLanguage = _authenticationService.GetLanguage();
            if (currentLanguage != Languages.English)
            {
                queryScript =
                    $"select P.Id,P.IsDeleted,P.IsActive,P.CreatedDate,P.ModifiedDate,P.CreatedByName,P.ModifiedByName," +
                    $"P.Quantity,P.Coast,P.CategoryId,ProductLanguages.Name,ProductLanguages.Note,ProductLanguages.Description " +
                    $"from Products P " +
                    $"inner join ProductLanguages " +
                    $"on P.Id = ProductLanguages.ProductId and P.IsDeleted = 0 and P.IsActive = 1 and P.CategoryId ={categoryId} and ProductLanguages.LanguageId = {(int)currentLanguage}";
            }
            var productList = _adoNetDataReader.GetProductListDataReader(queryScript);
            if (productList.Count > 1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, "Products have been successfully found.",
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

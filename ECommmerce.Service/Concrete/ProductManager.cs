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

        public Product Get(int productID)
        {
            var queryScript = $"select * from dbo.Products where Id = {productID}";
            var product = _adoNetDataReader.GetProductDataReader(queryScript);
            return product;
        }

        public List<Product> GetAll()
        {
            var queryScript = $"select * from dbo.Products";
            var productList = _adoNetDataReader.GetProductListDataReader(queryScript);
            return productList;
        }

        public List<Product> GetAllByNonDeleted()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByNonDeletedAndActive()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int product)
        {
            throw new NotImplementedException();
        }

        public void Add(Product product, string createdByName)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public void Delete(int productId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public void HardDelete(int productID)
        {
            throw new NotImplementedException();
        }
    }
}

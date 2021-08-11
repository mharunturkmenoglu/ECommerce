using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECommerce.Entities.Concrete;

namespace ECommmerce.Service.Abstract
{
    public interface IProductService
    {
        Product Get(int productID);
        List<Product> GetAll();
        List<Product> GetAllByNonDeleted();
        List<Product> GetAllByNonDeletedAndActive();
        List<Product> GetAllByCategory(int product);
        void Add(Product product, string createdByName);
        void Update(Product product, string modifiedByName);
        void Delete(int productId, string modifiedByName);
        void HardDelete(int productID);
    }
}

using System.Collections.Generic;
using ECommerce.Entities.Concrete;

namespace ECommerce.Data.Abstract
{
    public interface IAdoNetDataReader
    {
        List<Category> GetCategoryListDataReader(string queryScript);
        Category GetCategoryDataReader(string queryScript);
        void ExecuteNonQuery(string script);
        List<Product> GetProductListDataReader(string queryScript);
        Product GetProductDataReader(string queryScript);
        List<User> GetUserListDataReader(string queryScript);
        User GetUserDataReader(string queryScript);
    }
}

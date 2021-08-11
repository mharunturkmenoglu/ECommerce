using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Entities.Concrete;

namespace ECommerce.Data.Abstract
{
    public interface IAdoNetDataReader
    {
        List<Category> GetCategoryListDataReader(string queryScript);
        Category GetCategoryDataReader(string queryScript);
        void ExecuteNonQueryCategory(string queryScript);
        List<Product> GetProductListDataReader(string queryScript);
        Product GetProductDataReader(string queryScript);
        List<User> GetUserListDataReader(string queryScript);
        User GetUserDataReader(string queryScript);
    }
}

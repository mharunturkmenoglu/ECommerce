using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECommerce.Entities.Concrete;

namespace ECommmerce.Service.Abstract
{
    public interface ICategoryService
    {
        void Get(int categoryID);
        void GetAll();
        void GetAllByNonDeleted();
        void GetAllByNonDeletedAndActive();
        void Add(Category category, string createdByName);
        void Update(Category category, string modifiedByName);
        void Delete(int categoryID, string modifiedByName);
        void HardDelete(int categoryID);
    }
}

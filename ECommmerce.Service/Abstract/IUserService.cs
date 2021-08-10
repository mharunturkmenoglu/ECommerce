using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECommerce.Entities.Concrete;

namespace ECommmerce.Service.Abstract
{
    public interface IUserService
    {
        void Get (int userID);
        void GetAll();
        void GetAllByNonDeleted();
        void GetAllByNonDeletedAndActive();
        void Add(User user, string createdByName);
        void Update(User user, string modifiedByName);
        void Delete(int userID, string modifiedByName);
        void HardDelete(int userID);
    }
}

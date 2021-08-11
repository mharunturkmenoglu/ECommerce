using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECommerce.Entities.Concrete;

namespace ECommmerce.Service.Abstract
{
    public interface IUserService
    {
        User Get (int userID);
        User GetByEmail (string email);
        User GetByEmailAndPassword (string email, string password);
        List<User> GetAll();
        List<User> GetAllByNonDeleted();
        List<User> GetAllByNonDeletedAndActive();
        void Add(User user, string createdByName);
        void Update(User user, string modifiedByName);
        void Delete(int userID, string modifiedByName);
        void HardDelete(int userID);

    }
}

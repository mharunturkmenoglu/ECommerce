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
    public class UserManager : IUserService
    {
        private readonly IAdoNetDataReader _adoNetDataReader;

        public UserManager(IAdoNetDataReader adoNetDataReader)
        {
            _adoNetDataReader = adoNetDataReader;
        }

        public User Get(int userID)
        {
            var queryScript = $"select * from dbo.Users where Id = {userID}";
            var user = _adoNetDataReader.GetUserDataReader(queryScript);
            return user;
        }

        public List<User> GetAll()
        {
            var queryScript = $"select * from dbo.Users";
            var userList = _adoNetDataReader.GetUserListDataReader(queryScript);
            return userList;
        }

        public List<User> GetAllByNonDeleted()
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllByNonDeletedAndActive()
        {
            throw new NotImplementedException();
        }

        public void Add(User user, string createdByName)
        {
            throw new NotImplementedException();
        }

        public void Update(User user, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public void Delete(int userID, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public void HardDelete(int userID)
        {
            throw new NotImplementedException();
        }

        public User GetByEmail(string email)
        {
            var queryScript = $"select * from Users where Email = '{email}'";
            var user = _adoNetDataReader.GetUserDataReader(queryScript);
            return user;
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            var queryScript = $"select * from Users where Email = '{email}' and [Password] = '{password}'";
            var user = _adoNetDataReader.GetUserDataReader(queryScript);
            return user;
        }
    }
}

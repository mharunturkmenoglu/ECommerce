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
            string queryScript = "select * from dbo.Users where IsDeleted = false and IsActive = true";
            var userList = _adoNetDataReader.GetUserListDataReader(queryScript);
            return userList;
        }

        public List<User> GetAllByNonDeletedAndActive()
        {
            string queryScript = "select * from Users where IsDeleted = false and IsActive = true";
            var userList = _adoNetDataReader.GetUserListDataReader(queryScript);
            return userList;
        }

        public void Add(User user, string createdByName)
        {
            var userAdd =
                _adoNetDataReader.GetUserDataReader($"select * from dbo.Users where Email = '{user.Email}'");

            if (userAdd.Email == null && userAdd.UserName == null)
            {
                string script = $"Insert Into Users(Description,IsDeleted,IsActive,CreatedDate,ModifiedDate,CreatedByName,ModifiedByName,Note,UserName,Email,Password)" +
                                $"Values('{user.Description}','{user.IsDeleted}','{user.IsActive}','{DateTime.Now}'," +
                                $"'{DateTime.Now}','{createdByName}','{createdByName}','{user.Note}','{user.UserName}','{user.Email}','{user.Password}')";
                _adoNetDataReader.ExecuteNonQuery(script);
            }
            else
            {
                throw new Exception("It s already created.");
            }
        }

        public void Update(User user, string modifiedByName)
        {
            var userUpdate =
                _adoNetDataReader.GetUserDataReader($"select * from dbo.Categories where Id = '{user.Email}'");

            if (userUpdate.Email != null)
            {
                string script = $"Update Users " +
                                $"Set Description='{user.Description}',IsDeleted='{user.IsDeleted}',IsActive='{user.IsActive}'," +
                                $"CreatedDate ='{user.CreatedDate}',ModifiedDate = '{DateTime.Now}',CreatedByName = '{user.CreatedByName}'," +
                                $"ModifiedByName = '{modifiedByName}',Note = '{user.Note}',UserName ='{user.UserName}',Email='{user.Email}',Password='{user.Password}'" +
                                $"where Id = '{user.Id}'";
                _adoNetDataReader.ExecuteNonQuery(script);
            }
            else
            {
                throw new Exception("The category has not been find.");
            }
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

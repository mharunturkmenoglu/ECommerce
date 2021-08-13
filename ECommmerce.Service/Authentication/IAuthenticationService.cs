using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using ECommerce.Entities.Concrete;
using ECommmerce.Service.Authentication;

namespace ECommerce.Service.Authentication

{
    public interface IAuthenticationService
    {
        public void Authenticate(User user);
        public User GetCurrentUser();
        public void SetLanguage(int id);
        public Languages GetLanguage();
    }
}
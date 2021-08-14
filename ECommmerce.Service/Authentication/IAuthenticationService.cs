using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using ECommerce.Entities.Concrete;
using ECommmerce.Entities.Dtos;
using ECommmerce.Service.Authentication;

namespace ECommerce.Service.Authentication

{
    public interface IAuthenticationService
    {
        public void Authenticate(User user);
        public void Logout();
        public UserCurrentDto GetCurrentUser();
        public void SetLanguage(int id);
        public Languages GetLanguage();
    }
}
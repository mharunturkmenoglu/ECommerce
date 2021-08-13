using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Entities.Concrete;
using ECommmerce.Service.Authentication;

namespace ECommerce.Service.Authentication
{
    public class AuthenticationManager : IAuthenticationService
    {
        private User user;
        public Languages CurrentLanguage { get; set; } = Languages.English;


        public AuthenticationManager(User user)
        {
            this.user = user;
        }
        public void Authenticate(User user)
        {
            this.user = user;
        }

        public User GetCurrentUser()
        {
            return user;
        }

        public void SetLanguage(int id)
        {
            this.CurrentLanguage = (Languages)Enum.ToObject(typeof(Languages), id);
        }

        public Languages GetLanguage()
        {
            return this.CurrentLanguage;
        }
    }
}

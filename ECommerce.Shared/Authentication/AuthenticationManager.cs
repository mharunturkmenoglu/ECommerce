using System;
using ECommerce.Entities.Concrete;
using ECommmerce.Entities.Dtos;
using ECommmerce.Shared.Authentication;

namespace ECommerce.Shared.Authentication
{
    public class AuthenticationManager : IAuthenticationService
    {
        private User user = null;
        private Languages currentLanguage = Languages.English;
        private bool signIn = false;

        public AuthenticationManager(User user)
        {
            this.user = user;
        }
        public void Authenticate(User user)
        {
            if (signIn == false)
            {
                this.user = user;
                this.signIn = true;
            }
            else
            {
                throw new Exception("The user is already authenticated.");
            }
        }

        public void Logout()
        {
            if (signIn)
            {
                signIn = false;
                user = null;
            }
            else
            {
                throw new Exception("The user is not authenticated.");
            }
        }

        public UserCurrentDto GetCurrentUser()
        {
            if (signIn)
            {
                return new UserCurrentDto
                {
                    Email = user.Email,
                    Id = user.Id,
                    Username = user.UserName
                };
            }
            else
            {
                throw new Exception("The user is not authenticated.");
            }
        }

        public void SetLanguage(int id)
        {
            this.currentLanguage = (Languages)Enum.ToObject(typeof(Languages), id);
        }

        public Languages GetLanguage()
        {
            return this.currentLanguage;
        }
    }
}

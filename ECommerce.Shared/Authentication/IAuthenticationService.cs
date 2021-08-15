using ECommerce.Entities.Concrete;
using ECommmerce.Entities.Dtos;
using ECommmerce.Shared.Authentication;

namespace ECommerce.Shared.Authentication
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
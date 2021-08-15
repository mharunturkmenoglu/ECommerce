using ECommerce.Entities.Abstract;

namespace ECommerce.Entities.Concrete
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

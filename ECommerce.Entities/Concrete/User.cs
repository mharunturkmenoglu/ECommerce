using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Entities.Abstract;

namespace ECommerce.Entities.Concrete
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
    }
}

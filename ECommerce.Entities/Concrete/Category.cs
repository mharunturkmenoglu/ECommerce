using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Entities.Abstract;

namespace ECommerce.Entities.Concrete
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

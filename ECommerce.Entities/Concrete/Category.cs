using System.Collections.Generic;
using ECommerce.Entities.Abstract;

namespace ECommerce.Entities.Concrete
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}

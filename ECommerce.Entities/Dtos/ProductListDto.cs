using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Entities.Concrete;

namespace ECommmerce.Entities.Dtos
{
    public class ProductListDto
    {
        public List<Product> Articles { get; set; }
    }
}

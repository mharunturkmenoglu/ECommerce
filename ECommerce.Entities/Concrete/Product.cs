using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Entities.Abstract;

namespace ECommerce.Entities.Concrete
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float Coast { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

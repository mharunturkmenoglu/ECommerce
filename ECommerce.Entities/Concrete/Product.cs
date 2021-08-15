using ECommerce.Entities.Abstract;

namespace ECommerce.Entities.Concrete
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Coast { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

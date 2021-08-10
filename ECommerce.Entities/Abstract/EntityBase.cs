using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Abstract
{
    public abstract class EntityBase
    {
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
        public virtual string CreatedByName { get; set; } = "admin";
        public virtual string ModifiedByName { get; set; } = "admin";
        public virtual string Note { get; set; }
    }
}

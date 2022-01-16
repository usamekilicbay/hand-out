using System.Collections.Generic;
using static Sidekick.NET.Types;

namespace EntityLayer.Concrete
{
    public class Category: BaseEntity
    {
        public string FontAwesomeIconName { get; set; }
        public CategoryStatus Status { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

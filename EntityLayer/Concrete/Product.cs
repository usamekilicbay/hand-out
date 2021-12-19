using System;
using static Sidekick.NET.Types;

namespace EntityLayer.Concrete
{
    public class Product : BaseEntity
    {
        public string Details { get; set; }
        public string Address { get; set; }
        public string PhotoURL { get; set; }
        public DateTime DatePublished { get; set; }
        public ProductStatus Status { get; set; }

        public int GrantorID { get; set; }
        public virtual User Grantor { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}

using System;
using static Sidekick.NET.Types;

namespace EntityLayer.Concrete
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime CreationDate { get; set; }
        public ProductStatus Status { get; set; }

        public int GrantorID { get; set; }
        public virtual User Grantor { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}

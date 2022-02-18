using System;
using System.Collections.Generic;
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

        public string GrantorId { get; set; }
        public virtual User Grantor { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
using System;
using System.Collections.Generic;
using static Sidekick.NET.Types;

namespace EntityLayer.Concrete
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public CategoryStatus Status { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

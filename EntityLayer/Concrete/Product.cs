using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }
        public short Status { get; set; }
        public User Grantor { get; set; }
        public Category Category { get; set; }
        public DateTime PublishDate { get; set; }
    }
}

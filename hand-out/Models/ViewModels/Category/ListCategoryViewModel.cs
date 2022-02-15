using System;
using System.Collections.Generic;
using static Sidekick.NET.Types;

namespace hand_out.Models.ViewModels.Category
{
    public class ListCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FontAwesomeIconName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public CategoryStatus Status { get; set; }

        public virtual ICollection<EntityLayer.Concrete.Product> Products { get; set; }
    }
}
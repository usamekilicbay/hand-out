using System;
using static Sidekick.NET.Types;

namespace DataLayer.Areas.Admin.Category
{
    public class UpdateCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FontAwesomeIconName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public CategoryStatus Status { get; set; }
    }
}
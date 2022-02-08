using System;
using static Sidekick.NET.Types;

namespace DataLayer.Areas.Admin.Category
{
    public class ListCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public CategoryStatus Status { get; set; }
    }
}
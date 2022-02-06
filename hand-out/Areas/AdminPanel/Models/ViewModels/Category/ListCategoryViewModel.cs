using System;
using System.ComponentModel.DataAnnotations;
using static Sidekick.NET.Types;

namespace hand_out.Areas.Admin.Models.ViewModels.Category
{
    public class ListCategoryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "Date Modified")]
        public DateTime DateModified { get; set; }
        public CategoryStatus Status { get; set; }
    }
}

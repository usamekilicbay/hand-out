using System;
using System.ComponentModel.DataAnnotations;
using static Sidekick.NET.Types;

namespace hand_out.Areas.Admin.Models.ViewModels.Product
{
    public class ListProductViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }
        [Display(Name = "Photo URL")]
        public string PhotoURL { get; set; }
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "Date Modified")]
        public DateTime DateModified { get; set; }
        [Display(Name = "Date Published")]
        public DateTime DatePublished { get; set; }
        public ProductStatus Status { get; set; }

        [Display(Name = "Grantor Name")]
        public string GrantorName { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }
}

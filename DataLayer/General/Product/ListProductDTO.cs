using System;
using System.ComponentModel.DataAnnotations;
using static Sidekick.NET.Types;

namespace DataLayer.Product
{
    public class ListProductDTO
    {
        public int Id { get; set; }
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
        public string GrantorUserName { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        public string CategoryFontAwesomeIconName { get; set; }
    }
}
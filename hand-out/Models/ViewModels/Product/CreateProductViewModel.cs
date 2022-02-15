using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hand_out.Models.ViewModels.Product
{
    public class CreateProductViewModel
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }
        public List<IFormFile> Photos { get; set; }
        [Display(Name = "Category Name")]
        public int CategoryId { get; set; }
    }
}
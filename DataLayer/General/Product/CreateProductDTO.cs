using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Product
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }
        public List<IFormFile> Photos { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}
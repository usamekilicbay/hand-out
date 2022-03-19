using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Sidekick.NET.Types;

namespace DataLayer.Product
{
    public class UpdateProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }
        public string PhotoURL { get; set; }
        public List<IFormFile> Photos { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public ProductStatus Status { get; set; }
    }
}
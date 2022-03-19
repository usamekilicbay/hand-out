using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static Sidekick.NET.Types;

namespace hand_out.Models.ViewModels.Product
{
    public class UpdateProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }
        public List<string> PhotoURLs { get; set; }
        public List<IFormFile> Photos { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public ProductStatus Status { get; set; }

        public UpdateProductViewModel(string photoURL)
        {
            PhotoURLs = photoURL.Split("|").ToList();
        }

        public UpdateProductViewModel()
        {

        }
    }
}
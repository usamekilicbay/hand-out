using System;
using System.Collections.Generic;
using System.Linq;

namespace hand_out.Models.ViewModels.Product
{
    public class DetailsProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }
        public string CategoryIcon { get; set; }
        public string CategoryName { get; set; }
        public string GrantorId { get; set; }
        public string GrantorUserName { get; set; }
        public string GrantorProfilePhotoURL { get; set; }
        public DateTime DatePublished { get; set; }
        public List<string> PhotoURLs { get; private set; }

        public DetailsProductViewModel(string photoLink)
        {
            PhotoURLs = photoLink.Split('|').ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace hand_out.Models.ViewModels.Product
{
    public class DetailsProductViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Details { get; set; }
        public string GrantorName { get; set; }
        public string CategoryName { get; set; }
        public string GrantorId { get; set; }
        public DateTime DatePublished { get; set; }
        public List<string> PhotoLinks { get; private set; }

        public DetailsProductViewModel(string photoLink)
        {
            PhotoLinks = photoLink.Split('|').ToList();
        }
    }
}

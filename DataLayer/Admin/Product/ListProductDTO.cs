using System;
using static Sidekick.NET.Types;

namespace DataLayer.Areas.Admin.Product
{
    public class ListProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }
        public string PhotoURL { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DatePublished { get; set; }
        public ProductStatus Status { get; set; }
        public string GrantorUserName { get; set; }
        public string CategoryName { get; set; }
        public string CategoryFontAwesomeIconName { get; set; }
    }
}
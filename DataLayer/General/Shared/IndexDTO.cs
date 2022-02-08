using DataLayer.Category;
using DataLayer.Product;
using System.Collections.Generic;

namespace DataLayer.Shared
{
    public class IndexDTO
    {
        public List<ListProductDTO> ListProductViewModel { get; private set; }
        public List<ListCategoryDTO> ListCategoryViewModel { get; private set; }

        public IndexDTO(List<ListProductDTO> listProductViewModels, List<ListCategoryDTO> listCategoryViewModels)
        {
            ListProductViewModel = listProductViewModels;
            ListCategoryViewModel = listCategoryViewModels;
        }
    }
}
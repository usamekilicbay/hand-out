using hand_out.Models.ViewModels.Category;
using hand_out.Models.ViewModels.Product;
using System.Collections.Generic;

namespace hand_out.Models.ViewModels.Shared
{
    public class IndexViewModel
    {
        public List<ListProductViewModel> ListProductViewModels { get; private set; }
        public List<ListCategoryViewModel> ListCategoryViewModels { get; private set; }

        public IndexViewModel(List<ListProductViewModel> listProductViewModels, List<ListCategoryViewModel> listCategoryViewModels)
        {
            ListProductViewModels = listProductViewModels;
            ListCategoryViewModels = listCategoryViewModels;
        }
    }
}
using hand_out.Models.ViewModels.Product;
using hand_out.Models.ViewModels.User;
using System.Collections.Generic;

namespace hand_out.Models.ViewModels.Shared
{
    public class ProfileViewModel
    {
        public DetailsUserViewModel DetailsUserViewModel { get; private set; }
        public IList<ListProductViewModel> ListProductViewModels { get; private set; }
        public CreateProductViewModel CreateProductViewModel { get; private set; }

        public ProfileViewModel(DetailsUserViewModel detailsUserViewModel, IList<ListProductViewModel> listProductViewModels)
        {
            DetailsUserViewModel = detailsUserViewModel;
            ListProductViewModels = listProductViewModels;
            CreateProductViewModel = new();
        }
    }
}
using hand_out.Models.ViewModels.Product;
using hand_out.Models.ViewModels.User;

namespace hand_out.Models.ViewModels.Shared
{
    public class ProfileViewModel
    {
        public DetailsUserViewModel DetailsUserViewModel { get; private set; }
        public CreateProductViewModel CreateProductViewModel { get; private set; }

        public ProfileViewModel(DetailsUserViewModel detailsUserViewModel, CreateProductViewModel createProductViewModel)
        {
            DetailsUserViewModel = detailsUserViewModel;
            CreateProductViewModel = createProductViewModel;
        }
    }
}
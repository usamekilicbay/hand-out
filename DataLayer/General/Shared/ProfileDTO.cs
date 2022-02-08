using DataLayer.User;
using DataLayer.Product;

namespace DataLayer.Shared
{
    public class ProfileDTO
    {
        public DetailsUserDTO DetailsUserViewModel { get; private set; }
        public CreateProductDTO CreateProductViewModel { get; private set; }

        public ProfileDTO(DetailsUserDTO detailsUserViewModel, CreateProductDTO createProductViewModel)
        {
            DetailsUserViewModel = detailsUserViewModel;
            CreateProductViewModel = createProductViewModel;
        }
    }
}
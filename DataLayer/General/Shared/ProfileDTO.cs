using DataLayer.User;
using DataLayer.Product;
using System.Collections.Generic;

namespace DataLayer.Shared
{
    public class ProfileDTO
    {
        public DetailsUserDTO DetailsUserDTO { get; private set; }
        public IList<ListProductDTO> ListProductDTOs { get; private set; }

        public ProfileDTO(DetailsUserDTO detailsUserDTO, IList<ListProductDTO> listProductDTOs)
        {
            DetailsUserDTO = detailsUserDTO;
            ListProductDTOs = listProductDTOs;
        }
    }
}
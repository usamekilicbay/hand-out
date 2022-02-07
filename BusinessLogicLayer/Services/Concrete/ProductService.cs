using AutoMapper;
using BusinessLogicLayer.Services.Abstract;
using DataAccessLayer;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.Repositories.Concrete;
using DataLayer.ViewModels.Product;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Constant = Sidekick.NET.Constant;

namespace BusinessLogicLayer.Services.Concrete
{
    public class ProductService : Service<Product>, IProductService
    {
        public IProductRepository ProductRepository { get; set; }

        public ProductService(ApplicationDbContext applicationDbContext,
            IMapper mapper, UnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            ProductRepository = new ProductRepository(applicationDbContext);
            Repository = ProductRepository;
        }

        public async Task InsertAsync(CreateProductViewModel productModel)
        {
            StringBuilder photoURLBuilder = new();

            List<string> uploadPaths = new();

            if (!Directory.Exists(Constant.Path.PRODUCT_IMAGES))
                Directory.CreateDirectory(Constant.Path.PRODUCT_IMAGES);

            foreach (IFormFile photo in productModel.Photos)
            {
                string fileName = new StringBuilder()
                    .Append(Path.GetFileNameWithoutExtension(photo.FileName))
                    .Append('-')
                    .Append(Guid.NewGuid().ToString().Replace("-", string.Empty))
                    .Append(Path.GetExtension(photo.FileName)).ToString();

                uploadPaths.Add(Path.Combine($"{Constant.Path.PRODUCT_IMAGES}", fileName));
                photoURLBuilder.Append($"{fileName}|");
            }

            Product product = mapper.Map<Product>(productModel);

            product.PhotoURL = photoURLBuilder.ToString();
            product.GrantorID = UnitOfWork.UserService.GetCurrentUserId();

            ProductRepository.Insert(product);

            for (int i = 0; i < productModel.Photos.Count; i++)
            {
                string path = uploadPaths[i];
                using (FileStream fileStream = new(path, FileMode.CreateNew))
                {
                    await productModel.Photos[i].CopyToAsync(fileStream);
                }
            }
        }
    }
}
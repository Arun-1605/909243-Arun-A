using ECart_DAL;
using System.Collections.Generic;

namespace ECart_BLL
{
    public class ProductService
    {
        private readonly ProductsRepository productsRepository;
        public ProductService()
        {
            productsRepository = new ProductsRepository();
        }
        public IEnumerable<ProductDto> GetProducts()
        {
            var Products = productsRepository.Get();
            var Dtos = new List<ProductDto>();
            foreach (var item in Products)
                Dtos.Add(new ProductDto
                {
                    Id = item.ProductId,
                    ImageURL = item.ImageURL,
                    Name = item.ProductName,
                    Price = item.ProductPrice
                });
            return Dtos;
        }
        public ProductDto GetProduct(int id)
        {
            var Product = productsRepository.Get(id);
            return new ProductDto
            {
                Id = Product.ProductId,
                Price = Product.ProductPrice,
                ImageURL = Product.ImageURL,
                Name = Product.ProductName
            };
        }
    }
}

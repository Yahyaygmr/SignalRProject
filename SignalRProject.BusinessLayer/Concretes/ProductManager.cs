using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SignalRProject.BusinessLayer.Abstracts;
using SignalRProject.DataAccessLayer.Abstracts.Interfaces;
using SignalRProject.DtoLayer.ProductDtos;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.BusinessLayer.Concretes
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public DbSet<Product> EntityTable => _productDal.EntityTable;

        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ResultProductWithCategoryDto> ListProductsWithCategory()
        {
            var values = _productDal.ListProductsWithCategory();
            var result = values.Select(x => new ResultProductWithCategoryDto
            {
                CategoryName = x.Category.Name,
                Description = x.Description,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Price = x.Price,
                ProductId = x.ProductId,
                Status = x.Status,
            }).ToList();

            return result;
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}

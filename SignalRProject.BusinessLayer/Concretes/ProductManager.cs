using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SignalRProject.BusinessLayer.Abstracts;
using SignalRProject.DataAccessLayer.Abstracts.Interfaces;
using SignalRProject.DataAccessLayer.EntityFramework;
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
            _productDal.Add(entity);
        }

        public void Delete(int id)
        {
            Product? product = _productDal.GetById(id);
            if (product != null)
            {
                _productDal.Delete(product);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
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
            _productDal.Update(entity);
        }
    }
}

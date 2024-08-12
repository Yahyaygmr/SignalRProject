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
        private readonly ICategoryDal _categoryDal;
        public ProductManager(IProductDal productDal, ICategoryDal categoryDal)
        {
            _productDal = productDal;
            _categoryDal = categoryDal;
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

        public decimal ProductAvgPrice()
        {
            return _productDal.EntityTable.Average(x => x.Price);
        }

        public int ProductCount()
        {
            return _productDal.EntityTable.Count();
        }

        public int ProductCountByDrink()
        {
            return _productDal.EntityTable.Where(x => x.CategoryId == (_categoryDal.EntityTable.Where(x => x.Name == "İçecek").Select(x => x.CategoryId).FirstOrDefault())).Count();
        }

        public int ProductCountByHamburger()
        {
            return _productDal.EntityTable.Where(x => x.CategoryId == (_categoryDal.EntityTable.Where(x => x.Name == "Hamburger").Select(x => x.CategoryId).FirstOrDefault())).Count();
        }

        public string ProductNameByMaxPrice()
        {
            return _productDal.EntityTable.Where(x => x.Price == (_productDal.EntityTable.Max(y => y.Price))).Select(y => y.Name).FirstOrDefault();
        }

        public string ProductNameByMinPrice()
        {
            return _productDal.EntityTable.Where(x => x.Price == (_productDal.EntityTable.Min(y => y.Price))).Select(y => y.Name).FirstOrDefault();
        }

        public decimal ProductPriceAvgByHamburger()
        {
            return _productDal.EntityTable.Where(x => x.CategoryId == (_categoryDal.EntityTable.Where(y => y.Name == "Hamburger").Select(z => z.CategoryId).FirstOrDefault())).Average(x => x.Price);
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}

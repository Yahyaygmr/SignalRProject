using Microsoft.EntityFrameworkCore;
using SignalRProject.BusinessLayer.Abstracts;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.BusinessLayer.Concretes
{
    public class ProductManager : IProductService
    {
        public DbSet<Product> EntityTable => throw new NotImplementedException();

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

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SignalRProject.BusinessLayer.Abstracts;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.BusinessLayer.Concretes
{
    public class DiscountManager : IDiscountService
    {
        public DbSet<Discount> EntityTable => throw new NotImplementedException();

        public void Add(Discount entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Discount> GetAll()
        {
            throw new NotImplementedException();
        }

        public Discount GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Discount entity)
        {
            throw new NotImplementedException();
        }
    }
}

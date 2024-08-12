using Microsoft.EntityFrameworkCore;
using SignalRProject.BusinessLayer.Abstracts;
using SignalRProject.DataAccessLayer.Abstracts.Interfaces;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.BusinessLayer.Concretes
{
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            this.discountDal = discountDal;
        }

        public DbSet<Discount> EntityTable => discountDal.EntityTable;

        public void Add(Discount entity)
        {
            discountDal.Add(entity);
        }

        public void Delete(int id)
        {
            Discount? discount = discountDal.GetById(id);
            if (discount != null)
            {
                discountDal.Delete(discount);
            }
        }

        public int DiscountCount()
        {
            return discountDal.EntityTable.Count();
        }

        public List<Discount> GetAll()
        {
            return discountDal.GetAll();
        }

        public Discount GetById(int id)
        {
            return discountDal.GetById(id);
        }

        public void Update(Discount entity)
        {
            discountDal.Update(entity);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SignalRProject.BusinessLayer.Abstracts;
using SignalRProject.DataAccessLayer.Abstracts.Interfaces;
using SignalRProject.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRProject.BusinessLayer.Concretes
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            this.basketDal = basketDal;
        }

        public DbSet<Basket> EntityTable => basketDal.EntityTable;

        public void Add(Basket entity)
        {
            basketDal.Add(entity);
        }

        public void Delete(int id)
        {
            Basket? basket = basketDal.GetById(id);
            if (basket != null)
            {
                basketDal.Delete(basket);
            }
        }

        public List<Basket> GetAll()
        {
            return basketDal.GetAll();
        }

        public List<Basket> GetBasketByMenuTableId(int menuTableId)
        {
            return basketDal.GetBasketByMenuTableId(menuTableId);
        }

        public Basket GetById(int id)
        {
            return basketDal.GetById(id);
        }

        public void Update(Basket entity)
        {
            basketDal.Update(entity);
        }
    }
}

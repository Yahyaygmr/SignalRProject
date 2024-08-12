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
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            this.orderDal = orderDal;
        }

        public DbSet<Order> EntityTable => orderDal.EntityTable;

        public int ActiveOrderCount()
        {
            return orderDal.EntityTable.Where(x => x.Description == "Müşteri Masada").Count();
        }

        public void Add(Order entity)
        {
            orderDal.Add(entity);
        }

        public void Delete(int id)
        {
            Order? order = orderDal.GetById(id);
            if (order != null)
            {
                orderDal.Delete(order);
            }
        }

        public List<Order> GetAll()
        {
            return orderDal.GetAll();
        }

        public Order GetById(int id)
        {
            return orderDal.GetById(id);
        }

        public decimal LastOrderPrice()
        {
            return orderDal.EntityTable.OrderByDescending(x => x.OrderId).Take(1).Select(y => y.TotalPrice).FirstOrDefault();
        }

        public int TotalOrderCount()
        {
            return orderDal.EntityTable.Count();
        }
        public void Update(Order entity)
        {
            orderDal.Update(entity);
        }
    }
}

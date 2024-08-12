using Microsoft.EntityFrameworkCore;
using SignalRProject.BusinessLayer.Abstracts;
using SignalRProject.DataAccessLayer.Abstracts.Interfaces;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.BusinessLayer.Concretes
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailDal orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            this.orderDetailDal = orderDetailDal;
        }

        public DbSet<OrderDetail> EntityTable => orderDetailDal.EntityTable;

        public void Add(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetail> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderDetail GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}

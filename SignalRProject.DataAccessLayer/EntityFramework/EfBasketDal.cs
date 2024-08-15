using Microsoft.EntityFrameworkCore;
using SignalRProject.DataAccessLayer.Abstracts.Interfaces;
using SignalRProject.DataAccessLayer.Concretes;
using SignalRProject.DataAccessLayer.Repositories;
using SignalRProject.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRProject.DataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        private readonly SignalRContext _context;
        public EfBasketDal(SignalRContext context) : base(context)
        {
            _context = context;
        }
        public List<Basket> GetBasketByMenuTableId(int menuTableId)
        {
            var values = _context.Baskets
                .Where(x => x.MenuTableId == menuTableId)
                .Include(x=>x.Product)
                //.Include(x=>x.Product.Category)
                .Include(x=>x.MenuTable)
                .ToList();
            return values;
        }
    }
}

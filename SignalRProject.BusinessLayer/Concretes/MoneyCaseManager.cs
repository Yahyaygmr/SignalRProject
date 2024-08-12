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
    public class MoneyCaseManager : IMoneyCaseService
    {
        private readonly IMoneyCaseDal moneyCaseDal;

        public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
        {
            this.moneyCaseDal = moneyCaseDal;
        }

        public DbSet<MoneyCase> EntityTable => moneyCaseDal.EntityTable;

        public void Add(MoneyCase entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<MoneyCase> GetAll()
        {
            throw new NotImplementedException();
        }

        public MoneyCase GetById(int id)
        {
            throw new NotImplementedException();
        }

        public decimal TotalMoneyCaseAmount()
        {
            return moneyCaseDal.EntityTable.Select(x => x.TotalAmount).FirstOrDefault();
        }

        public void Update(MoneyCase entity)
        {
            throw new NotImplementedException();
        }
    }
}

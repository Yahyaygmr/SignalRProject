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
    public class AboutManager(IAboutDal aboutDal) : IAboutService
    {
        private readonly IAboutDal _aboutDal = aboutDal;

        public DbSet<About> EntityTable => _aboutDal.EntityTable;

        public int AboutCount()
        {
            return _aboutDal.EntityTable.Count();
        }

        public void Add(About entity)
        {
            _aboutDal.Add(entity);
        }

        public void Delete(int id)
        {
            About? about = _aboutDal.GetById(id);
            if (about != null)
            {
                _aboutDal.Delete(about);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public List<About> GetAll()
        {
            return _aboutDal.GetAll();
        }

        public About GetById(int id)
        {
            return _aboutDal.GetById(id);
        }

        public void Update(About entity)
        {
            _aboutDal.Update(entity);
        }
    }
}

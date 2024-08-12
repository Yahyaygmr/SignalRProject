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
    public class MenuTableManager : IMenuTableService
    {
        private readonly IMenuTableDal menuTableDal;

        public MenuTableManager(IMenuTableDal menuTableDal)
        {
            this.menuTableDal = menuTableDal;
        }

        public DbSet<MenuTable> EntityTable => menuTableDal.EntityTable;

        public void Add(MenuTable entity)
        {
            menuTableDal.Add(entity);
        }

        public void Delete(int id)
        {
            MenuTable? menuTable = menuTableDal.GetById(id);
            if (menuTable != null)
            {
                menuTableDal.Delete(menuTable);
            }
        }

        public List<MenuTable> GetAll()
        {
            return menuTableDal.GetAll();
        }

        public MenuTable GetById(int id)
        {
            return menuTableDal.GetById(id);
        }

        public int MenuTableCount()
        {
            return menuTableDal.EntityTable.Count();
        }

        public void Update(MenuTable entity)
        {
            menuTableDal.Update(entity);
        }
    }
}

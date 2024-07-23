using Microsoft.EntityFrameworkCore;
using SignalRProject.DataAccessLayer.Abstracts;
using SignalRProject.DataAccessLayer.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRProject.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly SignalRContext _context;

        public GenericRepository(SignalRContext context)
        {
            _context = context;
        }

        public DbSet<T> EntityTable => _context.Set<T>();

        public void Add(T entity)
        {
            EntityTable.Add(entity);
        }

        public void Delete(T entity)
        {
            EntityTable.Remove(entity);
        }

        public List<T> GetAll()
        {
            return EntityTable.ToList();
        }

        public T GetById(int id)
        {
            return EntityTable.Find(id);
        }

        public void Update(T entity)
        {
            EntityTable.Update(entity);
        }
    }
}

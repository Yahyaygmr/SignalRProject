using Microsoft.EntityFrameworkCore;
using SignalRProject.BusinessLayer.Abstracts;
using SignalRProject.DataAccessLayer.Abstracts.Interfaces;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.BusinessLayer.Concretes
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public DbSet<Category> EntityTable => _categoryDal.EntityTable;

        public void Add(Category entity)
        {
            _categoryDal.Add(entity);
        }

        public void Delete(int id)
        {
            Category? category = _categoryDal.GetById(id);
            if (category != null)
            {
                _categoryDal.Delete(category);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public void Update(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SignalRProject.BusinessLayer.Abstracts;
using SignalRProject.DataAccessLayer.Abstracts.Interfaces;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.BusinessLayer.Concretes
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal contactDal;

        public ContactManager(IContactDal contactDal)
        {
            this.contactDal = contactDal;
        }

        public DbSet<Contact> EntityTable => contactDal.EntityTable;

        public void Add(Contact entity)
        {
            contactDal.Add(entity);
        }

        public int ContactCount()
        {
            return contactDal.EntityTable.Count();
        }

        public void Delete(int id)
        {
            Contact contact = contactDal.GetById(id);
            if (contact != null)
            {
                contactDal.Delete(contact);
            }
        }

        public List<Contact> GetAll()
        {
            return contactDal.GetAll();
        }

        public Contact GetById(int id)
        {
            return contactDal.GetById(id);
        }

        public void Update(Contact entity)
        {
            contactDal.Update(entity);
        }
    }
}

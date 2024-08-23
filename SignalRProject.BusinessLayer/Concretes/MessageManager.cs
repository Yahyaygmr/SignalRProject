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
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public DbSet<Message> EntityTable => _messageDal.EntityTable;

        public void Add(Message entity)
        {
            _messageDal.Add(entity);
        }

        public void Delete(int id)
        {
            Message? message = _messageDal.GetById(id);
            if (message != null)
            {
                _messageDal.Delete(message);
            }
        }

        public List<Message> GetAll()
        {
            return _messageDal.GetAll();
        }

        public Message GetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public void Update(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}

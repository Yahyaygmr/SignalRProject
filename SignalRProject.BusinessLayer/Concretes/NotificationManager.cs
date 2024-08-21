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
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public DbSet<Notification> EntityTable => _notificationDal.EntityTable;

        public void Add(Notification entity)
        {
            _notificationDal.Add(entity);
        }

        public void Delete(int id)
        {
            Notification? notification = _notificationDal.GetById(id);
            if (notification != null)
            {
                _notificationDal.Delete(notification);
            }
        }

        public List<Notification> GetAll()
        {
            return _notificationDal.GetAll();
        }

        public Notification GetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public List<Notification> GetNotificationsByStatus(bool status)
        {
            return _notificationDal.GetNotificationsByStatus(status);
        }

        public void NotificationChangeToFalse(int id)
        {
            _notificationDal.NotificationChangeToFalse(id);
        }

        public void NotificationChangeToTrue(int id)
        {
            _notificationDal.NotificationChangeToTrue(id);
        }

        public int NotificationCountByStatus(bool status)
        {
            return _notificationDal.NotificationCountByStatus(status);
        }

        public void Update(Notification entity)
        {
            _notificationDal.Update(entity);
        }
    }
}

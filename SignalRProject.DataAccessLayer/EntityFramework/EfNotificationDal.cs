﻿using SignalRProject.DataAccessLayer.Abstracts.Interfaces;
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
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        private readonly SignalRContext _context;
        public EfNotificationDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public List<Notification> GetNotificationsByStatus(bool status)
        {
            return _context.Notifications.Where(x => x.Status == status).ToList();
        }

        public void NotificationChangeToFalse(int id)
        {
            Notification? notification = _context.Notifications.Find(id);
            if (notification != null)
            {
                notification.Status = false;
                _context.SaveChanges();
            }
        }

        public void NotificationChangeToTrue(int id)
        {
            Notification? notification = _context.Notifications.Find(id);
            if (notification != null)
            {
                notification.Status = true;
                _context.SaveChanges();
            }
        }

        public int NotificationCountByStatus(bool status)
        {
            return _context.Notifications
                .Where(x => x.Status == status)
                .Count();
        }
    }
}

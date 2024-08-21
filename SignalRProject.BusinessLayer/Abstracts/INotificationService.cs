using SignalRProject.BusinessLayer.Abstracts.Generics;
using SignalRProject.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRProject.BusinessLayer.Abstracts
{
    public interface INotificationService : IGenericService<Notification>
    {
        int NotificationCountByStatus(bool status);
        List<Notification> GetNotificationsByStatus(bool status);
        void NotificationChangeToTrue(int id);
        void NotificationChangeToFalse(int id);
    }
}

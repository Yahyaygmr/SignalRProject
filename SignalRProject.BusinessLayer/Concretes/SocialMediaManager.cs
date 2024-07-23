using Microsoft.EntityFrameworkCore;
using SignalRProject.BusinessLayer.Abstracts;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.BusinessLayer.Concretes
{
    public class SocialMediaManager : ISocialMediaService
    {
        public DbSet<SocialMedia> EntityTable => throw new NotImplementedException();

        public void Add(SocialMedia entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(SocialMedia entity)
        {
            throw new NotImplementedException();
        }

        public List<SocialMedia> GetAll()
        {
            throw new NotImplementedException();
        }

        public SocialMedia GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(SocialMedia entity)
        {
            throw new NotImplementedException();
        }
    }
}

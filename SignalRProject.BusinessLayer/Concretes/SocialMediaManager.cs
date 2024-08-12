using Microsoft.EntityFrameworkCore;
using SignalRProject.BusinessLayer.Abstracts;
using SignalRProject.DataAccessLayer.Abstracts.Interfaces;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.BusinessLayer.Concretes
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            this.socialMediaDal = socialMediaDal;
        }

        public DbSet<SocialMedia> EntityTable => socialMediaDal.EntityTable;

        public void Add(SocialMedia entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
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

        public int SocialMediaCount()
        {
            return socialMediaDal.EntityTable.Count();
        }

        public void Update(SocialMedia entity)
        {
            throw new NotImplementedException();
        }
    }
}

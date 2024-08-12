using Microsoft.EntityFrameworkCore;
using SignalRProject.BusinessLayer.Abstracts;
using SignalRProject.DataAccessLayer.Abstracts.Interfaces;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.BusinessLayer.Concretes
{
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            this.featureDal = featureDal;
        }

        public DbSet<Feature> EntityTable => featureDal.EntityTable;

        public void Add(Feature entity)
        {
            featureDal.Add(entity);
        }

        public void Delete(int id)
        {
            Feature? feature = featureDal.GetById(id);
            if (feature != null)
            {
                featureDal.Delete(feature);
            }
        }

        public int FeatureCount()
        {
            return featureDal.EntityTable.Count();
        }

        public List<Feature> GetAll()
        {
            return featureDal.GetAll();
        }

        public Feature GetById(int id)
        {
            return featureDal.GetById(id);
        }

        public void Update(Feature entity)
        {
            featureDal.Update(entity);
        }
    }
}

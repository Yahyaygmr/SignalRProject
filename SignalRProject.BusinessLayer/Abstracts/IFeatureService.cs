﻿using SignalRProject.BusinessLayer.Abstracts.Generics;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.BusinessLayer.Abstracts
{
    public interface IFeatureService : IGenericService<Feature>
    {
        int FeatureCount();
    }
}

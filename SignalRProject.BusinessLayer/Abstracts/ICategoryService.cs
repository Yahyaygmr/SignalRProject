using SignalRProject.BusinessLayer.Abstracts.Generics;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.BusinessLayer.Abstracts
{
    public interface ICategoryService : IGenericService<Category>
    {
        int CategoryCount();
        int ActiveCategoryCount();
        int PassiveCategoryCount();
    }
}

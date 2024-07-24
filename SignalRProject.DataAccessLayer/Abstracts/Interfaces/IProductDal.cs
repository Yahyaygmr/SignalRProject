using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.DataAccessLayer.Abstracts.Interfaces
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> ListProductsWithCategory();
    }
}

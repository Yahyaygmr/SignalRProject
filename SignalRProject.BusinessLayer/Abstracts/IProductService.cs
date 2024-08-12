using SignalRProject.BusinessLayer.Abstracts.Generics;
using SignalRProject.DtoLayer.ProductDtos;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.BusinessLayer.Abstracts
{
    public interface IProductService : IGenericService<Product>
    {
        List<ResultProductWithCategoryDto> ListProductsWithCategory();
        int ProductCount();
        int ProductCountByHamburger();
        int ProductCountByDrink();
        decimal ProductAvgPrice();
        string ProductNameByMaxPrice();
        string ProductNameByMinPrice();
        decimal ProductPriceAvgByHamburger();
    }
}

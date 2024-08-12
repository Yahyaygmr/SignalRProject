using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRProject.BusinessLayer.Abstracts.Generics
{
    public interface IServiceManager
    {
        IAboutService aboutService { get; }
        IBookingService bookingService { get; }
        ICategoryService categoryService { get; }
        IContactService contactService { get; }
        IDiscountService discountService { get; }
        IFeatureService featureService { get; }
        IProductService productService { get; }
        ISocialMediaService socialMediaService { get; }
        ITestimonialService testimonialService { get; }
        IOrderService orderService { get; }
        IOrderDetailService orderDetailService { get; }
        IMoneyCaseService moneyCaseService { get; }
        IMenuTableService menuTableService { get; }
    }
}

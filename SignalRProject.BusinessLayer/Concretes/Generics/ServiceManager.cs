using SignalRProject.BusinessLayer.Abstracts;
using SignalRProject.BusinessLayer.Abstracts.Generics;
using SignalRProject.DataAccessLayer.Abstracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRProject.BusinessLayer.Concretes.Generics
{
    public class ServiceManager : IServiceManager
    {
        private readonly IAboutService _aboutService;
        private readonly IBookingService _bookingService;
        private readonly ICategoryService _categoryService;
        private readonly IContactService _contactService;
        private readonly IDiscountService _discountService;
        private readonly IFeatureService _featureService;
        private readonly IProductService _productService;
        private readonly ISocialMediaService _socialMediaService;
        private readonly ITestimonialService _testimonialService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBasketService _basketService;
        private readonly INotificationService _notificationService;

        public ServiceManager(IAboutService aboutService, IBookingService bookingService, ICategoryService categoryService, IContactService contactService, IDiscountService discountService, IFeatureService featureService, IProductService productService, ISocialMediaService socialMediaService, ITestimonialService testimonialService, IOrderService orderService, IOrderDetailService orderDetailService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBasketService basketService, INotificationService notificationService)
        {
            _aboutService = aboutService;
            _bookingService = bookingService;
            _categoryService = categoryService;
            _contactService = contactService;
            _discountService = discountService;
            _featureService = featureService;
            _productService = productService;
            _socialMediaService = socialMediaService;
            _testimonialService = testimonialService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _basketService = basketService;
            _notificationService = notificationService;
        }

        public IAboutService aboutService => _aboutService;

        public IBookingService bookingService => _bookingService;

        public ICategoryService categoryService => _categoryService;

        public IContactService contactService => _contactService;

        public IDiscountService discountService => _discountService;

        public IFeatureService featureService => _featureService;

        public IProductService productService => _productService;

        public ISocialMediaService socialMediaService => _socialMediaService;

        public ITestimonialService testimonialService => _testimonialService;

        public IOrderService orderService => _orderService;

        public IOrderDetailService orderDetailService => _orderDetailService;

        public IMoneyCaseService moneyCaseService => _moneyCaseService;

        public IMenuTableService menuTableService => _menuTableService;

        public IBasketService basketService => _basketService;

        public INotificationService notificationService => _notificationService;
    }
}

using Microsoft.AspNetCore.SignalR;
using SignalRProject.BusinessLayer.Abstracts;
using SignalRProject.BusinessLayer.Abstracts.Generics;

namespace SignalRProject.Api.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IServiceManager _serviceManager;

        public SignalRHub(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public async Task SendStatistics()
        {
            var value = _serviceManager.categoryService.EntityTable.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);

            var value2 = _serviceManager.productService.EntityTable.Count();
            await Clients.All.SendAsync("ReceiveProductCount", value2);

            var value3 = _serviceManager.categoryService.ActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);

            var value4 = _serviceManager.categoryService.PassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);

            var value5 = _serviceManager.productService.ProductCountByHamburger();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", value5);

            var value6 = _serviceManager.productService.ProductCountByDrink();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value6);

            var value7 = _serviceManager.productService.ProductAvgPrice();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", value7.ToString("0.00") + "₺");

            var value8 = _serviceManager.productService.ProductNameByMaxPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", value8);

            var value9 = _serviceManager.productService.ProductNameByMinPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMinPrice", value9);

            var value10 = _serviceManager.productService.ProductPriceAvgByHamburger();
            await Clients.All.SendAsync("ReceiveProductAvgPriceByHamburger", value10.ToString("0.00") + "₺");

            var value11 = _serviceManager.orderService.TotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value11);

            var value12 = _serviceManager.orderService.ActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value12);

            var value13 = _serviceManager.orderService.LastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", value13.ToString("0.00") + "₺");

            var value14 = _serviceManager.moneyCaseService.TotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value14.ToString("0.00") + "₺");

            var value16 = _serviceManager.menuTableService.MenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", value16);
        }

        public async Task SendProgress()
        {
            var value = _serviceManager.moneyCaseService.TotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value.ToString("0.00") + "₺");

            var value1 = _serviceManager.orderService.ActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value1);

            var value2 = _serviceManager.menuTableService.MenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", value2);
        }

        public async Task GetBookingList()
        {
            var values = _serviceManager.bookingService.GetAll();
            await Clients.All.SendAsync("RecieveBookingList", values);
        }

        public async Task SendNotification()
        {
            var value = _serviceManager.notificationService.NotificationCountByStatus(false);
            await Clients.All.SendAsync("RecieveNotificationCountByStatusFalse", value);

            var value1 = _serviceManager.notificationService.GetNotificationsByStatus(false);
            await Clients.All.SendAsync("RecieveNotificationListByStatusFalse", value1);
        }
        public async Task SendMenuTableList()
        {
            var value = _serviceManager.menuTableService.GetAll();
            await Clients.All.SendAsync("RecieveMenuTableList", value);
        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("RecieveMessage", user, message);
        }
    }
}

using Microsoft.AspNetCore.SignalR;
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
        public async Task SendCategoryCount()
        {
            var value = _serviceManager.categoryService.EntityTable.Count();
            await Clients.All.SendAsync("RecieveCategoryCount", value);
        }
    }
}

using SignalRProject.Api.Hubs;
using SignalRProject.Api.Mapping;
using SignalRProject.BusinessLayer.Abstracts;
using SignalRProject.BusinessLayer.Abstracts.Generics;
using SignalRProject.BusinessLayer.Concretes;
using SignalRProject.BusinessLayer.Concretes.Generics;
using SignalRProject.DataAccessLayer.Abstracts.Interfaces;
using SignalRProject.DataAccessLayer.Concretes;
using SignalRProject.DataAccessLayer.EntityFramework;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SignalRContext>();

builder.Services.AddScoped<IServiceManager, ServiceManager>();

builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();

builder.Services.AddScoped<IBookingDal, EfBookingDal>();
builder.Services.AddScoped<IBookingService, BookingManager>();

builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<IDiscountDal, EfDiscountDal>();
builder.Services.AddScoped<IDiscountService, DiscountManager>();

builder.Services.AddScoped<IFeatureDal, EfFeatureDal>();
builder.Services.AddScoped<IFeatureService, FeatureManager>();

builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<IProductService, ProductManager>();

builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();

builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();

builder.Services.AddScoped<IOrderDal, EfOrderDal>();
builder.Services.AddScoped<IOrderService, OrderManager>();

builder.Services.AddScoped<IOrderDetailDal, EfOrderDetailDal>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailManager>();

builder.Services.AddScoped<IMoneyCaseDal, EfMoneyCaseDal>();
builder.Services.AddScoped<IMoneyCaseService, MoneyCaseManager>();

builder.Services.AddScoped<IMenuTableDal, EfMenuTableDal>();
builder.Services.AddScoped<IMenuTableService, MenuTableManager>();

builder.Services.AddScoped<IBasketDal, EfBasketDal>();
builder.Services.AddScoped<IBasketService, BasketManager>();

builder.Services.AddScoped<INotificationDal, EfNotificationDal>();
builder.Services.AddScoped<INotificationService, NotificationManager>();

builder.Services.AddScoped<IMessageDal, EfMessageDal>();
builder.Services.AddScoped<IMessageService, MessageManager>();

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(opt => opt.AddPolicy("CorsPolicy", builder =>
{
    builder.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    .SetIsOriginAllowed((host) => true);

}));
builder.Services.AddSignalR();

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");

app.Run();

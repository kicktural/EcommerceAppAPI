using AutoMapper;
using Business.Abstract;
using Business.AutoMapper;
using Business.Concreate;
using Core.Utilities.EmailHelper;
using DataaAccess.Abstract;
using DataaAccess.Concreate.SQLServer;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolver
{
    public static class ServiceRegistration
    {
        public static void AddServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<AppDBContext>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDAL, EFUserDAL>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDAL, EFCategoryDAL>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDAL, EFProductDAL>();

            services.AddScoped<IEmailHelper, EmailHelper>();

            services.AddScoped<ISpecificationService, SpecificationManager>();
            services.AddScoped<ISpecificationDAL, EFSpecificationDAL>();

            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IOrderDAL, EFOrderDAL>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<MappingProfile>();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

using CicekSepetiStudyCase.Manager.Dtos;
using CicekSepetiStudyCase.Manager.Interfaces;
using CicekSepetiStudyCase.Manager.Services;
using CicekSepetiStudyCase.Manager.Validation;
using CicekSepetiStudyCase.Domain.Repositories;
using CicekSepetiStudyCase.Infrastructure.Database.MongoDB;
using CicekSepetiStudyCase.Infrastructure.Database.Redis;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CicekSepetiStudyCase.API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IBasketRepository, BasketRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBasketService, BasketService>();

            services.AddScoped<IECommerceContext, EcommerceContext>();

            services.AddTransient<IValidator<BasketDto>, BasketValidator>();
            services.AddTransient<IValidator<BasketItemDto>, BasketItemValidator>();


            return services;
        }
    }
}

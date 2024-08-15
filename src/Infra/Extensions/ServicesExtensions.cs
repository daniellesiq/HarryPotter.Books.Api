using Domain.Interfaces;
using Domain.Interfaces.Https;
using Domain.UseCases;
using Infra.Https;
using Infra.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Infra.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IGetBookService, GetBookService>();
            services.AddSingleton<IGetBooksUseCase, GetBooksUseCase>();
            return services;
        }

        public static IServiceCollection AddHttps(this IServiceCollection services, IConfiguration configuration)
        {
            var apiBaseUrl = configuration.GetValue<string>("PotterApi:BaseAddress")!;

            services
                .AddRefitClient<IGetBooksHttps>()
                 .ConfigureHttpClient(c => c.BaseAddress = new Uri(apiBaseUrl));
            return services;
        }
    }
}

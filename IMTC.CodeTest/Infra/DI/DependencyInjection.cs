using IMTC.CodeTest.Application.Services;
using IMTC.CodeTest.Domain.Interfaces.ApplicationServices;
using IMTC.CodeTest.Domain.Interfaces.InfraServices;
using IMTC.CodeTest.Infra.Services;

namespace IMTC.CodeTest.Infra.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IImtcCalculator, ImtcCalculator>();
            services.AddScoped<IIndexProvider, IndexProvider>();
            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IYtwCalculatorService, YtwCalculatorService>();
            return services;
        }
    }
}

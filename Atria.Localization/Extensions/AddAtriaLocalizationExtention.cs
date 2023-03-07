using Microsoft.Extensions.DependencyInjection;

namespace Atria.Localization.Extensions
{
    public static class AddAtriaLocalizationExtention
    {
        public static IServiceCollection AddAtriaLocalization(this IServiceCollection services)
        {
            services.AddSingleton<AtriaLocalization>();
            return services;
        }
    }   
}

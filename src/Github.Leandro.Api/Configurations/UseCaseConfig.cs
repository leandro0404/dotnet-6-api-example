using Github.Leandro.Borders.UseCases;
using Github.Leandro.UseCases;

namespace Github.Leandro.Api.Configurations
{
     public static class UseCaseConfig
    {
        public static void ConfigureUseCase(this IServiceCollection services)
        {
            services.AddScoped<IGetHealthCheckUseCase,GetHealthCheckUseCase>();
            
        }

    }

}
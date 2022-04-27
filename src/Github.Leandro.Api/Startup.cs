using Github.Leandro.Api.Configurations;

namespace Github.Leandro.Api
{
 
   public  interface IStartup
   {
        IConfiguration Configuration {get;}
        void ConfigureServices(IServiceCollection services);
        void Configure(WebApplication app, IWebHostEnvironment env );
   }
    public class Startup : IStartup
    {
        public Startup(IConfiguration configuration)
        {
        Configuration = configuration;
        }

        public IConfiguration Configuration {get;}

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.ConfigureUseCase();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env )
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
            app.UseSwagger();
            app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

        
        }
    }

    public static class StartupExtensions
    {
        public static  WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder webApplicationBuilder )  where  TStartup :IStartup  {

            var startup = Activator.CreateInstance(typeof(TStartup),webApplicationBuilder.Configuration) as IStartup;
            if(startup is null) throw new ArgumentException("invalid startup class");
            startup.ConfigureServices(webApplicationBuilder.Services);
            var app = webApplicationBuilder.Build();
            startup.Configure(app,app.Environment);
            app.Run();

            return webApplicationBuilder;
        }
    }
}
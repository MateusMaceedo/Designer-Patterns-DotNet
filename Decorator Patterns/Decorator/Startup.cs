using Decorator.Domain.Extensions;
using Decorator.Infra.Stores.Caching.Redis;
using Decorator.Stores;
using Decorator.Stores.Caching;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Decorator
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMemoryCache();
            services.AddSwagger();
            RegisterServices(services);
            EnableDecorator(services);
            RedisConnector(services);
        }

        private void RedisConnector(IServiceCollection services)
        {
            services.AddSingleton<RedisConnection>();
        }

        private void EnableDecorator(IServiceCollection services)
        {
            services.Decorate<ICarStore, CarCachingStore>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICarStore, CarStore>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwaggerUI();

            app.UseSwagger();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

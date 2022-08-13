using Amazon.DynamoDBv2;
using Decorator.Application.Interfaces;
using Decorator.Application.UseCases;
using Decorator.Domain.Extensions;
using Decorator.Domain.Interfaces.Context;
using Decorator.Infra.Extensions;
using Decorator.Infra.Stores.Caching.Redis;
using Decorator.Infra.Stores.V2;
using Decorator.Repository.Context;
using Decorator.Stores;
using Decorator.Stores.Caching;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

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
            //services.AddSwagger();
            RegisterServices(services);
            EnableDecorator(services);
            RedisConnector(services);
            // GitHub do ASP.NET API Versioning:
            // https://github.com/microsoft/aspnet-api-versioning

            // GitHub do projeto que utilizei como base para a
            // a implementação desta aplicação:
            // https://github.com/microsoft/aspnet-api-versioning/tree/master/samples/aspnetcore/SwaggerSample

            // Algumas referências sobre ASP.NET API Versioning:
            // https://devblogs.microsoft.com/aspnet/open-source-http-api-packages-and-tools/
            // https://www.hanselman.com/blog/aspnet-core-restful-web-api-versioning-made-easy

            services.AddApiVersioning(options =>
            {
                // Retorna os headers "api-supported-versions" e "api-deprecated-versions"
                // indicando versões suportadas pela API e o que está como deprecated
                options.ReportApiVersions = true;

                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 1);
            });

            services.AddVersionedApiExplorer(options =>
            {
                // Agrupar por número de versão
                // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                // note: the specified format code will format the version as "'v'major[.minor][-status]"
                options.GroupNameFormat = "'v'VVV";

                // Necessário para o correto funcionamento das rotas
                // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                // can also be used to control the format of the API version in route templates
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddSwaggerGen(options =>
            {
                // add a custom operation filter which sets default values
                options.OperationFilter<SwaggerDefaultValues>();
            });

            services.AddScoped<IRealizarBuscaPorCarsPorIdUseCase, RealizarBuscaPorCarsPorIdUseCase>();
            services.AddScoped<IRealizarBuscarPorCarsUseCase, RealizarBuscarPorCarsUseCase>();

            //var client = Configuration.GetAWSOptions().CreateServiceClient<IAmazonDynamoDB>();
            //services.AddScoped<IDynamoDbContext<AwesomeClass>>(provider => new DynamoDbContext<AwesomeClass>(client));
        }

        private void RedisConnector(IServiceCollection services)
        {
            services.AddSingleton<RedisConnection>();
        }

        private void EnableDecorator(IServiceCollection services)
        {
            services.Decorate<ICarStoreV1, CarCachingStore>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICarStoreV1, CarStoreV1>();
            services.AddScoped<ICarStoreV2, CarStoreV2>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                // Geração de um endpoint do Swagger para cada versão descoberta
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                }
            });

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

using Coterie.Api.Middleware;
using Coterie.Db;
using Coterie.Services.Businesses;
using Coterie.Services.Quotes;
using Coterie.Services.States;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Coterie.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            MigrateDatabase();
        }

        public IConfiguration Configuration { get; }

        private void MigrateDatabase()
        {
            using var dbContext = CoterieDbContext.CreateSqliteContext(
                Configuration.GetConnectionString("LocalDB")
            );
            dbContext.Database.Migrate();
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Coterie.Api", Version = "v1"});
            });

            services.AddDbContextPool<CoterieDbContext>(
                builder => CoterieDbContext.ConfigureSqlite(
                    Configuration.GetConnectionString("LocalDB"),
                    builder
                )
            );
            services.AddScoped<IBusinessService, BusinessService>();
            services.AddScoped<IQuoteService, QuoteService>();
            services.AddScoped<IStateService, StateService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(appBuilder => appBuilder.UseMiddleware<ErrorHandlerMiddleware>());
            
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Coterie.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Yorenizden.API.Controllers.Config;
using Yorenizden.API.Domain.Repositories;
using Yorenizden.API.Domain.Services;
using Yorenizden.API.Extensions;
using Yorenizden.API.Persistence.Contexts;
using Yorenizden.API.Persistence.Repositories;
using Yorenizden.API.Services;

namespace Yorenizden.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();

            services.AddCustomSwagger();

            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                // Adds a custom error response factory when ModelState is invalid
                options.InvalidModelStateResponseFactory = InvalidModelStateResponseFactory.ProduceErrorResponse;
            });

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase(Configuration.GetConnectionString("memory"));
            });

            services.AddScoped<IKategoriRepository, KategoriRepository>();
            services.AddScoped<IÜrünRepository, ÜrünRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IKategoriService, KategoriService>();
            services.AddScoped<IÜrünlerervice, Ürünlerervice>();

            services.AddAutoMapper(typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomSwagger();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
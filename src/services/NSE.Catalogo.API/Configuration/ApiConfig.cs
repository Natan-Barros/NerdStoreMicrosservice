using Microsoft.EntityFrameworkCore;
using NSE.Catalogo.API.Data;
using NSE.WebAPI.Core.Identidade;

namespace NSE.Catalogo.API.Configuration
{
    public static class ApiConfig
    {
        public static void AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CatalogoContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("Total",
                builder =>
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

            services.RegisterServices();
            services.AddSwaggerConfiguration();
        }

        public static void UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Total");

            app.UseIdentityConfiguration();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}

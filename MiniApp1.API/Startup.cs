using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MiniApp1.Core.Repositories;
using MiniApp1.Core.Services;
using MiniApp1.Core.UnitOfWork;
using MiniApp1.Data;
using MiniApp1.Data.Repositories;
using MiniApp1.Service.Services;
using SharedLibrary.Configurations;
using SharedLibrary.Extensions;

namespace MiniApp1.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.Configure<CustomTokenOption>(Configuration.GetSection("TokenOption"));
            var tokenOptions = Configuration.GetSection("TokenOption").Get<CustomTokenOption>();
            services.AddCustomTokenAuth(tokenOptions);

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("SqlServer"), options =>
                {
                    options.MigrationsAssembly("MiniApp1.Data");
                });
            });




            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MiniApp1.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MiniApp1.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

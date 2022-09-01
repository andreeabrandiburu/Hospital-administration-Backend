using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProiectFinal.Repositories;
using ProiectFinal.Services;
using WebProject;
using WebProject.Entities;

namespace ProiectFinal
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

            services.AddControllers();
            services.AddDbContext<ProiectFinalWebContext>(options =>options.UseSqlServer(Configuration.GetConnectionString("WebProjectConnString")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProiectFinal", Version = "v1" });
            });

            services.AddCors();


            services.AddTransient<IAddressRepository, AddressRepository>();

            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<IPacientRepository, PacientRepository>();

            services.AddTransient<IAddressService, AddressService>();

            services.AddTransient<IDoctorService, DoctorService>();

            services.AddTransient<IPacientService, PacientService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProiectFinal v1"));

                app.UseHttpsRedirection();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}

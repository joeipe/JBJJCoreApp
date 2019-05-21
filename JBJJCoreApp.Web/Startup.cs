using DayAtDojo.Data;
using DayAtDojo.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Schedule.Data;
using Schedule.Data.Services;
using Student.Data;
using Student.Data.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace JBJJCoreApp.Web
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
            {//dependency injection
                services.AddDbContext<ScheduleContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("JBJJCoreDBConnectionString"))
                );
                services.AddScoped<ScheduleUow>();
                services.AddScoped<ScheduleData>();

                services.AddDbContext<StudentContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("JBJJCoreDBConnectionString"))
                );
                services.AddScoped<StudentUow>();
                services.AddScoped<StudentData>();

                services.AddDbContext<DayAtDojoContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("JBJJCoreDBConnectionString"))
                );
                services.AddDbContext<ReferenceScheduleContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("JBJJCoreDBConnectionString"))
                );
                services.AddDbContext<ReferenceStudentContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("JBJJCoreDBConnectionString"))
                );
                services.AddScoped<DayAtDojoUow>();
                services.AddScoped<DayAtDojoData>();
            }

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "JBJJCoreApp API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "JBJJCoreApp API V1");
            });
        }
    }
}
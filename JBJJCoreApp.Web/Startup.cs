using DayAtDojo.Data;
using DayAtDojo.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Schedule.Data;
using Schedule.Data.Services;
using Student.Data;
using Student.Data.Services;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Text;
using User.Data;
using User.Domain;

namespace JBJJCoreApp.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private readonly string _corsPolicy = "CorsPolicy";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            {//dependency injection
                services.AddDbContext<UserContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("JBJJCoreDBConnectionString"))
                );
                services.AddTransient<UserSeeder>();

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

            services.AddCors(options =>
            {
                options.AddPolicy(_corsPolicy,
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            {
                services.AddIdentity<JBJJUser, IdentityRole>(cfg =>
                {
                    cfg.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<UserContext>();

                services.AddAuthentication()
                    .AddCookie()
                    .AddJwtBearer(cfg => {
                        cfg.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidIssuer = Configuration["Tokens:Issuer"],
                            ValidAudience = Configuration["Tokens:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                        };
                    });
            }

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "JBJJCoreApp API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = "header",
                    Name = "Authorization",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] { } }
                });
                //c.OperationFilter<SecurityRequirementsOperationFilter>();
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

            app.UseCors(_corsPolicy);

            app.UseAuthentication();

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
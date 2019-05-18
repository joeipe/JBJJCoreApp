﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DayAtDojo.Data;
using DayAtDojo.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Schedule.Data;
using Schedule.Data.Services;
using Student.Data;
using Student.Data.Services;

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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
        }
    }
}
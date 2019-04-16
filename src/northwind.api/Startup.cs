﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Api.Services;
using Northwind.Core.Interfaces;
using Northwind.Infrastructure.Data;

namespace Northwind.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<NorthwindContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("NorthwindContext");
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IDbContextResolver, DbContextResolver<NorthwindContext>>();
            services.AddScoped(typeof(IEntityRepository<>), typeof(DefaultEntityRepository<>));
            services.AddScoped(typeof(IEntityRepository<,>), typeof(DefaultEntityRepository<,>));

            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddTransient<IProductViewModelService, ProductViewModelService>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

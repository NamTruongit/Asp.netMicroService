using Baskets.API.GrpcSerives;
using Baskets.API.Repositories;
using Discount.GRPC.Protos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Baskets.API
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
            services.AddStackExchangeRedisCache(option =>
            {
                option.Configuration = Configuration.GetValue<string>("CacheSetting:ConnectionString");
            });
            services.AddControllersWithViews();
            services.AddSwaggerGen();

            services.AddGrpcClient<DiscountProtoSerivces.DiscountProtoSerivcesClient>(o => o.Address = new Uri(Configuration["GrpcSettings:Discount"]));
            services.AddScoped<DiscountGrpcServices>();
            services.AddScoped<IBasketsRepository, BasketRepositoty>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.API V1"));
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

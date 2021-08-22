using DTO.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(env.ContentRootPath)
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
             .AddJsonFile($"appsettings.Development.json", optional: true, reloadOnChange: true)
             .AddEnvironmentVariables();

            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "AuctionAPI", Version = "v1" });
            });

            DAL.Helper.DBConnection.GetConnectionString(Configuration);

            services.AddDbContextPool<DAL.Helper.AppDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

            services.AddScoped<BLL.Interfaces.IItem, BLL.Item>();
            services.AddScoped<DAL.Interfaces.IItem, DAL.Item>();
            services.AddTransient<BLL.Interfaces.IItemBidding, BLL.ItemBidding>();
            services.AddTransient<DAL.Interfaces.IItemBidding, DAL.ItemBidding>();
            services.AddScoped<BLL.Interfaces.IItemBiddingHistory, BLL.ItemBiddingHistory>();
            services.AddScoped<DAL.Interfaces.IItemBiddingHistory, DAL.ItemBiddingHistory>();
            services.AddScoped<BLL.Interfaces.IAutoBiddingAmount, BLL.AutoBiddingAmount>();
            services.AddScoped<DAL.Interfaces.IAutoBiddingAmount, DAL.AutoBiddingAmount>();
            services.AddTransient<DAL.Interfaces.IAutoBiddingBot, DAL.AutoBiddingBot>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
                options.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()

            );
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    c.SwaggerEndpoint("../swagger/v1/swagger.json", "AuctionAPI")
                );
            }
            Constant.BasePath = Path.Combine(env.ContentRootPath, "Images");
            app.UseRouting();

            app.UseAuthorization();
            app.UseDeveloperExceptionPage();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

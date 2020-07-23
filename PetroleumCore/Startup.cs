using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Repository;
using ServiceExt;

namespace PetroleumCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static IContainer AutofacContainer;
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<PetroleumDbContext>(option =>
            {
                option.UseSqlServer(Appsettings.GetSectionValue("ConnectionString:Entities"));
            });
            #region 配置跨域
            services.AddCors(options => options.AddPolicy("cors", bulider =>
                    bulider.WithOrigins(Appsettings.GetSectionValue("AppSettings:CorsIPs").Split(','))
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
             ));
            #endregion
            ////Senparc.CO2NET 全局注册（必须）
            //services.AddSenparcGlobalServices(Configuration);
        }




        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            #region 使用跨域
            app.UseCors("Cors");
            #endregion

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //扫描并注册服务
            builder.RegisterTypes(Assembly.Load("Repository").GetExportedTypes()).AsImplementedInterfaces();
            builder.RegisterTypes(Assembly.Load("PetroleumService").GetExportedTypes()).AsImplementedInterfaces();
            //builder.RegisterType<ISession>();

            //builder.RegisterDynamicProxy();
            //// 手动高亮
            builder.RegisterBuildCallback(container => AutofacContainer = (IContainer)container);

        }
    }
}

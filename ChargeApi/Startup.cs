using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ChargeApi.DbServer;
using ChargeApi.IService;
using ChargeApi.Models;
using ChargeApi.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NLog.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace ChargeApi
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
            services.AddCors(o =>
           o.AddPolicy("CorsPolicy",
              builder => builder
            .AllowAnyHeader()
            .AllowAnyMethod()
             //.SetIsOriginAllowed(_ => true)
             //.AllowCredentials()
             ));
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "V1"
                });
            });


            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                //options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = false,//是否验证Issuer
                    ValidateAudience = false,//是否验证Audience
                    ValidateLifetime = true,//是否验证失效时间
                    ValidateIssuerSigningKey = true,//是否验证SecurityKey
                   // ValidAudience = "AESCR",//Audience
                   // ValidIssuer = "AESCR",//Issuer，这两项和后面签发jwt的设置一致
                    ClockSkew = TimeSpan.Zero, // // 默认允许 300s  的时间偏移量，设置为0
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890123456"))
                };
            });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy(JwtBearerDefaults.AuthenticationScheme, policy =>
            //    {
            //        policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
            //        policy.RequireClaim(ClaimTypes.Name);
            //    });
            //});
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters =
            //            new TokenValidationParameters
            //            {
            //                ValidateAudience = true, //验证受众
            //              ValidateIssuer = true, //验证签发人
            //              ValidateActor = true, //验证签名
            //              ValidateLifetime = true, //是否在令牌生存期间验证
            //              ValidIssuer = "ExampleServer", //令牌发行者
            //              ValidAudience = "ExampleClients" //令牌受众
            //              //IssuerSigningKey = SecurityKey, //密钥

            //          };

            //    });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IConstantService, ConstantService>();
            services.AddScoped<IQueryService, QueryService>();
            services.AddScoped<IChargeService, ChargeService>();
            services.AddScoped<IRBACService, RBACService>();
            services.AddScoped<IMenuService, MenuService>();

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettingModel>(appSettingsSection);
            AppHelper.AppSetting = appSettingsSection.Get<AppSettingModel>();

            services.AddControllers();
            services.AddDbContext<ChargeContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                //option.UseMySql("Server=localhost;Database=test;User=root;Password=123456;");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/V1/swagger.json", "V1");
            });

            //  app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

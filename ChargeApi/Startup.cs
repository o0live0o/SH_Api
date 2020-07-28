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
                    ValidateIssuer = false,//�Ƿ���֤Issuer
                    ValidateAudience = false,//�Ƿ���֤Audience
                    ValidateLifetime = true,//�Ƿ���֤ʧЧʱ��
                    ValidateIssuerSigningKey = true,//�Ƿ���֤SecurityKey
                   // ValidAudience = "AESCR",//Audience
                   // ValidIssuer = "AESCR",//Issuer��������ͺ���ǩ��jwt������һ��
                    ClockSkew = TimeSpan.Zero, // // Ĭ������ 300s  ��ʱ��ƫ����������Ϊ0
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
            //                ValidateAudience = true, //��֤����
            //              ValidateIssuer = true, //��֤ǩ����
            //              ValidateActor = true, //��֤ǩ��
            //              ValidateLifetime = true, //�Ƿ������������ڼ���֤
            //              ValidIssuer = "ExampleServer", //���Ʒ�����
            //              ValidAudience = "ExampleClients" //��������
            //              //IssuerSigningKey = SecurityKey, //��Կ

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

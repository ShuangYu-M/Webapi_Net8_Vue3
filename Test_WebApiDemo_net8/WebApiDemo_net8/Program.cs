
using Microsoft.OpenApi.Models;
using WebApiDemo_net8.WebCore;
using WebApiDemo_net8.WebCore.SwaggerExt;

namespace WebApiDemo_net8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            //Cors：中间件
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("allcors", p =>
                {
                    p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });

            builder.Services.AddSwaggerExt();

            //log4net
            //nuget:log4net
            //Microsoft.Extensions.Logging.Log4Net.AspNetCore
            builder.Logging.AddLog4Net("ConfigFile/log4net.Config");


            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen(option =>
            //{
            //    #region 注释展示
            //    {
            //        //获取应用程序所在目录（绝对路径，不受工作目录影响，建议采用此方法获取路径）
            //        string basePath = AppContext.BaseDirectory;
            //        string xmlPath = Path.Combine(basePath, "WebApiDemo_net8.xml");
            //        option.IncludeXmlComments(xmlPath);
            //    }
            //    #endregion

            //    #region 支持Swagger版本控制
            //    foreach (var field in typeof(ApiVersionInfo).GetFields())
            //    {
            //        option.SwaggerDoc(field.Name, new OpenApiInfo()
            //        {
            //            Title = $"{field.Name}:这里是朝夕Core WebApi",
            //            Version = field.Name,
            //            Description = $"coreWebApi {field.Name} 版本"
            //        });
            //    }
            //    #endregion

            //    #region 支持token传值
            //    {
            //        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            //        {
            //            Description = "请输入token，格式为 Bearer xxxxxx （注意中间必须有空格）",
            //            Name = "Authorization",
            //            In = ParameterLocation.Header,
            //            Type = SecuritySchemeType.ApiKey,
            //            BearerFormat = "JWT",
            //            Scheme = "Bearer"

            //        });

            //        //添加安全要求
            //        option.AddSecurityRequirement(new OpenApiSecurityRequirement
            //        {
            //            {
            //                new OpenApiSecurityScheme
            //                {
            //                    Reference=new OpenApiReference()
            //                    {
            //                        Type=ReferenceType.SecurityScheme,
            //                        Id="Bearer"
            //                    }
            //                },
            //                new string[]{}
            //            }
            //        });
            //    }

            //    #endregion


            //});

            var app = builder.Build();


            //Cors：中间件
            app.UseCors("allcors");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UserSwaggerExt();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

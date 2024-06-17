
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

            //Cors���м��
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
            //    #region ע��չʾ
            //    {
            //        //��ȡӦ�ó�������Ŀ¼������·�������ܹ���Ŀ¼Ӱ�죬������ô˷�����ȡ·����
            //        string basePath = AppContext.BaseDirectory;
            //        string xmlPath = Path.Combine(basePath, "WebApiDemo_net8.xml");
            //        option.IncludeXmlComments(xmlPath);
            //    }
            //    #endregion

            //    #region ֧��Swagger�汾����
            //    foreach (var field in typeof(ApiVersionInfo).GetFields())
            //    {
            //        option.SwaggerDoc(field.Name, new OpenApiInfo()
            //        {
            //            Title = $"{field.Name}:�����ǳ�ϦCore WebApi",
            //            Version = field.Name,
            //            Description = $"coreWebApi {field.Name} �汾"
            //        });
            //    }
            //    #endregion

            //    #region ֧��token��ֵ
            //    {
            //        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            //        {
            //            Description = "������token����ʽΪ Bearer xxxxxx ��ע���м�����пո�",
            //            Name = "Authorization",
            //            In = ParameterLocation.Header,
            //            Type = SecuritySchemeType.ApiKey,
            //            BearerFormat = "JWT",
            //            Scheme = "Bearer"

            //        });

            //        //��Ӱ�ȫҪ��
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


            //Cors���м��
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

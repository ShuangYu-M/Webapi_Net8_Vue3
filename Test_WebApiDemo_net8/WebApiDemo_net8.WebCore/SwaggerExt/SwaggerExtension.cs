﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDemo_net8.WebCore.SwaggerExt
{
    public static class SwaggerExtension
    {
        public static void AddSwaggerExt(this IServiceCollection service)
        {
            service.AddEndpointsApiExplorer();
            service.AddSwaggerGen(option =>
            {
                #region 注释展示
                {
                    //获取应用程序所在目录（绝对路径，不受工作目录影响，建议采用此方法获取路径）
                    string basePath = AppContext.BaseDirectory;
                    string xmlPath = Path.Combine(basePath, "WebApiDemo_net8.xml");
                    option.IncludeXmlComments(xmlPath);
                }
                #endregion

                #region 支持Swagger版本控制
                foreach (var field in typeof(ApiVersionInfo).GetFields())
                {
                    option.SwaggerDoc(field.Name, new OpenApiInfo()
                    {
                        Title = $"{field.Name}:这里是朝夕Core WebApi",
                        Version = field.Name,
                        Description = $"coreWebApi {field.Name} 版本"
                    });
                }
                #endregion

                #region 支持token传值
                {
                    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                    {
                        Description = "请输入token，格式为 Bearer xxxxxx （注意中间必须有空格）",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        BearerFormat = "JWT",
                        Scheme = "Bearer"

                    });

                    //添加安全要求
                    option.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference=new OpenApiReference()
                                {
                                    Type=ReferenceType.SecurityScheme,
                                    Id="Bearer"
                                }
                            },
                            new string[]{}
                        }
                    });
                }

                #endregion


            });
        }


        public static void UserSwaggerExt(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var field in typeof(ApiVersionInfo).GetFields())
                {
                    options.SwaggerEndpoint($"/swagger/{field.Name}/swagger.json", $"{field.Name}");
                }
            });
        }

    }
}

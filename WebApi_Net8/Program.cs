
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using webApi_Net8.Helper;

namespace webApi_Net8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //注册数据库上下文
            //builder.Services.AddDbContext<SqlHelper>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            //解决跨域的问题
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("allcors", corsBuilder =>
                {
                    corsBuilder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                });
            });

            builder.Services.AddSwaggerGen(option =>
            {
                #region 支持Swagger版本控制
                foreach (var field in typeof(ApiVersions).GetFields())
                {
                    option.SwaggerDoc(field.Name, new OpenApiInfo()
                    {
                        Title = $"{field.Name}:版本控制！！",
                        Version = field.Name,
                        Description = $"coreWebApi {field.Name} 版本"
                    });
                }
                #endregion
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //Swagger版本控制
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    foreach (var field in typeof(ApiVersions).GetFields())
                    {
                        options.SwaggerEndpoint($"/swagger/{field.Name}/swagger.json", $"{field.Name}");
                    }
                });
            }


            //启用跨域
            app.UseCors("allcors");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

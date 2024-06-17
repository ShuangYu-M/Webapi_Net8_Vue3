using Microsoft.AspNetCore.Mvc;
using WebApiDemo_net8.WebCore.SwaggerExt;

namespace WebApiDemo_net8.Controllers
{
    /// <summary>
    /// RESTFul：把这个控制器为维度，当成一块资源：
    /// 对于这个资源，会提增删改查等等各种动作：这些动作都有唯一的URL地址：匹配请求的Method类型（get、post、put、delete）
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = nameof(ApiVersionInfo.v2))]
    public class v2Controller : ControllerBase
    {

        /// <summary>
        /// HttpGet
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Type = "Get",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55)
            })
            .ToArray();
        }

        /// <summary>
        /// HttpGetUser
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId:int}")]//特性路由
        public IEnumerable<WeatherForecast> GetUser()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Type = "Get",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55)
            })
            .ToArray();
        }

        /// <summary>
        /// HttpPost
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IEnumerable<WeatherForecast> Post()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Type = "Post",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55)
            })
            .ToArray();
        }

        /// <summary>
        /// HttpPut
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public IEnumerable<WeatherForecast> Put()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Type = "Put",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55)
            })
            .ToArray();
        }

        /// <summary>
        /// HttpDelete
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public IEnumerable<WeatherForecast> Delete()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Type = "Delete",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55)
            })
            .ToArray();
        }







    }
}

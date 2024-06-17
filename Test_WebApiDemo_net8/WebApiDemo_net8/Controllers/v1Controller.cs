using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using WebApiDemo_net8.rep;
using WebApiDemo_net8.req;
using WebApiDemo_net8.WebCore.SwaggerExt;

namespace WebApiDemo_net8.Controllers
{
    /// <summary>
    /// RESTFul：把这个控制器为维度，当成一块资源：
    /// 对于这个资源，会提增删改查等等各种动作：这些动作都有唯一的URL地址：匹配请求的Method类型（get、post、put、delete）
    /// [EnableCors("any")]：中间件，解决浏览器跨域问题
    /// Route：特性路由
    /// </summary>
    [EnableCors("any")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName =nameof(ApiVersionInfo.v1))]
    public class v1Controller : ControllerBase
    {

        /// <summary>
        /// HttpGet
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //public string Get()
        //{
        //    string thisTime = "当前是，北京时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //    return thisTime;
        //}

        /// <summary>
        /// HttpGetUser
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //[Route("{userId:int}")]//特性路由
        //public IEnumerable<WeatherForecast> GetUser()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Type = "Get",
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55)
        //    })
        //    .ToArray();
        //}

        /// <summary>
        /// HttpPost 获取验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public loginCode GetAuthCode()
        {

            return new loginCode()
            {
                code = 0,
                data = "http://dummyimage.com/100x40/dcdfe6/000000.png&text=V3Admin",
                message = "获取验证码成功！！"
            };
        }


        /// <summary>
        /// HttpPost 获取登录状态
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        //[Route("{account:string,passwored:string}")]//特性路由
        public userLogin PostLoggin([FromBody] LoginRequestData login)
        {
                Token token = new Token();
            token.token = "token-admin!!";
            if (login != null&&login.code==""&&login.username == ""&&login.password == "") {
                return new userLogin()
                {
                    code = 0,
                    data= token,
                    message= "登录成功！！"
                };
            }
            return new userLogin()
            {
                code = -1,
                data = token,
                message = "登陆失败！！"
            };

        }

        /// <summary>
        /// HttpPut
        /// </summary>
        /// <returns></returns>
        //[HttpPut]
        //public IEnumerable<WeatherForecast> Put()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Type = "Put",
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55)
        //    })
        //    .ToArray();
        //}

        /// <summary>
        /// HttpDelete
        /// </summary>
        /// <returns></returns>
        //[HttpDelete]
        //public IEnumerable<WeatherForecast> Delete()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Type = "Delete",
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55)
        //    })
        //    .ToArray();
        //}







    }
}

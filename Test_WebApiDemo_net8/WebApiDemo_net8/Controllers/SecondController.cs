using Microsoft.AspNetCore.Mvc;

namespace WebApiDemo_net8.Controllers
{
    public class SecondController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger<SecondController> _ILogger;
        /// <summary>
        /// 工厂
        /// </summary>
        private readonly ILoggerFactory _ILoggerFactory;

        /// <summary>
        /// 执行构造函数——自动创建出构造函数的参数——传递过来
        /// 依赖注入——构造函数注入
        /// 
        /// </summary>
        /// <param name="iLogger"></param>
        public SecondController(ILogger<SecondController> iLogger, ILoggerFactory iLoggerFactory)
        {
            _ILogger = iLogger;
            _ILoggerFactory = iLoggerFactory;

            _ILogger.LogInformation("LogInformation: this is Second 构造函数~");
            _ILogger.LogError("LogError: this is Second 构造函数~");
            _ILogger.LogWarning("LogWarning: this is Second 构造函数~");
            _ILogger.LogDebug("LogDebug: this is Second 构造函数~");

            _ILogger.LogInformation("=============================================");


            ILogger<SecondController> loger = _ILoggerFactory.CreateLogger<SecondController>();

            loger.LogInformation("LogInformation: this is Second 构造函数~");
            loger.LogError("LogError: this is Second 构造函数~");
            loger.LogWarning("LogWarning: this is Second 构造函数~");
            loger.LogDebug("LogDebug: this is Second 构造函数~");

        }

        /// <summary>
        /// 控制器
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            ILogger<SecondController> _Logger3 = _ILoggerFactory.CreateLogger<SecondController>();
            _Logger3.LogInformation($"Index 被执行了..._Logger3");
            _Logger3.LogInformation($"Index 被执行了...");

            return new JsonResult(new { Sucess = true });
        }



    }
}

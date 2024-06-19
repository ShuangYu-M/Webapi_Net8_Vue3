using Microsoft.AspNetCore.Mvc;
using webApi_Net8.Helper;
using webApi_Net8.response;

namespace webApi_Net8.Controllers.v2Controller
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = nameof(ApiVersions.v2))]
    public class v2Controller : ControllerBase
    {
        
        /// <summary>
        /// 获取登录验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public REP_response<string> loginCode()
        {
            return new REP_response<string>()
            {
                code = 200,
                data= "",
                message="请求成功！"
            };
        }


    }
}

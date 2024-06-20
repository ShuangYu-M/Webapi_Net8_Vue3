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
            //获取随机验证码
            // 定义随机验证码字符集
            string allCharacters = "23456789ABCDEFGHJKLMNPQRSTUVWXYZ";
            //定义验证码长度
            int codeLength = 5;
            // 生成指定长度的随机字符串
            string randomCode = "";
            Random random = new Random();
            for (int i = 0; i < codeLength; i++)
            {
                int randomIndex = random.Next(0, allCharacters.Length);
                randomCode += allCharacters[randomIndex];
            }



            return new REP_response<string>()
            {
                /*
                 http://dummyimage.com/100x40/dcdfe6/000000.png&text=V2Admin
                上述网址的等号=后面的内容就是页面可以显示的png图片内容，可以把地址从浏览器打开查看
                 */
                
                code = 0,
                data= "http://dummyimage.com/100x40/dcdfe6/000000.png&text="+ randomCode,
                message="获取验证码成功！"
            };
        }


    }
}

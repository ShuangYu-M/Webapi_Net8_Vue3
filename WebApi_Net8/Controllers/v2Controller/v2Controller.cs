using Microsoft.AspNetCore.Mvc;
using System.Data;
using webApi_Net8.Helper;
using webApi_Net8.request;
using webApi_Net8.response;

namespace webApi_Net8.Controllers.v2Controller
{
    [ApiController]
    [Route("api/v1")]
    [ApiExplorerSettings(GroupName = nameof(ApiVersions.v2))]
    public class v2Controller : ControllerBase
    {

        /// <summary>
        /// 获取登录验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("login/code")]
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
                data = "http://dummyimage.com/100x40/dcdfe6/000000.png&text=" + randomCode,
                message = "获取验证码成功！"
            };
        }


        /// <summary>
        /// 登录并返回 Token
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("users/login")]
        public REP_response<Token> usersLogin(testStudent student)
        {

            int code = 0;
            string message = "登录成功！";
            string sql = " SELECT 1 FROM Luoxianhua ";
            sql += " WHERE sname = '" + student.username + "' AND PASSWORD = '" + student.password + "' ";
            DataTable dt = SqlHelper.Query(sql);
            if (dt.Rows.Count == 0)
            {
                code = -1;
                message = "登录失败！";
            }

            return new REP_response<Token>()
            {
                code = code,
                data = new Token() { token = "token-admin" },
                message = message
            };
        }


        /// <summary>
        /// 登录成功获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("users/info")]
        public REP_response<userInfo> usersInfo()
        {
            userInfo user = new userInfo();
            user.roles = ["admin"];
            user.username = "admin";
            return new REP_response<userInfo>()
            {
                code = 0,
                data = user,
                message = "获取用户详情成功！"
            };
        }


        /// <summary>
        /// 获取Element Plus表格
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("table")]
        public REP_response<Element> getElement(string? username, string? phone)
        {
            string sql = " SELECT id,username,phone,roles,email,createTime ";
            sql += " ,CASE WHEN status = 'Y' THEN 'true' WHEN status = 'N' THEN 'false' ELSE 'false' END AS status ";
            sql += " FROM ElementPlus WHERE 1=1 ";
            if (string.IsNullOrEmpty(username))
                sql += " AND username LIKE '%" + username + "%' ";
            if (string.IsNullOrEmpty(phone))
                sql += " AND phone LIKE '%" + phone + "%' ";

            List<EPDetail> elements = SqlHelper.Query<EPDetail>(sql);


            Element result = new Element();
            result.total= elements.Count;
            result.list= elements;
            return new REP_response<Element>()
            {
                code = 0,
                data = result,
                message = "获取表格数据成功！"
            };
        }



    }
}

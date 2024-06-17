using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using WebApiDemo_net8.rep;
using WebApiDemo_net8.req;
using WebApiDemo_net8.WebCore.SwaggerExt;

namespace WebApiDemo_net8.Controllers
{
    /// <summary>
    /// RESTFul�������������Ϊά�ȣ�����һ����Դ��
    /// ���������Դ��������ɾ�Ĳ�ȵȸ��ֶ�������Щ��������Ψһ��URL��ַ��ƥ�������Method���ͣ�get��post��put��delete��
    /// [EnableCors("any")]���м��������������������
    /// Route������·��
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
        //    string thisTime = "��ǰ�ǣ�����ʱ�䣺" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //    return thisTime;
        //}

        /// <summary>
        /// HttpGetUser
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //[Route("{userId:int}")]//����·��
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
        /// HttpPost ��ȡ��֤��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public loginCode GetAuthCode()
        {

            return new loginCode()
            {
                code = 0,
                data = "http://dummyimage.com/100x40/dcdfe6/000000.png&text=V3Admin",
                message = "��ȡ��֤��ɹ�����"
            };
        }


        /// <summary>
        /// HttpPost ��ȡ��¼״̬
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        //[Route("{account:string,passwored:string}")]//����·��
        public userLogin PostLoggin([FromBody] LoginRequestData login)
        {
                Token token = new Token();
            token.token = "token-admin!!";
            if (login != null&&login.code==""&&login.username == ""&&login.password == "") {
                return new userLogin()
                {
                    code = 0,
                    data= token,
                    message= "��¼�ɹ�����"
                };
            }
            return new userLogin()
            {
                code = -1,
                data = token,
                message = "��½ʧ�ܣ���"
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

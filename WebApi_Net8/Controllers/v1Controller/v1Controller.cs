using Microsoft.AspNetCore.Mvc;
using webApi_Net8.Helper;
using webApi_Net8.request;
using webApi_Net8.response;

namespace webApi_Net8.Controllers.v1Controller
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = nameof(ApiVersions.v1))]
    public class v1Controller: ControllerBase
    {
        //WeatherForecastController GetDao = new WeatherForecastController();


        [HttpGet]
        public REP_response<List<testStudent>> GetStudent()
        {
            try
            {

                List<testStudent> list_student = new List<testStudent>();
                string sql = "select * from Luoxianhua";

                list_student = SqlHelper.Query<testStudent>(sql);

                return new REP_response<List<testStudent>>()
                {
                    code = 200,
                    data = list_student,
                    message = "请求成功！！"
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [HttpPost]
        public REP_response<int> insertUser(listStudent students)
        {

            string sql = "";
            for (int i = 0; i < students.students.Count; i++)
            {
                sql += " INSERT INTO Luoxianhua(id,sname) ";
                sql += "  VALUES ('"+ students.students[i].Id + "','"+ students.students[i].Name + "'); ";
            }
            int instUser = SqlHelper.ExecuteNonQuery(sql);


            return new REP_response<int>() {
                code = 200,
                data = instUser,
                message = "插入成功！！"
            };
        }



        [HttpPut]
        public REP_response<int> updateUser(testStudent student)
        {

            string sql = "UPDATE Luoxianhua SET sname ='"+ student.Name + "' WHERE id='"+ student.Id + "'";
            int UPDUser = SqlHelper.ExecuteNonQuery(sql);


            return new REP_response<int>()
            {
                code = 200,
                data = UPDUser,
                message = "修改成功！！"
            };
        }


        [HttpDelete("{Id}")]
        public REP_response<int> deleteUser(int Id)
        {

            string sql = "delete Luoxianhua WHERE id='" + Id + "'";
            int delUser = SqlHelper.ExecuteNonQuery(sql);


            return new REP_response<int>()
            {
                code = 200,
                data = delUser,
                message = "删除成功！！"
            };
        }








    }
}

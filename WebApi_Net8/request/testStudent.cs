using static webApi_Net8.Helper.SqlHelper;

namespace webApi_Net8.request
{
    public class testStudent
    {
        [ColumnName("id")]
        public int Id { get; set; }
        [ColumnName("sname")]

        public string? Name { get; set; }
        [ColumnName("id")]

        public int age { get; set; }


        //账号
        [ColumnName("sname")]
        public string username { get; set; }
        //密码
        [ColumnName("PASSWORD")]
        public string password { get; set; }
        //验证码
        [ColumnName("code")]
        public string code { get; set; }

    }

    public class listStudent
    {
        public List<testStudent> students { get; set; }

    }

    public class Token
    {
        public string token { get; set; }
    }

    public class userInfo
    {
        public List<string> roles { get; set; }
        public string username { get; set; }
    }

    //Element Plus
    public class Element
    {
        public int total { get; set; }

        public List<EPDetail> list { get; set; }=new List<EPDetail>();
    }

    public class EPDetail
    {
        [ColumnName("id")]
        public int id { get; set; }
        [ColumnName("phone")]
        public string? phone { get; set; }
        [ColumnName("roles")]
        public string? roles { get; set; }
        [ColumnName("status")]
        public bool status { get; set; }
        [ColumnName("username")]
        public string? username { get; set; }
        [ColumnName("email")]
        public string? email { get; set; }
        [ColumnName("createTime")]
        public string? createTime { get; set; }
    }

}

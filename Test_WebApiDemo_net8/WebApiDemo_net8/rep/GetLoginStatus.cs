namespace WebApiDemo_net8.rep
{

    /// <summary>
    /// 验证码
    /// </summary>
    public class loginCode
    {
        public int code { get; set; }
        public string data { get; set; }
        public string message { get; set; }
    }


    /// <summary>
    /// 登陆返回
    /// </summary>
    public class userLogin
    {
        public int code { get; set; }
        public Token data { get; set; }
        public string message { get; set; }

    }

    public class Token
    {
        public string token { get; set; }
    }
}

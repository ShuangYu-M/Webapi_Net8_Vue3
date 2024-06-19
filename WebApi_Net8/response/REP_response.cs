namespace webApi_Net8.response
{

    public class REP_response<T>
    {
        public int code {  get; set; }

        public T data { get; set; }

        public string message { get; set; }

    }
}

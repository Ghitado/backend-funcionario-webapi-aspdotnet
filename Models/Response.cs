namespace webapi_aspdotnet.Models
{
    public class Response<T>
    {
        public bool Status { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
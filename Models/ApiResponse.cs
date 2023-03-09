namespace WebAPI_CRUD.Models
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Value { get; set; }
    }
}

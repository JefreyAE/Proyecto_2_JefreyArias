namespace API_Proyecto_2.Helpers
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

        public ServiceResponse()
        {
            Success = true;
            this.Message = "Success";
        }
        public ServiceResponse(T data, bool success, string message)
        {
            Data = data;
            Success = success;
            Message = message;
        }
    }
}

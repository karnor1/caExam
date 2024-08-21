namespace CaExam.Helpers
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public ApiResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        public static ApiResponse SuccessResponse(string message = "Operation successful")
        {
            return new ApiResponse(true, message);
        }

        public static ApiResponse ErrorResponse(string message)
        {
            return new ApiResponse(false, message);
        }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T? Data { get; set; }

        public ApiResponse(bool success, string message, T? data = default)
            : base(success, message)
        {
            Data = data;
        }

        public static ApiResponse<T> SuccessResponse(T? data = default, string message = null)
        {
            return new ApiResponse<T>(true, message ?? "Operation successful", data);
        }

        public static ApiResponse<T> ErrorResponse(string message)
        {
            return new ApiResponse<T>(false, message);
        }
    }

}

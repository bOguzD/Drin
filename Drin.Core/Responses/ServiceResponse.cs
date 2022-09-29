namespace Drin.Core.Responses
{
    public class ServiceResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public int StatusCode { get; set; }
        public object? Data { get; set; }


        public static ServiceResponse Success(int statusCode, string? message)
        {
            return CreateServiceResponse(true, message, statusCode, null);
        }
        public static ServiceResponse Success(int statusCode, string? message, object data)
        {
            return CreateServiceResponse(true, message, statusCode, data);
        }

        public static ServiceResponse Failure(int statusCode, string? message)
        {
            message = CreateErrorMessage(message);
            return CreateServiceResponse(false, message, statusCode, null);
        }

        private static string CreateErrorMessage(string? message)
        {
            return string.IsNullOrEmpty(message)
                ? "Bilinmeyen Hata"
                : message;
        }

        private static ServiceResponse CreateServiceResponse(bool isSuccess, string? message, int statusCode, object? data)
        {
            return new ServiceResponse
            {
                IsSuccess = isSuccess,
                StatusCode = statusCode,
                Message = message,
                Data = data
            };
        }
    }
}

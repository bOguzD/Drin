namespace Drin.Core.Responses
{
    public class ServiceResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public int StatusCode { get; set; }
        public object? Data { get; set; }
        public List<string>? Errors { get; set; }


        public static ServiceResponse Success(int statusCode, string? message)
        {
            return CreateServiceResponse(true, message, statusCode, null, null);
        }
        public static ServiceResponse Success(int statusCode, string? message, object data)
        {
            return CreateServiceResponse(true, message, statusCode, data, null);
        }

        public static ServiceResponse Failure(int statusCode, string? message)
        {
            message = CreateErrorMessage(message);
            List<string> error = new();
            error.Add(message);
            return CreateServiceResponse(false, message, statusCode, null, error);
        }

        public static ServiceResponse Fails(int statusCode, List<string>? message)
        {
            return CreateServiceResponse(false, null, statusCode, null, message);
        }

        private static string CreateErrorMessage(string? message)
        {
            return string.IsNullOrEmpty(message)
                ? "Bilinmeyen Hata"
                : message;
        }

        private static ServiceResponse CreateServiceResponse(bool isSuccess, string? message, int statusCode, object? data, List<string>? errorMessages)
        {
            return new ServiceResponse
            {
                IsSuccess = isSuccess,
                StatusCode = statusCode,
                Message = message,
                Data = data,
                Errors = errorMessages
            };
        }
    }
}

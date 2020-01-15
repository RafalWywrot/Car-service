namespace CarService.WebApplication.Helpers
{
    public class JsonObjectResponse
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }

        public JsonObjectResponse()
        {
            Success = true;
        }

        public JsonObjectResponse(string message)
        {
            Success = false;
            Message = message;
        }
    }
}
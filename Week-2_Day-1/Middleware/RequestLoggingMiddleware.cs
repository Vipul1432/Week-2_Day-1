namespace Week_2_Day_1.Middleware
{
    public class RequestLoggingMiddleware 
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Log request details
            string requestDetails = $"{context.Request.Method} {context.Request.Path}";
            Console.WriteLine($"Request: {requestDetails}");

            await _next(context);
        }
    }

    public static class RequestLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}

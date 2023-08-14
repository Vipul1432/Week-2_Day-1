namespace Week_2_Day_1.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Simulate authentication logic
            bool isAuthenticated = CheckAuthentication(context);

            if (!isAuthenticated)
            {
                // Redirect to login page
                context.Response.Redirect("/Account/login");
                return;
            }

            await _next(context);
        }

        private bool CheckAuthentication(HttpContext context)
        {
            // Mock authentication check
            bool isAuthorized = context.User.Identity.IsAuthenticated;
            return isAuthorized;
        }
    }

    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}


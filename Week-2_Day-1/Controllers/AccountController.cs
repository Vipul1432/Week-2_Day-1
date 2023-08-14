using Microsoft.AspNetCore.Mvc;

namespace Week_2_Day_1.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(string username, string password)
        {
            if (IsAuthenticated(username, password))
            {
                //AuthenticationMock.IsAuthenticated = true;
                // Redirect to products page when successful login
                return Redirect("/Products");
            }

            // Handle invalid login
            ViewData["ErrorMessage"] = "Invalid username or password.";
            return View();
        }

        private bool IsAuthenticated(string username, string password)
        {
            // Mock authentication check
            return username == "admin" && password == "admin";
        }
    }
}

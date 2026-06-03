using Microsoft.AspNetCore.Mvc;
using Register_Login_MVC_Study.Data;
using Register_Login_MVC_Study.Models;
using System.Linq;

namespace Register_Login_MVC_Study.Controllers
{
    public class LoginController : Controller
    {

        private readonly AppDbContext _context;

        public LoginController (AppDbContext context)
        {
            _context = context;
        }

        // Esse método representa a página que o usuário vai acessar
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel loginData)
        {
            var userExists = _context.user_table.FirstOrDefault(u => u.user_email == loginData.user_email);

            // 2. We check the result of our SELECT
            if (userExists != null)
            {

                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginData.user_password, userExists.user_password);

                if (isPasswordValid)
                {
                    // If the user was found, return a simple text message saying success
                    return Content($"Success! Welcome back, {userExists.user_name}.");
                }

            }

            // If the user was NOT found, return to the login page

            ViewData["ErrorMessage"] = "Invalid email or password.";
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserModel newUserData)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(newUserData.user_password);

            newUserData.user_password = passwordHash;

            _context.user_table.Add(newUserData);

            _context.SaveChanges();

            return RedirectToAction("Login");
        }
    }
}

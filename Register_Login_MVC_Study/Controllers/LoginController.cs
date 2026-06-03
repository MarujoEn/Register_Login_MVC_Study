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
            var userExists = _context.user_table.FirstOrDefault(u => u.user_email == loginData.user_email && u.user_password == loginData.user_password);

            // 2. We check the result of our SELECT
            if (userExists != null)
            {
                // If the user was found, return a simple text message saying success
                return Content($"Success! Welcome back, {userExists.user_name}.");
            }

            // If the user was NOT found, return to the login page

            return View();
        }
    }
}

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebHoaqua.Areas.Admin.Controllers;
using WebHoaqua.Models;

namespace WebHoaqua.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        private readonly FruitShopContext _context;
        public LoginController(FruitShopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(string username, string password)
        {
            password = AdminAccountsController.CalculateMD5Hash(password);
            var check = _context.Accounts.Where(x => x.Username == username && x.Password == password).SingleOrDefault();
            if(check != null)
            {
                var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, check.Type),
                    new Claim(ClaimTypes.Name, check.Username),
                    new Claim("UserId", check.Username),

                };
                var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                var printc = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, printc);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Login");
        }
    }
}

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyContacts.Models;
using System.Security.Claims;

namespace MyContacts.Controllers
{
    public class UserController : Controller
    {
        ContactContext _ctx;
        public UserController(ContactContext ctx) {
            _ctx = ctx;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {

            if (ModelState.IsValid)
            {
                _ctx.Users.Add(user);
                _ctx.SaveChanges();
                return RedirectToAction("Login");
            }


            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            // Validate user credentials
            if (ModelState.IsValid)
            {
                var user = _ctx.Users.FirstOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password");
                }
                
            }
            return View();
        } 

    }
}

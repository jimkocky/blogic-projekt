using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekt_blogic.Data;
using System.Security.Claims;


namespace projekt_blogic.Controllers
{
    public class SecurityController : Controller
    {





        [AllowAnonymous]
        public async Task<IActionResult> Login(int userId, string name)
        {
            var user = DataBase.Users(userId);
            var claims = new List<Claim>
    {
                new Claim("UserId", user.UserId.ToString(), ClaimValueTypes.Integer),
                new Claim("Name", user.Name),
                new Claim("Email", user.Email),
                new Claim("ImageUrl", user.ImageUrl ?? string.Empty),
                new Claim(ClaimTypes.Role, user.Role.ToString())
    };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties();
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, properties);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }

}

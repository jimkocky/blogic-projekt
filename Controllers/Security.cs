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
        [HttpPost]
        public async Task<IActionResult> Login(int userId, string name)
        {
            var user = DataBase.GetUserById(userId);

            if (user == null)
            {
                return View("LoginFailed");
            }

            var claims = new List<Claim>
            {
                new Claim("UserId", user.UserId.ToString()),
                new Claim("Name", user.Name),
                new Claim("Email", user.Email),
                new Claim("ImageUrl", user.ImageUrl ?? string.Empty),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties
            );

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}

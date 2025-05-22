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
        public async Task<IActionResult> Login(int userId, string name)
        {
            var user = DataBase.GetUserById(userId); 

            var claims = new List<Claim>
            {
                new Claim("UserId", user.UserId.ToString()),
                new Claim("Name", user.Name),
                new Claim("Email", user.Email),
                new Claim("ImageUrl", user.ImageUrl ?? string.Empty),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };


        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
       
    
}
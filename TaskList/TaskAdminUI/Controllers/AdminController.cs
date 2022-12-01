using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer.Concrete;
using System.Linq;

namespace TaskAdminUI.Controllers
{
	public class AdminController : Controller
	{
        [HttpGet]
        public IActionResult Index(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            Context c = new Context();
            var admin = c.users.FirstOrDefault(x => x.user_name == user.user_name && x.user_pword == user.user_pword);
            if (admin != null)
            {
                var claims = new List<Claim>
                { new Claim(ClaimTypes.Name, admin.user_name),
                 new Claim(ClaimTypes.Role, admin.user_role)
                };


                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);

                await HttpContext.SignInAsync(principal);

                if (TempData["returnUrl"] != null)
                {
                    if (Url.IsLocalUrl(TempData["returnUrl"].ToString()))
                    {
                        return Redirect(TempData["returnUrl"].ToString());
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Task");
                }

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Admin");
        }
    }
}

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MVC_TravelTrip.Models.Sinifler;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVC_TravelTrip.Controllers
{
    public class GirisYapController : Controller
    {
        private readonly Context _c;

        public GirisYapController(Context c)
        {
            _c = c;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Admin adm)
        {
            var bilgi = _c.Admins.FirstOrDefault(x=>x.Kullanici==adm.Kullanici && x.Sifre==adm.Sifre);
            if (bilgi != null)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, bilgi.Kullanici) };
                var kimlik = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(new ClaimsPrincipal(kimlik));
                HttpContext.Session.SetString("Kullanici", bilgi.Kullanici);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
                
        }


        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using MVC_TravelTrip.Models.Sinifler;

namespace MVC_TravelTrip.Controllers
{
    public class IletisimController : Controller
    {
        private readonly Context _c;

        public IletisimController(Context c)
        {
            _c = c;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Iletisim i)
        {
            _c.Iletisims.Add(i);
            _c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

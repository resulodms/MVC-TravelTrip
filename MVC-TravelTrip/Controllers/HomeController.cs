using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_TravelTrip.Models;
using MVC_TravelTrip.Models.Sinifler;

namespace MVC_TravelTrip.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _c;
       

        BlogYorum by = new BlogYorum();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, Context c)
        {
            
            _logger = logger;
            _c = c;
        }

        public IActionResult Index()
        {

            var degerler = _c.Blogs.Take(10).ToList();


            return View(degerler);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}

using Microsoft.AspNetCore.Mvc;
using MVC_TravelTrip.Models.Sinifler;
namespace MVC_TravelTrip.Controllers
{
    public class AboutController : Controller
    {

        private readonly Context _c;

        public AboutController(Context c)
        {
            _c = c;
        }

        public IActionResult Index()
        {

            var degerler = _c.Hakkimizdas.ToList();


            return View(degerler);
        }

    


      
    }
}

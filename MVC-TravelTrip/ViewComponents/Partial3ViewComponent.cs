using Microsoft.AspNetCore.Mvc;
using MVC_TravelTrip.Models.Sinifler;

namespace MVC_TravelTrip.ViewComponents
{
    public class Partial3ViewComponent:ViewComponent
    {
        private readonly Context _c;

        public Partial3ViewComponent(Context c)
        {
            _c = c;
        }

        public IViewComponentResult Invoke()
        {
            var deger = _c.Blogs.Take(10).ToList();
            return View(deger);
        }
    }
}

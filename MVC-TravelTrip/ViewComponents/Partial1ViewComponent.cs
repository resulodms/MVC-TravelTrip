using Microsoft.AspNetCore.Mvc;
using MVC_TravelTrip.Models.Sinifler;

namespace MVC_TravelTrip.ViewComponents
{
    public class Partial1ViewComponent : ViewComponent
    {
        private readonly Context _c;

        public Partial1ViewComponent(Context c)
        {
            _c = c;
        }

        public IViewComponentResult Invoke()
        {
            var degerler = _c.Blogs
                .OrderByDescending(x => x.Id)
                .Take(2)
                .ToList();

            return View(degerler);
        }
    }
}
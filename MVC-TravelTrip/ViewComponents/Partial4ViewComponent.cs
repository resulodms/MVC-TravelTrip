using Microsoft.AspNetCore.Mvc;
using MVC_TravelTrip.Models.Sinifler;

namespace MVC_TravelTrip.ViewComponents
{
    public class Partial4ViewComponent:ViewComponent
    {
        private readonly Context _c;

        public Partial4ViewComponent(Context c)
        {
            _c = c;
        }
        public IViewComponentResult Invoke()
        {
           var deger= _c.Blogs.OrderByDescending(x => x.Id).Take(6).ToList();
            return View(deger);
        }

    }
}

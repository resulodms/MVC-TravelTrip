using Microsoft.AspNetCore.Mvc;
using MVC_TravelTrip.Models.Sinifler;

namespace MVC_TravelTrip.ViewComponents
{
    public class Partial2ViewComponent : ViewComponent
    {
        private readonly Context _c;

        public Partial2ViewComponent(Context c)
        {
            _c = c;
        }

        public IViewComponentResult Invoke()
        {
            var deger = _c.Blogs
                .Where(x => x.Id==1)
                .ToList();

            return View(deger);
        }
    }
}
//public PartialViewResult Partial2()
//{
//    var deger = _c.Blogs.Where(x => x.Id == 1).ToList();

//}
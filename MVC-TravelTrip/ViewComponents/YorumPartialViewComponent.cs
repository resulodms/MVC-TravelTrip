using Microsoft.AspNetCore.Mvc;
using MVC_TravelTrip.Models.Sinifler;

namespace MVC_TravelTrip.ViewComponents
{
    public class YorumPartialViewComponent:ViewComponent
    {
        private readonly Context _c;

        public YorumPartialViewComponent(Context c)
        {
            _c = c;
        }
       
        public IViewComponentResult Invoke(int id)
        {
           ViewBag.deger=id; 
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MVC_TravelTrip.Models.Sinifler;
namespace MVC_TravelTrip.Controllers
{
    public class BlogController : Controller
    {
        private readonly Context _c;

        public BlogController(Context c)
        {
            _c = c;
        }

        BlogYorum by = new BlogYorum();

        public IActionResult Index()
        {
            // var bloglar = _c.Blogs.ToList();
            by.Deger1 = _c.Blogs.ToList();
            by.Deger3 = _c.Blogs.Take(3).ToList();
            return View(by);
        }


      
        public ActionResult BlogDetay(int id)
        {


            //var blogbul = _c.Blogs.Where(x => x.Id == id).ToList();

            by.Deger1 = _c.Blogs.Where(x => x.Id == id).ToList();
            if (!by.Deger1.Any())
            {
                return RedirectToAction("Index");
            }
            by.Deger2 = _c.Yorumlars.Where(x=>x.BlogId==id).ToList();
            by.Deger3 = _c.Blogs.Take(3).ToList();
            return View(by);


        }
        [HttpPost]
        public IActionResult Yorum(Yorumlar y)
        {
            if (!_c.Blogs.Any(x => x.Id == y.BlogId))
            {
                return RedirectToAction("Index");
            }

            if (string.IsNullOrWhiteSpace(y.KullaniciAdi) ||
                string.IsNullOrWhiteSpace(y.Mail) ||
                string.IsNullOrWhiteSpace(y.Yorum))
            {
                return RedirectToAction("BlogDetay", new { id = y.BlogId });
            }

            _c.Yorumlars.Add(y);
            _c.SaveChanges();
            return RedirectToAction("BlogDetay", new { id = y.BlogId });
        }




    }
}

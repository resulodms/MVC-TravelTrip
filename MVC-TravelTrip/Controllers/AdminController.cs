using Microsoft.AspNetCore.Mvc;
using MVC_TravelTrip.Models.Sinifler;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace MVC_TravelTrip.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly Context _c;
        
        public AdminController(Context c)
        {
            _c = c;
        }
       
        public IActionResult Index()
        {
            var degerler = _c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult YeniBlog()
        {
            return View();

        }
        [HttpPost]
        public IActionResult YeniBlog(Blog p)
        {
            _c.Blogs.Add(p);
            _c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult BlogSil(int id)
        {
            var b = _c.Blogs.Find(id);
            if (b==null)
            {
                return RedirectToAction("Index");
            }
            _c.Blogs.Remove(b);
            _c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int id)
        {
            var bl = _c.Blogs.Find(id);
            if (bl == null)
            {
                return RedirectToAction("Index");
            }
            return View("BlogGetir", bl);

        }

        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = _c.Blogs.Find(b.Id);
            if (blg == null)
            {
                return RedirectToAction("Index");
            }
            blg.Aciklama=b.Aciklama;
            blg.Baslik=b.Baslik;
            blg.BlogImage=b.BlogImage;
            blg.Tarih=b.Tarih;
            _c.SaveChanges();

            return RedirectToAction("Index");


        }

        public ActionResult YorumListesi()
        {
            var yorumlar = _c.Yorumlars.Include(x=>x.Blog).ToList();
            return View(yorumlar);
            //var yorumlar = _c.Yorumlars.Include(x => x.Blog).ToList();
            //return View(yorumlar);
        }


        public ActionResult YorumSil(int id)
        {
            var y = _c.Yorumlars.Find(id);
            if (y == null)
            {
                return RedirectToAction("Index");
            }
            _c.Yorumlars.Remove(y);
            _c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

     
        public IActionResult YorumGetir(int id)
        {
           var yr= _c.Yorumlars.Find(id);
            if (yr == null)
            {
                return RedirectToAction("Index");
            }

            return View("YorumGetir",yr);
        }

        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = _c.Yorumlars.Find(y.Id);
            if (yrm == null)
            {
                return RedirectToAction("Index");
            }
            yrm.KullaniciAdi=y.KullaniciAdi;
            yrm.Mail=y.Mail;
            yrm.Yorum=y.Yorum;
           _c.SaveChanges();
            return RedirectToAction("YorumListesi");

        }

        public IActionResult IletisimListesi()
        {
            var mesajlar = _c.Iletisims.ToList();
            return View(mesajlar);
        }

    }
}

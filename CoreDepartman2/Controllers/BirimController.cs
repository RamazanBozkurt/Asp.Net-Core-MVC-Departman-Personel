using CoreDepartman2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDepartman2.Controllers
{
    public class BirimController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var degerler = c.Birims.ToList();
            return View(degerler);
        }

        [HttpGet]
        public IActionResult YeniBirim()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniBirim(Birim b)
        {
            c.Birims.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult BirimSil(int id)
        {
            var index = c.Birims.Find(id);   // id yi bulur ve index değişkenine aktarır
            c.Birims.Remove(index);          // index değişkenindeki değeri siler 
            c.SaveChanges();                        // değişiklikleri kaydeder
            return RedirectToAction("Index");       // işlem bittikten sonra Index sayfasına geri döner
        }

        public IActionResult BirimGetir(int id)
        {
            var brm = c.Birims.Find(id);
            return View("BirimGetir", brm);
        }

        public IActionResult BirimGuncelle(Birim b)
        {
            var birim = c.Birims.Find(b.Id);
            birim.Ad = b.Ad;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Detaylar(int id)
        {
            var deger = c.Personels.Where(x => x.BirimId == id).ToList();
            // birim detay sayfasında birimin adını göstermek için kullanılır
            var brmAd = c.Birims.Where(x => x.Id == id).Select(y => y.Ad).FirstOrDefault();
            ViewBag.brm = brmAd;
            return View(deger);
        }
    }
}
